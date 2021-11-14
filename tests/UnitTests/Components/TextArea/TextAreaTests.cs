namespace Blatternfly.UnitTests.Components;

public class TextAreaTests
{
    [Fact]
    public void DefaultTest()
    {
        // Arrange
        using var ctx = new TestContext();

        // Act
        var cut = ctx.RenderComponent<TextArea>(properties => properties
            .Add(p => p.AriaLabel, "simple textarea")
            .Add(p => p.Value, "test textarea")
        );

        // Assert
        cut.MarkupMatches(
@"
<textarea
  aria-invalid=""false""
  aria-label=""simple textarea""
  class=""pf-c-form-control""
  value=""test textarea""
/>
");
    }      
    
    [Fact]
    public void IsDisabledTest()
    {
        // Arrange
        using var ctx = new TestContext();

        // Act
        var cut = ctx.RenderComponent<TextArea>(properties => properties
            .Add(p => p.AriaLabel, "is disabled textarea")
            .Add(p => p.Value, "test textarea")
            .Add(p => p.IsDisabled, true)
        );

        // Assert
        cut.MarkupMatches(
@"
<textarea
  aria-invalid=""false""
  aria-label=""is disabled textarea""
  class=""pf-c-form-control""
  disabled=""""
  value=""test textarea""
/>
");
    }
    
    [Fact]
    public void IsReadonlyTest()
    {
        // Arrange
        using var ctx = new TestContext();

        // Act
        var cut = ctx.RenderComponent<TextArea>(properties => properties
            .Add(p => p.AriaLabel, "is read only textarea")
            .Add(p => p.Value, "test textarea")
            .Add(p => p.IsReadOnly, true)
        );

        // Assert
        cut.MarkupMatches(
@"
<textarea
  aria-invalid=""false""
  aria-label=""is read only textarea""
  class=""pf-c-form-control""
  readonly=""""
  value=""test textarea""
/>
");
    }       
    
    [Fact]
    public void IsInvalidTest()
    {
        // Arrange
        using var ctx = new TestContext();

        // Act
        var cut = ctx.RenderComponent<TextArea>(properties => properties
            .Add(p => p.AriaLabel, "invalid textarea")
            .Add(p => p.Value, "test textarea")
            .Add(p => p.IsRequired, true)
            .Add(p => p.Validated, ValidatedOptions.Error)
        );

        // Assert
        cut.MarkupMatches(
@"
<textarea
  aria-invalid=""true""
  aria-label=""invalid textarea""
  class=""pf-c-form-control""
  required=""""
  value=""test textarea""
/>
");
    }
    
    [Fact]
    public void ValidatedSuccessTest()
    {
        // Arrange
        using var ctx = new TestContext();

        // Act
        var cut = ctx.RenderComponent<TextArea>(properties => properties
            .Add(p => p.AriaLabel, "validated textarea")
            .Add(p => p.Value, "test textarea")
            .Add(p => p.IsRequired, true)
            .Add(p => p.Validated, ValidatedOptions.Success)
        );

        // Assert
        cut.MarkupMatches(
@"
<textarea
  aria-invalid=""false""
  aria-label=""validated textarea""
  class=""pf-c-form-control pf-m-success""
  required=""""
  value=""test textarea""
/>
");
    }
    
    [Fact]
    public void ValidatedWarningTest()
    {
        // Arrange
        using var ctx = new TestContext();

        // Act
        var cut = ctx.RenderComponent<TextArea>(properties => properties
            .Add(p => p.AriaLabel, "validated textarea")
            .Add(p => p.Value, "test textarea")
            .Add(p => p.IsRequired, true)
            .Add(p => p.Validated, ValidatedOptions.Warning)
        );

        // Assert
        cut.MarkupMatches(
@"
<textarea
  aria-invalid=""false""
  aria-label=""validated textarea""
  class=""pf-c-form-control pf-m-warning""
  required=""""
  value=""test textarea""
/>
");
    }
    
    [Fact]
    public void VerticallyResizableTest()
    {
        // Arrange
        using var ctx = new TestContext();

        // Act
        var cut = ctx.RenderComponent<TextArea>(properties => properties
            .Add(p => p.AriaLabel, "vertical resize textarea")
            .Add(p => p.Value, "test textarea")
            .Add(p => p.ResizeOrientation, ResizeOrientation.Vertical)
        );

        // Assert
        cut.MarkupMatches(
@"
<textarea
  aria-invalid=""false""
  aria-label=""vertical resize textarea""
  class=""pf-c-form-control pf-m-resize-vertical""
  value=""test textarea""
/>
");
    }       
    
    [Fact]
    public void HorizontallyResizableTest()
    {
        // Arrange
        using var ctx = new TestContext();

        // Act
        var cut = ctx.RenderComponent<TextArea>(properties => properties
            .Add(p => p.AriaLabel, "horizontal resize textarea")
            .Add(p => p.Value, "test textarea")
            .Add(p => p.ResizeOrientation, ResizeOrientation.Horizontal)
            .Add(p => p.IsRequired, true)
            .Add(p => p.Validated, ValidatedOptions.Error)
        );

        // Assert
        cut.MarkupMatches(
@"
<textarea
  aria-invalid=""true""
  aria-label=""horizontal resize textarea""
  class=""pf-c-form-control pf-m-resize-horizontal""
  required=""""
  value=""test textarea""
/>
");
    }         
    
    [Fact]
    public void ResizableTest()
    {
        // Arrange
        using var ctx = new TestContext();

        // Act
        var cut = ctx.RenderComponent<TextArea>(properties => properties
            .Add(p => p.AriaLabel, "resize textarea")
            .Add(p => p.Value, "test textarea")
            .Add(p => p.ResizeOrientation, ResizeOrientation.Both)
        );

        // Assert
        cut.MarkupMatches(
@"
<textarea
  aria-invalid=""false""
  aria-label=""resize textarea""
  class=""pf-c-form-control pf-m-resize-both""
  value=""test textarea""
/>
");
    }      
    
    [Fact]
    public void ShouldThrowErrorWhenNoAriaLabelOrIdIsGiven()
    {
        // Arrange
        using var ctx = new TestContext();

        // Assert
        var exception = Assert.Throws<InvalidOperationException>(() => ctx.RenderComponent<TextArea>());

        Assert.Equal("TextArea: TextArea requires either an id or aria-label to be specified", exception.Message);
    }
    
    [Fact]
    public void ShouldNotThrowErrorWhenIdIsGivenButNoAriaLabelTest()
    {
        // Arrange
        using var ctx = new TestContext();
        
        // Assert
        var exception = Record.Exception(() => ctx.RenderComponent<TextArea>(parameters => parameters
            .AddUnmatched("id", "text-area-1")
        ));

        Assert.Null(exception);
    }
    
    [Fact]
    public void ShouldNotThrowErrorWhenAriaLabelIsGivenButNoIdTest()
    {
        // Arrange
        using var ctx = new TestContext();
        
        // Assert
        var exception = Record.Exception(() => ctx.RenderComponent<TextArea>(parameters => parameters
            .Add(p => p.AriaLabel, "test textarea")
        ));

        Assert.Null(exception);
    }        
}
