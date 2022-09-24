namespace Blatternfly.Components;

public partial class Button : ComponentBase
{
    public ElementReference Element { get; protected set; }

    /// <summary>Additional attributes that will be applied to the component.</summary>
    [Parameter(CaptureUnmatchedValues = true)]
    public IReadOnlyDictionary<string, object> AdditionalAttributes { get; set; }

    /// <summary>Content rendered inside the component.</summary>
    [Parameter]
    public RenderFragment ChildContent { get; set; }

    /// <summary>Sets the base component to render. defaults to button.</summary>
    [Parameter]
    public string Component { get; set; } = "button";

    /// <summary>Adds active styling to button.</summary>
    [Parameter]
    public bool IsActive { get; set; }

    /// <summary>Adds block styling to button.</summary>
    [Parameter]
    public bool IsBlock { get; set; }

    /// <summary>Disables the button and adds disabled styling.</summary>
    [Parameter]
    public bool IsDisabled { get; set; }

    /// <summary>Adds disabled styling and communicates that the button is disabled using the aria-disabled html attribute.</summary>
    [Parameter]
    public bool IsAriaDisabled { get; set; }

    /// <summary>Adds progress styling to button.</summary>
    [Parameter]
    public bool? IsLoading { get; set; }

    /// <summary>Aria-valuetext for the loading spinner.</summary>
    [Parameter]
    public string SpinnerAriaValueText { get; set; }

    /// <summary>Accessible label for the spinner to describe what is loading.</summary>
    [Parameter]
    public string SpinnerAriaLabel { get; set; }

    /// <summary>Id of element which describes what is being loaded.</summary>
    [Parameter]
    public string SpinnerAriaLabelledBy { get; set; }

    /// <summary>@beta Events to prevent when the button is in an aria-disabled state.</summary>
    [Parameter]
    public string[] InoperableEvents { get; set; }

    /// <summary>Adds inline styling to a link button.</summary>
    [Parameter]
    public bool IsInline { get; set; }

    /// <summary>Sets button type.</summary>
    [Parameter]
    public ButtonType Type { get; set; } = ButtonType.Button;

    /// <summary>Adds button variant styles.</summary>
    [Parameter]
    public ButtonVariant Variant { get; set; } = ButtonVariant.Primary;

    /// <summary>Sets position of the link icon.</summary>
    [Parameter]
    public Alignment IconPosition { get; set; } = Alignment.Left;

    /// <summary>Adds accessible text to the button.</summary>
    [Parameter]
    public string AriaLabel { get; set; }

    /// <summary>Icon for the button. Usable by all variants except for plain.</summary>
    [Parameter]
    public RenderFragment Icon { get; set; }

    /// <summary>Set button tab index unless component is not a button and is disabled.</summary>
    [Parameter]
    public int? TabIndex { get; set; }

    /// <summary>Adds small styling to the button.</summary>
    [Parameter]
    public bool IsSmall { get; set; }

    /// <summary>Adds large styling to the button.</summary>
    [Parameter]
    public bool IsLarge { get; set; }

    /// <summary>Adds danger styling to secondary or link button variants.</summary>
    [Parameter]
    public bool IsDanger { get; set; }

    /// <summary>Button Click.</summary>
    [Parameter]
    public EventCallback<MouseEventArgs> OnClick { get; set; }

    /// <summary>Adds count number to button.</summary>
    [Parameter] public BadgeCountObject CountOptions { get; set; }

    private string ButtonTypeValue { get => IsButtonElement ? ButtonTypeChoice : null; }
    private string Role            { get => IsInlineSpan ? "button" : null; }
    private int?   TabIndexValue   { get => TabIndex ?? DefaultTabIndex; }
    private bool   IsButtonElement { get => Component == "button"; }
    private bool   IsInlineSpan    { get => IsInline && Component == "span"; }
    private string AriaDisabled    { get => IsDisabled || IsAriaDisabled ? "true" : "false"; }
    private string Disabled
    {
        get
        {
            if (IsButtonElement && IsDisabled)
            {
                return IsDisabled || IsAriaDisabled ? "" : null;
            }

            return null;
        }
    }

    private int? DefaultTabIndex
    {
        get
        {
            if (IsDisabled)
            {
                return IsButtonElement ? null : -1;
            }
            else if (IsAriaDisabled)
            {
                return null;
            }
            else if (IsInlineSpan)
            {
                return 0;
            }

            return null;
        }
    }

    private string ButtonTypeChoice
    {
        get => Type switch
        {
            ButtonType.Button => "button",
            ButtonType.Submit => "submit",
            ButtonType.Reset  => "reset",
            _                 => null
        };
    }

