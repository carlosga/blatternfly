namespace Blatternfly.Components;

public class AccordionContent : BaseComponent
{
    /// Parent Accordion
    [CascadingParameter] public Accordion ParentAccordion { get; set; }
    [CascadingParameter] public AccordionItem ParentItem { get; set; }

    /// Flag to indicate Accordion content is fixed.
    [Parameter] public bool IsFixed { get; set; }

    /// Adds accessible text to the Accordion content.
    [Parameter] public string AriaLabel { get; set; }

    /// Component to use as content container.
    [Parameter] public string Component { get; set; }

    /// Flag indicating content is custom. Expanded content Body wrapper will be removed from children.
    /// This allows multiple bodies to be rendered as content.
    [Parameter] public bool IsCustomContent { get; set; }

    /// Flag to show if the expanded content of the Accordion item is visible.
    private bool IsHidden { get => !ParentItem.Toggle.IsExpanded; }

    private string CssClass => new CssBuilder("pf-c-accordion__expanded-content")
        .AddClass("pf-m-fixed"   , IsFixed)
        .AddClass("pf-m-expanded", !IsHidden)
        .AddClassFromAttributes(AdditionalAttributes)
        .Build();

    protected override void BuildRenderTree(RenderTreeBuilder builder)
    {
        builder.OpenElement(0, Component ?? ParentAccordion.ContentContainer);
        builder.AddMultipleAttributes(1, AdditionalAttributes);
        builder.AddAttribute(2, "class", CssClass);
        builder.AddAttribute(3, "hidden", IsHidden);
        builder.AddAttribute(4, "aria-label", AriaLabel);

        if (IsCustomContent)
        {
            builder.AddContent(5, ChildContent);
        }
        else
        {
            builder.OpenComponent<AccordionExpandedContentBody>(6);
            builder.AddAttribute(7, "ChildContent", ChildContent);
            builder.CloseElement();
        }

        builder.CloseElement();
    }
}
