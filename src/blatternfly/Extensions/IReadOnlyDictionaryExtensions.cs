namespace System.Collections.Generic;

internal static class IReadOnlyDictionaryExtensions
{
    internal static string GetPropertyValue(this IReadOnlyDictionary<string, object> dictionary, string propertyName)
    {
        if (dictionary is { Count: > 0 })
        {
            if (dictionary.TryGetValue(propertyName, out var propertyValue))
            {
                return propertyValue as string;
            }
        }
        return null;
    }
}
