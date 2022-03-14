namespace Blatternfly.UnitTests.Components;

public class PopoverFooterTests
{
    [Fact]
    public void DefaultTest()
    {
        // Arrange
        using var ctx = Helper.CreateTestContext();

        // Act
        var cut = ctx.RenderComponent<PopoverFooter>(properties => properties
            .AddUnmatched("class", "''")
            .AddChildContent("<div>ReactNode</div>")
        );

        // Assert
        cut.MarkupMatches(
@"
<footer
  class=""pf-c-popover__footer ''""
>
  <div>
    ReactNode
  </div>
</footer>
");
    }
}
