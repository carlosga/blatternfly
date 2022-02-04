namespace Blatternfly.UnitTests.Components;

public class OverflowMenuControlTests
{
    [Fact]
    public void BasicTest()
    {
        // Arrange
        using var ctx = Helper.CreateTestContext();

        // Act
        var cut = ctx.RenderComponent<OverflowMenuControl>(parameters => parameters
            .Add(p => p.IsBelowBreakpoint, true)
        );

        // Assert
        cut.MarkupMatches(@"<div class=""pf-c-overflow-menu__control""> </div>");
    }

    [Fact]
    public void WithAdditionalOptionsTest()
    {
        // Arrange
        using var ctx = Helper.CreateTestContext();

        // Act
        var cut = ctx.RenderComponent<OverflowMenuControl>(parameters => parameters
            .Add(p => p.HasAdditionalOptions, true)
        );

        // Assert
        cut.MarkupMatches(@"<div class=""pf-c-overflow-menu__control""> </div>");
    }
}
