namespace Blatternfly.UnitTests.Components;

public class LoginMainFooterBandItemTests
{
    [Fact]
    public void DefaultTest()
    {
        // Arrange
        using var ctx = new TestContext();

        // Act
        var cut = ctx.RenderComponent<LoginMainFooterBandItem>();

        // Assert
        cut.MarkupMatches(
@"
<p
  class=""pf-c-login__main-footer-band-item""
/>
");
    }      
    
    [Fact]
    public void WithAdditionalCssClassTest()
    {
        // Arrange
        using var ctx = new TestContext();

        // Act
        var cut = ctx.RenderComponent<LoginMainFooterBandItem>(parameters => parameters
            .AddUnmatched("class", "extra-class")

        );

        // Assert
        cut.MarkupMatches(
@"
<p
  class=""pf-c-login__main-footer-band-item extra-class""
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
        var cut = ctx.RenderComponent<LoginMainFooterBandItem>(parameters => parameters
            .AddUnmatched("data-testid", testId)

        );

        // Assert
        cut.MarkupMatches(
$@"
<p
  class=""pf-c-login__main-footer-band-item"" 
  data-testid=""{testId}""
/>
");
    }        
    
    [Fact]
    public void WithChildContentTest()
    {
        // Arrange
        using var ctx = new TestContext();

        // Act
        var cut = ctx.RenderComponent<LoginMainFooterBandItem>(parameters => parameters
            .AddChildContent("<div>My custom node</div>")

        );

        // Assert
        cut.MarkupMatches(
@"
<p
  class=""pf-c-login__main-footer-band-item"" 
>
  <div>My custom node</div>
</p>
");
    }            
}
