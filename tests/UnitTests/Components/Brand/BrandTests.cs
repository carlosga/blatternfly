namespace Blatternfly.UnitTests.Components;

public class BrandTests
{
    [Fact]
    public void SimpleBrandTest()
    {
        // Arrange
        using var ctx = new TestContext();

        // Act
        var cut = ctx.RenderComponent<Brand>(parameters => parameters
            .Add(p => p.Alt, "brand")
        );

        // Assert
        cut.MarkupMatches(
@"
<img
  alt=""brand""
  class=""pf-c-brand""
  src=""""
/>
");
    }        
}
