namespace Blatternfly.Components;

public partial class AccordionItem : ComponentBase
{
    /// <summary>Content rendered inside the component.</summary>
    [Parameter] public RenderFragment ChildContent { get; set; }

    internal AccordionToggle Toggle { get; private set; }

    internal void RegisterToggle(AccordionToggle toggle)
    {
        Toggle = toggle;
    }
}
