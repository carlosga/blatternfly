namespace Blatternfly.UnitTests.Components;

public class NotificationBadgeTests
{
    [Theory]
    [InlineData(NotificationBadgeVariant.Read)]
    [InlineData(NotificationBadgeVariant.Unread)]
    public void IsReadTest(NotificationBadgeVariant variant)
    {
        // Arrange
        using var ctx = Helper.CreateTestContext();
        var variantClass = variant switch
        {
            NotificationBadgeVariant.Attention => "pf-m-attention",
            NotificationBadgeVariant.Read      => "pf-m-read",
            NotificationBadgeVariant.Unread    => "pf-m-unread",
            _                                  => null
        };

        // Act
        var cut = ctx.RenderComponent<NotificationBadge>(parameters => parameters
            .Add(p => p.Variant, variant)
        );

        // Assert
        cut.MarkupMatches(
$@"
<button
  aria-disabled=""false""
  class=""pf-c-button pf-m-plain""
  type=""button""
>
  <span
    class=""pf-c-notification-badge {variantClass}""
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
</button>
");
    }

    [Fact]
    public void NeedsAttentionTestTest()
    {
        // Arrange
        using var ctx = Helper.CreateTestContext();

        // Act
        var cut = ctx.RenderComponent<NotificationBadge>(parameters => parameters
            .Add(p => p.Variant, NotificationBadgeVariant.Attention)
            .AddChildContent("needs attention Badge")
        );

        // Assert
        cut.MarkupMatches(
@"
<button aria-disabled=""false"" class=""pf-c-button pf-m-plain"" type=""button"">
  <span class=""pf-c-notification-badge pf-m-attention"">
    needs attention Badge
  </span>
</button>
");
    }

    [Fact]
    public void NotificationCountTest()
    {
        // Arrange
        using var ctx = Helper.CreateTestContext();

        // Act
        var cut = ctx.RenderComponent<NotificationBadge>(parameters => parameters
            .Add(p => p.Variant, NotificationBadgeVariant.Read)
            .Add(p => p.Count, 3)
        );

        // Assert
        cut.MarkupMatches(
$@"
<button
  aria-disabled=""false""
  class=""pf-c-button pf-m-plain""
  type=""button""
>
  <span
    class=""pf-c-notification-badge pf-m-read""
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
    <span class=""pf-c-notification-badge__count"">3</span>
  </span>
</button>
");
    }
}
