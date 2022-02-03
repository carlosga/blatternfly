namespace Blatternfly.UnitTests.Components;

public class NotificationDrawerListTests
{
    [Fact]
    public void DefaultTest()
    {
        // Arrange
        using var ctx = Helper.CreateTestContext();

        // Act
        var cut = ctx.RenderComponent<NotificationDrawerList>();

        // Assert
        cut.MarkupMatches(
@"
<ul
  class=""pf-c-notification-drawer__list""
/>
");
    }

    [Fact]
    public void WithAdditionalCssClassTest()
    {
        // Arrange
        using var ctx = Helper.CreateTestContext();

        // Act
        var cut = ctx.RenderComponent<NotificationDrawerList>(parameters => parameters
            .AddUnmatched("class", "extra-class")
        );

        // Assert
        cut.MarkupMatches(
@"
<ul
  class=""pf-c-notification-drawer__list extra-class""
/>
");
    }

    [Fact]
    public void WithAdditionalPropertiesOnRootElementTest()
    {
        // Arrange
        using var ctx = Helper.CreateTestContext();
        var testId = "notification-drawer";

        // Act
        var cut = ctx.RenderComponent<NotificationDrawerList>(parameters => parameters
            .AddUnmatched("data-testid", testId)
        );

        // Assert
        cut.MarkupMatches(
$@"
<ul
  class=""pf-c-notification-drawer__list""
  data-testid=""{testId}""
/>
");
    }

    [Fact]
    public void IsHiddenTest()
    {
        // Arrange
        using var ctx = Helper.CreateTestContext();

        // Act
        var cut = ctx.RenderComponent<NotificationDrawerList>(parameters => parameters
            .Add(p => p.IsHidden, true)
        );

        // Assert
        cut.MarkupMatches(
@"
<ul
  class=""pf-c-notification-drawer__list""
  hidden=""""
/>
");
    }
}
