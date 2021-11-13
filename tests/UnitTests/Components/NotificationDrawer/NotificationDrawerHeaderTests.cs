namespace Blatternfly.UnitTests.Components;

public class NotificationDrawerHeaderTests
{
    [Fact]
    public void DefaultTest()
    {
        // Arrange
        using var ctx = new TestContext();

        // Act
        var cut = ctx.RenderComponent<NotificationDrawerHeader>();

        // Assert
        cut.MarkupMatches(
@"
<div class=""pf-c-notification-drawer__header"">
  <h1 data-pf-content=""true"" class=""pf-c-notification-drawer__header-title"">
    Notifications
  </h1>
</div>
");
    }
    
    [Fact]
    public void WithAdditionalCssClassTest()
    {
        // Arrange
        using var ctx = new TestContext();

        // Act
        var cut = ctx.RenderComponent<NotificationDrawerHeader>(parameters => parameters
            .AddUnmatched("class", "extra-class")
        );

        // Assert
        cut.MarkupMatches(
@"
<div class=""pf-c-notification-drawer__header extra-class"">
  <h1 data-pf-content=""true"" class=""pf-c-notification-drawer__header-title"">
    Notifications
  </h1>
</div>
");
    }   
    
    [Fact]
    public void WithAdditionalPropertiesOnRootElementTest()
    {
        // Arrange
        using var ctx = new TestContext();
        var testId = "notification-drawer";

        // Act
        var cut = ctx.RenderComponent<NotificationDrawerHeader>(parameters => parameters
            .AddUnmatched("data-testid", testId)
        );

        // Assert
        cut.MarkupMatches(
$@"
<div class=""pf-c-notification-drawer__header"" data-testid=""{testId}"">
  <h1 data-pf-content=""true"" class=""pf-c-notification-drawer__header-title"">
    Notifications
  </h1>
</div>
");
    }  
    
    [Fact]
    public void WithCountTest()
    {
        // Arrange
        using var ctx = new TestContext();

        // Act
        var cut = ctx.RenderComponent<NotificationDrawerHeader>(parameters => parameters
            .Add(p => p.Count, 2)
        );

        // Assert
        cut.MarkupMatches(
@"
<div class=""pf-c-notification-drawer__header"">
  <h1 data-pf-content=""true"" class=""pf-c-notification-drawer__header-title"">
    Notifications
  </h1>
  <span
    class=""pf-c-notification-drawer__header-status""
  >
    2 unread
  </span>
</div>
");
    }         
    
    [Fact]
    public void WithTitleTest()
    {
        // Arrange
        using var ctx = new TestContext();

        // Act
        var cut = ctx.RenderComponent<NotificationDrawerHeader>(parameters => parameters
            .Add(p => p.Title, "Drawer Notifications")
        );

        // Assert
        cut.MarkupMatches(
@"
<div class=""pf-c-notification-drawer__header"">
  <h1 data-pf-content=""true"" class=""pf-c-notification-drawer__header-title"">
    Drawer Notifications
  </h1>
</div>
");
    }        
    
    [Fact]
    public void WithCustomTest()
    {
        // Arrange
        using var ctx = new TestContext();

        // Act
        var cut = ctx.RenderComponent<NotificationDrawerHeader>(parameters => parameters
            .Add(p => p.CustomText, "2 unread alerts")
        );

        // Assert
        cut.MarkupMatches(
@"
<div class=""pf-c-notification-drawer__header"">
  <h1 data-pf-content=""true"" class=""pf-c-notification-drawer__header-title"">
    Notifications
  </h1>
  <span
    class=""pf-c-notification-drawer__header-status""
  >
    2 unread alerts
  </span>
</div>
");
    }         
}
