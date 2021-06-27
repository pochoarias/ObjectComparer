using ObjectComparer.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace ObjectComparer
{
    public class ObjectComparer : IObjectComparer
    {
        public bool DeepCompare { get; set; } = false;
        public string Differences { get; set; } = "";
        private Dictionary<Type, PropertyInfo[]> CacheProperties { get; set; } = new Dictionary<Type, PropertyInfo[]>();
        private Dictionary<Type, FieldInfo[]> CacheFields { get; set; } = new Dictionary<Type, FieldInfo[]>();

        /// <summary>
        /// Caches the properties based on a type
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        private PropertyInfo[] GetCacheProperties(Type input)
        {

            if (CacheProperties.TryGetValue(input, out var propertyInfos))
            {
                return propertyInfos;
            }

            var properties = input.GetProperties(BindingFlags.Public | BindingFlags.Instance).ToArray();
            CacheProperties.Add(input, properties);
            return properties;
        }

        /// <summary>
        /// Caches the fields based on the type
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        private FieldInfo[] GetCacheFields(Type input)
        {

            if (CacheFields.TryGetValue(input, out var fieldInfos))
            {
                return fieldInfos;
            }

            var fields = input.GetFields(BindingFlags.Public | BindingFlags.Instance).ToArray();
            CacheFields.Add(input, fields);
            return fields;
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
            }

            Type type1 = input1.GetType();
            Type type2 = input2.GetType();

            if (type1 != type2)
            {
                return false;
                //throw new Exception("Object types are not the same");
            }

            var cacheProperties = GetCacheProperties(type1);
            if (!AnalyzeProperties(input1, input2, cacheProperties))
                return false;

            var cahcheFields = GetCacheFields(type1);
            if (!AnalyzeFields(input1, input2, cahcheFields))
                return false;

            return true;

        }

        private bool AnalyzeFields<T>(T input1, T input2, FieldInfo[] cahcheFields) where T : class
        {
            foreach (var cacheField in cahcheFields)
            {
                if (cacheField.FieldType.IsSimpleType())
                {
                    var value1 = cacheField.GetValue(input1);
                    var value2 = cacheField.GetValue(input2);

                    if (value1 != value2 && (value1 == null || !value1.Equals(value2)))
                    {
                        return false;
                        //throw new Exception("Object values are not the same"); //TO-DO: Register the differences
                    }
                    continue;
                }

                if (this.DeepCompare)
                {
                    if (AnalyzeComplexTypes(input1, input2, cacheField))
                    {
                        continue;
                    }
                    return false;
                }
            }
            return true;
        }


        private bool AnalyzeProperties<T>(T input1, T input2, PropertyInfo[] cacheProperties) where T : class
        {
            foreach (var cacheProperty in cacheProperties)
            {
                if (cacheProperty.PropertyType.IsSimpleType())
                {
                    var value1 = cacheProperty.GetValue(input1);
                    var value2 = cacheProperty.GetValue(input2);

                    if (value1 != value2 && (value1 == null || !value1.Equals(value2)))
                    {
                        return false;
                        //throw new Exception("Object values are not the same"); //TO-DO: Register the differences
                    }
                    continue;
                }

                if (this.DeepCompare) {
                    if (AnalyzeComplexTypes(input1, input2, cacheProperty))
                    {
                        continue;
                    }
                    return false;
                }
            }
            return true;
        }

        private bool AnalyzeComplexTypes<T>(T input1, T input2, PropertyInfo propertyInfo)
        {

            var value1 = propertyInfo.GetValue(input1, null);
            var value2 = propertyInfo.GetValue(input2, null);
            return CompareElements(value1, value2);

        }

        private bool AnalyzeComplexTypes<T>(T input1, T input2, FieldInfo fieldInfo)
        {
            var value1 = fieldInfo.GetValue(input1);
            var value2 = fieldInfo.GetValue(input2);
            return CompareElements(value1, value2);

        }


    }
}
