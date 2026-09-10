using XXX.Net.Core.DbContextLocator;
using XXX.Net.Core.Services.Option.Attribute;
using XXX.Net.Core.Services.Option.Attributes;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.Data;
using System.Reflection;
using Z.EntityFramework.Extensions;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace XXX.Net.Core.Services.Option.Providers
{
    public class EntityOptionProvider : IOptionProvider
    {
        private readonly IRepository _repository;
        public bool CanHandle(OptionAttribute attribute) => attribute is OptionEntityAttribute;

        public EntityOptionProvider(IRepository repository)
        {
            _repository = repository;
        }

        public async Task<List<PagedOptions>> GetOptions(PropertyInfo property, bool tree = false)
        {
            var attr = property.GetCustomAttribute<OptionEntityAttribute>();
            if (attr == null) return null;
            var options = new List<PagedOptions>();
            if (string.IsNullOrEmpty(attr.ValueField) || string.IsNullOrEmpty(attr.LabelField))
                return options;

            if (string.IsNullOrEmpty(attr.TableName))
            {
                var entityType = OptionEntityAttribute.GetEntityType(property);
                attr.TableName = entityType?.Name;
            }
            if (string.IsNullOrEmpty(attr.TableName))
            {
                return options;
            }
            string tableName= attr.TableName.Replace("Inventory", "Inv");
            var query = _repository.Sql<SlaveDbContextLocator>();


            var dt = await query.SqlQueryAsync($"select * from {tableName}");
            var mlOption = new List<PagedOptions>();
            if (tree) {
                return TreeHelper.BuildTree(dt);
            }
            foreach (DataRow item in dt.Rows)
            {
                var value = item[attr.ValueField];
                var label = Convert.ToString(item[attr.LabelField] ?? "");
                mlOption.Add(new PagedOptions
                {
                    Value = Convert.ToInt64(value!),
                    Label = label
                });
            }
            return mlOption;
        }

        public async Task<List<PagedOptions>> GetOptions(string name, string valueKey = "Name", string labelKey = "Id", bool tree = false)
        {
            var query = _repository.Sql<SlaveDbContextLocator>();
            var dt = await query.SqlQueryAsync($"select {labelKey},{valueKey} from {name}");
            var mlOption = new List<PagedOptions>();
            if (tree)
            {
                return TreeHelper.BuildTree(dt);
            }
            foreach (DataRow item in dt.Rows)
            {
                var value = item[valueKey];
                var label = Convert.ToString(item[labelKey] ?? "");
                mlOption.Add(new PagedOptions
                {
                    Value = Convert.ToInt64(value!),
                    Label = label
                });
            }
            return mlOption;
        }
        public async Task<List<PagedOptions>> GetOptions(string name, bool tree )
        {
            return await GetOptions(name, "Id", "Name", tree);
        }
    }
}
