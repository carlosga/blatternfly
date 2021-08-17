using System;
using Blatternfly.Components;
using Bunit;
using Xunit;

namespace Blatternfly.UnitTests.Components
{
    public class TextInputTests
    {
        [Fact]
        public void DefaultTest()
        {
            // Arrange
            using var ctx = new TestContext();

            // Act
            var cut = ctx.RenderComponent<TextInput>(properties => properties
                .Add(p => p.AriaLabel, "simple text input")
                .Add(p => p.Value, "test input")
            );

            // Assert
            cut.MarkupMatches(
@"
<input
  aria-invalid=""false""
  aria-label=""simple text input""
  class=""pf-c-form-control""
  type=""text""
  value=""test input""
/>
");
        }    
        
        [Fact]
        public void IsDisabledTest()
        {
            // Arrange
            using var ctx = new TestContext();

            // Act
            var cut = ctx.RenderComponent<TextInput>(properties => properties
                .Add(p => p.AriaLabel, "disabled text input")
                .Add(p => p.Value, "test input")
                .Add(p => p.IsDisabled, true)
            );

            // Assert
            cut.MarkupMatches(
@"
<input
  aria-invalid=""false""
  aria-label=""disabled text input""
  class=""pf-c-form-control""
  disabled=""""
  type=""text""
  value=""test input""
/>
");
        }         
        
        [Fact]
        public void IsReadonlyTest()
        {
            // Arrange
            using var ctx = new TestContext();

            // Act
            var cut = ctx.RenderComponent<TextInput>(properties => properties
                .Add(p => p.AriaLabel, "readonly text input")
                .Add(p => p.Value, "test input")
                .Add(p => p.IsReadOnly, true)
            );

            // Assert
            cut.MarkupMatches(
@"
<input
  aria-invalid=""false""
  aria-label=""readonly text input""
  class=""pf-c-form-control""
  readonly=""""
  type=""text""
  value=""test input""
/>
");
        }
        
        [Fact]
        public void IsInvalidTest()
        {
            // Arrange
            using var ctx = new TestContext();

            // Act
            var cut = ctx.RenderComponent<TextInput>(properties => properties
                .Add(p => p.AriaLabel, "invalid text input")
                .Add(p => p.Value, "test input")
                .Add(p => p.IsRequired, true)
                .Add(p => p.Validated, ValidatedOptions.Error)
            );

            // Assert
            cut.MarkupMatches(
@"
<input
  aria-invalid=""true""
  aria-label=""invalid text input""
  class=""pf-c-form-control""
  required=""""
  type=""text""
  value=""test input""
/>
");
        }  
        
        [Fact]
        public void ValidatedSuccessTest()
        {
            // Arrange
            using var ctx = new TestContext();

            // Act
            var cut = ctx.RenderComponent<TextInput>(properties => properties
                .Add(p => p.AriaLabel, "validated text input")
                .Add(p => p.Value, "test input")
                .Add(p => p.IsRequired, true)
                .Add(p => p.Validated, ValidatedOptions.Success)
            );

            // Assert
            cut.MarkupMatches(
@"
<input
  aria-invalid=""false""
  aria-label=""validated text input""
  class=""pf-c-form-control pf-m-success""
  required=""""
  type=""text""
  value=""test input""
/>
");
        }    
        
        [Fact]
        public void ValidatedWarningTest()
        {
            // Arrange
            using var ctx = new TestContext();

            // Act
            var cut = ctx.RenderComponent<TextInput>(properties => properties
                .Add(p => p.AriaLabel, "validated warning text input")
                .Add(p => p.Value, "test input")
                .Add(p => p.IsRequired, true)
                .Add(p => p.Validated, ValidatedOptions.Warning)
            );

            // Assert
            cut.MarkupMatches(
@"
<input
  aria-invalid=""false""
  aria-label=""validated warning text input""
  class=""pf-c-form-control pf-m-warning""
  required=""""
  type=""text""
  value=""test input""
/>
");
        }        
        
        [Fact]
        public void ShouldThrowErrorWhenNoAriaLabelOrAriaLabelledByOrIdIsGiven()
        {
            // Arrange
            using var ctx = new TestContext();

            // Assert
            var exception = Assert.Throws<InvalidOperationException>(() => ctx.RenderComponent<TextInput>());

            Assert.Equal("TextInput: Text input requires either an id or aria-label to be specified", exception.Message);
        }
        
        [Fact]
        public void ShouldNotThrowErrorWhenIdIsGivenButNoAriaLabelOrAriaLabelledByTest()
        {
            // Arrange
            using var ctx = new TestContext();
            
            // Assert
            var exception = Record.Exception(() => ctx.RenderComponent<TextInput>(parameters => parameters
                .AddUnmatched("id", "text-area-1")
            ));

            Assert.Null(exception);
        }
        
        [Fact]
        public void ShouldNotThrowErrorWhenAriaLabelIsGivenButNoIdOrAriaLabelledByTest()
        {
            // Arrange
            using var ctx = new TestContext();
            
            // Assert
            var exception = Record.Exception(() => ctx.RenderComponent<TextInput>(parameters => parameters
                .Add(p => p.AriaLabel, "test textarea")
            ));

            Assert.Null(exception);
        }         
        
        [Fact]
        public void ShouldNotThrowErrorWhenAriaLabelledByIsGivenButNoIdOrAriaLabelByTest()
        {
            // Arrange
            using var ctx = new TestContext();
            
            // Assert
            var exception = Record.Exception(() => ctx.RenderComponent<TextInput>(parameters => parameters
                .AddUnmatched("aria-labelledby", "test textarea")
            ));

            Assert.Null(exception);
        }           
    }
}
