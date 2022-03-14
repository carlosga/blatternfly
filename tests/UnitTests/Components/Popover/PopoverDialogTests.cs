namespace Blatternfly.UnitTests.Components;

public class PopoverDialogTests
{
    [Fact]
    public void DefaultTest()
    {
        // Arrange
        using var ctx = Helper.CreateTestContext();

        // Act
        var cut = ctx.RenderComponent<PopoverDialog>(properties => properties
            .Add(p => p.Position, PopoverDialogPosition.Top)
            .AddUnmatched("class", "null")
            .AddChildContent("ReactNode")
        );

        // Assert
        cut.MarkupMatches(
@"
<div
  aria-modal=""true""
  class=""pf-c-popover pf-m-top null""
  role=""dialog""
>
  ReactNode
</div>
");
    }
}
