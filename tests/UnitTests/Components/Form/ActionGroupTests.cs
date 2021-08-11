using System.Runtime.Serialization;
using Blatternfly.Components;
using Bunit;
using Microsoft.AspNetCore.Components.Forms;
using Xunit;

namespace Blatternfly.UnitTests.Components
{
    public class ActionGroupTests
    {
        [Fact]
        public void DefaultTest()
        {
            // Arrange
            using var ctx = new TestContext();

            // Act
            var cut = ctx.RenderComponent<ActionGroup>(parameters => parameters
                .AddChildContent("<div>Hello</div>")
            );

            // Assert
            cut.MarkupMatches(
@"
<div
  class=""pf-c-form__group pf-m-action""
>
  <div
    class=""pf-c-form__group-control""
  >
    <div
      class=""pf-c-form__actions""
    >
      <div>
        Hello
      </div>
    </div>
  </div>
</div>
");
        }        
        
        public void IsHorizontalTest()
        {
            // Arrange
            using var ctx = new TestContext();
            var context = new EditContext(new object());

            // Act
            var cut = ctx.RenderComponent<Form>(parameters => parameters
                .Add(p => p.IsHorizontal, true)
                .Add(p => p.EditContext, context)
                // .Add<ActionGroup, EditContext>(p => p.ChildContent)
            );

            // Assert
            cut.MarkupMatches(
@"
<form
  class=""pf-c-form pf-m-horizontal""
  noValidate=""true""
>
  <ActionGroup>
    <div
      class=""pf-c-form__group pf-m-action""
    >
      <div
        class=""pf-c-form__group-control""
      >
        <div
          class=""pf-c-form__actions""
        />
      </div>
    </div>
  </ActionGroup>
</form>
");
        }         
    }
}
