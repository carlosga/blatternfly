namespace Blatternfly.Components;

public partial class AccordionExpandedContentBody
{
    /// <summary>
    /// Content rendered inside the component.
    /// </summary>
    [Parameter]
    public RenderFragment ChildContent { get; set; }
}
