namespace Blatternfly.UnitTests.Layouts;

public class SplitItemTests
{
    [Fact]
    public void ItemTest()
    {
        // Arrange
        using var ctx = Helper.CreateTestContext();

        // Act
        var cut = ctx.RenderComponent<SplitItem>(parameters => parameters
            .Add(p => p.ChildContent, "<h1>Gallery Item</h1>")
        );

        // Assert
        cut.MarkupMatches(@"<div class=""pf-l-split__item""><h1>Gallery Item</h1></div>");
    }
}
