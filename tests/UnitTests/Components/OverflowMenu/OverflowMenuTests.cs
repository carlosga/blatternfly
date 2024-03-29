﻿namespace Blatternfly.UnitTests.Components;

public class OverflowMenuTests
{
    [Theory]
    [InlineData(Breakpoint.Medium)]
    [InlineData(Breakpoint.Large)]
    [InlineData(Breakpoint.ExtraLarge)]
    [InlineData(Breakpoint.ExtraLarge2)]
    public void WithBreakpointTest(Breakpoint breakpoint)
    {
        // Arrange
        using var ctx = Helper.CreateTestContext();

        // Act
        var cut = ctx.RenderComponent<OverflowMenu>(parameters => parameters
            .Add(p => p.Breakpoint, breakpoint)
        );

        // Assert
        cut.MarkupMatches(@"<div class=""pf-c-overflow-menu""> </div>");
    }

    [Fact]
    public void ShouldThrowOnInvalidBreakpointTest()
    {
        // Arrange
        using var ctx = Helper.CreateTestContext();

        // Act
        var ex = Assert.Throws<InvalidOperationException>(() =>
            ctx.RenderComponent<OverflowMenu>(parameters => parameters.Add(p => p.Breakpoint, (Breakpoint) 10))
        );

        Assert.Equal("OverflowMenu will not be visible without a valid breakpoint.", ex.Message);
    }
}
