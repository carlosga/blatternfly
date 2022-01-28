using System;
using System.ComponentModel;
using System.Reflection;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Blatternfly.Converters;

internal sealed class EnumDescriptionConverter<T> : JsonConverter<T>
{
    public override T Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        throw new NotImplementedException();
    }

    public override void Write(Utf8JsonWriter writer, T value, JsonSerializerOptions options)
    {
        FieldInfo fi = value.GetType().GetField(value.ToString());

        var description = fi.GetCustomAttribute<DescriptionAttribute>(false);

        writer.WriteStringValue(description.Description);
    }
}
