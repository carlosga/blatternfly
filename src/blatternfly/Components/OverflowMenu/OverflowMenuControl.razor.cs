namespace Blatternfly.Components;

public partial class OverflowMenuControl : ComponentBase
{
    [CascadingParameter(Name = "IsBelowBreakpoint")] internal bool IsBelowBreakpoint { get; set; }

    /// <summary>Additional attributes that will be applied to the component.</summary>
    [Parameter(CaptureUnmatchedValues = true)] public IReadOnlyDictionary<string, object> AdditionalAttributes { get; set; }

    /// <summary>Content rendered inside the component.</summary>
    [Parameter] public RenderFragment ChildContent { get; set; }

    /// <summary>Triggers the overflow dropdown to persist at all viewport sizes.</summary>
    [Parameter] public bool HasAdditionalOptions { get; set; }

    private string CssClass => new CssBuilder("pf-c-overflow-menu__control")
        .AddClassFromAttributes(AdditionalAttributes)
        .Build();
}