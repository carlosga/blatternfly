namespace Blatternfly.Components;

public partial class WizardFooterInternal : ComponentBase
{
    [CascadingParameter] private Wizard Parent { get; set; }

    /// <summary></summary>
    [Parameter] public EventCallback OnNext { get; set; }

    /// <summary></summary>
    [Parameter] public EventCallback OnBack { get; set; }

    /// <summary></summary>
    [Parameter] public EventCallback OnClose { get; set; }

    /// <summary></summary>
    [Parameter] public bool FirstStep { get; set; }

    /// <summary></summary>
    [Parameter] public WizardStep ActiveStep { get; set; }

    /// <summary></summary>
    [Parameter] public RenderFragment NextButtonText { get; set; }

    /// <summary></summary>
    [Parameter] public RenderFragment BackButtonText { get; set; }

    /// <summary></summary>
    [Parameter] public RenderFragment CancelButtonText { get; set; }

    private bool IsDisabled { get => !Parent.IsValid; }
}