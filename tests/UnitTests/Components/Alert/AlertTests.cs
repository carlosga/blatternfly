using Blatternfly.Components;
using Bunit;
using Xunit;

namespace Blatternfly.UnitTests.Components.Alert
{
    public class AlertTests
    {
        [Theory]
        [InlineData(AlertVariant.Success)]
        [InlineData(AlertVariant.Danger)]
        [InlineData(AlertVariant.Warning)]
        [InlineData(AlertVariant.Info)]
        [InlineData(AlertVariant.Default)]
        public void VariantDescriptionTest(AlertVariant variant)
        {
            // Arrange
            using var ctx = new TestContext();
            var variantText  = variant.ToString();
            var variantClass = variant == AlertVariant.Default ? "" : $"pf-m-{variantText.ToLower()}";
            var iconPath     = variant switch
            {
                AlertVariant.Success => CheckCircleIcon.SvgPath,
                AlertVariant.Danger  => ExclamationCircleIcon.SvgPath,
                AlertVariant.Warning => ExclamationTriangleIcon.SvgPath,
                AlertVariant.Info    => InfoCircleIcon.SvgPath,
                AlertVariant.Default => BellIcon.SvgPath,
                _                    => ""
            };
            var viewBox = variant switch
            {
                AlertVariant.Success => CheckCircleIcon.IconDefinition.ViewBox,
                AlertVariant.Danger  => ExclamationCircleIcon.IconDefinition.ViewBox,
                AlertVariant.Warning => ExclamationTriangleIcon.IconDefinition.ViewBox,
                AlertVariant.Info    => InfoCircleIcon.IconDefinition.ViewBox,
                AlertVariant.Default => BellIcon.IconDefinition.ViewBox,
                _                    => ""
            };

            // Act
            var cut = ctx.RenderComponent<Blatternfly.Components.Alert>(parameters => parameters
                .Add(p => p.Variant, variant)
                .Add(p => p.Title, "")
                .AddChildContent($"Some alert")
            );

            // Assert
            cut.MarkupMatches(
@$"
<div
  aria-label=""{variantText} Alert""
  class=""pf-c-alert {variantClass}""
>
  <div
      class=""pf-c-alert__icon""
  >
    <svg
        aria-hidden=""true""
        fill=""currentColor""
        height=""1em""
        role=""img""
        style=""vertical-align: -0.125em""
        viewBox=""{viewBox}""
        width=""1em""
    >
        <path
        d=""{iconPath}""
        />
    </svg>
  </div>
  <h4
    class=""pf-c-alert__title""
  >
    <span
      class=""pf-u-screen-reader""
    >
      {variantText} alert:
    </span>
  </h4>
  <div
    class=""pf-c-alert__description""
  >
    Some alert
  </div>
</div>
");            
        }        
    }
}
