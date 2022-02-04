namespace Blatternfly.UnitTests.Components;

public class EmptyStateBodyTests
{
    [Fact]
    public void DefaultTest()
    {
        // Arrange
        using var ctx = Helper.CreateTestContext();

        // Act
        var cut = ctx.RenderComponent<EmptyStateBody>(parameters => parameters
            .AddUnmatched("class" , "custom-empty-state-body")
            .AddUnmatched("id"    , "empty-state-1")
        );

        // Assert
        cut.MarkupMatches(
@"
<div
  id=""empty-state-1""
  class=""pf-c-empty-state__body custom-empty-state-body""
/>
");
    }
}
