using Blatternfly.Components;
using Bunit;
using Xunit;

namespace Blatternfly.UnitTests.Components
{
    public class NotificationDrawerListItemTests
    {
        [Fact]
        public void DefaultTest()
        {
            // Arrange
            using var ctx = new TestContext();

            // Act
            var cut = ctx.RenderComponent<NotificationDrawerListItem>();

            // Assert
            cut.MarkupMatches(
@"
<li
  class=""pf-c-notification-drawer__list-item pf-m-hoverable pf-m-default""
  tabIndex=""0""
/>
");
        }     
        
        [Fact]
        public void WithAdditionalCssClassTest()
        {
            // Arrange
            using var ctx = new TestContext();

            // Act
            var cut = ctx.RenderComponent<NotificationDrawerListItem>(parameters => parameters
                .AddUnmatched("class", "extra-class")
            );

            // Assert
            cut.MarkupMatches(
@"
<li
  class=""pf-c-notification-drawer__list-item pf-m-hoverable pf-m-default extra-class""
  tabIndex=""0""
/>
");
        }          
        
        [Fact]
        public void WithExtraPropertiesOnRootElementTest()
        {
            // Arrange
            using var ctx = new TestContext();
            var testId = "notification-drawer";

            // Act
            var cut = ctx.RenderComponent<NotificationDrawerListItem>(parameters => parameters
                .AddUnmatched("data-testid", testId)
            );

            // Assert
            cut.MarkupMatches(
@$"
<li
  class=""pf-c-notification-drawer__list-item pf-m-hoverable pf-m-default""
  tabIndex=""0""
  data-testid=""{testId}""
/>
");
        }             
        
        [Fact]
        public void IsHoverableTest()
        {
            // Arrange
            using var ctx = new TestContext();

            // Act
            var cut = ctx.RenderComponent<NotificationDrawerListItem>(parameters => parameters
                .Add(p => p.IsHoverable, true)
            );

            // Assert
            cut.MarkupMatches(
@"
<li
  class=""pf-c-notification-drawer__list-item pf-m-hoverable pf-m-default""
  tabIndex=""0""
/>
");
        }    
        
        [Fact]
        public void IsReadTest()
        {
            // Arrange
            using var ctx = new TestContext();

            // Act
            var cut = ctx.RenderComponent<NotificationDrawerListItem>(parameters => parameters
                .Add(p => p.IsRead, true)
            );

            // Assert
            cut.MarkupMatches(
@"
<li
  class=""pf-c-notification-drawer__list-item pf-m-hoverable pf-m-default pf-m-read""
  tabIndex=""0""
/>
");
        }
        
        [Fact]
        public void WithTabIndexTest()
        {
            // Arrange
            using var ctx = new TestContext();

            // Act
            var cut = ctx.RenderComponent<NotificationDrawerListItem>(parameters => parameters
                .Add(p => p.TabIndex, 4)
            );

            // Assert
            cut.MarkupMatches(
@"
<li
  class=""pf-c-notification-drawer__list-item pf-m-hoverable pf-m-default""
  tabIndex=""4""
/>
");
        }         
        
        [Theory]
        [InlineData(SeverityLevel.Danger)]
        [InlineData(SeverityLevel.Default)]
        [InlineData(SeverityLevel.Info)]
        [InlineData(SeverityLevel.Success)]
        [InlineData(SeverityLevel.Warning)]
        public void VariantTest(SeverityLevel level)
        {
            // Arrange
            using var ctx = new TestContext();
            var variantClass = level switch
            {
                SeverityLevel.Success => "pf-m-success",
                SeverityLevel.Danger  => "pf-m-danger",
                SeverityLevel.Warning => "pf-m-warning",
                SeverityLevel.Info    => "pf-m-info",
                SeverityLevel.Default => "pf-m-default",
                _                     => null
            };
            
            // Act
            var cut = ctx.RenderComponent<NotificationDrawerListItem>(properties => properties
                .Add(p => p.Variant, level)
            );

            // Assert
            cut.MarkupMatches(
@$"
<li
  class=""pf-c-notification-drawer__list-item pf-m-hoverable {variantClass}""
  tabIndex=""0""
/>
");
        }

    }
}
