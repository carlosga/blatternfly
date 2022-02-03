namespace Blatternfly.UnitTests.Components;

public class LoginMainFooterTests
{
    [Fact]
    public void DefaultTest()
    {
        // Arrange
        using var ctx = Helper.CreateTestContext();

        // Act
        var cut = ctx.RenderComponent<LoginMainFooter>();

        // Assert
        cut.MarkupMatches(
@"
<div
  class=""pf-c-login__main-footer""
/>
");
    }

    [Fact]
    public void WithAdditionalCssClassTest()
    {
        // Arrange
        using var ctx = Helper.CreateTestContext();

        // Act
        var cut = ctx.RenderComponent<LoginMainFooter>(parameters => parameters
            .AddUnmatched("class", "extra-class")

        );

        // Assert
        cut.MarkupMatches(
@"
<div
  class=""pf-c-login__main-footer extra-class""
/>
");
    }

    [Fact]
    public void WithAdditionalPropertiesOnRootElementTest()
    {
        // Arrange
        using var ctx = Helper.CreateTestContext();
        var testId = "login-body";

        // Act
        var cut = ctx.RenderComponent<LoginMainFooter>(parameters => parameters
            .AddUnmatched("data-testid", testId)

        );

        // Assert
        cut.MarkupMatches(
$@"
<div
  class=""pf-c-login__main-footer""
  data-testid=""{testId}""
/>
");
    }
}
