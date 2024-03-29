﻿namespace Blatternfly.UnitTests.Components;

public class AlertTests
{
    private static string GetIconPath(AlertVariant variant)
    {
        return variant switch
        {
            AlertVariant.Success => CheckCircleIcon.IconDefinition.SvgPath,
            AlertVariant.Danger  => ExclamationCircleIcon.IconDefinition.SvgPath,
            AlertVariant.Warning => ExclamationTriangleIcon.IconDefinition.SvgPath,
            AlertVariant.Info    => InfoCircleIcon.IconDefinition.SvgPath,
            AlertVariant.Default => BellIcon.IconDefinition.SvgPath,
            _                    => ""
        };
    }
    private static string GetIconViewBox(AlertVariant variant)
    {
        return variant switch
        {
            AlertVariant.Success => CheckCircleIcon.IconDefinition.ViewBox,
            AlertVariant.Danger  => ExclamationCircleIcon.IconDefinition.ViewBox,
            AlertVariant.Warning => ExclamationTriangleIcon.IconDefinition.ViewBox,
            AlertVariant.Info    => InfoCircleIcon.IconDefinition.ViewBox,
            AlertVariant.Default => BellIcon.IconDefinition.ViewBox,
            _                    => ""
        };
    }

    [Fact]
    public void TruncateTitleTest()
    {
        // Arrange
        using var ctx = Helper.CreateTestContext();

        var iconPath  = GetIconPath(AlertVariant.Default);
        var viewBox   = GetIconViewBox(AlertVariant.Default);

        // Act
        var cut = ctx.RenderComponent<Alert>(parameters => parameters
            .Add(p => p.TruncateTitle, 1)
            .Add(p => p.Title, "this is a test")
            .AddChildContent("Alert testing")
        );

        // Assert
        cut.MarkupMatches(
@$"
<div
  aria-label=""Default Alert""
  class=""pf-c-alert""
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
    id=""pf-c-alert-title-1""
    class=""pf-c-alert__title pf-m-truncate""
    style=""--pf-c-alert__title--max-lines:1;""
  >
    <span
      class=""pf-u-screen-reader""
    >
      Default alert:
    </span>
    this is a test
  </h4>
  <div
    class=""pf-c-alert__description""
  >
    Alert testing
  </div>
</div>
");
    }

    [Theory]
    [InlineData(AlertVariant.Success)]
    [InlineData(AlertVariant.Danger)]
    [InlineData(AlertVariant.Warning)]
    [InlineData(AlertVariant.Info)]
    [InlineData(AlertVariant.Default)]
    public void DescriptionTest(AlertVariant variant)
    {
        // Arrange
        using var ctx = Helper.CreateTestContext();

        var variantText  = variant.ToString();
        var variantClass = variant == AlertVariant.Default ? "" : $"pf-m-{variantText.ToLower()}";
        var iconPath     = GetIconPath(variant);
        var viewBox      = GetIconViewBox(variant);

        // Act
        var cut = ctx.RenderComponent<Alert>(parameters => parameters
            .Add(p => p.Variant, variant)
            .Add(p => p.Title, "")
            .AddChildContent("Some alert")
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
    id=""pf-c-alert-title-1""
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

    [Theory]
    [InlineData(AlertVariant.Success)]
    [InlineData(AlertVariant.Danger)]
    [InlineData(AlertVariant.Warning)]
    [InlineData(AlertVariant.Info)]
    [InlineData(AlertVariant.Default)]
    public void TitleTest(AlertVariant variant)
    {
        // Arrange
        using var ctx = Helper.CreateTestContext();

        var variantText  = variant.ToString();
        var variantClass = variant == AlertVariant.Default ? "" : $"pf-m-{variantText.ToLower()}";
        var iconPath     = GetIconPath(variant);
        var viewBox      = GetIconViewBox(variant);

        // Act
        var cut = ctx.RenderComponent<Alert>(parameters => parameters
            .Add(p => p.Variant, variant)
            .Add(p => p.Title, "Some title")
            .AddChildContent("Some alert")
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
    id=""pf-c-alert-title-1""
    class=""pf-c-alert__title""
  >
    <span
      class=""pf-u-screen-reader""
    >
      {variantText} alert:
    </span>
    Some title
  </h4>
  <div
    class=""pf-c-alert__description""
  >
    Some alert
  </div>
</div>
");
    }

    [Theory]
    [InlineData(AlertVariant.Success)]
    [InlineData(AlertVariant.Danger)]
    [InlineData(AlertVariant.Warning)]
    [InlineData(AlertVariant.Info)]
    [InlineData(AlertVariant.Default)]
    public void HeadingLevel(AlertVariant variant)
    {
        // Arrange
        using var ctx = Helper.CreateTestContext();

        var variantText  = variant.ToString();
        var variantClass = variant == AlertVariant.Default ? "" : $"pf-m-{variantText.ToLower()}";
        var iconPath     = GetIconPath(variant);
        var viewBox      = GetIconViewBox(variant);

        // Act
        var cut = ctx.RenderComponent<Alert>(parameters => parameters
            .Add(p => p.Variant, variant)
            .Add(p => p.Title, "Some title")
            .Add(p => p.TitleHeadingLevel, Blatternfly.HeadingLevel.h1)
            .AddChildContent("Some alert")
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
      <path d=""{iconPath}"" />
    </svg>
  </div>
  <h1
    id=""pf-c-alert-title-1""
    class=""pf-c-alert__title""
  >
    <span
      class=""pf-u-screen-reader""
    >
      {variantText} alert:
    </span>
    Some title
  </h1>
  <div
    class=""pf-c-alert__description""
  >
    Some alert
  </div>
</div>
");
    }

    [Theory]
    [InlineData(AlertVariant.Success)]
    [InlineData(AlertVariant.Danger)]
    [InlineData(AlertVariant.Warning)]
    [InlineData(AlertVariant.Info)]
    [InlineData(AlertVariant.Default)]
    public void ActionLinkTest(AlertVariant variant)
    {
        // Arrange
        using var ctx = Helper.CreateTestContext();

        var variantText  = variant.ToString();
        var variantClass = variant == AlertVariant.Default ? "" : $"pf-m-{variantText.ToLower()}";
        var iconPath     = GetIconPath(variant);
        var viewBox      = GetIconViewBox(variant);

        // Act
        var cut = ctx.RenderComponent<Alert>(parameters => parameters
            .Add(p => p.Variant, variant)
            .Add<AlertActionLink>(p => p.ActionLinks, alparams => alparams
                .Add(p => p.ChildContent, "test")
             )
            .AddChildContent("Some alert")
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
      style=""vertical-align: -0.125em;""
      viewBox=""{viewBox}""
      width=""1em""
    >
      <path
        d=""{iconPath}""
      />
    </svg>
  </div>
  <h4
    id=""pf-c-alert-title-1""
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
  <div
    class=""pf-c-alert__action-group""
  >
    <button
      aria-disabled=""false""
      class=""pf-c-button pf-m-link pf-m-inline""
      type=""button""
    >
      test
    </button>
  </div>
</div>
");
    }

    [Theory]
    [InlineData(AlertVariant.Success)]
    [InlineData(AlertVariant.Danger)]
    [InlineData(AlertVariant.Warning)]
    [InlineData(AlertVariant.Info)]
    [InlineData(AlertVariant.Default)]
    public void CloseButtonTest(AlertVariant variant)
    {
        // Arrange
        using var ctx = Helper.CreateTestContext();

        var variantText         = variant.ToString();
        var variantClass        = variant == AlertVariant.Default ? "" : $"pf-m-{variantText.ToLower()}";
        var iconPath            = GetIconPath(variant);
        var viewBox             = GetIconViewBox(variant);
        var closeButtonViewBox  = TimesIcon.IconDefinition.ViewBox;
        var closeButtonIconPath = TimesIcon.IconDefinition.SvgPath;

        // Act
        var cut = ctx.RenderComponent<Alert>(parameters => parameters
            .Add(p => p.Variant, variant)
            .Add<AlertActionCloseButton>(p => p.ActionClose, alparams => alparams
                .Add(p => p.AriaLabel, "Close")
             )
            .Add(p => p.Title, $"Sample {variantText} alert")
            .AddChildContent("Some alert")
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
    id=""pf-c-alert-title-1""
    class=""pf-c-alert__title""
  >
    <span
      class=""pf-u-screen-reader""
    >
      {variantText} alert:
    </span>
    Sample {variantText} alert
  </h4>
  <div
    class=""pf-c-alert__action""
  >
    <button
      aria-disabled=""false""
      aria-label=""Close""
      class=""pf-c-button pf-m-plain""
      type=""button""
    >
      <svg
        aria-hidden=""true""
        fill=""currentColor""
        height=""1em""
        role=""img""
        style=""vertical-align: -0.125em""
        viewBox=""{closeButtonViewBox}""
        width=""1em""
      >
        <path
          d=""{closeButtonIconPath}""
        />
      </svg>
    </button>
  </div>
  <div
    class=""pf-c-alert__description""
  >
    Some alert
  </div>
</div>
");
    }

    [Theory]
    [InlineData(AlertVariant.Success)]
    [InlineData(AlertVariant.Danger)]
    [InlineData(AlertVariant.Warning)]
    [InlineData(AlertVariant.Info)]
    [InlineData(AlertVariant.Default)]
    public void CustomAriaLabelTest(AlertVariant variant)
    {
        // Arrange
        using var ctx = Helper.CreateTestContext();

        var variantText  = variant.ToString();
        var variantClass = variant == AlertVariant.Default ? "" : $"pf-m-{variantText.ToLower()}";
        var iconPath     = GetIconPath(variant);
        var viewBox      = GetIconViewBox(variant);

        // Act
        var cut = ctx.RenderComponent<Alert>(parameters => parameters
            .Add(p => p.Variant, variant)
            .Add(p => p.AriaLabel, $"Custom aria label for {variantText}")
            .Add(p => p.Title, "Some title")
            .Add<AlertActionLink>(p => p.ActionLinks, alparams => alparams
                .Add(p => p.ChildContent, "test")
             )
            .AddChildContent("Some alert")
        );

        // Assert
        cut.MarkupMatches(
@$"
<div
  aria-label=""Custom aria label for {variantText}""
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
      style=""vertical-align: -0.125em;""
      viewBox=""{viewBox}""
      width=""1em""
    >
      <path
        d=""{iconPath}""
      />
    </svg>
  </div>
  <h4
    id=""pf-c-alert-title-1""
    class=""pf-c-alert__title""
  >
    <span
      class=""pf-u-screen-reader""
    >
      {variantText} alert:
    </span>
    Some title
  </h4>
  <div
    class=""pf-c-alert__description""
  >
    Some alert
  </div>
  <div
    class=""pf-c-alert__action-group""
  >
    <button
      aria-disabled=""false""
      class=""pf-c-button pf-m-link pf-m-inline""
      type=""button""
    >
      test
    </button>
  </div>
</div>
");
    }

    [Theory]
    [InlineData(AlertVariant.Success)]
    [InlineData(AlertVariant.Danger)]
    [InlineData(AlertVariant.Warning)]
    [InlineData(AlertVariant.Info)]
    [InlineData(AlertVariant.Default)]
    public void InlineVariationTest(AlertVariant variant)
    {
        // Arrange
        using var ctx = Helper.CreateTestContext();

        var variantText  = variant.ToString();
        var variantClass = variant == AlertVariant.Default ? "" : $"pf-m-{variantText.ToLower()}";
        var iconPath     = GetIconPath(variant);
        var viewBox      = GetIconViewBox(variant);

        // Act
        var cut = ctx.RenderComponent<Alert>(parameters => parameters
            .Add(p => p.Variant, variant)
            .Add(p => p.IsInline, true)
            .Add(p => p.Title, "Some title")
            .AddChildContent("Some alert")
        );

        // Assert
        cut.MarkupMatches(
@$"
<div
  aria-label=""{variantText} Alert""
  class=""pf-c-alert {variantClass} pf-m-inline""
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
    id=""pf-c-alert-title-1""
    class=""pf-c-alert__title""
  >
    <span
      class=""pf-u-screen-reader""
    >
      {variantText} alert:
    </span>
    Some title
  </h4>
  <div
    class=""pf-c-alert__description""
  >
    Some alert
  </div>
</div>
");
    }

    [Theory]
    [InlineData(AlertVariant.Success)]
    [InlineData(AlertVariant.Danger)]
    [InlineData(AlertVariant.Warning)]
    [InlineData(AlertVariant.Info)]
    [InlineData(AlertVariant.Default)]
    public void PlainVariationTest(AlertVariant variant)
    {
        // Arrange
        using var ctx = Helper.CreateTestContext();

        var variantText  = variant.ToString();
        var variantClass = variant == AlertVariant.Default ? "" : $"pf-m-{variantText.ToLower()}";
        var iconPath     = GetIconPath(variant);
        var viewBox      = GetIconViewBox(variant);

        // Act
        var cut = ctx.RenderComponent<Alert>(parameters => parameters
            .Add(p => p.Variant, variant)
            .Add(p => p.IsPlain, true)
            .Add(p => p.Title, "Some title")
            .AddChildContent("Some alert")
        );

        // Assert
        cut.MarkupMatches(
@$"
<div
  aria-label=""{variantText} Alert""
  class=""pf-c-alert {variantClass} pf-m-plain""
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
    id=""pf-c-alert-title-1""
    class=""pf-c-alert__title""
  >
    <span
      class=""pf-u-screen-reader""
    >
      {variantText} alert:
    </span>
    Some title
  </h4>
  <div
    class=""pf-c-alert__description""
  >
    Some alert
  </div>
</div>
");
    }

    [Theory]
    [InlineData(AlertVariant.Success)]
    [InlineData(AlertVariant.Danger)]
    [InlineData(AlertVariant.Warning)]
    [InlineData(AlertVariant.Info)]
    [InlineData(AlertVariant.Default)]
    public void ExpandableVariation(AlertVariant variant)
    {
        // Arrange
        using var ctx = Helper.CreateTestContext();

        var variantText  = variant.ToString();
        var variantClass = variant == AlertVariant.Default ? "" : $"pf-m-{variantText.ToLower()}";
        var iconPath     = GetIconPath(variant);
        var viewBox      = GetIconViewBox(variant);

        // Act
        var cut = ctx.RenderComponent<Alert>(parameters => parameters
            .Add(p => p.Variant, variant)
            .Add(p => p.IsExpandable, true)
            .Add(p => p.Title, "Some title")
            .AddChildContent("<p>Success alert description. This should tell the user more information about the alert.</p>")
        );

        // Assert
        cut.MarkupMatches(
$@"
<div
  aria-label=""{variantText} Alert""
  class=""pf-c-alert pf-m-expandable {variantClass}""
>
  <div
    class=""pf-c-alert__toggle""
  >
    <button
      aria-disabled=""false""
      aria-label=""{variantText} alert details""
      class=""pf-c-button pf-m-plain""
      type=""button""
    >
      <span
        class=""pf-c-alert__toggle-icon""
      >
        <svg
            aria-hidden=""true""
            fill=""currentColor""
            height=""1em""
            role=""img""
            style=""vertical-align: -0.125em""
            viewBox=""{AngleRightIcon.IconDefinition.ViewBox}""
            width=""1em""
        >
            <path d=""{AngleRightIcon.IconDefinition.SvgPath}"" />
        </svg>
      </span>
    </button>
  </div>
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
        <path d=""{iconPath}"" />
    </svg>
  </div>
  <h4
    id=""pf-c-alert-title-1""
    class=""pf-c-alert__title""
  >
    <span
      class=""pf-u-screen-reader""
    >
      {variantText} alert:
    </span>
    Some title
  </h4>
</div>
");
    }

    [Theory]
    [InlineData(AlertVariant.Success)]
    [InlineData(AlertVariant.Danger)]
    [InlineData(AlertVariant.Warning)]
    [InlineData(AlertVariant.Info)]
    [InlineData(AlertVariant.Default)]
    public void ToastAlertTest(AlertVariant variant)
    {
        // Arrange
        using var ctx = Helper.CreateTestContext();

        var variantText  = variant.ToString();
        var variantClass = variant == AlertVariant.Default ? "" : $"pf-m-{variantText.ToLower()}";
        var iconPath     = GetIconPath(variant);
        var viewBox      = GetIconViewBox(variant);

        // Act
        var cut = ctx.RenderComponent<Alert>(parameters => parameters
            .Add(p => p.IsLiveRegion, true)
            .Add(p => p.Variant, variant)
            .Add(p => p.AriaLabel, $"{variantText} toast alert")
            .Add(p => p.Title, "Some title")
            .AddChildContent("Some toast alert")
        );

        // Assert
        cut.MarkupMatches(
@$"
<div
  aria-atomic=""false""
  aria-label=""{variantText} toast alert""
  aria-live=""polite""
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
    id=""pf-c-alert-title-1""
    class=""pf-c-alert__title""
  >
    <span
      class=""pf-u-screen-reader""
    >
      {variantText} alert:
    </span>
    Some title
  </h4>
  <div
    class=""pf-c-alert__description""
  >
    Some toast alert
  </div>
</div>
");
    }

    [Theory]
    [InlineData(AlertVariant.Success)]
    [InlineData(AlertVariant.Danger)]
    [InlineData(AlertVariant.Warning)]
    [InlineData(AlertVariant.Info)]
    [InlineData(AlertVariant.Default)]
    public void CustomIconTest(AlertVariant variant)
    {
        // Arrange
        using var ctx = Helper.CreateTestContext();

        var variantText  = variant.ToString();
        var variantClass = variant == AlertVariant.Default ? "" : $"pf-m-{variantText.ToLower()}";
        var iconPath     = UsersIcon.IconDefinition.SvgPath;
        var viewBox      = UsersIcon.IconDefinition.ViewBox;

        // Act
        var cut = ctx.RenderComponent<Alert>(parameters => parameters
            .Add(p => p.Variant, variant)
            .Add(p => p.AriaLabel, $"{variantText} custom icon alert")
            .Add(p => p.Title, "custom icon alert title")
            .Add<UsersIcon>(p => p.CustomIcon)
            .AddChildContent("Some noisy alert")
        );

        // Assert
        cut.MarkupMatches(
@$"
<div
  aria-label=""{variantText} custom icon alert""
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
    id=""pf-c-alert-title-1""
    class=""pf-c-alert__title""
  >
    <span
      class=""pf-u-screen-reader""
    >
      {variantText} alert:
    </span>
    custom icon alert title
  </h4>
  <div
    class=""pf-c-alert__description""
  >
    Some noisy alert
  </div>
</div>
");
    }
}
