namespace Blatternfly.Components;

public partial class LoginMainFooterLinksItem : ComponentBase
{
    /// <summary>
    /// Additional attributes that will be applied to the component.
    /// </summary>
    [Parameter(CaptureUnmatchedValues = true)]
    public IReadOnlyDictionary<string, object> AdditionalAttributes { get; set; }

    /// <summary>
    /// Content rendered inside the component.
    /// </summary>
    [Parameter]
    public RenderFragment ChildContent { get; set; }

    /// <summary>
    /// HREF for footer link item.
    /// </summary>
    [Parameter]
    public string Href { get; set; }

    /// <summary>
    /// Target for footer link item.
    /// </summary>
    [Parameter]
    public string Target { get; set; }

    private string CssClass => new CssBuilder("pf-c-login__main-footer-links-item")
        .AddClassFromAttributes(AdditionalAttributes)
        .Build();
}