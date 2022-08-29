namespace Blatternfly.Components;

public partial class AboutModalBoxHero
{   
    /// <summary>
    /// Additional attributes that will be applied to the component.
    /// </summary>
    [Parameter(CaptureUnmatchedValues = true)]
    public IReadOnlyDictionary<string, object> AdditionalAttributes { get; set; }

    /// <summary>
    /// background image data or file path.
    /// </summary>
    [Parameter]
    public string BackgroundImageSource { get; set; }

    private string CssClass => new CssBuilder("pf-c-about-modal-box__hero")
        .AddClassFromAttributes(AdditionalAttributes)
        .Build();
    
    private string CssStyle => new StyleBuilder()
        .AddStyle(() => $"background-image: url(\"{BackgroundImageSource}\")", !string.IsNullOrEmpty(BackgroundImageSource))
        .Build();
}
