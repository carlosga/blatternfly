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

    protected override void BuildRenderTree(RenderTreeBuilder builder)
    {
        var fixedClass    = IsFixed ? "pf-m-fixed" : null;
        var expandedClass = !IsHidden ? "pf-m-expanded" : null;

        builder.OpenElement(1, Component ?? ParentAccordion.ContentContainer);
        builder.AddMultipleAttributes(2, AdditionalAttributes);
        builder.AddAttribute(3, "class", $"pf-c-accordion__expanded-content {fixedClass} {expandedClass}");
        builder.AddAttribute(4, "hidden", IsHidden);
        builder.AddAttribute(5, "aria-label", AriaLabel);

        if (IsCustomContent)
        {
            builder.AddContent(6, ChildContent);
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
