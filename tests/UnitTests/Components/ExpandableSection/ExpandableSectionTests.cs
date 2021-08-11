using System.Collections.Generic;
using Blatternfly.Components;
using Bunit;
using Xunit;

namespace Blatternfly.UnitTests.Components
{
    public class ExpandableSectionTests
    {
        [Fact]
        public void DefaultTest()
        {
            // Arrange
            using var ctx = new TestContext();

            // Act
            var cut = ctx.RenderComponent<ExpandableSection>(parameters => parameters
                .AddChildContent("test ")
            );
            
            // Assert
            cut.MarkupMatches(
@$"
<div
  class=""pf-c-expandable-section""
>
  <button
    class=""pf-c-expandable-section__toggle""
    type=""button""
  >
    <span
      class=""pf-c-expandable-section__toggle-icon""
    >
      <svg
        style=""vertical-align: -0.125em;"" 
        fill=""currentColor"" 
        height=""1em"" 
        width=""1em"" 
        viewBox=""{AngleRightIcon.IconDefinition.ViewBox}"" 
        aria-hidden=""true"" 
        role=""img""
      >
        <path d=""{AngleRightIcon.IconDefinition.SvgPath}""></path>
      </svg>
    </span>
    <span
      class=""pf-c-expandable-section__toggle-text""
    />
  </button>
  <div
    class=""pf-c-expandable-section__content""
    hidden=""true""
  >
    test 
  </div>
</div>
");
        }
        
        [Fact]
        public void IsExpandedTest()
        {
            // Arrange
            using var ctx = new TestContext();

            // Act
            var cut = ctx.RenderComponent<ExpandableSection>(parameters => parameters
                .Add(p => p.IsExpanded, true)
                .AddChildContent("test ")
            );
            
            // Assert
            cut.MarkupMatches(
@$"
<div
  class=""pf-c-expandable-section pf-m-expanded""
>
  <button
    aria-expanded=""true""
    class=""pf-c-expandable-section__toggle""
    type=""button""
  >
    <span
      class=""pf-c-expandable-section__toggle-icon""
    >
      <svg
        style=""vertical-align: -0.125em;"" 
        fill=""currentColor"" 
        height=""1em"" 
        width=""1em"" 
        viewBox=""{AngleRightIcon.IconDefinition.ViewBox}"" 
        aria-hidden=""true"" 
        role=""img""
      >
        <path d=""{AngleRightIcon.IconDefinition.SvgPath}""></path>
      </svg>
    </span>
    <span
      class=""pf-c-expandable-section__toggle-text""
    />
  </button>
  <div
    class=""pf-c-expandable-section__content""
  >
     test 
  </div>
</div>
");
        }
        
        [Fact]
        public void DisclosureSectionTest()
        {
            // Arrange
            using var ctx = new TestContext();

            // Act
            var cut = ctx.RenderComponent<ExpandableSection>(parameters => parameters
                .Add(p => p.DisplaySize, DisplaySize.Large)
                .Add(p => p.IsWidthLimited, true)
                .AddChildContent("test ")
            );
            
            // Assert
            cut.MarkupMatches(
@$"
<div
  class=""pf-c-expandable-section pf-m-display-lg pf-m-limit-width""
>
  <button
    class=""pf-c-expandable-section__toggle""
    type=""button""
  >
    <span
      class=""pf-c-expandable-section__toggle-icon""
    >
      <svg
        style=""vertical-align: -0.125em;"" 
        fill=""currentColor"" 
        height=""1em"" 
        width=""1em"" 
        viewBox=""{AngleRightIcon.IconDefinition.ViewBox}"" 
        aria-hidden=""true"" 
        role=""img""
      >
        <path d=""{AngleRightIcon.IconDefinition.SvgPath}""></path>
      </svg>
    </span>
    <span
      class=""pf-c-expandable-section__toggle-text""
    />
  </button>
  <div
    class=""pf-c-expandable-section__content""
    hidden=""true""
  >
    test 
  </div>
</div>
");
        }        
    }
}
