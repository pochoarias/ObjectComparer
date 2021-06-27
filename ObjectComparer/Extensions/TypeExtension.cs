using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace ObjectComparer.Extensions
{
    public static class TypeExtension
    {
        public static bool IsSimpleType(this Type type)
        {
            return
               type.IsValueType ||
               type.IsPrimitive ||
               new[]
               {
               typeof(String),
               typeof(Decimal),
               typeof(DateTime),
               typeof(DateTimeOffset),
               typeof(TimeSpan),
               typeof(Guid)
               }.Contains(type) ||
               (Convert.GetTypeCode(type) != TypeCode.Object);
        }

    }
}
