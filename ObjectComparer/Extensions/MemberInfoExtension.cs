using System;
using System.Reflection;

namespace ObjectComparer.Extensions
{
    public static class MemberInfoExtension
    {
        public static object GetValue(this MemberInfo memberInfo, object forObject)
        {
            switch (memberInfo.MemberType)
            {
                case MemberTypes.Field:
                    return ((FieldInfo)memberInfo).GetValue(forObject);
                case MemberTypes.Property:
                    return ((PropertyInfo)memberInfo).GetValue(forObject);
                default:
                    throw new ArgumentException
                    (
                     "Input MemberInfo must be of type FieldInfo or PropertyInfo"
                    );
            }
        }

        public static Type GetUnderlyingType(this MemberInfo member)
        {
            switch (member.MemberType)
            {
                case MemberTypes.Field:
                    return ((FieldInfo)member).FieldType;
                case MemberTypes.Property:
                    return ((PropertyInfo)member).PropertyType;
                default:
                    throw new ArgumentException
                    (
                     "Input MemberInfo must be of type FieldInfo or PropertyInfo"
                    );
            }
        }
    }
}
