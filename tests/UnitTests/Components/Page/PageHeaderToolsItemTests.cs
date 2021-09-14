using Blatternfly.Components;
using Bunit;
using Xunit;

namespace Blatternfly.UnitTests.Components
{
    public class PageHeaderToolsItemTests
    {
        [Fact]
        public void DefaultTest()
        {
            // Arrange
            using var ctx = new TestContext();

            // Act
            var cut = ctx.RenderComponent<PageHeaderToolsItem>(parameters => parameters
                .AddChildContent("test")
            );

            // Assert
            cut.MarkupMatches(
@"
<div
  class=""pf-c-page__header-tools-item""
>
  test
</div>
");
        }        
        
        [Fact]
        public void IsSelectedTest()
        {
            // Arrange
            using var ctx = new TestContext();

            // Act
            var cut = ctx.RenderComponent<PageHeaderToolsItem>(parameters => parameters
                .Add(p => p.IsSelected, true)
                .AddChildContent("test")
            );

            // Assert
            cut.MarkupMatches(
@"
<div
  class=""pf-c-page__header-tools-item pf-m-current""
>
  test
</div>
");
        }           
    }
}
