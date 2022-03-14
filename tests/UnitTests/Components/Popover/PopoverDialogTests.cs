namespace Blatternfly.UnitTests.Components;

public class PopoverDialogTests
{
    [Theory]
    [InlineData(PopoverDialogPosition.Bottom)]
    [InlineData(PopoverDialogPosition.Left)]
    [InlineData(PopoverDialogPosition.Right)]
    [InlineData(PopoverDialogPosition.Top)]
    public void WithPositionTest(PopoverDialogPosition position)
    {
        // Arrange
        using var ctx = Helper.CreateTestContext();

        var cssClass = position switch
        {
            PopoverDialogPosition.Top    => "pf-m-top",
            PopoverDialogPosition.Bottom => "pf-m-bottom",
            PopoverDialogPosition.Left   => "pf-m-left",
            PopoverDialogPosition.Right  => "pf-m-right",
            _                            => null
        };

        // Act
        var cut = ctx.RenderComponent<PopoverDialog>(properties => properties
            .Add(p => p.Position, position)
            .AddUnmatched("class", "null")
            .AddChildContent("ReactNode")
        );

        // Assert
        cut.MarkupMatches(
$@"
<div
  aria-modal=""true""
  class=""pf-c-popover {cssClass} null""
  role=""dialog""
>
  ReactNode
</div>
");
    }

    [Fact]
    public void WithoutPositionShouldStickToTop()
    {
        // Arrange
        using var ctx = Helper.CreateTestContext();

        // Act
        var cut = ctx.RenderComponent<PopoverDialog>(properties => properties
            .AddUnmatched("class", "null")
            .AddChildContent("ReactNode")
        );

        // Assert
        cut.MarkupMatches(
$@"
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
