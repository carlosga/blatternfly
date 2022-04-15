namespace Blatternfly.UnitTests.Components;

public class PageHeaderToolsGroupTests
{
    [Fact]
    public void DefaultTest()
    {
        // Arrange
        using var ctx = Helper.CreateTestContext();

        // Act
        var cut = ctx.RenderComponent<PageHeaderToolsGroup>(parameters => parameters
            .AddChildContent("test")
        );

        // Assert
        cut.MarkupMatches(
@"
<div
  class=""pf-c-page__header-tools-group""
>
  test
</div>
");
    }

    [Theory]
    [InlineData(Visibility.Visible)]
    [InlineData(Visibility.Hidden)]
    public void IsVisibleTest(Visibility value)
    {
        // Arrange
        using var ctx = Helper.CreateTestContext();
        var visibility = new VisibilityModifiers
        {
          Default     = value,
          Large       = value,
          Medium      = value,
          Small       = value,
          ExtraLarge  = value,
          ExtraLarge2 = value
        };
        var cssClasses = value switch
        {
            Visibility.Hidden  => "pf-m-hidden pf-m-hidden-on-sm pf-m-hidden-on-md pf-m-hidden-on-lg pf-m-hidden-on-xl pf-m-hidden-on-2xl",
            Visibility.Visible => "pf-m-visible pf-m-visible-on-sm pf-m-visible-on-md pf-m-visible-on-lg pf-m-visible-on-xl pf-m-visible-on-2xl",
            _                    => null
        };

        // Act
        var cut = ctx.RenderComponent<PageHeaderToolsGroup>(parameters => parameters
            .Add(p => p.Visibility, visibility)
            .AddChildContent("test")
        );

        // Assert
        cut.MarkupMatches(
$@"
<div
  class=""pf-c-page__header-tools-group {cssClasses}""
>
  test
</div>
");
    }
}
