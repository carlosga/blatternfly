using System;
using System.Threading.Tasks;

namespace Blatternfly.Components;

public class AccordionToggle : BaseComponent
{
    /// Parent Accordion
    [CascadingParameter] public Accordion ParentAccordion { get; set; }

    ///  Parent Accordion Item
    [CascadingParameter] public AccordionItem ParentItem { get; set; }

    /// Container to override the default for toggle.
    [Parameter] public string Component { get; set; }

    /// Callback called when toggle is clicked.
    [Parameter] public EventCallback<MouseEventArgs> OnToggle { get; set; }

    /// Flag to show if the expanded content of the Accordion item is visible.
    internal bool IsExpanded { get => ParentAccordion?.IsExpanded(InternalId) ?? false; }

    private string CssClass => new CssBuilder("pf-c-accordion__toggle")
        .AddClass("pf-m-expanded", IsExpanded)
        .AddClassFromAttributes(AdditionalAttributes)
        .Build();

    protected override void OnInitialized()
    {
        base.OnInitialized();

        if (string.IsNullOrEmpty(InternalId))
        {
            throw new InvalidOperationException("Accordion: Accordion Toggle requires an id to be specified");
        }

        ParentItem.RegisterToggle(this);
    }

    protected override void BuildRenderTree(RenderTreeBuilder builder)
    {
        builder.OpenElement(1, Component ?? ParentAccordion.ToggleContainer);

        builder.OpenElement(2, "button");
        builder.AddMultipleAttributes(3, AdditionalAttributes);
        builder.AddAttribute(4, "class", CssClass);
        builder.AddAttribute(5, "aria-expanded", IsExpanded ? "true" : "false");
        builder.AddAttribute(6, "onclick", EventCallback.Factory.Create<MouseEventArgs>(this, ToggleHandler));
        builder.AddAttribute(7, "type", "button");
        builder.AddEventStopPropagationAttribute(8, "onclick", true);

        builder.OpenElement(9, "span");
        builder.AddAttribute(10, "class", "pf-c-accordion__toggle-text");
        builder.AddContent(11, ChildContent);
        builder.CloseElement();

        builder.OpenElement(12, "span");
        builder.AddAttribute(13, "class", "pf-c-accordion__toggle-icon");

        builder.OpenComponent<AngleRightIcon>(14);
        builder.CloseComponent();

        builder.CloseElement();

        builder.CloseElement();

        builder.CloseElement();
    }

    private async Task ToggleHandler(MouseEventArgs args)
    {
        await OnToggle.InvokeAsync(args);
        ParentAccordion.Toggle(InternalId);
    }
}
