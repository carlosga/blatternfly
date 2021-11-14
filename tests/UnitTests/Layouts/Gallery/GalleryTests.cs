namespace Blatternfly.UnitTests.Layouts;

public class GalleryTests
{
    [Fact]
    public void GutterTest()
    {
        // Arrange
        using var ctx = new TestContext();

        // Act
        var cut = ctx.RenderComponent<Gallery>(parameters => parameters
            .Add(p => p.HasGutter, true)
        );

        // Assert
        cut.MarkupMatches(
@"
<div
  class=""pf-l-gallery pf-m-gutter""
/>
");            
    }

    [Fact]
    public void GutterBreakpointsTest()
    {
        // Arrange
        using var ctx = new TestContext();
        var minWidths = new GalleryBreakpoints
        {
            Default    = "100%",
            Medium     = "100px",
            ExtraLarge = "300px"
        };
        var maxWidths = new GalleryBreakpoints
        {
            Medium     = "200px",
            ExtraLarge = "1fr"
        };
    
        // Act
        var cut = ctx.RenderComponent<Gallery>(parameters => parameters
            .Add(p => p.HasGutter, true)
            .Add(p => p.MinWidths, minWidths)
            .Add(p => p.MaxWidths, maxWidths)
        );

        // Assert
        cut.MarkupMatches(
@"
<div
  class=""pf-l-gallery pf-m-gutter""
  style=""--pf-l-gallery--GridTemplateColumns--min:100%;
  --pf-l-gallery--GridTemplateColumns--min-on-md:100px;
  --pf-l-gallery--GridTemplateColumns--min-on-xl:300px;
  --pf-l-gallery--GridTemplateColumns--max-on-md:200px;
  --pf-l-gallery--GridTemplateColumns--max-on-xl:1fr;""
/>
");            
    }
    
    [Fact]
    public void ItemsTest()
    {
        // Arrange
        using var ctx = new TestContext();

        // Act
        var cut = ctx.RenderComponent<Gallery>(parameters => parameters
            .Add<GalleryItem>(p => p.ChildContent, itemparams => itemparams
                .Add(p => p.ChildContent, "<h1>Gallery Item</h1>")
            )
        );
        
        // Assert
        cut.MarkupMatches(
@"
<div
  class=""pf-l-gallery""
>
  <div><h1>Gallery Item</h1></div>
</div>
");
    }
    
    [Fact]
    public void AlternativeComponentTest()
    {
        // Arrange
        using var ctx = new TestContext();

        // Act
        var cut = ctx.RenderComponent<Gallery>(parameters => parameters
            .Add(p => p.Component, "ul")
            .Add<GalleryItem>(p => p.ChildContent, itemparams => itemparams
                .Add(p => p.Component, "li")
                .AddChildContent("Test")
            )
        );

        // Assert
        cut.MarkupMatches(
@"
<ul
  class=""pf-l-gallery""
>
  <li>
    Test
  </li>
</ul>
");            
    }        
}
