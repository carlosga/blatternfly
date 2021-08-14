using Blatternfly.Components;
using Bunit;
using Xunit;

namespace Blatternfly.UnitTests.Components
{
    public class NumberInputTests
    {
        [Fact]
        public void WithAdditionalCssClassAndProperties()
        {
            // Arrange
            using var ctx = new TestContext();

            // Act
            var cut = ctx.RenderComponent<NumberInput<int?>>(properties => properties
                .AddUnmatched("class", "custom")
                .AddUnmatched("id", "numberInput1")
                .Add(p => p.Value, 0)
            );

            // Assert
            cut.MarkupMatches(
@$"
<div
  class=""pf-c-number-input custom""
  id=""numberInput1""
>
  <div
    class=""pf-c-input-group""
  >
    <button
      aria-disabled=""false""
      aria-label=""Minus""
      class=""pf-c-button pf-m-control""
      type=""button""
    >
      <span
        class=""pf-c-number-input__icon""
      >
        <svg
          style=""vertical-align: -0.125em;"" 
          fill=""currentColor"" 
          height=""1em"" 
          width=""1em"" 
          viewBox=""{MinusIcon.IconDefinition.ViewBox}"" 
          aria-hidden=""true"" 
          role=""img""
        >
          <path d=""{MinusIcon.IconDefinition.SvgPath}""></path>
        </svg>
      </span>
    </button>
    <input
      step=""any""
      aria-label=""Input""
      class=""pf-c-form-control""
      type=""number""
      value=""0""
    />
    <button
      aria-disabled=""false""
      aria-label=""Plus""
      class=""pf-c-button pf-m-control""
      type=""button""
    >
      <span
        class=""pf-c-number-input__icon""
      >
        <svg
          style=""vertical-align: -0.125em;"" 
          fill=""currentColor"" 
          height=""1em"" 
          width=""1em"" 
          viewBox=""{PlusIcon.IconDefinition.ViewBox}"" 
          aria-hidden=""true"" 
          role=""img""
        >
          <path d=""{PlusIcon.IconDefinition.SvgPath}""></path>
        </svg>
      </span>
    </button>
  </div>
</div>
");
        }
        
        [Fact]
        public void WithValueTest()
        {
            // Arrange
            using var ctx = new TestContext();

            // Act
            var cut = ctx.RenderComponent<NumberInput<int?>>(properties => properties
                .AddUnmatched("class", "custom")
                .AddUnmatched("id", "numberInput1")
                .Add(p => p.Value, 90)
            );

            // Assert
            cut.MarkupMatches(
                @$"
<div
  class=""pf-c-number-input custom""
  id=""numberInput1""
>
  <div
    class=""pf-c-input-group""
  >
    <button
      aria-disabled=""false""
      aria-label=""Minus""
      class=""pf-c-button pf-m-control""
      type=""button""
    >
      <span
        class=""pf-c-number-input__icon""
      >
        <svg
          style=""vertical-align: -0.125em;"" 
          fill=""currentColor"" 
          height=""1em"" 
          width=""1em"" 
          viewBox=""{MinusIcon.IconDefinition.ViewBox}"" 
          aria-hidden=""true"" 
          role=""img""
        >
          <path d=""{MinusIcon.IconDefinition.SvgPath}""></path>
        </svg>
      </span>
    </button>
    <input
      step=""any""
      aria-label=""Input""
      class=""pf-c-form-control""
      type=""number""
      value=""90""
    />
    <button
      aria-disabled=""false""
      aria-label=""Plus""
      class=""pf-c-button pf-m-control""
      type=""button""
    >
      <span
        class=""pf-c-number-input__icon""
      >
        <svg
          style=""vertical-align: -0.125em;"" 
          fill=""currentColor"" 
          height=""1em"" 
          width=""1em"" 
          viewBox=""{PlusIcon.IconDefinition.ViewBox}"" 
          aria-hidden=""true"" 
          role=""img""
        >
          <path d=""{PlusIcon.IconDefinition.SvgPath}""></path>
        </svg>
      </span>
    </button>
  </div>
</div>
");
        }
    }
}
