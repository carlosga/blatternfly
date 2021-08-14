using Blatternfly.Components;
using Bunit;
using Xunit;

namespace Blatternfly.UnitTests.Components.NotificationDrawer
{
    public class NotificationDrawerListItemHeaderTests
    {
        [Fact]
        public void DefaultTest()
        {
            // Arrange
            using var ctx = new TestContext();

            // Act
            var cut = ctx.RenderComponent<NotificationDrawerListItemHeader>(properties => properties
                .Add(p => p.Title, "Pod quit unexpectedly")
            );

            // Assert
            cut.MarkupMatches(
@$"
<div
  class=""pf-c-notification-drawer__list-item-header""
>
  <span
    class=""pf-c-notification-drawer__list-item-header-icon""
  >
    <svg
      style=""vertical-align: -0.125em;"" 
      fill=""currentColor"" 
      height=""1em"" 
      width=""1em"" 
      viewBox=""{BellIcon.IconDefinition.ViewBox}"" 
      aria-hidden=""true"" 
      role=""img""
    >
      <path d=""{BellIcon.IconDefinition.SvgPath}""></path>
    </svg>
  </span>
  <h2
    class=""pf-c-notification-drawer__list-item-header-title""
  >
    Pod quit unexpectedly
  </h2>
</div>
");
        }    
        
        [Fact]
        public void WitAdditionalCssClassTest()
        {
            // Arrange
            using var ctx = new TestContext();

            // Act
            var cut = ctx.RenderComponent<NotificationDrawerListItemHeader>(properties => properties
                .AddUnmatched("class", "extra-class")
                .Add(p => p.Title, "Pod quit unexpectedly")
            );

            // Assert
            cut.MarkupMatches(
@$"
<div
  class=""pf-c-notification-drawer__list-item-header extra-class""
>
  <span
    class=""pf-c-notification-drawer__list-item-header-icon""
  >
    <svg
      style=""vertical-align: -0.125em;"" 
      fill=""currentColor"" 
      height=""1em"" 
      width=""1em"" 
      viewBox=""{BellIcon.IconDefinition.ViewBox}"" 
      aria-hidden=""true"" 
      role=""img""
    >
      <path d=""{BellIcon.IconDefinition.SvgPath}""></path>
    </svg>
  </span>
  <h2
    class=""pf-c-notification-drawer__list-item-header-title""
  >
    Pod quit unexpectedly
  </h2>
</div>
");
        }        
        
        [Fact]
        public void WithCustomIconTest()
        {
            // Arrange
            using var ctx = new TestContext();

            // Act
            var cut = ctx.RenderComponent<NotificationDrawerListItemHeader>(properties => properties
                .Add(p => p.Title, "Pod quit unexpectedly")
                .Add<AttentionBellIcon>(p => p.Icon)
            );

            // Assert
            cut.MarkupMatches(
                @$"
<div
  class=""pf-c-notification-drawer__list-item-header""
>
  <span
    class=""pf-c-notification-drawer__list-item-header-icon""
  >
    <svg
      style=""vertical-align: -0.125em;"" 
      fill=""currentColor"" 
      height=""1em"" 
      width=""1em"" 
      viewBox=""{AttentionBellIcon.IconDefinition.ViewBox}"" 
      aria-hidden=""true"" 
      role=""img""
    >
      <path d=""{AttentionBellIcon.IconDefinition.SvgPath}""></path>
    </svg>
  </span>
  <h2
    class=""pf-c-notification-drawer__list-item-header-title""
  >
    Pod quit unexpectedly
  </h2>
</div>
");
        }         
        
        [Fact]
        public void WithScreenReaderTitle()
        {
            // Arrange
            using var ctx = new TestContext();

            // Act
            var cut = ctx.RenderComponent<NotificationDrawerListItemHeader>(properties => properties
                .Add(p => p.Title, "Pod quit unexpectedly")
                .Add(p => p.ScreenReaderTitle, "screen reader title")
            );

            // Assert
            cut.MarkupMatches(
@$"
<div
  class=""pf-c-notification-drawer__list-item-header""
>
  <span
    class=""pf-c-notification-drawer__list-item-header-icon""
  >
    <svg
      style=""vertical-align: -0.125em;"" 
      fill=""currentColor"" 
      height=""1em"" 
      width=""1em"" 
      viewBox=""{BellIcon.IconDefinition.ViewBox}"" 
      aria-hidden=""true"" 
      role=""img""
    >
      <path d=""{BellIcon.IconDefinition.SvgPath}""></path>
    </svg>
  </span>
  <h2
    class=""pf-c-notification-drawer__list-item-header-title""
  >
    <span
      class=""pf-u-screen-reader""
    >
      screen reader title
    </span>
    Pod quit unexpectedly
  </h2>
</div>
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
            var icon = level switch 
            {
                SeverityLevel.Success => CheckCircleIcon.IconDefinition,
                SeverityLevel.Danger  => ExclamationCircleIcon.IconDefinition,
                SeverityLevel.Warning => ExclamationTriangleIcon.IconDefinition,
                SeverityLevel.Info    => InfoCircleIcon.IconDefinition,
                _                     => BellIcon.IconDefinition
            };
            
            // Act
            var cut = ctx.RenderComponent<NotificationDrawerListItemHeader>(properties => properties
                .Add(p => p.Title, "Pod quit unexpectedly")
                .Add(p => p.Variant, level)
            );

            // Assert
            cut.MarkupMatches(
                @$"
<div
  class=""pf-c-notification-drawer__list-item-header""
>
  <span
    class=""pf-c-notification-drawer__list-item-header-icon""
  >
    <svg
      style=""vertical-align: -0.125em;"" 
      fill=""currentColor"" 
      height=""1em"" 
      width=""1em"" 
      viewBox=""{icon.ViewBox}"" 
      aria-hidden=""true"" 
      role=""img""
    >
      <path d=""{icon.SvgPath}""></path>
    </svg>
  </span>
  <h2
    class=""pf-c-notification-drawer__list-item-header-title""
  >
    Pod quit unexpectedly
  </h2>
</div>
");
        }
        
        [Fact]
        public void WithTruncatedTitleTest()
        {
            // Arrange
            using var ctx = new TestContext();

            // Act
            var cut = ctx.RenderComponent<NotificationDrawerListItemHeader>(properties => properties
                .Add(p => p.TruncateTitle, 1)
                .Add(p => p.Title, "Pod quit unexpectedly")
                .Add(p => p.Variant, SeverityLevel.Success)
            );

            // Assert
            cut.MarkupMatches(
@$"
<div class=""pf-c-notification-drawer__list-item-header"">
  <span class=""pf-c-notification-drawer__list-item-header-icon"">
    <svg
      style=""vertical-align: -0.125em;"" 
      fill=""currentColor"" 
      height=""1em"" 
      width=""1em"" 
      viewBox=""{CheckCircleIcon.IconDefinition.ViewBox}"" 
      aria-hidden=""true"" 
      role=""img""
    >
      <path d=""{CheckCircleIcon.IconDefinition.SvgPath}""></path>
    </svg>
  </span>
  <h2 
    class=""pf-c-notification-drawer__list-item-header-title pf-m-truncate"" 
    style=""--pf-c-notification-drawer__list-item-header-title--max-lines: 1;""
  >
    Pod quit unexpectedly
  </h2>
</div>
");
        }            
    }
}
