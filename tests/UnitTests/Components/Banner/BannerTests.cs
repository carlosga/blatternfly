using System.Collections.Generic;
using Blatternfly.Components;
using Bunit;
using Xunit;

namespace Blatternfly.UnitTests.Components
{
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
            using var ctx = new TestContext();
            var variantCssClass = variant == BannerVariant.Default ? string.Empty : $"pf-m-{variant.ToString().ToLower()}";
            var label           = variant.ToString().ToLower();

            // Act
            var cut = ctx.RenderComponent<Banner>(parameters => parameters
                .Add(p => p.Variant, variant)
                .Add(p => p.AdditionalAttributes, new Dictionary<string, object> { { "aria-label", label } })
                .AddChildContent($"{label} Banner")
            );

            // Assert
            cut.MarkupMatches(
                @$"
<div
  class=""pf-c-banner {variantCssClass}""
>
  {label} 
   Banner
</div>
");            
        }

        [Fact]
        public void StickyBannerTest()
        {
            // Arrange
            using var ctx = new TestContext();
            var label     = "sticky";

            // Act
            var cut = ctx.RenderComponent<Banner>(parameters => parameters
                .Add(p => p.IsSticky, true)
                .Add(p => p.AdditionalAttributes, new Dictionary<string, object> { { "aria-label", label } })
                .AddChildContent($"{label} Banner")
            );

            // Assert
            cut.MarkupMatches(
                @$"
<div
  class=""pf-c-banner pf-m-sticky""
>
  {label} 
    Banner
</div>
");            
        }         
    }
}
