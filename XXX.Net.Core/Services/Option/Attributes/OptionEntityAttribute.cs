using XXX.Net.Core.Services.Option.Attributes;
using XXX.Net.Core.Services.Option.Providers;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace XXX.Net.Core.Services.Option.Attribute
{
    [AttributeUsage(AttributeTargets.Property)]
    public class OptionEntityAttribute : OptionAttribute
    {
        public string TableName { get; set; }
        public string ValueField { get; } = "Id";
        public string LabelField { get; } = "Name";

        public string Where { get; set; }

        public OptionEntityAttribute(

            string tableName ,
            string valueField = "Id",
            string labelField = "Name") : base(typeof(EntityOptionProvider))
        {
            TableName = tableName;
            ValueField = valueField;
            LabelField = labelField;
        }
        public OptionEntityAttribute(Type table, string valueField = "Id",string labelField = "Name") : base(typeof(EntityOptionProvider)) 
        {
            TableName = table.Name;
            ValueField = valueField;
            LabelField = labelField;
        }
        public OptionEntityAttribute() : base(typeof(EntityOptionProvider))
        {
            TableName = null;
            ValueField = "Id";
            LabelField = "Name";
        }
        public OptionEntityAttribute(string valueField , string labelField ) : base(typeof(EntityOptionProvider))
        {
            TableName = null;
            ValueField = valueField;
            LabelField = labelField;
        }
        /// <summary>
        /// 根据使用此 Attribute 的属性，获取 TEntity
        /// </summary>
        /// <param name="propertyInfo"></param>
        /// <returns></returns>
        public static Type GetEntityType(PropertyInfo propertyInfo)
        {
            return propertyInfo.DeclaringType?
      .GetGenericArguments()
      .FirstOrDefault();
            //var type = propertyInfo.DeclaringType;

            //while (type != null)
            //{
            //    if (type.IsGenericType)
            //    {
            //        var genericArguments = type.GetGenericArguments();

            //        if (genericArguments.Length == 1)
            //        {
            //            return genericArguments[0];
            //        }
            //    }

            //    type = type.BaseType;
            //}

            //return null;
        }

        /// <summary>
        /// 获取 TEntity 的名称
        /// </summary>
        public static string GetEntityName(PropertyInfo propertyInfo)
        {
            return GetEntityType(propertyInfo).Name;
        }
    }
}
    
