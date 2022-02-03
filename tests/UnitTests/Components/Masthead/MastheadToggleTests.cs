namespace Blatternfly.UnitTests.Components;

public class MastheadToggleTests
{
    [Fact]
    public void DefaultTest()
    {
        // Arrange
        using var ctx = Helper.CreateTestContext();

        // Act
        var cut = ctx.RenderComponent<MastheadToggle>(parameters => parameters
            .AddChildContent("test")
        );

        // Assert
        cut.MarkupMatches(
@"
<div
  class=""pf-c-masthead__toggle""
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
        var cut = ctx.RenderComponent<MastheadToggle>(parameters => parameters
            .AddUnmatched("class", "custom-css")
            .AddChildContent("test")
        );

        // Assert
        cut.MarkupMatches(
@"
<div
  class=""pf-c-masthead__toggle custom-css""
>
  test
</div>
");
    }
}
