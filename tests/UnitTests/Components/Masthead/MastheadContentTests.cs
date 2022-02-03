namespace Blatternfly.UnitTests.Components;

public class MastheadContentTests
{
    [Fact]
    public void DefaultTest()
    {
        // Arrange
        using var ctx = Helper.CreateTestContext();

        // Act
        var cut = ctx.RenderComponent<MastheadContent>(parameters => parameters
            .AddChildContent("test")
        );

        // Assert
        cut.MarkupMatches(
@"
<div
  class=""pf-c-masthead__content""
>
  test
</div>
");
    }

    [Fact]
    public void WithAdditionalCssClassTest()
    {
        // Arrange
        using var ctx = Helper.CreateTestContext();

        // Act
        var cut = ctx.RenderComponent<MastheadContent>(parameters => parameters
            .AddUnmatched("class", "custom-css")
            .AddChildContent("test")
        );

        // Assert
        cut.MarkupMatches(
@"
<div
  class=""pf-c-masthead__content custom-css""
>
  test
</div>
");
    }
}
