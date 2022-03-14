namespace Blatternfly.UnitTests.Components;

public class PopoverContentTests
{
    [Fact]
    public void DefaultTest()
    {
        // Arrange
        using var ctx = Helper.CreateTestContext();

        // Act
        var cut = ctx.RenderComponent<PopoverContent>(properties => properties
            .AddUnmatched("class", "null")
            .AddChildContent("<div>ReactNode</div>")
        );

        // Assert
        cut.MarkupMatches(
@"
<div
  class=""pf-c-popover__content null""
>
  <div>
    ReactNode
  </div>
</div>
");
    }
}