    private string CssClass => new CssBuilder("pf-c-button")
        .AddClass("pf-m-primary"      ,  Variant is ButtonVariant.Primary)
        .AddClass("pf-m-secondary"    ,  Variant is ButtonVariant.Secondary)
        .AddClass("pf-m-tertiary"     ,  Variant is ButtonVariant.Tertiary)
        .AddClass("pf-m-danger"       ,  Variant is ButtonVariant.Danger)
        .AddClass("pf-m-warning"      ,  Variant is ButtonVariant.Warning)
        .AddClass("pf-m-link"         ,  Variant is ButtonVariant.Link)
        .AddClass("pf-m-plain"        ,  Variant is ButtonVariant.Plain)
        .AddClass("pf-m-inline"       ,  Variant is ButtonVariant.Inline)
        .AddClass("pf-m-control"      ,  Variant is ButtonVariant.Control)
        .AddClass("pf-m-block"        ,  IsBlock)
        .AddClass("pf-m-disabled"     ,  IsDisabled)
        .AddClass("pf-m-aria-disabled",  IsAriaDisabled)
        .AddClass("pf-m-active"       ,  IsActive)
        .AddClass("pf-m-inline"       ,  Variant is ButtonVariant.Link && IsInline)
        .AddClass("pf-m-danger"       ,  IsDanger && (Variant is ButtonVariant.Secondary or ButtonVariant.Link))
        .AddClass("pf-m-progress"     ,  IsLoading.HasValue && ChildContent is not null)
        .AddClass("pf-m-in-progress"  ,  IsLoading.GetValueOrDefault())
        .AddClass("pf-m-small"        ,  IsSmall)
        .AddClass("pf-m-display-lg"   ,  IsLarge)
        .AddClassFromAttributes(AdditionalAttributes)
        .Build();

    protected override void BuildRenderTree(RenderTreeBuilder builder)
    {
        var isDisabled   = IsDisabled || IsAriaDisabled ? "" : null;
        var ariaDisabled = IsDisabled || IsAriaDisabled ? "true" : "false";

        builder.OpenElement(0, Component);
        builder.AddAttribute(1, "onclick", EventCallback.Factory.Create(this, OnClick));
        builder.AddEventStopPropagationAttribute(2, "onclick", true);
        builder.AddEventPreventDefaultAttribute(3, "onclick", true);
        builder.AddEventPreventDefaultAttribute(4, "onkeypress", true);
        builder.AddMultipleAttributes(5, AdditionalAttributes);
        builder.AddAttribute(6, "aria-disabled", ariaDisabled);
        builder.AddAttribute(7, "aria-label", AriaLabel);
        builder.AddAttribute(8, "class", CssClass);
        if (IsButtonElement && IsDisabled)
        {
            builder.AddAttribute(9, "disabled", IsButtonElement ? isDisabled : null);
        }
        builder.AddAttribute(10, "tabindex", TabIndex ?? DefaultTabIndex);
        builder.AddAttribute(11, "type", IsButtonElement ? ButtonTypeChoice : null);
        builder.AddAttribute(12, "role", IsInlineSpan ? "button" : null);
        if (IsLoading.GetValueOrDefault())
        {
            builder.OpenElement(13, "span");
            builder.AddAttribute(14, "class", "pf-c-button__progress");
            builder.OpenComponent<Spinner>(15);
            builder.AddAttribute(16, "size", SpinnerSize.Medium);
            builder.AddAttribute(17, "AriaValueText", SpinnerAriaValueText);
            builder.AddAttribute(18, "AriaLabel", SpinnerAriaLabel);
            builder.AddAttribute(19, "AriaLabelledBy", SpinnerAriaLabelledBy);
            builder.CloseComponent();
            builder.CloseElement();
        }
        if (Variant is ButtonVariant.Plain && ChildContent is null && Icon is not null)
        {
            builder.AddContent(20, Icon);
        }
        if (Variant is not ButtonVariant.Plain && Icon is not null && IconPosition is Alignment.Left)
        {
            builder.OpenElement(21, "span");
            builder.AddAttribute(22, "class", "pf-c-button__icon pf-m-start");
            builder.AddContent(23, Icon);
            builder.CloseElement();
        }
        builder.AddContent(24, ChildContent);
        if (Variant is not ButtonVariant.Plain && Icon is not null && IconPosition is Alignment.Right)
        {
            builder.OpenElement(25, "span");
            builder.AddAttribute(26, "class", "pf-c-button__icon pf-m-end");
            builder.AddContent(27, Icon);
            builder.CloseElement();
        }
        if (CountOptions is not null)
        {
            builder.OpenElement(28, "span");
            builder.AddAttribute(29, "class", $"pf-c-button__count {CountOptions.ClassName}");

            builder.OpenComponent<Badge>(30);
            builder.AddAttribute(31, "IsRead", CountOptions.IsRead);
            builder.AddAttribute(32, "ChildContent", (RenderFragment)delegate(RenderTreeBuilder innerBuilder)
            {
                innerBuilder.AddContent(33, CountOptions.Count?.ToString());
            });
            builder.CloseComponent();

            builder.CloseElement();
        }
        builder.AddElementReferenceCapture(34, __reference => Element = __reference);
        builder.CloseElement();
    }
}
