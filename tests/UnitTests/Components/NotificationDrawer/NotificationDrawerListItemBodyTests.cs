namespace Blatternfly.UnitTests.Components;

public class NotificationDrawerListItemBodyTests
{
    [Fact]
    public void DefaultTest()
    {
        // Arrange
        using var ctx = new TestContext();

        // Act
        var cut = ctx.RenderComponent<NotificationDrawerListItemBody>();

        // Assert
        cut.MarkupMatches(
@"
<div
  class=""pf-c-notification-drawer__list-item-description""
/>
");
    }        
    
    [Fact]
    public void WithAdditionalCssClassTest()
    {
        // Arrange
        using var ctx = new TestContext();

        // Act
        var cut = ctx.RenderComponent<NotificationDrawerListItemBody>(parameters => parameters
            .AddUnmatched("class", "extra-class")
        );

        // Assert
        cut.MarkupMatches(
@"
<div
  class=""pf-c-notification-drawer__list-item-description extra-class""
/>
");
    }  
    
    [Fact]
    public void WithTimestampTest()
    {
        // Arrange
        using var ctx = new TestContext();

        // Act
        var cut = ctx.RenderComponent<NotificationDrawerListItemBody>(parameters => parameters
            .Add(p => p.Timestamp, "5 minutes ago")
        );

        // Assert
        cut.MarkupMatches(
@"
<div
  class=""pf-c-notification-drawer__list-item-description""
>
</div>
<div
  class=""pf-c-notification-drawer__list-item-timestamp""
>
  5 minutes ago
</div>
");
    }          
}
