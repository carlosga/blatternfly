namespace Blatternfly.Components;

public partial class LoginMainHeader : ComponentBase
{
    /// <summary>
    /// Additional attributes that will be applied to the component.
    /// </summary>
    [Parameter(CaptureUnmatchedValues = true)] public IReadOnlyDictionary<string, object> AdditionalAttributes { get; set; }

    /// <summary>
    /// Content rendered inside the component.
    /// </summary>
    [Parameter] public RenderFragment ChildContent { get; set; }

    /// <summary>
    /// Title for the login main header.
    /// </summary>
    [Parameter] public string Title { get; set; }

    /// <summary>
    /// Subtitle that contains the text, URL, and URL text for the login main header.
    /// </summary>
    [Parameter] public string Subtitle { get; set; }

    /// <summary>
    /// Actions that render for the login main header.
    /// </summary>
    [Parameter] public RenderFragment HeaderUtilities { get; set; }

    private string CssClass => new CssBuilder("pf-c-login__main-header")
        .AddClassFromAttributes(AdditionalAttributes)
        .Build();

    private bool HasTitle    { get => !string.IsNullOrEmpty(Title); }
    private bool HasSubtitle { get => !string.IsNullOrEmpty(Subtitle); }
}