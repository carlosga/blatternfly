namespace Blatternfly.UnitTests.Components;

public class ActionListItemTests
{
    [Fact]
    public void RendersSuccessfullyTest()
    {
        // Arrange
        using var ctx = Helper.CreateTestContext();

        // Act
        var cut = ctx.RenderComponent<ActionListItem>(parameters => parameters
            .AddChildContent("test")
        );

        // Assert
        cut.MarkupMatches(
@"
<div
  class=""pf-c-action-list__item""
>
  test
</div>
");
    }
}
