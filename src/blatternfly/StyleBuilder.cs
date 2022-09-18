// Copyright (c) 2011 - 2019 Ed Charbeneau
// License: MIT
// https://github.com/EdCharbeneau/CssBuilder

namespace Blatternfly;

public struct StyleBuilder
{
    private string stringBuffer;

    /// <summary>
    /// Creates a StyleBuilder used to define conditional in-line style used in a component. Call Build() to return the completed style as a string.
    /// </summary>
    /// <param name="prop"></param>
    /// <param name="value"></param>
    public static StyleBuilder Default(string prop, string value) => new StyleBuilder(prop, value);

    /// <summary>
    /// Creates a StyleBuilder used to define conditional in-line style used in a component. Call Build() to return the completed style as a string.
    /// </summary>
    /// <param name="style"></param>
    public static StyleBuilder Default(string style) => Empty().AddStyle(style);

    /// <summary>
    /// Creates a StyleBuilder used to define conditional in-line style used in a component. Call Build() to return the completed style as a string.
    /// </summary>
    public static StyleBuilder Empty() => new StyleBuilder();

    /// <summary>
    /// Creates a StyleBuilder used to define conditional in-line style used in a component. Call Build() to return the completed style as a string.
    /// </summary>
    /// <param name="prop"></param>
    /// <param name="value"></param>
    public StyleBuilder(string prop, string value) => stringBuffer = $"{prop}:{value};";

    /// <summary>
    /// Adds a conditional in-line style to the builder with space separator and closing semicolon.
    /// </summary>
    /// <param name="style"></param>
    public StyleBuilder AddStyle(string style) => !string.IsNullOrWhiteSpace(style) ? AddRaw($"{style};") : this;

    /// <summary>
    /// Adds a raw string to the builder that will be concatenated with the next style or value added to the builder.
    /// </summary>
    /// <param name="style"></param>
    /// <returns>StyleBuilder</returns>
    private StyleBuilder AddRaw(string style)
    {
        stringBuffer += style;
        return this;
    }

    /// <summary>
    /// Adds a raw string to the builder that will be concatenated with the next style or value added to the builder.
    /// </summary>
    /// <param name="style"></param>
    /// <param name="prop"></param>
    /// <param name="when">Condition in which the style is added.</param>
    /// <returns>StyleBuilder</returns>
    internal StyleBuilder AddRaw(string style, bool when = true)  => when ? this.AddRaw(style) : this;

    /// <summary>
    /// Adds a conditional in-line style to the builder with space separator and closing semicolon..
    /// </summary>
    /// <param name="prop"></param>
    /// <param name="value">Style to add</param>
    /// <returns>StyleBuilder</returns>
    public StyleBuilder AddStyle<T>(string prop, T value) => value is not null ? AddRaw($"{prop}:{value};") : this;

    /// <summary>
    /// Adds a conditional in-line style to the builder with space separator and closing semicolon..
    /// </summary>
    /// <param name="prop"></param>
    /// <param name="value">Style to conditionally add.</param>
    /// <param name="when">Condition in which the style is added.</param>
    /// <returns>StyleBuilder</returns>
    public StyleBuilder AddStyle<T>(string prop, T value, bool when = true) => when ? this.AddStyle(prop, value) : this;

    /// <summary>
    /// Adds a conditional in-line style to the builder with space separator and closing semicolon..
    /// </summary>
    /// <param name="prop"></param>
    /// <param name="value">Style to conditionally add.</param>
    /// <param name="when">Condition in which the style is added.</param>
    /// <returns>StyleBuilder</returns>
    public StyleBuilder AddStyle<T>(Func<string> prop, T value, bool when = true) => when ? this.AddStyle(prop(), value) : this;

    /// <summary>
    /// Adds a conditional in-line style to the builder with space separator and closing semicolon..
    /// </summary>
    /// <param name="prop"></param>
    /// <param name="value">Style to conditionally add.</param>
    /// <param name="when">Condition in which the style is added.</param>
    /// <returns></returns>
    public StyleBuilder AddStyle<T>(string prop, Func<T> value, bool when = true) => when ? this.AddStyle(prop, value()) : this;

    /// <summary>
    /// Adds a conditional in-line style to the builder with space separator and closing semicolon..
    /// </summary>
    /// <param name="prop"></param>
    /// <param name="value">Style to conditionally add.</param>
    /// <param name="when">Condition in which the style is added.</param>
    /// <returns>StyleBuilder</returns>
    public StyleBuilder AddStyle<T>(string prop, T value, Func<bool> when = null) => this.AddStyle(prop, value, when());

    /// <summary>
    /// Adds a conditional in-line style to the builder with space separator and closing semicolon..
    /// </summary>
    /// <param name="prop"></param>
    /// <param name="value">Style to conditionally add.</param>
    /// <param name="when">Condition in which the style is added.</param>
    /// <returns>StyleBuilder</returns>
    public StyleBuilder AddStyle<T>(string prop, Func<T> value, Func<bool> when = null) => this.AddStyle(prop, value(), when());

    /// <summary>
    /// Adds a conditional nested StyleBuilder to the builder with separator and closing semicolon.
    /// </summary>
    /// <param name="builder">Style Builder to conditionally add.</param>
    /// <returns>StyleBuilder</returns>
    public StyleBuilder AddStyle(StyleBuilder builder) => this.AddRaw(builder.Build());

    /// <summary>
    /// Adds a conditional nested StyleBuilder to the builder with separator and closing semicolon.
    /// </summary>
    /// <param name="builder">Style Builder to conditionally add.</param>
    /// <param name="when">Condition in which the style is added.</param>
    /// <returns>StyleBuilder</returns>
    public StyleBuilder AddStyle(StyleBuilder builder, bool when = true) => when ? this.AddRaw(builder.Build()) : this;

    /// <summary>
    /// Adds a conditional in-line style to the builder with space separator and closing semicolon..
    /// </summary>
    /// <param name="builder">Style Builder to conditionally add.</param>
    /// <param name="when">Condition in which the styles are added.</param>
    /// <returns>StyleBuilder</returns>
    public StyleBuilder AddStyle(StyleBuilder builder, Func<bool> when = null) => this.AddStyle(builder, when());

    // <summary>
    // Adds a conditional in-line style to the builder with space separator and closing semicolon..
    // A ValueBuilder action defines a complex set of values for the property.
    // </summary>
    // <param name="prop"></param>
    // <param name="builder"></param>
    // <param name="when"></param>
    // public StyleBuilder AddStyle(string prop, Action<ValueBuilder> builder, bool when = true) {
    //     ValueBuilder values = new ValueBuilder();
    //     builder(values);
    //     return AddStyle(prop, values.ToString(), when && values.HasValue);
    // }

    /// <summary>
    /// Adds a conditional in-line style when it exists in a dictionary to the builder with separator.
    /// Null safe operation.
    /// </summary>
    /// <param name="additionalAttributes">Additional Attribute splat parameters</param>
    /// <returns>StyleBuilder</returns>
    public StyleBuilder AddStyleFromAttributes(IReadOnlyDictionary<string, object> additionalAttributes) =>
        additionalAttributes is null
            ? this
                : additionalAttributes.TryGetValue("style", out var c) ? AddRaw(c as string) : this;

    /// <summary>
    /// Finalize the completed Style as a string.
    /// </summary>
    /// <returns>string</returns>
    public string Build()
    {
        // String buffer finalization code
        return string.IsNullOrEmpty(stringBuffer) ? null : stringBuffer.Trim();
    }

    // ToString should only and always call Build to finalize the rendered string.
    public override string ToString() => Build();
}
