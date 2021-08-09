using System.Collections.Generic;
using Blatternfly.Components;
using Bunit;
using Xunit;

namespace Blatternfly.UnitTests.Components
{
    public class CheckboxTexts
    {
        [Fact]
        public void IsDisabled()
        {
            // Arrange
            using var ctx = new TestContext();

            // Act
            var cut = ctx.RenderComponent<Checkbox>(parameters => parameters
                .Add(p => p.AdditionalAttributes, new Dictionary<string, object> { { "id", "check" } })
                .Add(p => p.AriaLabel, "check")
                .Add(p => p.IsDisabled, true)
            );

            // Assert
            cut.MarkupMatches(
@"
<div class=""pf-c-check"">
  <input
    aria-invalid=""false""
    aria-label=""check""
    class=""pf-c-check__input""
    disabled=""""
    id=""check""
    type=""checkbox""
  />
</div>
");
        }        
    }
}
