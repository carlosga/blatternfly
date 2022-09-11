namespace Blatternfly.Components;

public partial class AboutModalBoxHeader : ComponentBase
{
    /// <summary>Additional attributes that will be applied to the component.</summary>
    [Parameter(CaptureUnmatchedValues = true)] public IReadOnlyDictionary<string, object> AdditionalAttributes { get; set; }

    /// <summary>Name of the Product.</summary>
    [Parameter] public string ProductName { get; set; }
}
