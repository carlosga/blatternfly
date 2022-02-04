namespace Blatternfly.UnitTests.Components;

public class BackdropUnitTests
{
    [Fact]
    public void BackdropTest()
    {
        // Arrange
        using var ctx = Helper.CreateTestContext();

        // Act
        var cut = ctx.RenderComponent<Backdrop>(parameters => parameters
            .AddChildContent("Backdrop")
        );

        // Assert
        cut.MarkupMatches(
@"
<div
  class=""pf-c-backdrop""
>
  Backdrop
</div>
");
    }
}
