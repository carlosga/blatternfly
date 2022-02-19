namespace Blatternfly.UnitTests.Components;

public class TooltipTests
{
    [Fact]
    public void DefaultTest()
    {
        // Arrange
        using var ctx = Helper.CreateTestContext();

        // Act
        var cut = ctx.RenderComponent<Tooltip>(properties => properties
            .AddUnmatched("id", "tooltip-id")
            .Add(p => p.Content, "<div>Lorem ipsum dolor sit amet, consectetur adipiscing elit. Nullam id feugiat augue, nec fringilla turpis.</div>")
            .AddChildContent("<div>Toggle tooltip</div>")
        );

        // Assert
        cut.MarkupMatches(@"<div>Toggle tooltip</div>");
    }

    [Fact]
    public void ShouldThrowErrorWhenNoIdIsGivenTest()
    {
        // Arrange
        using var ctx = Helper.CreateTestContext();



        // Assert
        var exception = Assert.Throws<InvalidOperationException>(() => ctx.RenderComponent<Tooltip>());

        Assert.Equal("Tooltip: Tooltip requires an id to be specified", exception.Message);
    }
}
