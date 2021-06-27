using ObjectComparer.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace ObjectComparer
{
    /// <summary>
    /// Class design to compare to objects
    /// </summary>
    public class ObjectComparer : IObjectComparer
    {
        /// <summary>
        /// Deep or Shallow searches
        /// </summary>
        public bool DeepCompare { get; set; } = false;

        /// <summary>
        /// Stores the differences between the objects
        /// </summary>
        public string Differences { get; set; } = ""; // TO-DO: Store the differences

        /// <summary>
        /// Stores the fieldsInfo and PrpertyInfo
        /// </summary>
        private Dictionary<Type, MemberInfo[]> CacheMemberInfo { get; set; } = new Dictionary<Type, MemberInfo[]>();

        /// <summary>
        /// Caches the properties based on a type
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        private MemberInfo[] GetCacheMemberInfo(Type input)
        {
            if (CacheMemberInfo.TryGetValue(input, out var propertyInfos))
            {
                return propertyInfos;
            }
            
            var memberInfos = input.GetMembers().Where(x=> x.MemberType == MemberTypes.Field || x.MemberType == MemberTypes.Property).ToArray();
            CacheMemberInfo.Add(input, memberInfos);
            return memberInfos;
        }

        /// <summary>
        /// Identifies if two classes are identical
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="input1"></param>
        /// <param name="input2"></param>
        /// <returns></returns>
        public bool CompareElements<T>(T input1, T input2) where T : class
        {
            if (input1 == null || input2 == null)
            {
                return false;
                //TO-DO: Register the differences
            }

            Type type1 = input1.GetType();
            Type type2 = input2.GetType();

            if (type1 != type2)
            {
                return false;
                //TO-DO: Register the differences
            }

            var cacheProperties = GetCacheMemberInfo(type1);
            if (!AnalyzeMembers(input1, input2, cacheProperties))
                return false;

            return true;
        }

        /// <summary>
        /// Compares properties and fields
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="input1"></param>
        /// <param name="input2"></param>
        /// <param name="cahcheFields"></param>
        /// <returns></returns>
        private bool AnalyzeMembers<T>(T input1, T input2, MemberInfo[] cahcheFields) where T : class
        {
            foreach (var cacheField in cahcheFields)
            {
                var type = cacheField.GetUnderlyingType();
                if (type.IsSimpleType())
                {
                    var value1 = cacheField.GetValue(input1);
                    var value2 = cacheField.GetValue(input2);

                    if (value1 != value2 && (value1 == null || !value1.Equals(value2)))
                    {
                        return false;
                        //TO-DO: Register the differences
                    }
                    continue;
                }

                if (this.DeepCompare)
                {
                    if (!AnalyzeComplexTypes(input1, input2, cacheField))
                    {
                        return false;
                        //TO-DO: Register the differences
                    }
                    continue;
                }
            }
            return true;
        }

        /// <summary>
        /// Deep compare of objects
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="input1"></param>
        /// <param name="input2"></param>
        /// <param name="propertyInfo"></param>
        /// <returns></returns>
        private bool AnalyzeComplexTypes<T>(T input1, T input2, MemberInfo propertyInfo)
        {
            var value1 = propertyInfo.GetValue(input1);
            var value2 = propertyInfo.GetValue(input2);
            return CompareElements(value1, value2);
        }
    }
}
