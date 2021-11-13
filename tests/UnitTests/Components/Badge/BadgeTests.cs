namespace Blatternfly.UnitTests.Components;

public class BadgeUnitTests
{
    [Theory]
    [InlineData(true)]
    [InlineData(false)]
    public void BadgeTest(bool isRead)
    {
        // Arrange
        using var ctx = new TestContext();
        var fragment = isRead ? "read" : "unread";

        // Act
        var cut = ctx.RenderComponent<Badge>(parameters => parameters
            .Add(p => p.IsRead, isRead)
            .AddChildContent($"{fragment} Badge")
        );
        
        // Assert
        cut.MarkupMatches(
$@"
<span
  class=""pf-c-badge pf-m-{fragment}""
>
  {fragment}
   Badge
</span>
");            
    }
}
