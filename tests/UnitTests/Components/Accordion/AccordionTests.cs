using Blatternfly.Components;
using Bunit;
using Xunit;

namespace Blatternfly.UnitTests.Components
{
    public class AccordionTests
    {
        [Fact]
        public void DefaultTest()
        {
            // Arrange
            using var ctx = new TestContext();

            // Act
            var cut = ctx.RenderComponent<Accordion>(parameters => parameters
                .Add(p => p.AriaLabel, "this is a simple accordion")
            );

            // Assert
            cut.MarkupMatches(
@"
<dl
  aria-label=""this is a simple accordion""
  class=""pf-c-accordion""
/>
");
        }     
        
        [Fact]
        public void WithNonDefaultHeadingLevelTest()
        {
            // Arrange
            using var ctx = new TestContext();

            // Act
            var cut = ctx.RenderComponent<Accordion>(parameters => parameters
                .Add(p => p.AsDefinitionList, false)
                .Add(p => p.HeadingLevel, HeadingLevel.h2)
                .Add<AccordionItem>(p => p.ChildContent, itemparams => itemparams
                    .Add<AccordionToggle>(p => p.ChildContent, toggleparams => toggleparams
                        .AddUnmatched("id", "item-1")
                        .AddChildContent("Item One")
                    )
                    .Add<AccordionContent>(p => p.ChildContent, contentparams => contentparams
                        .AddChildContent("Item One Content")
                    )
                )
            );

            // Assert
            cut.MarkupMatches(
$@"
<div
  class=""pf-c-accordion""
>
  <h2>
    <button
      aria-expanded=""false""
      class=""pf-c-accordion__toggle""
      id=""item-1""
      type=""button""
    >
      <span
        class=""pf-c-accordion__toggle-text""
      >
        Item One
      </span>
      <span
        class=""pf-c-accordion__toggle-icon""
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
    </button>
  </h2>
  <div class=""pf-c-accordion__expanded-content"" hidden="""">
    <div class=""pf-c-accordion__expanded-content-body"">Item One Content</div>
  </div>
</div>
");
        }
        
        [Fact]
        public void WithAdditionalPropertiesTest()
        {
            // Arrange
            using var ctx = new TestContext();

            // Act
            var cut = ctx.RenderComponent<Accordion>(parameters => parameters
                .Add(p => p.AsDefinitionList, true)
                .Add<AccordionItem>(p => p.ChildContent, itemparams => itemparams
                    .Add<AccordionToggle>(p => p.ChildContent, toggleparams => toggleparams
                        .AddUnmatched("id", "ex-toggle2")
                        .AddUnmatched("aria-label", "Toggle details for")
                        .AddUnmatched("aria-labelledby", "ex-toggle2 ex-item2")
                    )
                )
            );

            // Assert
            cut.MarkupMatches(
$@"
<dl
  class=""pf-c-accordion""
>
  <dt>
    <button
      aria-expanded=""false""
      class=""pf-c-accordion__toggle""
      id=""ex-toggle2""
      aria-label=""Toggle details for""
      aria-labelledby=""ex-toggle2 ex-item2""
      type=""button""
    >
      <span class=""pf-c-accordion__toggle-text""></span>
      <span
        class=""pf-c-accordion__toggle-icon""
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
    </button>
  </dt>
</div>
");
        }
        
        [Fact]
        public void BorderedTest()
        {
            // Arrange
            using var ctx = new TestContext();

            // Act
            var cut = ctx.RenderComponent<Accordion>(parameters => parameters
                .Add(p => p.IsBordered, true)
                .Add<AccordionItem>(p => p.ChildContent, itemparams => itemparams
                    .Add<AccordionToggle>(p => p.ChildContent, toggleparams => toggleparams
                        .AddUnmatched("id", "item-1")
                        .AddChildContent("Item One")
                    )
                    .Add<AccordionContent>(p => p.ChildContent, contentparams => contentparams
                        .AddChildContent("Item One Content")
                    )                
                )
            );

            // Assert
            cut.MarkupMatches(
$@"
<dl
  class=""pf-c-accordion pf-m-bordered""
>
  <dt>
    <button
      aria-expanded=""false""
      class=""pf-c-accordion__toggle""
      id=""item-1""
      type=""button""
    >
      <span
        class=""pf-c-accordion__toggle-text""
      >
        Item One
      </span>
      <span
        class=""pf-c-accordion__toggle-icon""
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
    </button>
  </dt>
  <dd class=""pf-c-accordion__expanded-content"" hidden="""">
    <div class=""pf-c-accordion__expanded-content-body"">Item One Content</div>
  </dd>
</dl>
");
        }

        [Fact]
        public void DisplayLargeTest()
        {
            // Arrange
            using var ctx = new TestContext();

            // Act
            var cut = ctx.RenderComponent<Accordion>(parameters => parameters
                .Add(p => p.DisplaySize, DisplaySize.Large)
                .Add<AccordionItem>(p => p.ChildContent, itemparams => itemparams
                    .Add<AccordionToggle>(p => p.ChildContent, toggleparams => toggleparams
                        .AddUnmatched("id", "item-1")
                        .AddChildContent("Item One")
                    )
                    .Add<AccordionContent>(p => p.ChildContent, contentparams => contentparams
                        .AddChildContent("Item One Content")
                    )                
                )
            );

            // Assert
            cut.MarkupMatches(
$@"
<dl
  class=""pf-c-accordion pf-m-display-lg""
>
  <dt>
    <button
      aria-expanded=""false""
      class=""pf-c-accordion__toggle""
      id=""item-1""
      type=""button""
    >
      <span
        class=""pf-c-accordion__toggle-text""
      >
        Item One
      </span>
      <span
        class=""pf-c-accordion__toggle-icon""
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
    </button>
  </dt>
  <dd class=""pf-c-accordion__expanded-content"" hidden="""">
    <div class=""pf-c-accordion__expanded-content-body"">Item One Content</div>
  </dd>
</dl>
");
        }

        [Fact]
        public void WithCustomContentTest()
        {
            // Arrange
            using var ctx = new TestContext();

            // Act
            var cut = ctx.RenderComponent<Accordion>(parameters => parameters
                .Add(p => p.DisplaySize, DisplaySize.Large)
                .Add<AccordionItem>(p => p.ChildContent, itemparams => itemparams
                    .Add<AccordionToggle>(p => p.ChildContent, toggleparams => toggleparams
                        .AddUnmatched("id", "item-1")
                        .AddChildContent("Item One")
                    )
                    .Add<AccordionContent>(p => p.ChildContent, contentparams => contentparams
                        .Add(p => p.IsCustomContent, true)
                        .Add<AccordionExpandedContentBody>(p => p.ChildContent, i1params => i1params.Add(p => p.ChildContent, "Item one content body 1"))
                        .Add<AccordionExpandedContentBody>(p => p.ChildContent, i2params => i2params.Add(p => p.ChildContent, "Item one content body 2"))
                    )                
                )
            );

            // Assert
            cut.MarkupMatches(
                $@"
<dl
  class=""pf-c-accordion pf-m-display-lg""
>
  <dt>
    <button
      aria-expanded=""false""
      class=""pf-c-accordion__toggle""
      id=""item-1""
      type=""button""
    >
      <span
        class=""pf-c-accordion__toggle-text""
      >
        Item One
      </span>
      <span
        class=""pf-c-accordion__toggle-icon""
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
    </button>
  </dt>
  <dd class=""pf-c-accordion__expanded-content"" hidden="""">
    <div
      class=""pf-c-accordion__expanded-content-body""
    >
      Item one content body 1
    </div>
    <div
      class=""pf-c-accordion__expanded-content-body""
    >
      Item one content body 2
    </div>
  </dd>
</dl>
");
        }
    }
}
