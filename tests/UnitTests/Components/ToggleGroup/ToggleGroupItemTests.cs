using Blatternfly.Components;
using Bunit;
using Xunit;

namespace Blatternfly.UnitTests.Components
{
    public class ToggleGroupItemTests
    {
        [Fact]
        public void SelectedTest()
        {
            // Arrange
            using var ctx = new TestContext();

            // Act
            var cut = ctx.RenderComponent<ToggleGroupItem>(properties => properties
                .Add(p => p.Text, "test")
                .Add(p => p.IsSelected, true)
                .Add(p => p.ButtonId, "toggleGroupItem")
                .Add(p => p.AriaLabel, "basic selected")
            );

            // Assert
            cut.MarkupMatches(
@"
<div
  class=""pf-c-toggle-group__item""
>
  <button
    aria-label=""basic selected""
    aria-pressed=""true""
    class=""pf-c-toggle-group__button pf-m-selected""
    id=""toggleGroupItem""
    type=""button""
  >
    <span class=""pf-c-toggle-group__text"">test</span>
  </button>
</div>
");
        }
        
        [Fact]
        public void NotSelectedTest()
        {
            // Arrange
            using var ctx = new TestContext();

            // Act
            var cut = ctx.RenderComponent<ToggleGroupItem>(properties => properties
                .Add(p => p.Text, "test")
                .Add(p => p.ButtonId, "toggleGroupItem")
                .Add(p => p.AriaLabel, "basic not selected")
            );

            // Assert
            cut.MarkupMatches(
@"
<div
  class=""pf-c-toggle-group__item""
>
  <button
    aria-label=""basic not selected""
    aria-pressed=""false""
    class=""pf-c-toggle-group__button""
    id=""toggleGroupItem""
    type=""button""
  >
    <span class=""pf-c-toggle-group__text"">test</span>
  </button>
</div>
");
        }       
        
        [Fact]
        public void IconVariantTest()
        {
            // Arrange
            using var ctx = new TestContext();

            // Act
            var cut = ctx.RenderComponent<ToggleGroupItem>(properties => properties
                .Add(p => p.ButtonId, "toggleGroupItem")
                .Add(p => p.AriaLabel, "icon variant")
                .Add(p => p.IsSelected, true)
                .Add<CopyIcon>(p => p.Icon)
            );

            // Assert
            cut.MarkupMatches(
$@"
<div class=""pf-c-toggle-group__item"">
  <button 
    type=""button"" 
    class=""pf-c-toggle-group__button pf-m-selected"" 
    aria-pressed=""true"" 
    aria-label=""icon variant"" 
    id=""toggleGroupItem""
  >
    <span class=""pf-c-toggle-group__icon"">
      <svg
        style=""vertical-align: -0.125em;"" 
        fill=""currentColor"" 
        height=""1em"" 
        width=""1em"" 
        viewBox=""{CopyIcon.IconDefinition.ViewBox}"" 
        aria-hidden=""true"" 
        role=""img""
      >
        <path d=""{CopyIcon.IconDefinition.SvgPath}""></path>
      </svg>          
    </span>
  </button>
</div>
");
        }
        
        [Fact]
        public void IsDisabledTest()
        {
            // Arrange
            using var ctx = new TestContext();

            // Act
            var cut = ctx.RenderComponent<ToggleGroupItem>(properties => properties
                .Add(p => p.Text, "test")
                .Add(p => p.ButtonId, "toggleGroupItem")
                .Add(p => p.AriaLabel, "isDisabled")
                .Add(p => p.IsDisabled, true)
            );

            // Assert
            cut.MarkupMatches(
@"
<div
  class=""pf-c-toggle-group__item""
>
  <button
    aria-label=""isDisabled""
    aria-pressed=""false""
    class=""pf-c-toggle-group__button""
    disabled=""""
    id=""toggleGroupItem""
    type=""button""
  >
    <span class=""pf-c-toggle-group__text"">test</span>
  </button>
</div>
");
        }
    }
}
