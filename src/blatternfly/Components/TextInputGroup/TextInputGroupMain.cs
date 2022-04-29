namespace Blatternfly.Components;

public class TextInputGroupMain : InputComponentBase<string>
{
    public ElementReference Element { get; protected set; }

    [CascadingParameter] public TextInputGroup ParentInputGroup { get; protected set; }

    /// Content rendered inside the component.
    [Parameter] public RenderFragment ChildContent { get; set; }

    /// Icon to be shown on the left side of the text input group main container.
    [Parameter] public RenderFragment Icon { get; set; }

    /// Type that the input accepts.
    [Parameter] public TextInputTypes Type { get; set; }

    /// Suggestion that will show up like a placeholder even with text in the input.
    [Parameter] public string Hint { get; set; }

    /// Callback for when the input field is focused.
    [Parameter] public EventCallback<FocusEventArgs> OnFocus { get; set; }

    /// Callback for when focus is lost on the input field.
    [Parameter] public EventCallback<FocusEventArgs> OnBlur { get; set; }

    /// Accessibility label for the input.
    [Parameter] public string AriaLabel { get; set; }

    /// Placeholder value for the input.
    [Parameter] public string Placeholder { get; set; }

    private bool IsDisabled { get => ParentInputGroup.IsDisabled; }

    private string CssClass => new CssBuilder("pf-c-text-input-group__main")
        .AddClass("pf-m-icon", Icon is not null)
        .AddClassFromAttributes(AdditionalAttributes)
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

    protected override void BuildRenderTree(RenderTreeBuilder builder)
    {
        builder.OpenElement(0, "div");
        builder.AddMultipleAttributes(1, AdditionalAttributes);
        builder.AddAttribute(2, "class", CssClass);
        builder.AddAttribute(3, "ChildContent", (RenderFragment)delegate(RenderTreeBuilder innerBuilder)
        {
            innerBuilder.AddContent(4, ChildContent);
        });

        builder.OpenElement(5, "span");
        builder.AddAttribute(6, "class", "pf-c-text-input-group__text");

        if (!string.IsNullOrEmpty(Hint))
        {
            builder.OpenElement(7, "input");
            builder.AddAttribute(8, "class", "pf-c-text-input-group__text-input pf-m-hint");
            builder.AddAttribute(9, "type", "text");
            builder.AddAttribute(10, "disabled", "disabled");
            builder.AddAttribute(11, "aria-hidden", "true");
            builder.AddAttribute(12, "value", Hint);
            builder.CloseElement();
        }

        if (Icon is not null)
        {
            builder.OpenElement(13, "span");
            builder.AddAttribute(14, "class", "pf-c-text-input-group__icon");
            builder.AddContent(15, Icon);
            builder.CloseElement();
        }

        builder.OpenElement(16, "input");
        builder.AddAttribute(17, "type", InputType);
        builder.AddAttribute(18, "class", "pf-c-text-input-group__text-input");
        builder.AddAttribute(19, "aria-label", AriaLabel);
        builder.AddAttribute(20, "aria-invalid", AriaInvalid);
        builder.AddAttribute(21, "disabled", IsDisabled);
        builder.AddAttribute(22, "value", BindConverter.FormatValue(CurrentValueAsString));
        builder.AddAttribute(23, "oninput", EventCallback.Factory.CreateBinder<string>(this, __value => CurrentValueAsString = __value, CurrentValueAsString));
        builder.AddAttribute(24, "onfocus", EventCallback.Factory.Create(this, OnFocus));
        builder.AddAttribute(25, "onblur", EventCallback.Factory.Create(this, OnBlur));
        builder.AddAttribute(26, "placeholder", Placeholder);
        builder.AddElementReferenceCapture(27, __reference => Element = __reference);
        builder.CloseElement();

        builder.CloseElement();

        builder.CloseElement();
    }

    protected override bool TryParseValueFromString(string value, out string result, out string validationErrorMessage)
    {
        result                 = value;
        validationErrorMessage = null;
        return true;
    }
}
