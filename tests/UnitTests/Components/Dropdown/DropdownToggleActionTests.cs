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
                .AddUnmatched("id", "action")
                .AddUnmatched("aria-label", "action")
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
                .AddUnmatched("id", "action")
                .AddUnmatched("aria-label", "action")
                .Add(p => p.IsDisabled, true)
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
                .AddUnmatched("id", "action")
                .AddUnmatched("aria-label", "action")
                .AddUnmatched("class", "abc")
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
