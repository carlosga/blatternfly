using Blatternfly.Components;
using Bunit;
using Xunit;

namespace Blatternfly.UnitTests.Components
{
    public class DataListContentTests
    {
        [Fact]
        public void DefaultTest()
        {
            // Arrange
            using var ctx = new TestContext();

            // Act
            var cut = ctx.RenderComponent<DataListContent>(parameters => parameters
                .Add(p => p.AriaLabel, "Primary Content Details")
                .AddChildContent("test")
            );

            // Assert
            cut.MarkupMatches(
@"
<section
  aria-label=""Primary Content Details""
  class=""pf-c-data-list__expandable-content""
>
  <div
    class=""pf-c-data-list__expandable-content-body""
  >
   test
  </div>
</section>
");
        }
        
        [Fact]
        public void WithNoPaddingTest()
        {
            // Arrange
            using var ctx = new TestContext();

            // Act
            var cut = ctx.RenderComponent<DataListContent>(parameters => parameters
                .Add(p => p.AriaLabel, "Primary Content Details")
                .Add(p => p.IsHidden, true)
                .Add(p => p.HasNoPadding, true)
                .AddChildContent("test")
            );

            // Assert
            cut.MarkupMatches(
@"
<section
  aria-label=""Primary Content Details""
  class=""pf-c-data-list__expandable-content""
  hidden=""""
>
  <div
    class=""pf-c-data-list__expandable-content-body pf-m-no-padding""
  >
    test
  </div>
</section>
");
        }           
    }
}
