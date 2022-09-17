namespace Blatternfly.Components;

public partial class WizardDrawerWrapper : ComponentBase
{
    /// <summary>Additional attributes that will be applied to the component.</summary>
    [Parameter(CaptureUnmatchedValues = true)] public IReadOnlyDictionary<string, object> AdditionalAttributes { get; set; }

    /// <summary>Content rendered inside the component.</summary>
    [Parameter] public RenderFragment ChildContent { get; set; }

    /// <summary>Flag indicating the wizard has a drawer for at least one of the wizard steps.</summary>
    [Parameter] public bool HasDrawer { get; set; }

    /// <summary>The drawer component which wraps the wizard content.</summary>
    [Parameter] public RenderFragment Wrapper { get; set; }
}