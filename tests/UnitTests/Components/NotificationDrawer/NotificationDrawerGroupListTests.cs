using Blatternfly.Components;
using Bunit;
using Xunit;

namespace Blatternfly.UnitTests.Components
{
    public class NotificationDrawerGroupListTests
    {
        [Fact]
        public void DefaultTest()
        {
            // Arrange
            using var ctx = new TestContext();

            // Act
            var cut = ctx.RenderComponent<NotificationDrawerGroupList>();

            // Assert
            cut.MarkupMatches(
@"
<div
  class=""pf-c-notification-drawer__group-list""
/>
");
        }
        
        [Fact]
        public void WithAdditionalCssClassTest()
        {
            // Arrange
            using var ctx = new TestContext();

            // Act
            var cut = ctx.RenderComponent<NotificationDrawerGroupList>(parameters => parameters
                .AddUnmatched("class", "extra-class")
            );

            // Assert
            cut.MarkupMatches(
@"
<div
  class=""pf-c-notification-drawer__group-list extra-class""
/>
");
        }        
        
        [Fact]
        public void WithAdditionalPropertiesOnRootElementTest()
        {
            // Arrange
            using var ctx = new TestContext();
            var testId = "notification-drawer";

            // Act
            var cut = ctx.RenderComponent<NotificationDrawerGroupList>(parameters => parameters
                .AddUnmatched("data-testid", testId)
            );

            // Assert
            cut.MarkupMatches(
$@"
<div
  class=""pf-c-notification-drawer__group-list""
  data-testid=""{testId}""
/>
");
        }          
    }
}
