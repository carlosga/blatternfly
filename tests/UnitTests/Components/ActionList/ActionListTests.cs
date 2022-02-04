namespace Blatternfly.UnitTests.Components;

public class ActionListTests
{
    [Fact]
    public void RendersSuccessfullyTest()
    {
        // Arrange
        using var ctx = Helper.CreateTestContext();

        // Act
        var cut = ctx.RenderComponent<ActionList>(parameters => parameters
            .AddChildContent("test")
        );

        // Assert
        cut.MarkupMatches(
@"
<div
  class=""pf-c-action-list""
>
  test
</div>
");
    }

    [Fact]
    public void IsIconListTest()
    {
        // Arrange
        using var ctx = Helper.CreateTestContext();

        // Act
        var cut = ctx.RenderComponent<ActionList>(parameters => parameters
            .Add(p => p.IsIconList, true)
            .AddChildContent("test")
        );

        // Assert
        cut.MarkupMatches(
@"
<div
  class=""pf-c-action-list  pf-m-icons""
>
  test
</div>
");
    }
}
