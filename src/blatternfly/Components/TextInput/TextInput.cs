using System;

namespace Blatternfly.Components;

public class TextInput : InputComponentBase<string>
{
    public ElementReference Element { get; protected set; }

    /// Type that the input accepts.
    [Parameter] public TextInputTypes Type { get; set; } = TextInputTypes.Text;

    /// Flag to show if the input is read only.
    [Parameter] public bool IsReadOnly { get; set; }

    /// Callback function when input is focused.
    [Parameter] public EventCallback OnFocus { get; set; }

    /// Callback function when input is blurred (focus leaves).
    [Parameter] public EventCallback OnBlur { get; set; }

    /// Aria-label. The input requires an associated id or aria-label.
    [Parameter] public string AriaLabel { get; set; }

    /// Icon variant
    [Parameter] public TextInputIconVariants? IconVariant { get; set; }

    /// Custom icon url to set as the input's background-image.
    [Parameter] public string CustomIconUrl { get; set; }

    /// Dimensions for the custom icon set as the input's background-size.
    [Parameter] public string CustomIconDimensions { get; set; }

    private string CssStyle => new StyleBuilder()
        .AddStyle("background-image", $"url('{CustomIconUrl}')" , !string.IsNullOrEmpty(CustomIconUrl))
        .AddStyle("background-size" , "'{CustomIconDimensions}'", !string.IsNullOrEmpty(CustomIconDimensions))
        .Build();

    private string CssClass => new CssBuilder("pf-c-form-control")
        .AddClass("pf-m-icon"    , (IconVariant.HasValue && IconVariant != TextInputIconVariants.Search) || !string.IsNullOrEmpty(CustomIconUrl))
        .AddClass("pf-m-calendar", IconVariant == TextInputIconVariants.Calendar)
        .AddClass("pf-m-clock"   , IconVariant == TextInputIconVariants.Clock)
        .AddClass("pf-m-search"  , IconVariant == TextInputIconVariants.Search)
        .AddClass(ValidationClass)
        .Build();

    private string InputType
    {
        get => Type switch
        {
            TextInputTypes.Text          => "text",
            TextInputTypes.Date          => "date",
            TextInputTypes.DatetimeLocal => "datetime-local",
            TextInputTypes.Email         => "email",
            TextInputTypes.Month         => "month",
            TextInputTypes.Number        => "number",
            TextInputTypes.Password      => "password",
            TextInputTypes.Search        => "search",
            TextInputTypes.Tel           => "tel",
            TextInputTypes.Time          => "time",
            TextInputTypes.Url           => "url",
            _                            => "text"
        };
    }

    protected override void OnParametersSet()
    {
        base.OnParametersSet();

        var ariaLabelledBy = GetPropertyValue("aria-labelledby");

        if (string.IsNullOrEmpty(InternalId)
         && string.IsNullOrEmpty(AriaLabel)
         && string.IsNullOrEmpty(ariaLabelledBy))
        {
            throw new InvalidOperationException("TextInput: Text input requires either an id or aria-label to be specified");
        }
    }

    protected override void BuildRenderTree(RenderTreeBuilder builder)
    {
        builder.OpenElement(1, "input");
        builder.AddMultipleAttributes(2, AdditionalAttributes);
        builder.AddAttribute(3, "class", CssClass);
        builder.AddAttribute(4, "type", InputType);
        builder.AddAttribute(5, "aria-label", AriaLabel);
        builder.AddAttribute(6, "aria-invalid", AriaInvalid);
        builder.AddAttribute(7, "required", IsRequired);
        builder.AddAttribute(8, "disabled", IsDisabled);
        builder.AddAttribute(9, "readOnly", IsReadOnly);
        builder.AddAttribute(10, "value", BindConverter.FormatValue(CurrentValueAsString));
        builder.AddAttribute(11, "onchange", EventCallback.Factory.CreateBinder<string>(this, __value => CurrentValueAsString = __value, CurrentValueAsString));
        builder.AddAttribute(12, "onfocus", EventCallback.Factory.Create(this, OnFocus));
        builder.AddAttribute(13, "onblur", EventCallback.Factory.Create(this, OnBlur));
        builder.AddAttribute(14, "style", CssStyle);
        builder.AddElementReferenceCapture(15, __inputReference => Element = __inputReference);
        builder.CloseElement();
    }

    protected override bool TryParseValueFromString(string value, out string result, out string validationErrorMessage)
    {
        result = value;
        validationErrorMessage = null;
        return true;
    }
}
