namespace Blatternfly.Components;

public partial class DropdownGroup : ComponentBase
{
    /// <summary>Additional attributes that will be applied to the component.</summary>
    [Parameter(CaptureUnmatchedValues = true)] public IReadOnlyDictionary<string, object> AdditionalAttributes { get; set; }

    /// <summary>Content rendered inside the component.</summary>
    [Parameter] public RenderFragment ChildContent { get; set; }

    /// <summary>Group label.</summary>
    [Parameter] public string Label { get; set; }

    private string CssClass => new CssBuilder("pf-c-dropdown__group")
        .AddClassFromAttributes(AdditionalAttributes)
        .Build();
}