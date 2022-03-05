namespace Blatternfly.UnitTests.Components;

public class CodeBlockActionTests
{
    [Fact]
    public void DefaultTest()
    {
        // Arrange
        using var ctx = Helper.CreateTestContext();

        // Act
        var cut = ctx.RenderComponent<CodeBlockAction>(parameters => parameters
            .AddChildContent("action")
        );

        // Assert
        cut.MarkupMatches(
@"
<div
  class=""pf-c-code-block__actions-item""
>
  action
</div>
");
    }
}
