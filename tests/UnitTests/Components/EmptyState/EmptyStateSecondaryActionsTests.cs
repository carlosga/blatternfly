using Blatternfly.Components;
using Bunit;
using Xunit;

namespace Blatternfly.UnitTests.Components
{
    public class EmptyStateSecondaryActionsTests
    {
        [Fact]
        public void DefaultTest()
        {
            // Arrange
            using var ctx = new TestContext();

            // Act
            var cut = ctx.RenderComponent<EmptyStateSecondaryActions>(parameters => parameters
                .AddUnmatched("class" , "custom-empty-state-secondary")
                .AddUnmatched("id"    , "empty-state-2")
            );

            // Assert
            cut.MarkupMatches(
                @"
<div
  id=""empty-state-2""
  class=""pf-c-empty-state__secondary custom-empty-state-secondary""
/>
");
        }        
    }
}
