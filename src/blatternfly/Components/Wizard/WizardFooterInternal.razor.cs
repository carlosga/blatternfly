namespace Blatternfly.Components;

public partial class WizardFooterInternal : ComponentBase
{
    [CascadingParameter] public Wizard Parent { get; set; }

    [Parameter] public EventCallback OnNext { get; set; }
    [Parameter] public EventCallback OnBack { get; set; }
    [Parameter] public EventCallback OnClose { get; set; }
    [Parameter] public bool FirstStep { get; set; }
    [Parameter] public WizardStep ActiveStep { get; set; }
    [Parameter] public RenderFragment NextButtonText { get; set; }
    [Parameter] public RenderFragment BackButtonText { get; set; }
    [Parameter] public RenderFragment CancelButtonText { get; set; }

    private bool IsDisabled { get => !Parent.IsValid; }
}