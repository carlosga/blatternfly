using Blatternfly.Components;
using Bunit;
using Xunit;

namespace Blatternfly.UnitTests.Components
{
    public class HintTests
    {
        [Fact]
        public void SimpleHintTest()
        {
            // Arrange
            using var ctx = new TestContext();

            // Act
            var cut = ctx.RenderComponent<Hint>(parameters => parameters
                .Add<HintTitle>(p => p.ChildContent, titleparams => titleparams
                    .AddChildContent("Title")
                 )
                .Add<HintBody>(p => p.ChildContent, bodyparams => bodyparams
                    .AddChildContent("Body")
                 )
                .Add<HintFooter>(p => p.ChildContent, footerparams => footerparams
                    .AddChildContent("Footer")
                 )
            );

            // Assert
            cut.MarkupMatches(
@"
<div class=""pf-c-hint"">
  <div class=""pf-c-hint__actions""></div>
  <div class=""pf-c-hint__title"">Title</div>
  <div class=""pf-c-hint__body"">Body</div>
  <div class=""pf-c-hint__footer"">Footer</div>
</div>
");
        }        
    }
}
