namespace Blatternfly.Components;

public partial class ToggleGroup : ComponentBase
{
    /// <summary>Additional attributes that will be applied to the component.</summary>
    [Parameter(CaptureUnmatchedValues = true)] public IReadOnlyDictionary<string, object> AdditionalAttributes { get; set; }

    /// <summary>Content rendered inside the component.</summary>
    [Parameter] public RenderFragment ChildContent { get; set; }

    /// <summary>Modifies the toggle group to include compact styling.</summary>
    [Parameter] public bool IsCompact { get; set; }

    /// <summary>Disable all toggle group items under this component.</summary>
    [Parameter] public bool AreAllGroupsDisabled { get; set; }

    /// <summary>Accessible label for the toggle group.</summary>
    [Parameter] public string AriaLabel { get; set; }

    private string CssClass => new CssBuilder("pf-c-toggle-group")
      .AddClass("pf-m-compact", IsCompact)
      .AddClassFromAttributes(AdditionalAttributes)
      .Build();
}