namespace Blatternfly.Components;

public interface ILoginFormModel
{
    /// Value for the Username
    string UsernameValue { get; set; }

    /// Value for the Password
    string PasswordValue { get; set; }

    /// Flag indicating if the remember me Checkbox is checked..
    bool IsRememberMeCheckedValue { get; set; }
}
