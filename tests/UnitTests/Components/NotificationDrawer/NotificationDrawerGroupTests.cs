namespace Blatternfly.UnitTests.Components;

public class NotificationDrawerGroupTests
{
    [Fact]
    public void DefaultTest()
    {
        // Arrange
        using var ctx = new TestContext();

        // Act
        var cut = ctx.RenderComponent<NotificationDrawerGroup>(parameters => parameters
            .Add(p => p.Count, 2)
            .Add(p => p.IsExpanded, false)
            .Add(p => p.Title, "Critical Alerts")
        );

        // Assert
        cut.MarkupMatches(
$@"
<section
  class=""pf-c-notification-drawer__group""
>
  <h1>
    <button
      aria-expanded=""false""
      class=""pf-c-notification-drawer__group-toggle""
    >
      <div
        class=""pf-c-notification-drawer__group-toggle-title""
      >
        Critical Alerts
      </div>
      <div
        class=""pf-c-notification-drawer__group-toggle-count""
      >
        <span
          class=""pf-c-badge pf-m-unread""
        >
          2
        </span>
      </div>
      <span
        class=""pf-c-notification-drawer__group-toggle-icon""
      >
        <svg
          style=""vertical-align: -0.125em;"" 
          fill=""currentColor"" 
          height=""1em"" 
          width=""1em"" 
          viewBox=""{AngleRightIcon.IconDefinition.ViewBox}"" 
          aria-hidden=""true"" 
          role=""img""
        >
          <path d=""{AngleRightIcon.IconDefinition.SvgPath}""></path>
        </svg>
      </span>
    </button>
  </h1>
</section>
");
    }
    
    [Fact]
    public void WithAdditionaCssClassTest()
    {
        // Arrange
        using var ctx = new TestContext();

        // Act
        var cut = ctx.RenderComponent<NotificationDrawerGroup>(parameters => parameters
            .Add(p => p.Count, 2)
            .Add(p => p.IsExpanded, false)
            .Add(p => p.Title, "Critical Alerts")
            .AddUnmatched("class", "extra-class")
        );

        // Assert
        cut.MarkupMatches(
$@"
<section
  class=""pf-c-notification-drawer__group extra-class""
>
  <h1>
    <button
      aria-expanded=""false""
      class=""pf-c-notification-drawer__group-toggle""
    >
      <div
        class=""pf-c-notification-drawer__group-toggle-title""
      >
        Critical Alerts
      </div>
      <div
        class=""pf-c-notification-drawer__group-toggle-count""
      >
        <span
          class=""pf-c-badge pf-m-unread""
        >
          2
        </span>
      </div>
      <span
        class=""pf-c-notification-drawer__group-toggle-icon""
      >
        <svg
          style=""vertical-align: -0.125em;"" 
          fill=""currentColor"" 
          height=""1em"" 
          width=""1em"" 
          viewBox=""{AngleRightIcon.IconDefinition.ViewBox}"" 
          aria-hidden=""true"" 
          role=""img""
        >
          <path d=""{AngleRightIcon.IconDefinition.SvgPath}""></path>
        </svg>
      </span>
    </button>
  </h1>
</section>
");
    }
    
    [Fact]
    public void WithAdditionaPropertiesOnRootNodeTest()
    {
        // Arrange
        using var ctx = new TestContext();
        var testId = "notification-drawer";

        // Act
        var cut = ctx.RenderComponent<NotificationDrawerGroup>(parameters => parameters
            .Add(p => p.Count, 2)
            .Add(p => p.IsExpanded, false)
            .Add(p => p.Title, "Critical Alerts")
            .AddUnmatched("data-testid", testId)
        );

        // Assert
        cut.MarkupMatches(
$@"
<section
  class=""pf-c-notification-drawer__group""
  data-testid=""{testId}""
>
  <h1>
    <button
      aria-expanded=""false""
      class=""pf-c-notification-drawer__group-toggle""
    >
      <div
        class=""pf-c-notification-drawer__group-toggle-title""
      >
        Critical Alerts
      </div>
      <div
        class=""pf-c-notification-drawer__group-toggle-count""
      >
        <span
          class=""pf-c-badge pf-m-unread""
        >
          2
        </span>
      </div>
      <span
        class=""pf-c-notification-drawer__group-toggle-icon""
      >
        <svg
          style=""vertical-align: -0.125em;"" 
          fill=""currentColor"" 
          height=""1em"" 
          width=""1em"" 
          viewBox=""{AngleRightIcon.IconDefinition.ViewBox}"" 
          aria-hidden=""true"" 
          role=""img""
        >
          <path d=""{AngleRightIcon.IconDefinition.SvgPath}""></path>
        </svg>
      </span>
    </button>
  </h1>
</section>
");
    }
    
    [Fact]
    public void IsExpandedTest()
    {
        // Arrange
        using var ctx = new TestContext();

        // Act
        var cut = ctx.RenderComponent<NotificationDrawerGroup>(parameters => parameters
            .Add(p => p.Count, 2)
            .Add(p => p.IsExpanded, true)
            .Add(p => p.Title, "Critical Alerts")
        );

        // Assert
        cut.MarkupMatches(
$@"
<section
  class=""pf-c-notification-drawer__group pf-m-expanded""
>
  <h1>
    <button
      aria-expanded=""true""
      class=""pf-c-notification-drawer__group-toggle""
    >
      <div
        class=""pf-c-notification-drawer__group-toggle-title""
      >
        Critical Alerts
      </div>
      <div
        class=""pf-c-notification-drawer__group-toggle-count""
      >
        <span
          class=""pf-c-badge pf-m-unread""
        >
          2
        </span>
      </div>
      <span
        class=""pf-c-notification-drawer__group-toggle-icon""
      >
        <svg
          style=""vertical-align: -0.125em;"" 
          fill=""currentColor"" 
          height=""1em"" 
          width=""1em"" 
          viewBox=""{AngleRightIcon.IconDefinition.ViewBox}"" 
          aria-hidden=""true"" 
          role=""img""
        >
          <path d=""{AngleRightIcon.IconDefinition.SvgPath}""></path>
        </svg>
      </span>
    </button>
  </h1>
</section>
");
    }
    
    [Fact]
    public void IsReadTest()
    {
        // Arrange
        using var ctx = new TestContext();

        // Act
        var cut = ctx.RenderComponent<NotificationDrawerGroup>(parameters => parameters
            .Add(p => p.Count, 2)
            .Add(p => p.IsExpanded, false)
            .Add(p => p.Title, "Critical Alerts")
            .Add(p => p.IsRead, true)
        );

        // Assert
        cut.MarkupMatches(
$@"
<section
  class=""pf-c-notification-drawer__group""
>
  <h1>
    <button
      aria-expanded=""false""
      class=""pf-c-notification-drawer__group-toggle""
    >
      <div
        class=""pf-c-notification-drawer__group-toggle-title""
      >
        Critical Alerts
      </div>
      <div
        class=""pf-c-notification-drawer__group-toggle-count""
      >
        <span
          class=""pf-c-badge pf-m-read""
        >
          2
        </span>
      </div>
      <span
        class=""pf-c-notification-drawer__group-toggle-icon""
      >
        <svg
          style=""vertical-align: -0.125em;"" 
          fill=""currentColor"" 
          height=""1em"" 
          width=""1em"" 
          viewBox=""{AngleRightIcon.IconDefinition.ViewBox}"" 
          aria-hidden=""true"" 
          role=""img""
        >
          <path d=""{AngleRightIcon.IconDefinition.SvgPath}""></path>
        </svg>
      </span>
    </button>
  </h1>
</section>
");
    }
}
