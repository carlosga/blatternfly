﻿using Blatternfly.Components;
using Bunit;
using Xunit;

namespace Blatternfly.UnitTests.Components
{
    public class ToggleGroupTests
    {
        [Fact]
        public void IsCompactTest()
        {
            // Arrange
            using var ctx = new TestContext();

            // Act
            var cut = ctx.RenderComponent<ToggleGroup>(properties => properties
                .Add(p => p.IsCompact, true)
                .Add<ToggleGroupItem>(p => p.ChildContent, itemparams1 => itemparams1
                    .Add(p => p.Text, "Test")
                )
                .Add<ToggleGroupItem>(p => p.ChildContent, itemparams2 => itemparams2
                    .Add(p => p.Text, "Test")
                )
            );

            // Assert
            cut.MarkupMatches(
@"
<div 
  class=""pf-c-toggle-group pf-m-compact"" 
  role=""group""
>
  <div class=""pf-c-toggle-group__item"">
    <button 
      type=""button"" 
      class=""pf-c-toggle-group__button"" 
      aria-pressed=""false""
    >
      <span class=""pf-c-toggle-group__text"">Test</span>
    </button>
  </div>
  <div class=""pf-c-toggle-group__item"">
    <button 
      type=""button"" 
      class=""pf-c-toggle-group__button"" 
      aria-pressed=""false""
    >
      <span class=""pf-c-toggle-group__text"">Test</span>
    </button>
  </div>
</div>
");
        }
    }
}