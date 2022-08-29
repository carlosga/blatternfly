namespace Blatternfly.Components;

public partial class AboutModalBoxBrand
{
    /// <summary>
    /// Additional attributes that will be applied to the component.
    /// </summary>
    [Parameter(CaptureUnmatchedValues = true)]
    public IReadOnlyDictionary<string, object> AdditionalAttributes { get; set; }

    /// <summary>
    /// Attribute that specifies the URL of the image for the Brand.
    /// </summary>
    [Parameter]
    public string Src { get; set; } = string.Empty;

    /// <summary>
    /// Attribute that specifies the alternate text of the image for the Brand.
    /// </summary>
    [Parameter]
    public string Alt { get; set; }
}
