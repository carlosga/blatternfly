namespace Blatternfly.UnitTests.Components;

public class PopoverHeaderTests
{
    [Fact]
    public void DefaultTest()
    {
        // Arrange
        using var ctx = Helper.CreateTestContext();

        // Act
        var cut = ctx.RenderComponent<PopoverHeader>(properties => properties
            .AddUnmatched("id", "string")
            .AddChildContent("<div>ReactNode</div>")
        );

        // Assert
        cut.MarkupMatches(
@"
<h6
  class=""pf-c-title pf-m-md""
  id=""string""
>
  <div>
    ReactNode
  </div>
</h6>
");
    }
}
