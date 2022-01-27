namespace Blatternfly.UnitTests.Components;

public class TooltipArrowTests
{
    [Fact]
    public void Default()
    {
        // Arrange
        using var ctx = new TestContext();

        // Act
        var cut = ctx.RenderComponent<TooltipArrow>();

        // Assert
        cut.MarkupMatches(@"<div class=""pf-c-tooltip__arrow"" />");
    }
}
