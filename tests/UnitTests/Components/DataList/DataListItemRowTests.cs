namespace Blatternfly.UnitTests.Components;

public class DataListItemRowTests
{
    [Fact]
    public void DefaultTest()
    {
        // Arrange
        using var ctx = Helper.CreateTestContext();

        // Act
        var cut = ctx.RenderComponent<DataListItemRow>(parameters => parameters
            .AddChildContent("test")
        );

        // Assert
        cut.MarkupMatches(@"<div class=""pf-c-data-list__item-row"">test</div>");
    }
}
