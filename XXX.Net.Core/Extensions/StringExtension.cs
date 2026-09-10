using System;
using System.Collections.Generic;
using System.Text;

namespace XXX.Net.Core.Extensions
{
    public  static class StringExtension
    {
        /// <summary>
        /// 首字母小写
        /// </summary>
        /// <param name="val"></param>
        /// <returns></returns>
        public static string ToFirstLowerInvariant(this string val)
        {
            if (string.IsNullOrEmpty(val))
                return val;

            return string.Create(val.Length, val, (span, source) =>
            {
                source.AsSpan().CopyTo(span);
                span[0] = char.ToLowerInvariant(span[0]);
            });
        }
        /// <summary>
        /// 首字母大写
        /// </summary>
        /// <param name="val"></param>
        /// <returns></returns>
        public static string ToFirstUpperInvariant(this string val)
        {
            if (string.IsNullOrEmpty(val))
                return val;

            return string.Create(val.Length, val, (span, source) =>
            {
                source.AsSpan().CopyTo(span);
                span[0] = char.ToUpperInvariant(span[0]);
            });
        }
    }
}
