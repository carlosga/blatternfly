namespace Blatternfly.Components;

public partial class DescriptionListTermHelpText : ComponentBase
{
    /// <summary>Additional attributes that will be applied to the component.</summary>
    [Parameter(CaptureUnmatchedValues = true)] public IReadOnlyDictionary<string, object> AdditionalAttributes { get; set; }

    /// <summary>Content rendered inside the component.</summary>
    [Parameter] public RenderFragment ChildContent { get; set; }

    private string CssClass => new CssBuilder("pf-c-description-list__term")
        .AddClassFromAttributes(AdditionalAttributes)
        .Build();
}