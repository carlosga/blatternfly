using Blatternfly.Components;

namespace Blatternfly.Demo.Pages.Components
{
    public sealed class LoginFormModel : ILoginFormModel
    {
        /// Value for the Username
        public string UsernameValue { get; set; }

        /// Value for the Password
        public string PasswordValue { get; set; }

        /// Flag indicating if the remember me Checkbox is checked..
        public bool IsRememberMeCheckedValue { get; set; }
    }
}
