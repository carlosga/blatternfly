namespace Blatternfly.Components;

public partial class Button : ComponentBase
{
    /// Additional attributes that will be applied to the component.
    [Parameter(CaptureUnmatchedValues = true)] public IReadOnlyDictionary<string, object> AdditionalAttributes { get; set; }

    /// Content rendered inside the component.
    [Parameter] public RenderFragment ChildContent { get; set; }

    /// Sets the base component to render. defaults to button.
    [Parameter] public string Component { get; set;  } = "button";

    /// Adds active styling to button.
    [Parameter] public bool IsActive { get; set; }

    /// Adds block styling to button.
    [Parameter] public bool IsBlock { get; set; }

    /// Disables the button and adds disabled styling.
    [Parameter] public bool IsDisabled { get; set; }

    /// Adds disabled styling and communicates that the button is disabled using the aria-disabled html attribute.
    [Parameter] public bool IsAriaDisabled { get; set; }

    /// Adds progress styling to button.
    [Parameter] public bool? IsLoading { get; set; }

    /// Aria-valuetext for the loading spinner.
    [Parameter] public string SpinnerAriaValueText { get; set; }

    /// Accessible label for the spinner to describe what is loading.
    [Parameter] public string SpinnerAriaLabel { get; set; }

    /// Id of element which describes what is being loaded.
    [Parameter] public string SpinnerAriaLabelledBy { get; set; }

    /// @beta Events to prevent when the button is in an aria-disabled state.
    [Parameter] public string[] InoperableEvents { get; set; }

    /// Adds inline styling to a link button.
    [Parameter] public bool IsInline { get; set; }

    /// Sets button type.
    [Parameter] public ButtonType Type { get; set; } = ButtonType.Button;

    /// Adds button variant styles.
    [Parameter] public ButtonVariant Variant { get; set; } = ButtonVariant.Primary;

    /// Sets position of the link icon
    [Parameter] public Alignment IconPosition { get; set; } = Alignment.Left;

    /// Adds accessible text to the button.
    [Parameter] public string AriaLabel { get; set; }

    /// Icon for the button. Usable by all variants except for plain.
    [Parameter] public RenderFragment Icon { get; set; }

    /// Set button tab index unless component is not a button and is disabled.
    [Parameter] public int? TabIndex { get; set; }

    /// Adds small styling to the button.
    [Parameter] public bool IsSmall { get; set; }

    /// Adds large styling to the button
    [Parameter] public bool IsLarge { get; set; }

    /// Adds danger styling to secondary or link button variants.
    [Parameter] public bool IsDanger { get; set; }

    /// Button Click
    [Parameter] public EventCallback<MouseEventArgs> OnClick { get; set; }

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
}
