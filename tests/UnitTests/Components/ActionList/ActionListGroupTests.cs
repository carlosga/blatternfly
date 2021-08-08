using Xunit;
using Bunit;
using Blatternfly.Components;

namespace Blatternfly.UnitTests.Components
{
    public class ActionListGroupTests
    {
        [Fact]
        public void RendersSuccessfullyTest()
        {
            // Arrange
            using var ctx = new TestContext();

            // Act
            var cut = ctx.RenderComponent<ActionListGroup>(parameters => parameters
                .AddChildContent("test")
            );

            // Assert
            cut.MarkupMatches(
@"
<div
  class=""pf-c-action-list__group""
>
  test
</div>
");
        }
    }
}
