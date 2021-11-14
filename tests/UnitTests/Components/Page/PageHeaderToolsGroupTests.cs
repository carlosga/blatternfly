namespace Blatternfly.UnitTests.Components;

public class PageHeaderToolsGroupTests
{
    [Fact]
    public void DefaultTest()
    {
        // Arrange
        using var ctx = new TestContext();

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
    [InlineData(Visibilities.Visible)]
    [InlineData(Visibilities.Hidden)]
    public void IsVisibleTest(Visibilities value)
    {
        // Arrange
        using var ctx = new TestContext();
        var visibility = new Visibility
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
            Visibilities.Hidden  => "pf-m-hidden pf-m-hidden-on-sm pf-m-hidden-on-md pf-m-hidden-on-lg pf-m-hidden-on-xl pf-m-hidden-on-2xl",
            Visibilities.Visible => "pf-m-visible pf-m-visible-on-sm pf-m-visible-on-md pf-m-visible-on-lg pf-m-visible-on-xl pf-m-visible-on-2xl",
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
