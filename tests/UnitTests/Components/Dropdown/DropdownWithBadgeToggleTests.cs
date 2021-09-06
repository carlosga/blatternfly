using Blatternfly.Components;
using Blatternfly.Interop;
using Bunit;
using Microsoft.Extensions.DependencyInjection;
using Xunit;

namespace Blatternfly.UnitTests.Components
{
    public class DropdownWithBadgeToggleTests
    {
        [Fact]
        public void DefaultTest()
        {
            // Arrange
            using var ctx = new TestContext();

            // Setup Javascript interop
            ctx.SetupJavascriptInterop();
            
            // Act
            var cut = ctx.RenderComponent<Dropdown>(parameters => parameters
                .AddDropdownItems()
                .Add<BadgeToggle>(p => p.Toggle, toggleParams => toggleParams
                    .AddUnmatched("id", "Dropdown Toggle")
                    .AddChildContent("Dropdown")
                )
            );

            // Assert
            cut.MarkupMatches(
@$"
<div 
  class=""pf-c-dropdown"" 
>
  <button 
    id=""Dropdown Toggle"" 
    class=""pf-c-dropdown__toggle pf-m-plain""
    type=""button"" 
    aria-label=""Actions""
    aria-expanded=""false"" 
    aria-haspopup=""true""
  >
    <span class=""pf-c-badge pf-m-read"">
      Dropdown
      <span class=""pf-c-dropdown__toggle-icon"">
        <svg style=""vertical-align: -0.125em;"" fill=""currentColor"" height=""1em"" width=""1em"" viewBox=""{CaretDownIcon.IconDefinition.ViewBox}"" aria-hidden=""true"" role=""img"">
          <path d=""{CaretDownIcon.IconDefinition.SvgPath}""></path>
        </svg>
      </span>
    </span>
  </button>
</div>
");            
        }
        
        [Fact]
        public void UnreadTest()
        {
            // Arrange
            using var ctx = new TestContext();

            // Setup Javascript interop
            ctx.SetupJavascriptInterop();
            
            // Act
            var cut = ctx.RenderComponent<Dropdown>(parameters => parameters
                .AddDropdownItems()
                .Add<BadgeToggle>(p => p.Toggle, toggleParams => toggleParams
                    .AddUnmatched("id", "Dropdown Toggle")
                    .Add(p => p.IsRead, false)
                    .AddChildContent("Dropdown")
                )
            );

            // Assert
            cut.MarkupMatches(
                @$"
<div 
  class=""pf-c-dropdown"" 
>
  <button 
    id=""Dropdown Toggle"" 
    class=""pf-c-dropdown__toggle pf-m-plain""
    type=""button"" 
    aria-label=""Actions""
    aria-expanded=""false"" 
    aria-haspopup=""true""
  >
    <span class=""pf-c-badge pf-m-unread"">
      Dropdown
      <span class=""pf-c-dropdown__toggle-icon"">
        <svg style=""vertical-align: -0.125em;"" fill=""currentColor"" height=""1em"" width=""1em"" viewBox=""{CaretDownIcon.IconDefinition.ViewBox}"" aria-hidden=""true"" role=""img"">
          <path d=""{CaretDownIcon.IconDefinition.SvgPath}""></path>
        </svg>
      </span>
    </span>
  </button>
</div>
");            
        }        
    }
}
