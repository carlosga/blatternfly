namespace Blatternfly.UnitTests.Components;

public class NotificationDrawerTests
{
    [Fact]
    public void DefaultTest()
    {
        // Arrange
        using var ctx = new TestContext();

        // Act
        var cut = ctx.RenderComponent<NotificationDrawer>();

        // Assert
        cut.MarkupMatches(
@"
<div
  class=""pf-c-notification-drawer""
/>
");
    }
    
    [Fact]
    public void WithAdditionalCssClass()
    {
        // Arrange
        using var ctx = new TestContext();

        // Act
        var cut = ctx.RenderComponent<NotificationDrawer>(parameters => parameters
            .AddUnmatched("class", "extra-class")
        );

        // Assert
        cut.MarkupMatches(
@"
<div
  class=""pf-c-notification-drawer extra-class""
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
        var cut = ctx.RenderComponent<NotificationDrawer>(parameters => parameters
            .AddUnmatched("data-testid", testId)
        );

        // Assert
        cut.MarkupMatches(
$@"
<div
  class=""pf-c-notification-drawer""
  data-testid=""{testId}""
/>
");
    }          
}
