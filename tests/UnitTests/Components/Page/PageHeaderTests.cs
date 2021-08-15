using Blatternfly.Components;
using Bunit;
using Xunit;

namespace Blatternfly.UnitTests.Components
{
    public class PageHeaderTests
    {
        [Fact]
        public void VerticalLayoutTest()
        {
            // Arrange
            using var ctx = new TestContext();

            // Act
            var cut = ctx.RenderComponent<PageHeader>(parameters => parameters
                .Add(p => p.Logo, "Logo")
                .Add(p => p.HeaderTools, "PageHeaderTools | Avatar")
            );

            // Assert
            cut.MarkupMatches(
@"
<header
  class=""pf-c-page__header""
>
  <div
    class=""pf-c-page__header-brand""
  >
    <a
      class=""pf-c-page__header-brand-link""
    >
      Logo
    </a>
  </div>
  PageHeaderTools | Avatar
</header>
");
        }
    }
}
