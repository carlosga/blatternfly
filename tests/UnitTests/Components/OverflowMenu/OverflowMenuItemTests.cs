namespace Blatternfly.UnitTests.Components;

public class OverflowMenuItemClass
{
    [Fact]
    public void IsPersistentAndBelowBreakpointShouldStillShowTest()
    {
        // Arrange
        using var ctx = new TestContext();

        // Act
        var cut = ctx.RenderComponent<OverflowMenuItem>(parameters => parameters
            .Add(p => p.IsBelowBreakpoint, true)
            .Add(p => p.IsPersistent, true)
        );
        
        // Assert
        cut.MarkupMatches(@"<div class=""pf-c-overflow-menu__item"">  </div>");
    }
    
    [Fact]
    public void BelowBreakpointAndNotIsPersistentShouldNotShowTest()
    {
        // Arrange
        using var ctx = new TestContext();

        // Act
        var cut = ctx.RenderComponent<OverflowMenuItem>(parameters => parameters
            .Add(p => p.IsBelowBreakpoint, true)
        );
        
        // Assert
        cut.MarkupMatches("");
    }        
}
