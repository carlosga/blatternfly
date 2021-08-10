using System.Collections.Generic;
using Blatternfly.Components;
using Bunit;
using Xunit;

namespace Blatternfly.UnitTests.Components
{
    public class DropdownToggleActionTests
    {
        [Fact]
        public void WithTextTest()
        {
            // Arrange
            using var ctx = new TestContext();

            // Act
            var cut = ctx.RenderComponent<DropdownToggleAction>(parameters => parameters
                .Add(p => p.AdditionalAttributes, new Dictionary<string, object>
                {
                    { "id", "action" },
                    { "aria-label", "action" }
                })
            );

            // Assert
            cut.MarkupMatches(
@"
<button
  aria-label=""action""
  class=""pf-c-dropdown__toggle-button""
  id=""action""
/>
");            
        }        
        
        [Fact]
        public void IsDisabledTest()
        {
            // Arrange
            using var ctx = new TestContext();

            // Act
            var cut = ctx.RenderComponent<DropdownToggleAction>(parameters => parameters
                .Add(p => p.IsDisabled, true)
                .Add(p => p.AdditionalAttributes, new Dictionary<string, object>
                {
                    { "id", "action" },
                    { "aria-label", "action" }
                })
            );

            // Assert
            cut.MarkupMatches(
@"
<button
  aria-disabled=""true""
  aria-label=""action""
  class=""pf-c-dropdown__toggle-button""
  disabled=""true""
  id=""action""
/>
");            
        }       
        
        [Fact]
        public void WithCustomCssClass()
        {
            // Arrange
            using var ctx = new TestContext();

            // Act
            var cut = ctx.RenderComponent<DropdownToggleAction>(parameters => parameters
                .Add(p => p.AdditionalAttributes, new Dictionary<string, object>
                {
                    { "id", "action" },
                    { "aria-label", "action" },
                    { "class", "abc" }
                })
            );

            // Assert
            cut.MarkupMatches(
@"
<button
  aria-label=""action""
  class=""pf-c-dropdown__toggle-button abc""
  id=""action""
/>
");            
        }
    }
}
