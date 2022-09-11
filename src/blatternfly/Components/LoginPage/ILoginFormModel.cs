namespace Blatternfly.Components;

/// <summary>Login form model interface.</summary>
public interface ILoginFormModel
{
    /// <summary>Value for the username.</summary>
    string UsernameValue { get; set; }

    /// <summary>Value for the password.</summary>
    string PasswordValue { get; set; }

    /// <summary>Flag indicating if the remember me Checkbox is checked.</summary>
    bool IsRememberMeCheckedValue { get; set; }
}
