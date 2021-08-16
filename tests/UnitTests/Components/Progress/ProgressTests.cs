using Blatternfly.Components;
using Bunit;
using Xunit;

namespace Blatternfly.UnitTests.Components
{
    public class ProgressTests
    {
        [Fact]
        public void DefaultTest()
        {
            // Arrange
            using var ctx = new TestContext();

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
            using var ctx = new TestContext();

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
            using var ctx = new TestContext();

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
            using var ctx = new TestContext();

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
            using var ctx = new TestContext();

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
            using var ctx = new TestContext();

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
    }
}
