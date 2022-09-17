namespace Blatternfly.Components;

public partial class WizardFooter : ComponentBase
{
    /// <summary>Content rendered inside the component.</summary>
    [Parameter] public RenderFragment ChildContent { get; set; }
}