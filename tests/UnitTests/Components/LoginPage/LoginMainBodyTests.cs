namespace Blatternfly.UnitTests.Components;

public class LoginMainBodyTests
{
    [Fact]
    public void DefaultTest()
    {
        // Arrange
        using var ctx = new TestContext();

        // Act
        var cut = ctx.RenderComponent<LoginMainBody>();

        // Assert
        cut.MarkupMatches(
@"
<div
  class=""pf-c-login__main-body""
/>
");
    }      
    
    [Fact]
    public void WithAdditionalCssClassTest()
    {
        // Arrange
        using var ctx = new TestContext();

        // Act
        var cut = ctx.RenderComponent<LoginMainBody>(parameters => parameters
            .AddUnmatched("class", "extra-class")

        );

        // Assert
        cut.MarkupMatches(
@"
<div
  class=""pf-c-login__main-body extra-class""
/>
");
    }           
    
    [Fact]
    public void WithAdditionalPropertiesOnRootElementTest()
    {
        // Arrange
        using var ctx = new TestContext();
        var testId = "login-body";

        // Act
        var cut = ctx.RenderComponent<LoginMainBody>(parameters => parameters
            .AddUnmatched("data-testid", testId)

        );

        // Assert
        cut.MarkupMatches(
$@"
<div
  class=""pf-c-login__main-body"" 
  data-testid=""{testId}""
/>
");
    }
}
