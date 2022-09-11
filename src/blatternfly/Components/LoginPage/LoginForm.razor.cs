namespace Blatternfly.Components;

public partial class LoginForm : ComponentBase
{
    /// <summary>Additional attributes that will be applied to the component.</summary>
    [Parameter(CaptureUnmatchedValues = true)] public IReadOnlyDictionary<string, object> AdditionalAttributes { get; set; }

    /// <summary>Login form model.</summary>
    [Parameter] public ILoginFormModel Model { get; set; }

    /// <summary>Flag indicating the helper text is visible.</summary>
    [Parameter] public bool ShowHelperText { get; set; }

    /// <summary>Content displayed in the helper text component.</summary>
    [Parameter] public RenderFragment HelperText { get; set; }

    /// <summary>Icon displayed to the left in the helper text.</summary>
    [Parameter] public RenderFragment HelperTextIcon { get; set; }

    /// <summary>Label for the username input field.</summary>
    [Parameter] public string UsernameLabel { get; set; } = "Username";

    /// <summary>Function that handles the onChange event for the username.</summary>
    [Parameter] public EventCallback<string> OnChangeUsername { get; set; }

    /// <summary>Username validation state.</summary>
    [Parameter] public ValidatedOptions? UsernameValidation { get; set; }

    /// <summary>Label for the password input field.</summary>
    [Parameter] public string PasswordLabel { get; set; } = "Password";

    /// <summary>Function that handles the onChange event for the password.</summary>
    [Parameter] public EventCallback<string> OnChangePassword { get; set; }

    /// <summary>Password validation state.</summary>
    [Parameter] public ValidatedOptions? PasswordValidation { get; set; }

    /// <summary>Flag indicating if the user can toggle hiding the password.</summary>
    [Parameter] public bool IsShowPasswordEnabled { get; set; }

    /// <summary>Accessible label for the show password button.</summary>
    [Parameter] public string ShowPasswordAriaLabel { get; set; } = "Show password";

    /// <summary>Accessible label for the hide password button.</summary>
    [Parameter] public string HidePasswordAriaLabel { get; set; }  = "Hide password";

    /// <summary>Label for the log in button input.</summary>
    [Parameter] public string LoginButtonLabel { get; set; } = "Log In";

    /// <summary>Flag indicating if the login button is disabled.</summary>
    [Parameter] public bool IsLoginButtonDisabled { get; set; }

    /// <summary>Function that is called when the login button is clicked.</summary>
    [Parameter] public EventCallback<MouseEventArgs> OnLoginButtonClick { get; set; }

    /// <summary>
    /// Label for the remember me checkbox that indicates the user should be kept logged in.
    /// If the label is not provided, the checkbox will not show.
    /// </summary>
    [Parameter] public string RememberMeLabel { get; set; }

    /// <summary>Function that handles the onChange event for the remember me checkbox.</summary>
    [Parameter] public EventCallback<bool> OnChangeRememberMe { get; set; }

    /// <summary>Flag to indicate if the first item should not gain initial focus.</summary>
    [Parameter] public bool NoAutoFocus { get; set; } = false;

    private TextInput UsernameInput { get; set; }
    private bool PasswordHidden     { get; set; }  = true;
    private bool IsHelperTextError  { get => !IsValidUsername || !IsValidPassword; }
    private bool IsHelperTextHidden { get => !ShowHelperText; }
    private bool AutoFocus          { get => !NoAutoFocus; }

    private string ShowPasswordButtonAriaLabel
    {
        get => PasswordHidden ? ShowPasswordAriaLabel : HidePasswordAriaLabel;
    }

    private bool IsValidUsername
    {
        get => UsernameValidation is null or ValidatedOptions.Success;
    }

    private bool IsValidPassword
    {
        get => PasswordValidation is null or ValidatedOptions.Success;
    }

    private TextInputTypes PasswordInputType
    {
        get => PasswordHidden ? TextInputTypes.Password: TextInputTypes.Text;
    }

    private void SetPasswordHidden(MouseEventArgs _)
    {
        PasswordHidden = !PasswordHidden;
    }

    protected override async Task OnAfterRenderAsync(bool firstRender)
    {
        await base.OnAfterRenderAsync(firstRender);

        if (firstRender)
        {
            if (AutoFocus)
            {
                await UsernameInput.Element.FocusAsync();
            }
        }
    }
}