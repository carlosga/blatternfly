namespace Blatternfly.UnitTests.Components;

public class HelperTextItemTests
{
    [Theory]
    [InlineData(HelperTextItemVariant.Default)]
    [InlineData(HelperTextItemVariant.Indeterminate)]
    [InlineData(HelperTextItemVariant.Warning)]
    [InlineData(HelperTextItemVariant.Success)]
    [InlineData(HelperTextItemVariant.Error)]
    public void VariantTests(HelperTextItemVariant variant)
    {
        // Arrange
        using var ctx = Helper.CreateTestContext();
        var variantString = variant == HelperTextItemVariant.Default ? "div" : variant.ToString();
        var variantClass = variant switch
        {
            HelperTextItemVariant.Indeterminate => "pf-m-indeterminate",
            HelperTextItemVariant.Warning       => "pf-m-warning",
            HelperTextItemVariant.Success       => "pf-m-success",
            HelperTextItemVariant.Error         => "pf-m-error",
            _                                   => null
        };

        // Act
        var cut = ctx.RenderComponent<HelperTextItem>(parameters => parameters
            .Add(p => p.Variant, variant)
            .Add(p => p.ChildContent, $"{variantString} help test text")
        );

        // Assert
        cut.MarkupMatches(
$@"
<div
  class=""pf-c-helper-text__item {variantClass}""
>
  <span
    class=""pf-c-helper-text__item-text""
  >
    {variantString} help test text
  </span>
</div>
");
    }

    [Theory]
    [InlineData(HelperTextItemVariant.Default)]
    [InlineData(HelperTextItemVariant.Indeterminate)]
    [InlineData(HelperTextItemVariant.Warning)]
    [InlineData(HelperTextItemVariant.Success)]
    [InlineData(HelperTextItemVariant.Error)]
    public void DefaultIconsForDynamicItemsTest(HelperTextItemVariant variant)
    {
        // Arrange
        using var ctx = Helper.CreateTestContext();
        var variantClass = variant switch
        {
            HelperTextItemVariant.Indeterminate => "pf-m-indeterminate",
            HelperTextItemVariant.Warning       => "pf-m-warning",
            HelperTextItemVariant.Success       => "pf-m-success",
            HelperTextItemVariant.Error         => "pf-m-error",
            _                                   => null
        };
        var icon = variant switch
        {
            HelperTextItemVariant.Warning => ExclamationTriangleIcon.IconDefinition,
            HelperTextItemVariant.Success => CheckCircleIcon.IconDefinition,
            HelperTextItemVariant.Error   => ExclamationCircleIcon.IconDefinition,
            _                             => MinusIcon.IconDefinition
        };

        // Act
        var cut = ctx.RenderComponent<HelperTextItem>(parameters => parameters
            .Add(p => p.IsDynamic, true)
            .Add(p => p.Variant, variant)
            .Add(p => p.ChildContent, "help test text")
        );

        // Assert
        cut.MarkupMatches(
$@"
<div
  class=""pf-c-helper-text__item {variantClass} pf-m-dynamic""
>
  <span
    aria-hidden=""true""
    class=""pf-c-helper-text__item-icon""
  >
    <svg
      aria-hidden=""true""
      fill=""currentColor""
      height=""1em""
      role=""img""
      style=""vertical-align: -0.125em""
      viewBox=""{icon.ViewBox}""
      width=""1em""
    >
      <path
        d=""{icon.SvgPath}""
      />
    </svg>
  </span>
  <span
    class=""pf-c-helper-text__item-text""
  >
    help test text
    <span
      class=""pf-u-screen-reader""
    >
      : {variant} status;
    </span>
  </span>
</div>
");
    }
}
