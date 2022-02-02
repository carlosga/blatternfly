namespace Blatternfly.UnitTests.Components;

public class TooltipTests
{
    [Fact]
    public void Default()
    {
        // Arrange
        using var ctx = new TestContext();

        // Add service configuration
        ctx.AddServices();

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
    public void ShouldThrowErrorWhenNoIdIsGiven()
    {
        // Arrange
        using var ctx = new TestContext();

        // Add service configuration
        ctx.AddServices();

        // Assert
        var exception = Assert.Throws<InvalidOperationException>(() => ctx.RenderComponent<Tooltip>());

        Assert.Equal("Tooltip: Tooltip requires an id to be specified", exception.Message);
    }
}
