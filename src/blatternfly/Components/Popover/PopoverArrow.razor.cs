namespace Blatternfly.Components;

public partial class PopoverArrow : ComponentBase
{
    /// <summary>Additional attributes that will be applied to the component.</summary>
    [Parameter(CaptureUnmatchedValues = true)] public IReadOnlyDictionary<string, object> AdditionalAttributes { get; set; }

    private string CssClass => new CssBuilder("pf-c-popover__arrow")
        .AddClassFromAttributes(AdditionalAttributes)
        .Build();
}