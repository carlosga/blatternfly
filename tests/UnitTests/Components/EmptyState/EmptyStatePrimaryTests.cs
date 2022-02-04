namespace Blatternfly.UnitTests.Components;

public class EmptyStatePrimaryTests
{
    [Fact]
    public void DefaultTest()
    {
        // Arrange
        using var ctx = Helper.CreateTestContext();

        // Act
        var cut = ctx.RenderComponent<EmptyStatePrimary>(parameters => parameters
            .AddUnmatched("class" , "custom-empty-state-prim-cls")
            .AddUnmatched("id"    , "empty-state-prim-id")
        );

        // Assert
        cut.MarkupMatches(
@"
<div
  id=""empty-state-prim-id""
  class=""pf-c-empty-state__primary custom-empty-state-prim-cls""
/>
");
    }
}
