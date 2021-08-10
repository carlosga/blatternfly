using System.Collections.Generic;
using Blatternfly.Components;
using Blatternfly.Observers;
using Bunit;
using Microsoft.Extensions.DependencyInjection;
using Xunit;

namespace Bunit
{
    internal static class BUnitExtensions
    {
        internal static ComponentParameterCollectionBuilder<Dropdown> AddDropdownItems(this ComponentParameterCollectionBuilder<Dropdown> parameters)
        {
            parameters
                .Add<DropdownItem>(p => p.DropdownItems, p1 => p1.AddChildContent("Link"))
                .Add<DropdownItem>(p => p.DropdownItems, p2 => p2.AddChildContent("Action").Add(p => p.Component, "button"))
                .Add<DropdownItem>(p => p.DropdownItems, p2 => p2.AddChildContent("Disabled Link").Add(p => p.IsDisabled, true))
                .Add<DropdownItem>(p => p.DropdownItems, p2 => p2.AddChildContent("Disabled Action").Add(p => p.IsDisabled, true).Add(p => p.Component, "button"))
                .Add<DropdownSeparator>(p => p.DropdownItems)
                .Add<DropdownItem>(p => p.DropdownItems, p1 => p1.AddChildContent("Separated Link"))
                .Add<DropdownItem>(p => p.DropdownItems, p2 => p2.AddChildContent("Separated Action").Add(p => p.Component, "button"));
            
            return parameters;
        }
    }
}

namespace Blatternfly.UnitTests.Components
{
    public class DropdownTests
    {
        [Fact]
        public void DefaultDropdownTest()
        {
            // Arrange
            using var ctx = new TestContext();
            ctx.JSInterop.Mode = JSRuntimeMode.Strict;
            
            ctx.JSInterop.SetupVoid("Blatternfly.Dropdown.onKeyDown", _ => true);
            
            // Register services
            ctx.Services.AddSingleton<IWindowObserver>(new WindowObserver(ctx.JSInterop.JSRuntime));   
            
            // Act
            var cut = ctx.RenderComponent<Dropdown>(parameters => parameters
                .AddDropdownItems()
                .Add<DropdownToggle>(p => p.Toggle, toggleParams => toggleParams
                    .Add(p => p.AdditionalAttributes, new Dictionary<string, object> { { "id", "Dropdown Toggle" } })
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
    class=""pf-c-dropdown__toggle"" 
    type=""button"" 
    aria-expanded=""false"" 
    aria-haspopup=""true""
  >
    <span class=""pf-c-dropdown__toggle-text"">Dropdown</span>
    <span class=""pf-c-dropdown__toggle-icon"">
      <svg style=""vertical-align: -0.125em;"" fill=""currentColor"" height=""1em"" width=""1em"" viewBox=""{CaretDownIcon.IconDefinition.ViewBox}"" aria-hidden=""true"" role=""img"">
        <path d=""{CaretDownIcon.IconDefinition.SvgPath}""></path>
      </svg>
    </span>
  </button>
</div>
");            
        }           
    }
}
