namespace Blatternfly.UnitTests.Components;

public class PopoverBodyTests
{
    [Fact]
    public void DefaultTest()
    {
        // Arrange
        using var ctx = Helper.CreateTestContext();

        // Act
        var cut = ctx.RenderComponent<PopoverBody>(properties => properties
            .AddUnmatched("id", "string")
            .AddChildContent("<div>ReactNode</div>")
        );

        // Assert
        cut.MarkupMatches(
@"
<div
  class=""pf-c-popover__body""
  id=""string""
>
  <div>
    ReactNode
  </div>
</div>
");
    }
}
