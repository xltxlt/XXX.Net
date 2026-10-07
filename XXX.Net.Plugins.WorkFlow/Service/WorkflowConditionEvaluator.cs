using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text.Json;

namespace XXX.Net.Plugins.WorkFlow.Service
{
    /// <summary>
    /// 工作流条件 DSL 执行器。
    /// Edge.Condition 继续使用 string 存储，新条件保存为 JSON。
    /// 同时兼容旧版：amount > 100、status == approved。
    /// </summary>
    public static class WorkflowConditionEvaluator
    {
        public static bool Evaluate(string expression, Dictionary<string, object> variables)
        {
            if (string.IsNullOrWhiteSpace(expression)) return true;
            expression = expression.Trim();

            if (expression.StartsWith("{"))
            {
                using var doc = JsonDocument.Parse(expression);
                return EvaluateRule(doc.RootElement, variables);
            }

            return EvaluateLegacy(expression, variables);
        }

        private static bool EvaluateRule(JsonElement rule, Dictionary<string, object> variables)
        {
            if (rule.ValueKind != JsonValueKind.Object) return false;
            var type = GetString(rule, "type")?.ToLowerInvariant();

            if (type == "group")
            {
                var logic = (GetString(rule, "operator") ?? "and").ToLowerInvariant();
                var children = GetArray(rule, "children").ToList();
                return logic == "or"
                    ? children.Any(x => EvaluateRule(x, variables))
                    : children.All(x => EvaluateRule(x, variables));
            }

            if (type == "collection")
                return EvaluateCollection(rule, variables);

            if (type != "condition") return false;

            var left = ResolveValue(rule.GetProperty("left"), variables);
            var right = rule.TryGetProperty("right", out var rightNode)
                ? ResolveValue(rightNode, variables)
                : null;

            return Compare(left, right, GetString(rule, "operator") ?? "eq");
        }

        private static bool EvaluateCollection(JsonElement rule, Dictionary<string, object> variables)
        {
            var source = rule.TryGetProperty("source", out var sourceNode)
                ? ResolveValue(sourceNode, variables)
                : null;

            var items = ToEnumerable(source).ToList();
            var quantifier = (GetString(rule, "quantifier") ?? "any").ToLowerInvariant();
            var childFieldId = GetString(rule, "childFieldId");
            var op = GetString(rule, "operator") ?? "eq";
            var right = rule.TryGetProperty("value", out var valueNode)
                ? ResolveValue(valueNode, variables)
                : null;

            bool Match(object? item)
            {
                var left = string.IsNullOrWhiteSpace(childFieldId)
                    ? item
                    : GetPathValue(item, childFieldId!);
                return Compare(left, right, op);
            }

            return quantifier switch
            {
                "all" => items.Count > 0 && items.All(Match),
                "none" => items.All(x => !Match(x)),
                _ => items.Any(Match)
            };
        }

        private static object? ResolveValue(JsonElement node, Dictionary<string, object> variables)
        {
            if (node.ValueKind != JsonValueKind.Object) return JsonToValue(node);

            var type = GetString(node, "type")?.ToLowerInvariant();

            if (type == "value")
                return node.TryGetProperty("value", out var value) ? JsonToValue(value) : null;

            if (type == "field")
            {
                var nodeId = GetString(node, "nodeId");
                var fieldId = GetString(node, "fieldId");
                if (string.IsNullOrWhiteSpace(nodeId) || string.IsNullOrWhiteSpace(fieldId)) return null;
                return variables.TryGetValue(nodeId!, out var source)
                    ? GetPathValue(source, fieldId!)
                    : null;
            }

            if (type == "aggregate")
            {
                var function = (GetString(node, "function") ?? "count").ToLowerInvariant();
                var source = node.TryGetProperty("source", out var sourceNode)
                    ? ResolveValue(sourceNode, variables)
                    : null;
                var items = ToEnumerable(source).ToList();

                if (function == "count") return items.Count;

                var childFieldId = GetString(node, "childFieldId");
                decimal sum = 0;
                foreach (var item in items)
                {
                    var value = string.IsNullOrWhiteSpace(childFieldId)
                        ? item
                        : GetPathValue(item, childFieldId!);
                    if (TryDecimal(value, out var number)) sum += number;
                }
                return sum;
            }

            return null;
        }

        private static object? GetPathValue(object? source, string path)
        {
            object? current = source;

            foreach (var part in path.Split('.', StringSplitOptions.RemoveEmptyEntries))
            {
                if (current is IDictionary<string, object> dict)
                {
                    if (!dict.TryGetValue(part, out current)) return null;
                    continue;
                }

                if (current is JsonElement element)
                {
                    if (element.ValueKind != JsonValueKind.Object ||
                        !element.TryGetProperty(part, out var child)) return null;
                    current = JsonToValue(child);
                    continue;
                }

                var prop = current?.GetType().GetProperty(part);
                if (prop == null) return null;
                current = prop.GetValue(current);
            }

            return current;
        }

        private static IEnumerable<object?> ToEnumerable(object? value)
        {
            if (value is IEnumerable enumerable && value is not string)
                foreach (var item in enumerable) yield return item;
        }

