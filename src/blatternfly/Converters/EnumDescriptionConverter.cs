using System;
using System.ComponentModel;
using System.Reflection;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Blatternfly.Converters;

internal sealed class EnumDescriptionConverter<T> : JsonConverter<T> where T : struct
{
    public override T Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        var value  = reader.GetString();
        var fields = typeof(T).GetFields();

        foreach (var field in fields)
        {
            var description = field.GetCustomAttribute<DescriptionAttribute>(false);

            if (description is not null)
            {
                if (description.Description == value)
                {
                    return Enum.Parse<T>(field.Name);
                }
            }
        }

        return default;
    }

    public override void Write(Utf8JsonWriter writer, T value, JsonSerializerOptions options)
    {
        var fieldInfo   = value.GetType().GetField(value.ToString());
        var description = fieldInfo.GetCustomAttribute<DescriptionAttribute>(false);

        writer.WriteStringValue(description.Description);
    }
}
