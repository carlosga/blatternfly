namespace Blatternfly.UnitTests.Layouts;

public class GalleryItemTests
{
    [Fact]
    public void ItemTest()
    {
        // Arrange
        using var ctx = new TestContext();

        // Act
        var cut = ctx.RenderComponent<GalleryItem>(parameters => parameters
            .Add(p => p.ChildContent, "<h1>Gallery Item</h1>")
        );

        // Assert
        cut.MarkupMatches(@"<div><h1>Gallery Item</h1></div>");            
    }
}
