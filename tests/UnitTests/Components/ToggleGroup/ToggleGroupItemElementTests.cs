namespace Blatternfly.UnitTests.Components;

public class ToggleGroupItemElementTests
{
    [Fact]
    public void TextVariantTest()
    {
        // Arrange
        using var ctx = Helper.CreateTestContext();

        // Act
        var cut = ctx.RenderComponent<ToggleGroupItemElement>(properties => properties
            .Add(p => p.Variant, ToggleGroupItemVariant.Text)
            .AddChildContent("Test")
        );

        // Assert
        cut.MarkupMatches(
@"
<span
  class=""pf-c-toggle-group__text""
>
  Test
</span>
");
    }

    [Fact]
    public void IconVariantTest()
    {
        // Arrange
        using var ctx = Helper.CreateTestContext();

        // Act
        var cut = ctx.RenderComponent<ToggleGroupItemElement>(properties => properties
            .Add(p => p.Variant, ToggleGroupItemVariant.Icon)
            .AddChildContent("ICON")
        );

        // Assert
        cut.MarkupMatches(
@"
<span
  class=""pf-c-toggle-group__icon""
>
  ICON
</span>
");
    }

    [Fact]
    public void EmptyTest()
    {
        // Arrange
        using var ctx = Helper.CreateTestContext();

        // Act
        var cut = ctx.RenderComponent<ToggleGroupItemElement>();

        // Assert
        cut.MarkupMatches(
@"
<span />
");
    }
}
