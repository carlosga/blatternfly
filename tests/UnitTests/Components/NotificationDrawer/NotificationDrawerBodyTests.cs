namespace Blatternfly.UnitTests.Components;

public class NotificationDrawerBodyTests
{
    [Fact]
    public void DefaultTest()
    {
        // Arrange
        using var ctx = new TestContext();

        // Act
        var cut = ctx.RenderComponent<NotificationDrawerBody>();

        // Assert
        cut.MarkupMatches(
@"
<div
  class=""pf-c-notification-drawer__body""
/>
");
    }
    
    [Fact]
    public void WithAdditionalCssClassTest()
    {
        // Arrange
        using var ctx = new TestContext();

        // Act
        var cut = ctx.RenderComponent<NotificationDrawerBody>(parameters => parameters
            .AddUnmatched("class", "extra-class")
        );

        // Assert
        cut.MarkupMatches(
@"
<div
  class=""pf-c-notification-drawer__body extra-class""
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
        var cut = ctx.RenderComponent<NotificationDrawerBody>(parameters => parameters
            .AddUnmatched("data-testid", testId)
        );

        // Assert
        cut.MarkupMatches(
$@"
<div
  class=""pf-c-notification-drawer__body""
  data-testid=""{testId}""
/>
");
    }  
}
    
