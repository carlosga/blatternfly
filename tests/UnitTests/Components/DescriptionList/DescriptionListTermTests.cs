using Blatternfly.Components;
using Bunit;
using Xunit;

namespace Blatternfly.UnitTests.Components
{
    public class DescriptionListTermTests
    {
        [Fact]
        public void DefaultTest()
        {
            // Arrange
            using var ctx = new TestContext();

            // Act
            var cut = ctx.RenderComponent<DescriptionListTerm>(parameters => parameters
                .AddUnmatched("aria-labelledby", "term-1")
                .AddChildContent("test")
            );

            // Assert
            cut.MarkupMatches(
@"
<dt
  aria-labelledby=""term-1""
  class=""pf-c-description-list__term""
>
  <span
    class=""pf-c-description-list__text""
  >
    test
  </span>
</dt>
");
        }         
    }
}
