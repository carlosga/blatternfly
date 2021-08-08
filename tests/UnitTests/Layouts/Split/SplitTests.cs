using Blatternfly.Layouts;
using Bunit;
using Xunit;

namespace Blatternfly.UnitTests.Layouts
{
    public class SplitTests
    {
        [Fact]
        public void IsFilledTest()
        {
            // Arrange
            using var ctx = new TestContext();

            // Act
            var cut = ctx.RenderComponent<Split>(parameters => parameters
                .Add<SplitItem>(p => p.ChildContent, itemparams => itemparams
                    .Add(p => p.IsFilled, true)
                    .AddChildContent("Main content")
                )
            );

            // Assert
            cut.MarkupMatches(
@"
<div
  class=""pf-l-split""
>
  <div
    class=""pf-l-split__item pf-m-fill""
  >
    Main content
  </div>
</div>
");
        }

        [Fact]
        public void IsFilledDefaultsToFalseTest()
        {
            // Arrange
            using var ctx = new TestContext();

            // Act
            var cut = ctx.RenderComponent<Split>(parameters => parameters
                .Add<SplitItem>(p => p.ChildContent, itemparams => itemparams
                    .AddChildContent("Basic content")
                )
            );

            // Assert
            cut.MarkupMatches(
                @"
<div
  class=""pf-l-split""
>
  <div
    class=""pf-l-split__item""
  >
    Basic content
  </div>
</div>
");
        }

        [Fact]
        public void GutterTest()
        {
            // Arrange
            using var ctx = new TestContext();

            // Act
            var cut = ctx.RenderComponent<Split>(parameters => parameters
                .Add(p => p.HasGutter, true)
                .Add<SplitItem>(p => p.ChildContent, itemparams => itemparams
                    .AddChildContent("Basic content")
                )
            );

            // Assert
            cut.MarkupMatches(
                @"
<div
  class=""pf-l-split pf-m-gutter""
>
  <div
    class=""pf-l-split__item""
  >
    Basic content
  </div>
</div>
");
        }

        [Fact]
        public void WrappableTest()
        {
            // Arrange
            using var ctx = new TestContext();

            // Act
            var cut = ctx.RenderComponent<Split>(parameters => parameters
                .Add(p => p.IsWrappable, true)
                .Add<SplitItem>(p => p.ChildContent, itemparams => itemparams.AddChildContent("Basic content"))
                .Add<SplitItem>(p => p.ChildContent, itemparams => itemparams.AddChildContent("Basic content"))
                .Add<SplitItem>(p => p.ChildContent, itemparams => itemparams.AddChildContent("Basic content"))
                .Add<SplitItem>(p => p.ChildContent, itemparams => itemparams.AddChildContent("Basic content"))
                .Add<SplitItem>(p => p.ChildContent, itemparams => itemparams.AddChildContent("Basic content"))
                .Add<SplitItem>(p => p.ChildContent, itemparams => itemparams.AddChildContent("Basic content"))
                .Add<SplitItem>(p => p.ChildContent, itemparams => itemparams.AddChildContent("Basic content"))
                .Add<SplitItem>(p => p.ChildContent, itemparams => itemparams.AddChildContent("Basic content"))
                .Add<SplitItem>(p => p.ChildContent, itemparams => itemparams.AddChildContent("Basic content"))
                .Add<SplitItem>(p => p.ChildContent, itemparams => itemparams.AddChildContent("Basic content"))
                .Add<SplitItem>(p => p.ChildContent, itemparams => itemparams.AddChildContent("Basic content"))
                .Add<SplitItem>(p => p.ChildContent, itemparams => itemparams.AddChildContent("Basic content"))
                .Add<SplitItem>(p => p.ChildContent, itemparams => itemparams.AddChildContent("Basic content"))
                .Add<SplitItem>(p => p.ChildContent, itemparams => itemparams.AddChildContent("Basic content"))
            );

            // Assert
            cut.MarkupMatches(
                @"
<div
  class=""pf-l-split pf-m-wrap""
>
  <div class=""pf-l-split__item"">Basic content</div>
  <div class=""pf-l-split__item"">Basic content</div>
  <div class=""pf-l-split__item"">Basic content</div>
  <div class=""pf-l-split__item"">Basic content</div>
  <div class=""pf-l-split__item"">Basic content</div>
  <div class=""pf-l-split__item"">Basic content</div>
  <div class=""pf-l-split__item"">Basic content</div>
  <div class=""pf-l-split__item"">Basic content</div>
  <div class=""pf-l-split__item"">Basic content</div>
  <div class=""pf-l-split__item"">Basic content</div>
  <div class=""pf-l-split__item"">Basic content</div>
  <div class=""pf-l-split__item"">Basic content</div>
  <div class=""pf-l-split__item"">Basic content</div>
  <div class=""pf-l-split__item"">Basic content</div>
</div>
");
        }
    }
}
