namespace Blatternfly.UnitTests.Components;

public class TooltipContentTests
{
    [Fact]
    public void Default()
    {
        // Arrange
        using var ctx = Helper.CreateTestContext();

        // Act
        var cut = ctx.RenderComponent<TooltipContent>(properties => properties
            .AddChildContent("<div>Lorem ipsum dolor sit amet, consectetur adipiscing elit. Nullam id feugiat augue, nec fringilla turpis.</div>")
        );

        // Assert
        cut.MarkupMatches(
@"
<div class=""pf-c-tooltip__content"">
  <div>Lorem ipsum dolor sit amet, consectetur adipiscing elit. Nullam id feugiat augue, nec fringilla turpis.</div>
</div>
");
    }

    [Fact]
    public void IsLeftAlignedTest()
    {
        // Arrange
        using var ctx = Helper.CreateTestContext();

        // Act
        var cut = ctx.RenderComponent<TooltipContent>(properties => properties
            .Add(p => p.IsLeftAligned, true)
            .AddChildContent("<div>Lorem ipsum dolor sit amet, consectetur adipiscing elit. Nullam id feugiat augue, nec fringilla turpis.</div>")
        );

        // Assert
        cut.MarkupMatches(
@"
<div class=""pf-c-tooltip__content pf-m-text-align-left"">
  <div>Lorem ipsum dolor sit amet, consectetur adipiscing elit. Nullam id feugiat augue, nec fringilla turpis.</div>
</div>
");
    }
}