        private static bool Compare(object? left, object? right, string op)
        {
            op = op.ToLowerInvariant();

            if (op == "isnull") return left == null;
            if (op == "isnotnull") return left != null;
            if (op == "isempty") return left == null || string.IsNullOrWhiteSpace(Convert.ToString(left, CultureInfo.InvariantCulture));
            if (op == "isnotempty") return left != null && !string.IsNullOrWhiteSpace(Convert.ToString(left, CultureInfo.InvariantCulture));

            if (left == null || right == null)
                return op == "eq" ? left == null && right == null : op == "neq" && !(left == null && right == null);

            if (op is "contains" or "notcontains" or "startswith" or "endswith")
            {
                var ls = Convert.ToString(left, CultureInfo.InvariantCulture) ?? string.Empty;
                var rs = Convert.ToString(right, CultureInfo.InvariantCulture) ?? string.Empty;
                var result = op switch
                {
                    "contains" or "notcontains" => ls.Contains(rs, StringComparison.OrdinalIgnoreCase),
                    "startswith" => ls.StartsWith(rs, StringComparison.OrdinalIgnoreCase),
                    _ => ls.EndsWith(rs, StringComparison.OrdinalIgnoreCase)
                };
                return op == "notcontains" ? !result : result;
            }

            if (TryDecimal(left, out var ln) && TryDecimal(right, out var rn))
            {
                return op switch
                {
                    "eq" => ln == rn, "neq" => ln != rn, "gt" => ln > rn,
                    "gte" => ln >= rn, "lt" => ln < rn, "lte" => ln <= rn, _ => false
                };
            }

            var compare = string.Compare(
                Convert.ToString(left, CultureInfo.InvariantCulture),
                Convert.ToString(right, CultureInfo.InvariantCulture),
                StringComparison.OrdinalIgnoreCase);

            return op switch
            {
                "eq" => compare == 0, "neq" => compare != 0, "gt" => compare > 0,
                "gte" => compare >= 0, "lt" => compare < 0, "lte" => compare <= 0, _ => false
            };
        }

        private static bool EvaluateLegacy(string expression, Dictionary<string, object> variables)
        {
            var operators = new[] { ">=", "<=", "!=", "==", ">", "<" };
            var op = operators.FirstOrDefault(expression.Contains);
            if (op == null) return GetVariableBool(expression, variables);

            var parts = expression.Split(new[] { op }, 2, StringSplitOptions.None);
            if (parts.Length != 2) return false;

            variables.TryGetValue(parts[0].Trim(), out var left);
            return Compare(left, ParseLegacyValue(parts[1].Trim()), op switch
            {
                "==" => "eq", "!=" => "neq", ">" => "gt", ">=" => "gte",
                "<" => "lt", "<=" => "lte", _ => op
            });
        }

        private static object? ParseLegacyValue(string value)
        {
            if ((value.StartsWith(""") && value.EndsWith(""")) ||
                (value.StartsWith("'") && value.EndsWith("'")))
                return value[1..^1];

            if (bool.TryParse(value, out var boolean)) return boolean;
            if (decimal.TryParse(value, NumberStyles.Any, CultureInfo.InvariantCulture, out var number)) return number;
            return value;
        }

        private static bool GetVariableBool(string name, Dictionary<string, object> variables)
        {
            if (!variables.TryGetValue(name.Trim(), out var value)) return false;
            if (value is bool b) return b;
            return bool.TryParse(Convert.ToString(value, CultureInfo.InvariantCulture), out var result) && result;
        }

        private static bool TryDecimal(object? value, out decimal result)
        {
            if (value is decimal d) { result = d; return true; }
            if (value is int i) { result = i; return true; }
            if (value is long l) { result = l; return true; }
            if (value is double db) { result = (decimal)db; return true; }
            if (value is float f) { result = (decimal)f; return true; }
            return decimal.TryParse(
                Convert.ToString(value, CultureInfo.InvariantCulture),
                NumberStyles.Any,
                CultureInfo.InvariantCulture,
                out result);
        }

        private static string? GetString(JsonElement node, string name) =>
            node.TryGetProperty(name, out var value) && value.ValueKind == JsonValueKind.String
                ? value.GetString()
                : null;

        private static IEnumerable<JsonElement> GetArray(JsonElement node, string name) =>
            node.TryGetProperty(name, out var value) && value.ValueKind == JsonValueKind.Array
                ? value.EnumerateArray()
                : Enumerable.Empty<JsonElement>();

        private static object? JsonToValue(JsonElement element)
        {
            return element.ValueKind switch
            {
                JsonValueKind.Null or JsonValueKind.Undefined => null,
                JsonValueKind.String => element.TryGetDateTime(out var dt) ? dt : element.GetString(),
                JsonValueKind.True => true,
                JsonValueKind.False => false,
                JsonValueKind.Number => element.TryGetInt64(out var l) ? l : element.TryGetDecimal(out var d) ? d : element.GetDouble(),
                JsonValueKind.Array => element.EnumerateArray().Select(JsonToValue).ToList(),
                JsonValueKind.Object => element.EnumerateObject().ToDictionary(x => x.Name, x => JsonToValue(x.Value)!),
                _ => element.ToString()
            };
        }
    }
}
