namespace Blatternfly.UnitTests.Components;

public class DividerTests
{
    [Theory]
    [InlineData(DividerVariant.hr)]
    [InlineData(DividerVariant.li)]
    [InlineData(DividerVariant.div)]
    public void DividerVariantTest(DividerVariant variant)
    {
        // Arrange
        using var ctx = Helper.CreateTestContext();
        var element   = variant.ToString().ToLower();
        var role      = variant == DividerVariant.hr ? string.Empty : @"role=""separator""";

        // Act
        var cut = ctx.RenderComponent<Divider>(parameters => parameters
            .Add(p => p.Component, variant)
        );

        // Assert
        cut.MarkupMatches(
$@"
<{element}
  class=""pf-c-divider""
  {role}
/>");
    }

    [Fact]
    public void VerticalDividerTest()
    {
        // Arrange
        using var ctx = Helper.CreateTestContext();

        // Act
        var cut = ctx.RenderComponent<Divider>(parameters => parameters
            .Add(p => p.Orientation, new()  { Default = Orientation.Vertical })
        );

        // Assert
        cut.MarkupMatches(
@"
<hr
  class=""pf-c-divider pf-m-vertical""
/>");
    }
}
