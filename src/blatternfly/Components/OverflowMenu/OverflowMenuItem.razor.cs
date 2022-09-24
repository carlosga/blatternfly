namespace Blatternfly.Components;

public partial class OverflowMenuItem : ComponentBase
{
    [CascadingParameter(Name = "IsBelowBreakpoint")] public bool IsBelowBreakpoint { get; set; }

    /// <summary>Additional attributes that will be applied to the component.</summary>
    [Parameter(CaptureUnmatchedValues = true)] public IReadOnlyDictionary<string, object> AdditionalAttributes { get; set; }

    /// <summary>Content rendered inside the component.</summary>
    [Parameter] public RenderFragment ChildContent { get; set; }

    /// <summary>Modifies the overflow menu item visibility.</summary>
    [Parameter] public bool IsPersistent { get; set; }

    private string CssClass => new CssBuilder("pf-c-overflow-menu__item")
        .AddClassFromAttributes(AdditionalAttributes)
        .Build();
}