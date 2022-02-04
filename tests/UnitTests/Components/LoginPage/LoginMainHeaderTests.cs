namespace Blatternfly.UnitTests.Components;

public class LoginMainHeaderTests
{
    [Fact]
    public void DefaultTest()
    {
        // Arrange
        using var ctx = Helper.CreateTestContext();

        // Act
        var cut = ctx.RenderComponent<LoginMainHeader>();

        // Assert
        cut.MarkupMatches(
@"
<header
  class=""pf-c-login__main-header""
/>
");
    }

    [Fact]
    public void WithAdditionalCssClassTest()
    {
        // Arrange
        using var ctx = Helper.CreateTestContext();

        // Act
        var cut = ctx.RenderComponent<LoginMainHeader>(parameters => parameters
            .AddUnmatched("class", "extra-class")
        );

        // Assert
        cut.MarkupMatches(
@"
<header
  class=""pf-c-login__main-header extra-class""
/>
");
    }

    [Fact]
    public void WithAdditionalPropertiesOnRootElementTest()
    {
        // Arrange
        using var ctx = Helper.CreateTestContext();
        var testId = "login-header";

        // Act
        var cut = ctx.RenderComponent<LoginMainHeader>(parameters => parameters
            .AddUnmatched("data-testid", testId)
        );

        // Assert
        cut.MarkupMatches(
$@"
<header
  class=""pf-c-login__main-header""
  data-testid=""{testId}""
/>
");
    }

    [Fact]
    public void WithTitleAndSubtitleTest()
    {
        // Arrange
        using var ctx = Helper.CreateTestContext();

        // Act
        var cut = ctx.RenderComponent<LoginMainHeader>(parameters => parameters
            .Add(p => p.Title, "Log in to your account")
            .Add(p => p.Subtitle, "Use LDAP credentials")
        );

        // Assert
        cut.MarkupMatches(
@"
<header class=""pf-c-login__main-header"">
  <h2 class=""pf-c-title pf-m-3xl"">Log in to your account</h2>
  <p class=""pf-c-login__main-header-desc"">Use LDAP credentials</p>
</header>
");
    }
}
