namespace Blatternfly.Components;

public partial class LoginPage : ComponentBase
{
    /// <summary>Additional attributes that will be applied to the component.</summary>
    [Parameter(CaptureUnmatchedValues = true)] public IReadOnlyDictionary<string, object> AdditionalAttributes { get; set; }

    /// <summary>Content rendered inside the component.</summary>
    [Parameter] public RenderFragment ChildContent { get; set; }

    /// <summary>Attribute that specifies the URL of the brand image for the login page.</summary>
    [Parameter] public string BrandImgSrc { get; set; }

    /// <summary>Attribute that specifies the alt text of the brand image for the login page.</summary>
    [Parameter] public string BrandImgAlt { get; set; }

    /// <summary>Attribute that specifies the URL of the background image for the login page.</summary>
    [Parameter] public BackgroundImageSrcMap BackgroundImgSrc { get; set; }

    /// <summary>Attribute that specifies the alt text of the background image for the login page.</summary>
    [Parameter] public string BackgroundImgAlt { get; set; }

    /// <summary>Content rendered inside of the text component of the login page.</summary>
    [Parameter] public string TextContent { get; set; }

    /// <summary>Items rendered inside of the footer list component of the login page.</summary>
    [Parameter] public RenderFragment FooterListItems { get; set; }

    /// <summary>Adds list variant styles for the footer list component of the login page. The only current value is'inline'.</summary>
    [Parameter] public ListVariant FooterListVariants { get; set; } = ListVariant.Inline;

    /// <summary>Title for the login main body header of the login page.</summary>
    [Parameter] public string LoginTitle { get; set; }

    /// <summary>Subtitle for the login main body header of the login page.</summary>
    [Parameter] public string LoginSubtitle { get; set; }

    /// <summary>Header utilities for the login main body header of the login page.</summary>
    [Parameter] public RenderFragment HeaderUtilities { get; set; }

    /// <summary>Content rendered inside of login main footer band to display a sign up for account message.</summary>
    [Parameter] public RenderFragment SignUpForAccountMessage { get; set; }

    /// <summary>Content rendered inside of login main footer band to display a forgot credentials link.</summary>
    [Parameter] public RenderFragment ForgotCredentials { get; set; }

    /// <summary>Content rendered inside of social media login footer section.</summary>
    [Parameter] public RenderFragment SocialMediaLoginContent { get; set; }

    /// <summary>Attribute that specifies the filter id of the background image for the login page.</summary>
    [Parameter] public string BackgroundImgFilterId { get; set;  }

    private bool ShowMainFooter
    {
        get => SocialMediaLoginContent is not null
            || ForgotCredentials       is not null
            || SignUpForAccountMessage is not null;
    }
    private bool ShowBackgroundImg { get => BackgroundImgSrc is not null && BackgroundImgSrc.IsNotEmpty; }
}