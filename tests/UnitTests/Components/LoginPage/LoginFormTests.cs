using Blatternfly.Components;
using Bunit;
using Xunit;

namespace Blatternfly.UnitTests.Components
{
    public sealed class LoginFormModel : ILoginFormModel
    {
        public string UsernameValue { get; set; }
        public string PasswordValue { get; set; }
        public bool IsRememberMeCheckedValue { get; set; }
    }
 
    public class LoginFormTests
    {
        [Fact]
        public void DefaultTest()
        {
            // Arrange
            using var ctx = new TestContext();

            var model = new LoginFormModel
            {
            UsernameValue = string.Empty,
            PasswordValue = string.Empty
            };

            // Act
            var cut = ctx.RenderComponent<LoginForm>(parameters => parameters
                .Add(p => p.Model, model)
            );

            // Assert
            cut.MarkupMatches(
@"
<form novalidate="""" class=""pf-c-form"">
  <p class=""pf-c-form__helper-text pf-m-hidden""></p>
  <div class=""pf-c-form__group"">
    <div class=""pf-c-form__group-label"">
      <label class=""pf-c-form__label"" for=""pf-login-username-id"">
        <span class=""pf-c-form__label-text"">Username</span>
        <span class=""pf-c-form__label-required"" aria-hidden=""true"">*</span>
      </label>
    </div>
    <div class=""pf-c-form__group-control"">
      <input
        autofocus=""""
        id=""pf-login-username-id""
        name=""pf-login-username-id""
        class=""pf-c-form-control""
        type=""text""
        aria-invalid=""false""
        required=""""
        value="""">
    </div>
  </div>
  <div class=""pf-c-form__group"">
    <div class=""pf-c-form__group-label"">
      <label class=""pf-c-form__label"" for=""pf-login-password-id"">
        <span class=""pf-c-form__label-text"">Password</span>
        <span class=""pf-c-form__label-required"" aria-hidden=""true"">*</span>
      </label>
    </div>
    <div class=""pf-c-form__group-control"">
      <input
        id=""pf-login-password-id""
        name=""pf-login-password-id""
        class=""pf-c-form-control""
        type=""password""
        aria-invalid=""false""
        required=""""
        value="""">
    </div>
  </div>
  <div class=""pf-c-form__group pf-m-action"">
    <div class=""pf-c-form__group-control"">
      <div class=""pf-c-form__actions"">
        <button 
          aria-disabled=""false"" 
          class=""pf-c-button pf-m-primary pf-m-block""
          type=""submit"" 
        >
          Log In
        </button>
      </div>
    </div>
  </div>
</form>
");
   }
   
        [Fact]
        public void WithRememberMeLabelTest()
        {
            // Arrange
            using var ctx = new TestContext();

            var model = new LoginFormModel
            {
                UsernameValue = string.Empty,
                PasswordValue = string.Empty
            };

            // Act
            var cut = ctx.RenderComponent<LoginForm>(parameters => parameters
                .Add(p => p.Model, model)
                .Add(p => p.RememberMeLabel, "remember me")
            );

            // Assert
            cut.MarkupMatches(
@"
<form novalidate="""" class=""pf-c-form"">
  <p class=""pf-c-form__helper-text pf-m-hidden""></p>
  <div class=""pf-c-form__group"">
    <div class=""pf-c-form__group-label"">
      <label class=""pf-c-form__label"" for=""pf-login-username-id"">
        <span class=""pf-c-form__label-text"">Username</span>
        <span class=""pf-c-form__label-required"" aria-hidden=""true"">*</span>
      </label>
    </div>
    <div class=""pf-c-form__group-control"">
      <input
        autofocus=""""
        id=""pf-login-username-id""
        name=""pf-login-username-id""
        class=""pf-c-form-control""
        type=""text""
        aria-invalid=""false""
        required=""""
        value=""""
      >
    </div>
  </div>
  <div class=""pf-c-form__group"">
    <div class=""pf-c-form__group-label"">
      <label class=""pf-c-form__label"" for=""pf-login-password-id"">
        <span class=""pf-c-form__label-text"">Password</span>
        <span class=""pf-c-form__label-required"" aria-hidden=""true"">*</span>
      </label>
    </div>
    <div class=""pf-c-form__group-control"">
      <input 
        id=""pf-login-password-id"" 
        name=""pf-login-password-id""
        class=""pf-c-form-control"" 
        type=""password"" 
        aria-invalid=""false"" 
        required=""""
        value=""""
      >
    </div>
  </div>
  <div class=""pf-c-form__group"">
    <div class=""pf-c-form__group-control"">
      <div class=""pf-c-check"">
        <input 
          id=""pf-login-remember-me-id"" 
          class=""pf-c-check__input""
          type=""checkbox""
          aria-invalid=""false"" 
        >
        <label class=""pf-c-check__label"" for=""pf-login-remember-me-id"">remember me</label>
      </div>
    </div>
  </div>
  <div class=""pf-c-form__group pf-m-action"">
    <div class=""pf-c-form__group-control"">
      <div class=""pf-c-form__actions"">
        <button 
          aria-disabled=""false"" 
          class=""pf-c-button pf-m-primary pf-m-block""
          type=""submit""
        >
          Log In
        </button>
      </div>
    </div>
  </div>
</form>
");
   }
  
        [Fact]
        public void WithShowPasswordEnabledTest()
        {
            // Arrange
            using var ctx = new TestContext();

            var model = new LoginFormModel
            {
                UsernameValue = string.Empty,
                PasswordValue = string.Empty
            };

            // Act
            var cut = ctx.RenderComponent<LoginForm>(parameters => parameters
                .Add(p => p.Model, model)
                .Add(p => p.IsShowPasswordEnabled, true)
            );

            // Assert
            cut.MarkupMatches(
@$"

<form novalidate class=""pf-c-form"">
  <p class=""pf-c-form__helper-text pf-m-hidden""></p>
  <div class=""pf-c-form__group"">
    <div class=""pf-c-form__group-label"">
      <label class=""pf-c-form__label"" for=""pf-login-username-id"">
        <span class=""pf-c-form__label-text"">Username</span>
        <span class=""pf-c-form__label-required"" aria-hidden=""true"">*</span>
      </label>
    </div>
    <div class=""pf-c-form__group-control"">
      <input
        autofocus=""""
        id=""pf-login-username-id""
        name=""pf-login-username-id""
        class=""pf-c-form-control""
        type=""text""
        aria-invalid=""false""
        required=""""
        value=""""
      >
    </div>
  </div>
  <div class=""pf-c-form__group"">
    <div class=""pf-c-form__group-label"">
      <label class=""pf-c-form__label"" for=""pf-login-password-id"">
        <span class=""pf-c-form__label-text"">Password</span>
        <span class=""pf-c-form__label-required"" aria-hidden=""true"">*</span>
      </label>
    </div>
    <div class=""pf-c-form__group-control"">
      <div class=""pf-c-input-group"">
        <input
          id=""pf-login-password-id""
          name=""pf-login-password-id""
          class=""pf-c-form-control""
          type=""password""
          aria-invalid=""false""
          required=""""
          value=""""
        >
        <button
          aria-disabled=""false""
          aria-label=""Show password""
          class=""pf-c-button pf-m-control""
          type=""button""
        >
          <svg
            style=""vertical-align: -0.125em;""
            fill=""currentColor""
            height=""1em""
            width=""1em""
            viewBox=""{EyeIcon.IconDefinition.ViewBox}""
            aria-hidden=""true""
            role=""img""
          >
            <path d=""{EyeIcon.IconDefinition.SvgPath}""></path>
          </svg>
        </button>
      </div>
    </div>
  </div>
  <div class=""pf-c-form__group pf-m-action"">
    <div class=""pf-c-form__group-control"">
      <div class=""pf-c-form__actions"">
        <button
          aria-disabled=""false""
          class=""pf-c-button pf-m-primary pf-m-block""
          type=""submit""
        >
          Log In
        </button>
      </div>
    </div>
  </div>
</form>
");    
        }
    }
}
