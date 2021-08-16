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
    }
}
