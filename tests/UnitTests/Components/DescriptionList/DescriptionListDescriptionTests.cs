namespace Blatternfly.UnitTests.Components;

public class DescriptionListDescriptionTests
{
    [Fact]
    public void DefaultTest()
    {
        // Arrange
        using var ctx = Helper.CreateTestContext();

        // Act
        var cut = ctx.RenderComponent<DescriptionListDescription>(parameters => parameters
            .AddUnmatched("class", "custom-description-list-description")
            .AddUnmatched("aria-labelledby", "description-1")
            .AddChildContent("test")
        );

        // Assert
        cut.MarkupMatches(
@"
<dd
  aria-labelledby=""description-1""
  class=""pf-c-description-list__description custom-description-list-description""
>
  <div
    class=""pf-c-description-list__text""
  >
    test
  </div>
</dd>
");
    }
}
