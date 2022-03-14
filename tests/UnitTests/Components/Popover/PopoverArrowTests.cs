namespace Blatternfly.UnitTests.Components;

public class PopoverArrowTests
{
    [Fact]
    public void DefaultTest()
    {
        // Arrange
        using var ctx = Helper.CreateTestContext();

        // Act
        var cut = ctx.RenderComponent<PopoverArrow>(properties => properties
            .AddUnmatched("class", "''")
        );

        // Assert
        cut.MarkupMatches(
@"
<div
  class=""pf-c-popover__arrow ''""
/>
");
    }
}
