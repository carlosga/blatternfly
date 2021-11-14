namespace Blatternfly.UnitTests.Layouts;

public class LevelTests
{
    [Fact]
    public void GutterTest()
    {
        // Arrange
        using var ctx = new TestContext();

        // Act
        var cut = ctx.RenderComponent<Level>(parameters => parameters
            .Add(p => p.HasGutter, true)
        );

        // Assert
        cut.MarkupMatches(
@"
<div
  class=""pf-l-level pf-m-gutter""
/>
");            
    }

    [Fact]
    public void ItemsTest()
    {
        // Arrange
        using var ctx = new TestContext();

        // Act
        var cut = ctx.RenderComponent<Level>(parameters => parameters
            .Add<LevelItem>(p => p.ChildContent, itemparams => itemparams
                .Add(p => p.ChildContent, "<h1>Level Item</h1>")
            )
        );
    
        // Assert
        cut.MarkupMatches(
@"
<div
  class=""pf-l-level""
>
  <div><h1>Level Item</h1></div>
</div>
");
    }        
}
