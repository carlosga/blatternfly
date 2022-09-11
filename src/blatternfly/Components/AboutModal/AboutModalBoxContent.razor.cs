namespace Blatternfly.Components;

public partial class AboutModalBoxContent : ComponentBase
{
    /// <summary>Additional attributes that will be applied to the component.</summary>
    [Parameter(CaptureUnmatchedValues = true)] public IReadOnlyDictionary<string, object> AdditionalAttributes { get; set; }

    /// <summary>Content rendered inside the component.</summary>
    [Parameter] public RenderFragment ChildContent { get; set; }

    /// <summary>The Trademark info for the product.</summary>
    [Parameter] public string Trademark { get; set; }

    /// <summary>Prevents the about modal from rendering content inside a container; allows for more flexible layouts.</summary>
    [Parameter] public bool NoAboutModalBoxContentContainer { get; set; }
}
