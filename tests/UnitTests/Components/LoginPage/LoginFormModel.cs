namespace Blatternfly.UnitTests.Components;

public sealed class LoginFormModel : ILoginFormModel
{
    public string UsernameValue { get; set; }
    public string PasswordValue { get; set; }
    public bool IsRememberMeCheckedValue { get; set; }
}
