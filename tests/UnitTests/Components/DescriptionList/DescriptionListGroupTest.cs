using Blatternfly.Components;
using Bunit;
using Xunit;

namespace Blatternfly.UnitTests.Components
{
    public class DescriptionListGroupTest
    {
        [Fact]
        public void DefaultTest()
        {
            // Arrange
            using var ctx = new TestContext();

            // Act
            var cut = ctx.RenderComponent<DescriptionListGroup>(parameters => parameters
                .AddUnmatched("class", "custom-description-list-group")
                .AddUnmatched("aria-labelledby", "group-1")
                .AddChildContent("test")
            );

            // Assert
            cut.MarkupMatches(
@"
<div
  aria-labelledby=""group-1""
  class=""pf-c-description-list__group custom-description-list-group""
>
  test
</div>
");
        }          
    }
}
