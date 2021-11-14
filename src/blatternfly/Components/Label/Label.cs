namespace Blatternfly.Components;

public class Label : BaseComponent
{
    /// Color of the label.
    [Parameter] public LabelColor? Color { get; set; } = LabelColor.Grey;

    /// Variant of the label.
    [Parameter] public LabelVariant Variant { get; set; } = LabelVariant.Filled;
    
    /// Flag indicating the label is compact.
    [Parameter] public bool IsCompact { get; set; }        

    /// Flag indicating the label text should be truncated.
    [Parameter] public bool IsTruncated { get; set; }

    /// Icon added to the left of the label text.
    [Parameter] public RenderFragment Icon { get; set; }

    /// Href for a label that is a link. If present, the label will change to an anchor element.
    [Parameter] public string Href { get; set; }

    /// Close click callback for removable labels. If present, label will have a close button.
    [Parameter] public EventCallback<MouseEventArgs> OnClose { get; set; }

    /// Node for custom close button.
    [Parameter] public RenderFragment CloseBtn { get; set; }
    
    /// Aria label for close button.
    [Parameter] public string CloseBtnAriaLabel { get; set; }        

    /// Flag indicating if the label is an overflow label.
    [Parameter] public bool IsOverflowLabel { get; set; }
    
    /// Label click.
    [Parameter] public EventCallback<MouseEventArgs> OnClick { get; set; }

    private CssBuilder CssClass => new CssBuilder("pf-c-label")
        .AddClass("pf-m-blue"    , Color == LabelColor.Blue)
        .AddClass("pf-m-cyan"    , Color == LabelColor.Cyan)
        .AddClass("pf-m-green"   , Color == LabelColor.Green)
        .AddClass("pf-m-orange"  , Color == LabelColor.Orange)
        .AddClass("pf-m-purple"  , Color == LabelColor.Purple)
        .AddClass("pf-m-red"     , Color == LabelColor.Red)
        .AddClass("pf-m-outline" , Variant == LabelVariant.Outline)
        .AddClass("pf-m-overflow", IsOverflowLabel)
        .AddClass("pf-m-compact" , IsCompact)
        .AddClassFromAttributes(AdditionalAttributes);
    
    protected override void BuildRenderTree(RenderTreeBuilder builder)
    {
        var index             = 0;
        var labelComponent    = IsOverflowLabel ? "button" : "span";
        var component         = !string.IsNullOrEmpty(Href) ? "a" : "span";
        var closeBtnAriaLabel = !string.IsNullOrEmpty(CloseBtnAriaLabel) ? CloseBtnAriaLabel : $"Close Label"; 

        builder.OpenElement(index++, labelComponent);
        builder.AddMultipleAttributes(index++, AdditionalAttributes);
        builder.AddAttribute(index++, "class", CssClass);
        builder.AddAttribute(index++, "onclick", EventCallback.Factory.Create(this, OnClick));

        builder.OpenElement(index++, component);
        builder.AddAttribute(index++, "class", "pf-c-label__content");
        builder.AddAttribute(index++, "href", Href);
        if (Icon is not null)
        {
            builder.OpenElement(index++, "span");
            builder.AddAttribute(index++, "class", "pf-c-label__icon");
            builder.AddContent(index++, Icon);
            builder.CloseElement();
        }
        if (IsTruncated)
        {
            builder.OpenElement(index++, "span");
            builder.AddAttribute(index++, "class", "pf-c-label__text");
            builder.AddContent(index++, ChildContent);
            builder.CloseElement();
        }
        else
        {
            builder.AddContent(index++, ChildContent);
        }
        builder.CloseElement();

        if (OnClose.HasDelegate)
        {
            if (CloseBtn is not null)
            {
                builder.AddContent(index++, CloseBtn);
            }
            else
            {
                builder.OpenComponent<Button>(index++);
                builder.AddAttribute(index++, "Type", ButtonType.Button);
                builder.AddAttribute(index++, "Variant", ButtonVariant.Plain);
                builder.AddAttribute(index++, "AriaLabel", closeBtnAriaLabel);
                builder.AddAttribute(index++, "OnClick", EventCallback.Factory.Create(this, OnClose));
                builder.AddAttribute(index++, "ChildContent", (RenderFragment)delegate(RenderTreeBuilder rfbuilder)
                {
                    rfbuilder.OpenComponent<TimesIcon>(index++);
                    rfbuilder.CloseComponent();
                });
                builder.CloseComponent();
            }
        }

        builder.CloseElement();
    }
}
