using System;
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
                .AddUnmatched("id", "check")
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
        
        [Fact]
        public void WithLabelDisabled()
        {
            // Arrange
            using var ctx = new TestContext();

            // Act
            var cut = ctx.RenderComponent<Checkbox>(parameters => parameters
                .AddUnmatched("id", "check")
                .Add(p => p.Label, "Label")
                .Add(p => p.AriaLabel, "check")
                .Add(p => p.Value, true)
            );

            // Assert
            cut.MarkupMatches(
@"
<div class=""pf-c-check"">
  <input
    aria-invalid=""false""
    aria-label=""check""
    checked=""""
    class=""pf-c-check__input""
    id=""check""
    type=""checkbox""
  />
  <label
    class=""pf-c-check__label""
    for=""check""
  >
    Label
  </label>
</div>
");
        }    
        
        [Fact]
        public void WithCustomCssClass()
        {
            // Arrange
            using var ctx = new TestContext();

            // Act
            var cut = ctx.RenderComponent<Checkbox>(parameters => parameters
                .AddUnmatched("id"   , "check")
                .AddUnmatched("class", "class-123")
                .Add(p => p.Label, "Label")
                .Add(p => p.AriaLabel, "check")
                .Add(p => p.Value, true)
            );

            // Assert
            cut.MarkupMatches(
@"
<div class=""pf-c-check class-123"">
  <input
    aria-invalid=""false""
    aria-label=""check""
    checked=""""
    class=""pf-c-check__input""
    id=""check""
    type=""checkbox""
  />
  <label
    class=""pf-c-check__label""
    for=""check""
  >
    Label
  </label>
</div>
");
        }        
        
        [Fact]
        public void WithCustomHtmlElementClass()
        {
            // Arrange
            using var ctx = new TestContext();

            // Act
            var cut = ctx.RenderComponent<Checkbox>(parameters => parameters
                .AddUnmatched("id", "check")
                .AddUnmatched("aria-labelledby", "labelId")
                .Add(p => p.Label, "Label")
                .Add(p => p.AriaLabel, "check")
                .Add(p => p.Value, true)
            );

            // Assert
            cut.MarkupMatches(
@"
<div class=""pf-c-check"">
  <input
    aria-labelledby=""labelId""
    aria-invalid=""false""
    aria-label=""check""
    checked=""""
    class=""pf-c-check__input""
    id=""check""
    type=""checkbox""
  />
  <label
    class=""pf-c-check__label""
    for=""check""
  >
    Label
  </label>
</div>
");
        }
        
        [Fact]
        public void WithDescription()
        {
            // Arrange
            using var ctx = new TestContext();

            // Act
            var cut = ctx.RenderComponent<Checkbox>(parameters => parameters
                .AddUnmatched("id", "check")
                .Add(p => p.Description, "Text description ...")
                .Add(p => p.Label, "Label")
                .Add(p => p.AriaLabel, "check")
                .Add(p => p.Value, true)
            );

            // Assert
            cut.MarkupMatches(
@"
<div class=""pf-c-check"">
  <input
    aria-invalid=""false""
    aria-label=""check""
    checked=""""
    class=""pf-c-check__input""
    id=""check""
    type=""checkbox""
  />
  <label
    class=""pf-c-check__label""
    for=""check""
  >
    Label
  </label>
  <span class=""pf-c-check__description"">Text description ...</span>
</div>
");
        }
        
        [Fact]
        public void WithBody()
        {
            // Arrange
            using var ctx = new TestContext();

            // Act
            var cut = ctx.RenderComponent<Checkbox>(parameters => parameters
                .AddUnmatched("id", "check")
                .Add(p => p.Body, "This is where custom content goes.")
                .Add(p => p.Label, "Label")
                .Add(p => p.AriaLabel, "check")
                .Add(p => p.Value, true)
            );

            // Assert
            cut.MarkupMatches(
                @"
<div class=""pf-c-check"">
  <input
    aria-invalid=""false""
    aria-label=""check""
    checked=""""
    class=""pf-c-check__input""
    id=""check""
    type=""checkbox""
  />
  <label
    class=""pf-c-check__label""
    for=""check""
  >
    Label
  </label>
  <span class=""pf-c-check__body"">This is where custom content goes.</span>
</div>
");
        }   
        
        [Fact(DisplayName = "should throw exception when no id is given")]
        public void WithoutId()
        {
            // Arrange
            using var ctx = new TestContext();

            // Act
            var exception = Assert.Throws<InvalidOperationException>(() => ctx.RenderComponent<Checkbox>());
            Assert.Equal("Checkbox: id is required to make input accessible.", exception.Message);
        }           
    }
}
