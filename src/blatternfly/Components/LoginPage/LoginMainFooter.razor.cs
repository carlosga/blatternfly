namespace Blatternfly.Components;

public partial class LoginMainFooter : ComponentBase
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
    /// Content rendered inside the login main footer as social media links.
    /// </summary>
    [Parameter]
    public RenderFragment SocialMediaLoginContent { get; set; }

    /// <summary>
    /// Content rendered inside of login main footer band to display a sign up for account message.
    /// </summary>
    [Parameter]
    public RenderFragment SignUpForAccountMessage { get; set; }

    /// <summary>
    /// Content rendered inside of login main footer band do display a forgot credentials link.
    /// </summary>
    [Parameter]
    public RenderFragment ForgotCredentials { get; set; }

    private string CssClass => new CssBuilder("pf-c-login__main-footer")
        .AddClassFromAttributes(AdditionalAttributes)
        .Build();
}