namespace Blatternfly.UnitTests.Components;

public class BannerTests
{
    [Theory]
    [InlineData(BannerVariant.Default)]
    [InlineData(BannerVariant.Success)]
    [InlineData(BannerVariant.Danger)]
    [InlineData(BannerVariant.Warning)]
    [InlineData(BannerVariant.Info)]
    public void BannerVariantTest(BannerVariant variant)
    {
        // Arrange
        using var ctx = Helper.CreateTestContext();
        var variantCssClass = variant == BannerVariant.Default ? string.Empty : $"pf-m-{variant.ToString().ToLower()}";
        var label           = variant.ToString().ToLower();
        var readerText      = $"{variant} banner";

        // Act
        var cut = ctx.RenderComponent<Banner>(parameters => parameters
            .AddUnmatched("aria-label", label)
            .Add(p => p.Variant, variant)
            .AddChildContent($"{label} banner")
        );

        // Assert
        cut.MarkupMatches(
$@"
<div
  aria-label=""{label}""
  class=""pf-c-banner {variantCssClass}""
>
  {label} banner
  <span class=""pf-u-screen-reader"">{readerText}</span>
</div>
");
    }

    [Fact]
    public void StickyBannerTest()
    {
        // Arrange
        using var ctx  = Helper.CreateTestContext();
        var label      = "sticky";

        // Act
        var cut = ctx.RenderComponent<Banner>(parameters => parameters
            .AddUnmatched("aria-label", label)
            .Add(p => p.IsSticky, true)
            .AddChildContent($"{label} banner")
        );

        // Assert
        cut.MarkupMatches(
$@"
<div
  aria-label=""{label}""
  class=""pf-c-banner pf-m-sticky""
>
  {label} banner
  <span class=""pf-u-screen-reader"">Default banner</span>
</div>
");
    }
}
