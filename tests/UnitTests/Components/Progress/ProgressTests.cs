namespace Blatternfly.UnitTests.Components;

public class ProgressTests
{
    [Fact]
    public void DefaultTest()
    {
        // Arrange
        using var ctx = Helper.CreateTestContext();

        // Act
        var cut = ctx.RenderComponent<Progress>(parameters => parameters
            .AddUnmatched("id", "progress-simple-example")
            .Add(p => p.Value, 33)
        );

        // Assert
        cut.MarkupMatches(
@"
<div
  class=""pf-c-progress pf-m-singleline""
  id=""progress-simple-example""
>
  <div
    aria-hidden=""true""
    class=""pf-c-progress__description""
    id=""progress-simple-example-description""
  ></div>
  <div
    aria-hidden=""true""
    class=""pf-c-progress__status""
  >
    <span
      class=""pf-c-progress__measure""
    >
      33%
    </span>
  </div>
  <div
    aria-valuemax=""100""
    aria-valuemin=""0""
    aria-valuenow=""33""
    class=""pf-c-progress__bar""
    role=""progressbar""
  >
    <div
      class=""pf-c-progress__indicator""
      style=""width: 33%""
    >
      <span
        class=""pf-c-progress__measure""
      />
    </div>
  </div>
</div>
");
    }

    [Fact]
    public void WithoutValueTest()
    {
        // Arrange
        using var ctx = Helper.CreateTestContext();

        // Act
        var cut = ctx.RenderComponent<Progress>(parameters => parameters
            .AddUnmatched("id", "no-value")
        );

        // Assert
        cut.MarkupMatches(
@"
<div
  class=""pf-c-progress pf-m-singleline""
  id=""no-value""
>
  <div
    aria-hidden=""true""
    class=""pf-c-progress__description""
    id=""no-value-description""
  ></div>
  <div
    aria-hidden=""true""
    class=""pf-c-progress__status""
  >
    <span
      class=""pf-c-progress__measure""
    >
      0%
    </span>
  </div>
  <div
    aria-valuemax=""100""
    aria-valuemin=""0""
    aria-valuenow=""0""
    class=""pf-c-progress__bar""
    role=""progressbar""
  >
    <div
      class=""pf-c-progress__indicator""
      style=""width: 0%""
    >
      <span
        class=""pf-c-progress__measure""
      />
    </div>
  </div>
</div>
");
    }

    [Fact]
    public void WithAdditionalLabelTest()
    {
        // Arrange
        using var ctx = Helper.CreateTestContext();

        // Act
        var cut = ctx.RenderComponent<Progress>(parameters => parameters
            .AddUnmatched("id", "additional-label")
            .Add(p => p.Label, "Additional label")
            .Add(p => p.Value, 33)
        );

        // Assert
        cut.MarkupMatches(
@"
<div
  class=""pf-c-progress pf-m-singleline""
  id=""additional-label""
>
  <div
    aria-hidden=""true""
    class=""pf-c-progress__description""
    id=""additional-label-description""
  ></div>
  <div
    aria-hidden=""true""
    class=""pf-c-progress__status""
  >
    <span
      class=""pf-c-progress__measure""
    >
      Additional label
    </span>
  </div>
  <div
    aria-valuemax=""100""
    aria-valuemin=""0""
    aria-valuenow=""33""
    class=""pf-c-progress__bar""
    role=""progressbar""
  >
    <div
      class=""pf-c-progress__indicator""
      style=""width: 33%""
    >
      <span
        class=""pf-c-progress__measure""
      />
    </div>
  </div>
</div>
");
    }

    [Fact]
    public void WithAriaValueTest()
    {
        // Arrange
        using var ctx = Helper.CreateTestContext();

        // Act
        var cut = ctx.RenderComponent<Progress>(parameters => parameters
            .AddUnmatched("id", "progress-aria-valuetext")
            .Add(p => p.Value, 33)
            .Add(p => p.ValueText, "Descriptive text here")
        );

        // Assert
        cut.MarkupMatches(
@"
<div
  class=""pf-c-progress pf-m-singleline""
  id=""progress-aria-valuetext""
>
  <div
    aria-hidden=""true""
    class=""pf-c-progress__description""
    id=""progress-aria-valuetext-description""
  ></div>
  <div
    aria-hidden=""true""
    class=""pf-c-progress__status""
  >
    <span
      class=""pf-c-progress__measure""
    >
      33%
    </span>
  </div>
  <div
    aria-valuemax=""100""
    aria-valuemin=""0""
    aria-valuenow=""33""
    aria-valuetext=""Descriptive text here""
    class=""pf-c-progress__bar""
    role=""progressbar""
  >
    <div
      class=""pf-c-progress__indicator""
      style=""width: 33%""
    >
      <span
        class=""pf-c-progress__measure""
      />
    </div>
  </div>
</div>
");
    }

    [Fact]
    public void WithValueLowerTahnMinValueTest()
    {
        // Arrange
        using var ctx = Helper.CreateTestContext();

        // Act
        var cut = ctx.RenderComponent<Progress>(parameters => parameters
            .AddUnmatched("id", "lower-min-value")
            .Add(p => p.Value, 33)
            .Add(p => p.Min, 40)
        );

        // Assert
        cut.MarkupMatches(
@"
<div
  class=""pf-c-progress pf-m-singleline""
  id=""lower-min-value""
>
  <div
    aria-hidden=""true""
    class=""pf-c-progress__description""
    id=""lower-min-value-description""
  ></div>
  <div
    aria-hidden=""true""
    class=""pf-c-progress__status""
  >
    <span
      class=""pf-c-progress__measure""
    >
      0%
    </span>
  </div>
  <div
    aria-valuemax=""100""
    aria-valuemin=""40""
    aria-valuenow=""33""
    class=""pf-c-progress__bar""
    role=""progressbar""
  >
    <div
      class=""pf-c-progress__indicator""
      style=""width: 0%""
    >
      <span
        class=""pf-c-progress__measure""
      />
    </div>
  </div>
</div>
");
    }

    [Fact]
    public void WithValueHigherThanMaxValueTest()
    {
        // Arrange
        using var ctx = Helper.CreateTestContext();

        // Act
        var cut = ctx.RenderComponent<Progress>(parameters => parameters
            .AddUnmatched("id", "higher-max-value")
            .Add(p => p.Value, 77)
            .Add(p => p.Max, 60)
        );

        // Assert
        cut.MarkupMatches(
@"
<div
  class=""pf-c-progress pf-m-singleline""
  id=""higher-max-value""
>
  <div
    aria-hidden=""true""
    class=""pf-c-progress__description""
    id=""higher-max-value-description""
  ></div>
  <div
    aria-hidden=""true""
    class=""pf-c-progress__status""
  >
    <span
      class=""pf-c-progress__measure""
    >
      100%
    </span>
  </div>
  <div
    aria-valuemax=""60""
    aria-valuemin=""0""
    aria-valuenow=""77""
    class=""pf-c-progress__bar""
    role=""progressbar""
  >
    <div
      class=""pf-c-progress__indicator""
      style=""width: 100%""
    >
      <span
        class=""pf-c-progress__measure""
      />
    </div>
  </div>
</div>
");
    }

    [Fact]
    public void WithValueScaledWithMinValueTest()
    {
        // Arrange
        using var ctx = Helper.CreateTestContext();

        // Act
        var cut = ctx.RenderComponent<Progress>(parameters => parameters
            .AddUnmatched("id", "scaled-min-value")
            .Add(p => p.Min, 10)
            .Add(p => p.Value, 50)
        );

        // Assert
        cut.MarkupMatches(
@"
<div
  class=""pf-c-progress pf-m-singleline""
  id=""scaled-min-value""
>
  <div
    aria-hidden=""true""
    class=""pf-c-progress__description""
    id=""scaled-min-value-description""
  ></div>
  <div
    aria-hidden=""true""
    class=""pf-c-progress__status""
  >
    <span
      class=""pf-c-progress__measure""
    >
      44%
    </span>
  </div>
  <div
    aria-valuemax=""100""
    aria-valuemin=""10""
    aria-valuenow=""50""
    class=""pf-c-progress__bar""
    role=""progressbar""
  >
    <div
      class=""pf-c-progress__indicator""
      style=""width: 44%""
    >
      <span
        class=""pf-c-progress__measure""
      />
    </div>
  </div>
</div>
");
    }

    [Fact]
    public void WithValueScaledWithMaxValueTest()
    {
        // Arrange
        using var ctx = Helper.CreateTestContext();

        // Act
        var cut = ctx.RenderComponent<Progress>(parameters => parameters
            .AddUnmatched("id", "scaled-max-value")
            .Add(p => p.Value, 50)
            .Add(p => p.Max, 80)
        );

        // Assert
        cut.MarkupMatches(
@"
<div
  class=""pf-c-progress pf-m-singleline""
  id=""scaled-max-value""
>
  <div
    aria-hidden=""true""
    class=""pf-c-progress__description""
    id=""scaled-max-value-description""
  ></div>
  <div
    aria-hidden=""true""
    class=""pf-c-progress__status""
  >
    <span
      class=""pf-c-progress__measure""
    >
      62%
    </span>
  </div>
  <div
    aria-valuemax=""80""
    aria-valuemin=""0""
    aria-valuenow=""50""
    class=""pf-c-progress__bar""
    role=""progressbar""
  >
    <div
      class=""pf-c-progress__indicator""
      style=""width: 62%""
    >
      <span
        class=""pf-c-progress__measure""
      />
    </div>
  </div>
</div>
");
    }

    [Theory]
    [InlineData(ProgressSize.Large)]
    [InlineData(ProgressSize.Medium)]
    [InlineData(ProgressSize.Small)]
    public void SizeTest(ProgressSize size)
    {
        // Arrange
        using var ctx = Helper.CreateTestContext();
        var sizeClass = size switch
        {
            ProgressSize.Large  => "pf-m-lg",
            ProgressSize.Small  => "pf-m-sm",
            _                   => null
        };

        // Act
        var cut = ctx.RenderComponent<Progress>(parameters => parameters
            .AddUnmatched("id", "progress-size")
            .Add(p => p.Value, 33)
            .Add(p => p.Size, size)
        );

        // Assert
        cut.MarkupMatches(
$@"
<div
  class=""pf-c-progress {sizeClass} pf-m-singleline""
  id=""progress-size""
>
  <div
    aria-hidden=""true""
    class=""pf-c-progress__description""
    id=""progress-size-description""
  ></div>
  <div
    aria-hidden=""true""
    class=""pf-c-progress__status""
  >
    <span
      class=""pf-c-progress__measure""
    >
      33%
    </span>
  </div>
  <div
    aria-valuemax=""100""
    aria-valuemin=""0""
    aria-valuenow=""33""
    class=""pf-c-progress__bar""
    role=""progressbar""
  >
    <div
      class=""pf-c-progress__indicator""
      style=""width: 33%""
    >
      <span
        class=""pf-c-progress__measure""
      />
    </div>
  </div>
</div>
");
    }

    [Theory]
    [InlineData(ProgressVariant.Danger)]
    [InlineData(ProgressVariant.Success)]
    [InlineData(ProgressVariant.Warning)]
    public void VariantTest(ProgressVariant variant)
    {
        // Arrange
        using var ctx = Helper.CreateTestContext();
        var variantClass = variant switch
        {
            ProgressVariant.Danger  => "pf-m-danger",
            ProgressVariant.Success => "pf-m-success",
            ProgressVariant.Warning => "pf-m-warning",
            _                       => null
        };
        var variantIcon = variant switch
        {
            ProgressVariant.Danger  => TimesCircleIcon.IconDefinition,
            ProgressVariant.Success => CheckCircleIcon.IconDefinition,
            ProgressVariant.Warning => ExclamationTriangleIcon.IconDefinition,
            _                       => null
        };

        // Act
        var cut = ctx.RenderComponent<Progress>(parameters => parameters
            .AddUnmatched("id", "progress-variant")
            .Add(p => p.Value, 33)
            .Add(p => p.Variant, variant)
        );

        // Assert
        cut.MarkupMatches(
$@"
<div
  class=""pf-c-progress {variantClass} pf-m-singleline""
  id=""progress-variant""
>
  <div
    aria-hidden=""true""
    class=""pf-c-progress__description""
    id=""progress-variant-description""
  ></div>
  <div
    aria-hidden=""true""
    class=""pf-c-progress__status""
  >
    <span
      class=""pf-c-progress__measure""
    >
      33%
    </span>
    <span
      class=""pf-c-progress__status-icon""
    >
      <svg
        aria-hidden=""true""
        fill=""currentColor""
        height=""1em""
        role=""img""
        style=""vertical-align: -0.125em""
        viewBox=""{variantIcon.ViewBox}""
        width=""1em""
      >
        <path
          d=""{variantIcon.SvgPath}""
        />
      </svg>
    </span>
  </div>
  <div
    aria-valuemax=""100""
    aria-valuemin=""0""
    aria-valuenow=""33""
    class=""pf-c-progress__bar""
    role=""progressbar""
  >
    <div
      class=""pf-c-progress__indicator""
      style=""width: 33%""
    >
      <span
        class=""pf-c-progress__measure""
      />
    </div>
  </div>
</div>
");
    }

    [Fact]
    public void WithInsideMeasureLocationTest()
    {
        // Arrange
        using var ctx = Helper.CreateTestContext();

        // Act
        var cut = ctx.RenderComponent<Progress>(parameters => parameters
            .AddUnmatched("id", "inside-progress")
            .Add(p => p.Value, 33)
            .Add(p => p.MeasureLocation, ProgressMeasureLocation.Inside)
        );

        // Assert
        cut.MarkupMatches(
@"
<div
  class=""pf-c-progress pf-m-inside pf-m-lg pf-m-singleline""
  id=""inside-progress""
>
  <div
    aria-hidden=""true""
    class=""pf-c-progress__description""
    id=""inside-progress-description""
  ></div>
  <div
    aria-hidden=""true""
    class=""pf-c-progress__status""
  ></div>
  <div
    aria-valuemax=""100""
    aria-valuemin=""0""
    aria-valuenow=""33""
    class=""pf-c-progress__bar""
    role=""progressbar""
  >
    <div
      class=""pf-c-progress__indicator""
      style=""width: 33%""
    >
      <span
        class=""pf-c-progress__measure""
      >
        33%
      </span>
    </div>
  </div>
</div>
");
    }

    [Fact]
    public void WithOutsideMeasureLocationTest()
    {
        // Arrange
        using var ctx = Helper.CreateTestContext();

        // Act
        var cut = ctx.RenderComponent<Progress>(parameters => parameters
            .AddUnmatched("id", "outside-progress")
            .Add(p => p.Value, 33)
            .Add(p => p.MeasureLocation, ProgressMeasureLocation.Outside)
        );

        // Assert
        cut.MarkupMatches(
@"
<div
  class=""pf-c-progress pf-m-outside pf-m-singleline""
  id=""outside-progress""
>
  <div
    aria-hidden=""true""
    class=""pf-c-progress__description""
    id=""outside-progress-description""
  ></div>
  <div
    aria-hidden=""true""
    class=""pf-c-progress__status""
  >
    <span
      class=""pf-c-progress__measure""
    >
      33%
    </span>
  </div>
  <div
    aria-valuemax=""100""
    aria-valuemin=""0""
    aria-valuenow=""33""
    class=""pf-c-progress__bar""
    role=""progressbar""
  >
    <div
      class=""pf-c-progress__indicator""
      style=""width: 33%""
    >
      <span
        class=""pf-c-progress__measure""
      />
    </div>
  </div>
</div>
");
    }

    [Fact]
    public void WithTopMeasureLocationTest()
    {
        // Arrange
        using var ctx = Helper.CreateTestContext();

        // Act
        var cut = ctx.RenderComponent<Progress>(parameters => parameters
            .AddUnmatched("id", "top-progress")
            .Add(p => p.Value, 33)
            .Add(p => p.MeasureLocation, ProgressMeasureLocation.Top)
        );

        // Assert
        cut.MarkupMatches(
@"
<div
  class=""pf-c-progress pf-m-singleline""
  id=""top-progress""
>
  <div
    aria-hidden=""true""
    class=""pf-c-progress__description""
    id=""top-progress-description""
  ></div>
  <div
    aria-hidden=""true""
    class=""pf-c-progress__status""
  >
    <span
      class=""pf-c-progress__measure""
    >
      33%
    </span>
  </div>
  <div
    aria-valuemax=""100""
    aria-valuemin=""0""
    aria-valuenow=""33""
    class=""pf-c-progress__bar""
    role=""progressbar""
  >
    <div
      class=""pf-c-progress__indicator""
      style=""width: 33%""
    >
      <span
        class=""pf-c-progress__measure""
      />
    </div>
  </div>
</div>
");
    }

    [Fact]
    public void InsideAndSmallShouldRenderLargeTest()
    {
        // Arrange
        using var ctx = Helper.CreateTestContext();

        // Act
        var cut = ctx.RenderComponent<Progress>(parameters => parameters
            .AddUnmatched("id", "large-progress")
            .Add(p => p.Value, 33)
            .Add(p => p.MeasureLocation, ProgressMeasureLocation.Inside)
            .Add(p => p.Size, ProgressSize.Small)
        );

        // Assert
        cut.MarkupMatches(
@"
<div
  class=""pf-c-progress pf-m-inside pf-m-lg pf-m-singleline""
  id=""large-progress""
>
  <div
    aria-hidden=""true""
    class=""pf-c-progress__description""
    id=""large-progress-description""
  ></div>
  <div
    aria-hidden=""true""
    class=""pf-c-progress__status""
  ></div>
  <div
    aria-valuemax=""100""
    aria-valuemin=""0""
    aria-valuenow=""33""
    class=""pf-c-progress__bar""
    role=""progressbar""
  >
    <div
      class=""pf-c-progress__indicator""
      style=""width: 33%""
    >
      <span
        class=""pf-c-progress__measure""
      >
        33%
      </span>
    </div>
  </div>
</div>
");
    }
}
