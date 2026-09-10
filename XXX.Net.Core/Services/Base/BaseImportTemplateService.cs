using MiniExcelLibs;
using MiniExcelLibs.Attributes;
using System;
using System.Collections.Generic;
using System.Dynamic;
using System.IO;
using System.Reflection;
using System.Text;

namespace XXX.Net.Core.Services.Base
{
    public class BaseImportTemplateService
    {
        /// <summary>仅表头行</summary>
        public static MemoryStream GenerateHeaderOnly<TDto>(string sheetName = "Sheet1")
        {
            var stream = new MemoryStream();
            MiniExcel.SaveAs(stream, new[] { BuildHeaderRow<TDto>(false) },
                printHeader: true, sheetName: sheetName);
            return stream;
        }

        /// <summary>表头 + 一条示例数据行</summary>
        public static MemoryStream GenerateWithSample<TDto>(string sheetName = "Sheet1")
        {
            var stream = new MemoryStream();
            MiniExcel.SaveAs(stream, new[] { BuildHeaderRow<TDto>(true) },
                printHeader: true, sheetName: sheetName);
            return stream;
        }

        /// <summary>表头 + 指定数量空行</summary>
        public static MemoryStream GenerateWithEmptyRows<TDto>(int emptyRowCount, string sheetName = "Sheet1")
        {
            var keys = GetHeaderKeys<TDto>();
            var rows = new List<ExpandoObject>();
            for (int i = 0; i < emptyRowCount; i++)
            {
                var row = new ExpandoObject();
                var d = (IDictionary<string, object?>)row;
                foreach (var k in keys) d[k] = null;
                rows.Add(row);
            }
            var stream = new MemoryStream();
            MiniExcel.SaveAs(stream, rows, printHeader: true, sheetName: sheetName);
            return stream;
        }

        private static ExpandoObject BuildHeaderRow<TDto>(bool fillSample)
        {
            var row = new ExpandoObject();
            var d = (IDictionary<string, object?>)row;
            foreach (var p in typeof(TDto).GetProperties(BindingFlags.Public | BindingFlags.Instance)
                                            .Where(p => p.CanWrite))
            {
                d[ResolveHeader(p)] = fillSample ? Sample(p.PropertyType) : null;
            }
            return row;
        }

        private static IEnumerable<string> GetHeaderKeys<TDto>() =>
            typeof(TDto).GetProperties(BindingFlags.Public | BindingFlags.Instance)
                        .Where(p => p.CanWrite).Select(ResolveHeader);

        /// <summary>表头优先级：ExcelColumnName > DisplayName > 属性名</summary>
        private static string ResolveHeader(PropertyInfo p)
        {
            var a = p.GetCustomAttribute<ExcelColumnNameAttribute>();
            if (a != null && !string.IsNullOrWhiteSpace(a.ExcelColumnName)) return a.ExcelColumnName;
            var da = p.GetCustomAttribute<System.ComponentModel.DisplayNameAttribute>();
            if (da?.DisplayName != null) return da.DisplayName;
            return p.Name;
        }

        private static object? Sample(Type t)
        {
            if (t == typeof(string)) return string.Empty;
            if (t == typeof(int) || t == typeof(int?)) return 0;
            if (t == typeof(long) || t == typeof(long?)) return 0;
            if (t == typeof(decimal) || t == typeof(decimal?)) return 0;
            if (t == typeof(DateTime) || t == typeof(DateTime?)) return "2026-01-01";
            if (t == typeof(bool) || t == typeof(bool?)) return false;
            return string.Empty;
        }
    }
}