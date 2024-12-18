namespace MyStack.DynamicForms.AspNetCore
{
    public static class ExtraPropertyDictionaryExtensions  
    {
        public static T? GetValue<T>(this ExtraPropertyDictionary extraProperty, string key)
        {
            if (extraProperty.TryGetValue(key, out object? value) && value != null)
            {
                var conversionType = typeof(T);
                if (typeof(T) == typeof(Guid))
                {
                    return (T)(object)Guid.Parse(value.ToString()!);
                }
                else if (typeof(T) == typeof(DateTime))
                {
                    return (T)(object)DateTime.Parse(value.ToString()!);
                }
                else if (conversionType == typeof(DateTimeOffset))
                {
                    return (T)(object)DateTimeOffset.Parse(value.ToString()!);
                }
                else if (conversionType == typeof(TimeSpan))
                {
                    return (T)(object)TimeSpan.Parse(value.ToString()!);
                }
                else
                {
                    return (T)Convert.ChangeType(value, conversionType);
                }
            }
            return default;
        }

        public static T? GetDefaultValue<T>(this ExtraPropertyDictionary extraProperty)
        {
            return extraProperty.GetValue<T>("DefaultValue");
        }
    }
}
