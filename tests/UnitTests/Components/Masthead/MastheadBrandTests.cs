namespace Blatternfly.UnitTests.Components;

public class MastheadBrandTests
{
    [Fact]
    public void DefaultTest()
    {
        // Arrange
        using var ctx = new TestContext();

        // Act
        var cut = ctx.RenderComponent<MastheadBrand>(parameters => parameters
            .AddChildContent("test")
        );

        // Assert
        cut.MarkupMatches(
@"
<a
  class=""pf-c-masthead__brand""
  tabindex=""0""
>
  test
</a>
");
    }       
    
    [Fact]
    public void WithAdditionalCssClassTest()
    {
        // Arrange
        using var ctx = new TestContext();

        // Act
        var cut = ctx.RenderComponent<MastheadBrand>(parameters => parameters
            .AddUnmatched("class", "custom-css")
            .AddChildContent("test")
        );

        // Assert
        cut.MarkupMatches(
@"
<a
  class=""pf-c-masthead__brand custom-css""
  tabindex=""0""
>
  test
</a>
");
    }         
    
    [Fact]
    public void WithDivComponentTest()
    {
        // Arrange
        using var ctx = new TestContext();

        // Act
        var cut = ctx.RenderComponent<MastheadBrand>(parameters => parameters
            .Add(p => p.Component, MastheadBrandComponent.div)
            .AddChildContent("test")
        );

        // Assert
        cut.MarkupMatches(
@"
<div
  class=""pf-c-masthead__brand""
  tabindex=""0""
>
  test
</div>
");
    }          
}
