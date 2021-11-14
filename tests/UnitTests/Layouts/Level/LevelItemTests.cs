namespace Blatternfly.UnitTests.Layouts;

public class LevelItemTests
{
    [Fact]
    public void ItemTest()
    {
        // Arrange
        using var ctx = new TestContext();

        // Act
        var cut = ctx.RenderComponent<LevelItem>(parameters => parameters
            .Add(p => p.ChildContent, "<h1>Gallery Item</h1>")
        );

        // Assert
        cut.MarkupMatches(@"<div><h1>Gallery Item</h1></div>");            
    }
}
