namespace Blatternfly.Components;

public class Button : BaseComponent
{
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

    /** Adds button variant styles */
    [Parameter] public ButtonVariant Variant { get; set; } = ButtonVariant.Primary;

    /// Sets position of the link icon
    [Parameter] public Alignments IconPosition { get; set; } = Alignments.Left;

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

    private bool IsButtonElement { get => Component == "button"; }
    private bool IsInlineSpan    { get => IsInline && Component == "span"; }
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
        .AddClass("pf-m-primary"      ,  Variant == ButtonVariant.Primary)
        .AddClass("pf-m-secondary"    ,  Variant == ButtonVariant.Secondary)
        .AddClass("pf-m-tertiary"     ,  Variant == ButtonVariant.Tertiary)
        .AddClass("pf-m-danger"       ,  Variant == ButtonVariant.Danger)
        .AddClass("pf-m-warning"      ,  Variant == ButtonVariant.Warning)
        .AddClass("pf-m-link"         ,  Variant == ButtonVariant.Link)
        .AddClass("pf-m-plain"        ,  Variant == ButtonVariant.Plain)
        .AddClass("pf-m-inline"       ,  Variant == ButtonVariant.Inline)
        .AddClass("pf-m-control"      ,  Variant == ButtonVariant.Control)
        .AddClass("pf-m-block"        ,  IsBlock)
        .AddClass("pf-m-disabled"     ,  IsDisabled)
        .AddClass("pf-m-aria-disabled",  IsAriaDisabled)
        .AddClass("pf-m-active"       ,  IsActive)
        .AddClass("pf-m-inline"       ,  Variant == ButtonVariant.Link && IsInline)
        .AddClass("pf-m-danger"       ,  IsDanger && (Variant is ButtonVariant.Secondary or ButtonVariant.Link))
        .AddClass("pf-m-progress"     ,  IsLoading.HasValue && ChildContent is not null)
        .AddClass("pf-m-in-progress"  ,  IsLoading.GetValueOrDefault())
        .AddClass("pf-m-small"        ,  IsSmall)
        .AddClass("pf-m-display-lg"   ,  IsLarge)
        .AddClassFromAttributes(AdditionalAttributes)
        .Build();

    protected override void BuildRenderTree(RenderTreeBuilder builder)
    {
        var index        = 0;
        var isDisabled   = IsDisabled || IsAriaDisabled ? "" : null;
        var ariaDisabled = IsDisabled || IsAriaDisabled ? "true" : "false";

        builder.OpenElement(index++, Component);
        builder.AddAttribute(index++, "onclick", EventCallback.Factory.Create(this, OnClick));
        builder.AddEventStopPropagationAttribute(index++, "onclick", true);
        builder.AddMultipleAttributes(index++, AdditionalAttributes);
        builder.AddAttribute(index++, "aria-disabled", ariaDisabled);
        builder.AddAttribute(index++, "aria-label", AriaLabel);
        builder.AddAttribute(index++, "class", CssClass);
        if (IsButtonElement && IsDisabled)
        {
            builder.AddAttribute(index++, "disabled", IsButtonElement ? isDisabled : null);
        }
        builder.AddAttribute(index++, "tabindex", TabIndex ?? DefaultTabIndex);
        builder.AddAttribute(index++, "type", IsButtonElement ? ButtonTypeChoice : null);
        builder.AddAttribute(index++, "role", IsInlineSpan ? "button" : null);
        if (IsLoading.GetValueOrDefault())
        {
            builder.OpenElement(index++, "span");
            builder.AddAttribute(index++, "class", "pf-c-button__progress");
            builder.OpenComponent<Spinner>(index++);
            builder.AddAttribute(index++, "size", SpinnerSize.Medium);
            builder.AddAttribute(index++, "AriaValueText", SpinnerAriaValueText);
            builder.AddAttribute(index++, "AriaLabel", SpinnerAriaLabel);
            builder.AddAttribute(index++, "AriaLabelledBy", SpinnerAriaLabelledBy);
            builder.CloseComponent();
            builder.CloseElement();
        }
        if (Variant == ButtonVariant.Plain && ChildContent is null && Icon is not null)
        {
            builder.AddContent(index++, Icon);
        }
        if (Variant != ButtonVariant.Plain && Icon is not null && IconPosition == Alignments.Left)
        {
            builder.OpenElement(index++, "span");
            builder.AddAttribute(index++, "class", "pf-c-button__icon pf-m-start");
            builder.AddContent(index++, Icon);
            builder.CloseElement();
        }
        builder.AddContent(index++, ChildContent);
        if (Variant != ButtonVariant.Plain && Icon is not null && IconPosition == Alignments.Right)
        {
            builder.OpenElement(index++, "span");
            builder.AddAttribute(index++, "class", "pf-c-button__icon pf-m-end");
            builder.AddContent(index++, Icon);
            builder.CloseElement();
        }
        builder.CloseElement();
    }
}
