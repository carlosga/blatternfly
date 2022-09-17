namespace Blatternfly.Components;

public partial class WizardNav : ComponentBase
{
    /// <summary>Additional attributes that will be applied to the component.</summary>
    [Parameter(CaptureUnmatchedValues = true)] public IReadOnlyDictionary<string, object> AdditionalAttributes { get; set; }

    /// <summary>Content rendered inside the component.</summary>
    [Parameter] public RenderFragment ChildContent { get; set; }

    /// <summary>Aria-label applied to the nav element.</summary>
    [Parameter] public string AriaLabel { get; set; }

    /// <summary>Sets the aria-labelledby attribute on the nav element.</summary>
    [Parameter] public string AriaLabelledBy { get; set; }

    /// <summary>Whether the nav is expanded.</summary>
    [Parameter] public bool IsOpen { get; set; }

    /// <summary>True to return the inner list without the wrapping nav element.</summary>
    [Parameter] public bool ReturnList { get; set; }

    private string CssClass => new CssBuilder("pf-c-wizard__nav")
        .AddClass("pf-m-expanded", IsOpen)
        .AddClassFromAttributes(AdditionalAttributes)
        .Build();
}