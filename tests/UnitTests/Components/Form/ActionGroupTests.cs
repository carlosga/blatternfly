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
    }
}
