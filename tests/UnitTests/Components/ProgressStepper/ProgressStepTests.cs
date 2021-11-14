namespace Blatternfly.UnitTests.Components;

public class ProgressStepTests
{
    [Fact]
    public void DefaultTest()
    {
        // Arrange
        using var ctx = new TestContext();

        // Act
        var cut = ctx.RenderComponent<ProgressStep>(parameters => parameters
            .AddUnmatched("id", "progress-step-1")
            .Add(p => p.TitleId, "progress-step-title-1")
            .AddChildContent("Title")
        );

        // Assert
        cut.MarkupMatches(
@"
<li
  id=""progress-step-1""
  class=""pf-c-progress-stepper__step""
>
  <div
    class=""pf-c-progress-stepper__step-connector""
  >
    <span
      class=""pf-c-progress-stepper__step-icon""
    />
  </div>
  <div
    class=""pf-c-progress-stepper__step-main""
  >
    <div
      id=""progress-step-title-1""
      aria-labelledby=""progress-step-1 progress-step-title-1""
      class=""pf-c-progress-stepper__step-title""
    >
      Title
    </div>
  </div>
</li>
");
    }

    [Theory]
    [InlineData(ProgressStepVariant.Success)]
    [InlineData(ProgressStepVariant.Info)] 
    [InlineData(ProgressStepVariant.Warning)] 
    [InlineData(ProgressStepVariant.Danger)]
    public void VariantTest(ProgressStepVariant variant)
    {
        // Arrange
        using var ctx = new TestContext();
        var variantText    = variant.ToString().ToLower();
        var variantClass   = variant is not ProgressStepVariant.Default ? $"pf-m-{variantText}" : null;
        var iconDefinition = variant switch 
        {
            ProgressStepVariant.Success => CheckCircleIcon.IconDefinition,
            ProgressStepVariant.Info    => ResourcesFullIcon.IconDefinition,
            ProgressStepVariant.Warning => ExclamationTriangleIcon.IconDefinition,
            ProgressStepVariant.Danger  => ExclamationCircleIcon.IconDefinition,
            _                           => null
        };

        // Act
        var cut = ctx.RenderComponent<ProgressStep>(parameters => parameters
            .AddUnmatched("id", "progress-step-1")
            .AddUnmatched("aria-label", variantText)
            .Add(p => p.TitleId, "progress-step-title-1")
            .Add(p => p.Variant, variant)
           .AddChildContent("Title")
        );

        // Assert
        cut.MarkupMatches(
$@"
<li
  id=""progress-step-1""
  aria-label=""{variantText}""
  class=""pf-c-progress-stepper__step {variantClass}""
>
  <div
    class=""pf-c-progress-stepper__step-connector""
  >
    <span
      class=""pf-c-progress-stepper__step-icon""
    >
      <svg
        aria-hidden=""true""
        fill=""currentColor""
        height=""1em""
        role=""img""
        style=""vertical-align: -0.125em""
        viewBox=""{iconDefinition.ViewBox}""
        width=""1em""
      >
        <path
          d=""{iconDefinition.SvgPath}""
        />
      </svg>
    </span>
  </div>
  <div
    class=""pf-c-progress-stepper__step-main""
  >
    <div
      id=""progress-step-title-1""
      aria-labelledby=""progress-step-1 progress-step-title-1""
      class=""pf-c-progress-stepper__step-title""
    >
      Title
    </div>
  </div>
</li>
");
    }
    
    [Fact]
    public void DefaultVariantTest()
    {
        // Arrange
        using var ctx = new TestContext();

        // Act
        var cut = ctx.RenderComponent<ProgressStep>(parameters => parameters
            .AddUnmatched("id", "progress-step-1")
            .Add(p => p.TitleId, "progress-step-title-1")
            .Add(p => p.Variant, ProgressStepVariant.Default)
            .AddChildContent("Title")
        );

        // Assert
        cut.MarkupMatches(
@"
<li
  id=""progress-step-1""
  class=""pf-c-progress-stepper__step""
>
  <div
    class=""pf-c-progress-stepper__step-connector""
  >
    <span
      class=""pf-c-progress-stepper__step-icon""
    />
  </div>
  <div
    class=""pf-c-progress-stepper__step-main""
  >
    <div
      id=""progress-step-title-1""
      aria-labelledby=""progress-step-1 progress-step-title-1""
      class=""pf-c-progress-stepper__step-title""
    >
      Title
    </div>
  </div>
</li>
");
    }
    
    [Fact]
    public void PendingVariantTest()
    {
        // Arrange
        using var ctx = new TestContext();

        // Act
        var cut = ctx.RenderComponent<ProgressStep>(parameters => parameters
            .AddUnmatched("id", "progress-step-1")
            .Add(p => p.TitleId, "progress-step-title-1")
            .Add(p => p.Variant, ProgressStepVariant.Pending)
            .AddChildContent("Title")
        );

        // Assert
        cut.MarkupMatches(
@"
<li
  id=""progress-step-1""
  class=""pf-c-progress-stepper__step pf-m-pending""
>
  <div
    class=""pf-c-progress-stepper__step-connector""
  >
    <span
      class=""pf-c-progress-stepper__step-icon""
    />
  </div>
  <div
    class=""pf-c-progress-stepper__step-main""
  >
    <div
      id=""progress-step-title-1""
      aria-labelledby=""progress-step-1 progress-step-title-1""
      class=""pf-c-progress-stepper__step-title""
    >
      Title
    </div>
  </div>
</li>
");
    }
    
    [Fact]
    public void IsCurrentTest()
    {
        // Arrange
        using var ctx = new TestContext();

        // Act
        var cut = ctx.RenderComponent<ProgressStep>(parameters => parameters
            .AddUnmatched("id", "progress-step-1")
            .Add(p => p.TitleId, "progress-step-title-1")
            .Add(p => p.IsCurrent, true)
            .AddChildContent("Title")
        );

        // Assert
        cut.MarkupMatches(
@"
<li
  id=""progress-step-1""
  class=""pf-c-progress-stepper__step pf-m-current""
>
  <div
    class=""pf-c-progress-stepper__step-connector""
  >
    <span
      class=""pf-c-progress-stepper__step-icon""
    />
  </div>
  <div
    class=""pf-c-progress-stepper__step-main""
  >
    <div
      id=""progress-step-title-1""
      aria-labelledby=""progress-step-1 progress-step-title-1""
      class=""pf-c-progress-stepper__step-title""
    >
      Title
    </div>
  </div>
</li>
");
    }

    [Fact]
    public void WithHelpText()
    {
        // Arrange
        using var ctx = new TestContext();
        var iconDefinition = InProgressIcon.IconDefinition; 

        // Act
        var cut = ctx.RenderComponent<ProgressStep>(parameters => parameters
            .AddUnmatched("id", "progress-step-1")
            .Add(p => p.TitleId, "progress-step-title-1")
            .Add(p => p.Popover, "<div></div>")
            .AddChildContent("Title")
        );

        // Assert
        cut.MarkupMatches(
@"
<li
  id=""progress-step-1""
  class=""pf-c-progress-stepper__step""
>
  <div
    class=""pf-c-progress-stepper__step-connector""
  >
    <span
      class=""pf-c-progress-stepper__step-icon""
    />
  </div>
  <div
    class=""pf-c-progress-stepper__step-main""
  >
    <span
      id=""progress-step-title-1""
      aria-labelledby=""progress-step-1 progress-step-title-1""
      class=""pf-c-progress-stepper__step-title pf-m-help-text""
      role=""button""
      tabindex=""0""
      type=""button""
    >
      Title
      <div></div>
    </div>
  </div>
</li>
");
    }
    
    [Fact]
    public void WithCustomIconTest()
    {
        // Arrange
        using var ctx = new TestContext();
        var iconDefinition = InProgressIcon.IconDefinition; 

        // Act
        var cut = ctx.RenderComponent<ProgressStep>(parameters => parameters
            .AddUnmatched("id", "progress-step-1")
            .Add(p => p.TitleId, "progress-step-title-1")
            .Add<InProgressIcon>(p => p.Icon)
            .AddChildContent("Title")
        );

        // Assert
        cut.MarkupMatches(
$@"
<li
  id=""progress-step-1""
  class=""pf-c-progress-stepper__step""
>
  <div
    class=""pf-c-progress-stepper__step-connector""
  >
    <span
      class=""pf-c-progress-stepper__step-icon""
    >
      <svg
        aria-hidden=""true""
        fill=""currentColor""
        height=""1em""
        role=""img""
        style=""vertical-align: -0.125em""
        viewBox=""{iconDefinition.ViewBox}""
        width=""1em""
      >
        <path
          d=""{iconDefinition.SvgPath}""
        />
      </svg>
    </span>
  </div>
  <div
    class=""pf-c-progress-stepper__step-main""
  >
    <div
      id=""progress-step-title-1""
      aria-labelledby=""progress-step-1 progress-step-title-1""
      class=""pf-c-progress-stepper__step-title""
    >
      Title
    </div>
  </div>
</li>
");
    }
    
    [Fact]
    public void WithDescriptionTest()
    {
        // Arrange
        using var ctx = new TestContext();

        // Act
        var cut = ctx.RenderComponent<ProgressStep>(parameters => parameters
            .AddUnmatched("id", "progress-step-1")
            .Add(p => p.TitleId, "progress-step-title-1")
            .Add(p => p.Description, "This is a description")
            .AddChildContent("Title")
        );

        // Assert
        cut.MarkupMatches(
@"
<li
  id=""progress-step-1""
  class=""pf-c-progress-stepper__step""
>
  <div
    class=""pf-c-progress-stepper__step-connector""
  >
    <span
      class=""pf-c-progress-stepper__step-icon""
    />
  </div>
  <div
    class=""pf-c-progress-stepper__step-main""
  >
    <div
      id=""progress-step-title-1""
      aria-labelledby=""progress-step-1 progress-step-title-1""
      class=""pf-c-progress-stepper__step-title""
    >
      Title
    </div>
    <div
      class=""pf-c-progress-stepper__step-description""
    >
      This is a description
    </div>
  </div>
</li>
");
    }
}
