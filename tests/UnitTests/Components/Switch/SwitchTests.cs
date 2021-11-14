namespace Blatternfly.UnitTests.Components;

public class SwitchTests
{
    [Fact]
    public void IsCheckedTest()
    {
        // Arrange
        using var ctx = new TestContext();

        // Act
        var cut = ctx.RenderComponent<Switch>(parameters => parameters
            .AddUnmatched("id", "switch-is-checked")
            .Add(p => p.Label, "On")
            .Add(p => p.LabelOff, "Off")
            .Add(p => p.Value, true)
        );

        // Assert
        cut.MarkupMatches(
@"
<label
  class=""pf-c-switch""
  for=""switch-is-checked""
>
  <input
    aria-label=""""
    aria-labelledby=""switch-is-checked-on""
    aria-invalid=""false""
    checked=""""
    class=""pf-c-switch__input""
    id=""switch-is-checked""
    type=""checkbox""
  />
  <span class=""pf-c-switch__toggle""></span>  
  <span
    aria-hidden=""true""
    class=""pf-c-switch__label pf-m-on""
    id=""switch-is-checked-on""
  >
    On
  </span>
  <span
    aria-hidden=""true""
    class=""pf-c-switch__label pf-m-off""
    id=""switch-is-checked-off""
  >
    Off
  </span>
</label>
");
    }
    
    [Fact]
    public void IsNotCheckedTest()
    {
        // Arrange
        using var ctx = new TestContext();

        // Act
        var cut = ctx.RenderComponent<Switch>(parameters => parameters
            .AddUnmatched("id", "switch-is-not-checked")
            .Add(p => p.Label, "On")
            .Add(p => p.LabelOff, "Off")
            .Add(p => p.Value, false)
        );

        // Assert
        cut.MarkupMatches(
@"
<label
  class=""pf-c-switch""
  for=""switch-is-not-checked""
>
  <input
    aria-label=""""
    aria-labelledby=""switch-is-not-checked-on""
    aria-invalid=""false""
    class=""pf-c-switch__input""
    id=""switch-is-not-checked""
    type=""checkbox""
  />
  <span class=""pf-c-switch__toggle""></span>  
  <span
    aria-hidden=""true""
    class=""pf-c-switch__label pf-m-on""
    id=""switch-is-not-checked-on""
  >
    On
  </span>
  <span
    aria-hidden=""true""
    class=""pf-c-switch__label pf-m-off""
    id=""switch-is-not-checked-off""
  >
    Off
  </span>
</label>
");
    }
    
    [Fact]
    public void WithOnlyLabelIsCheckedTest()
    {
        // Arrange
        using var ctx = new TestContext();
        var check = true;

        // Act
        var cut = ctx.RenderComponent<Switch>(parameters => parameters
            .AddUnmatched("id", "switch-is-checked")
            .Add(p => p.Label, check ? "On" : "Off")
            .Add(p => p.Value, check)
        );

        // Assert
        cut.MarkupMatches(
@"
<label
  class=""pf-c-switch""
  for=""switch-is-checked""
>
  <input
    aria-label=""""
    aria-labelledby=""switch-is-checked-on""
    aria-invalid=""false""
    checked=""""
    class=""pf-c-switch__input""
    id=""switch-is-checked""
    type=""checkbox""
  />
  <span class=""pf-c-switch__toggle""></span>
  <span
    aria-hidden=""true""
    class=""pf-c-switch__label pf-m-on""
    id=""switch-is-checked-on""
  >
    On
  </span>
  <span
    aria-hidden=""true""
    class=""pf-c-switch__label pf-m-off""
    id=""switch-is-checked-off""
  >
    On
  </span>
</label>
");
    }
    
    [Fact]
    public void WithOnlyLabelIsNotCheckedTest()
    {
        // Arrange
        using var ctx = new TestContext();
        var check = false;

        // Act
        var cut = ctx.RenderComponent<Switch>(parameters => parameters
            .AddUnmatched("id", "switch-is-not-checked")
            .Add(p => p.Label, check ? "On" : "Off")
            .Add(p => p.Value, check)
        );

        // Assert
        cut.MarkupMatches(
@"
<label
  class=""pf-c-switch""
  for=""switch-is-not-checked""
>
  <input
    aria-label=""""
    aria-labelledby=""switch-is-not-checked-on""
    aria-invalid=""false""
    class=""pf-c-switch__input""
    id=""switch-is-not-checked""
    type=""checkbox""
  />
  <span class=""pf-c-switch__toggle""></span>
  <span
    aria-hidden=""true""
    class=""pf-c-switch__label pf-m-on""
    id=""switch-is-not-checked-on""
  >
    Off
  </span>
  <span
    aria-hidden=""true""
    class=""pf-c-switch__label pf-m-off""
    id=""switch-is-not-checked-off""
  >
    Off
  </span>
</label>
");
    }

    [Fact]
    public void NoLabelSwitchIsCheckedTest()
    {
        // Arrange
        using var ctx = new TestContext();
        var check = true;

        // Act
        var cut = ctx.RenderComponent<Switch>(parameters => parameters
            .AddUnmatched("id", "no-label-switch-is-checked")
            .Add(p => p.Value, check)
        );

        // Assert
        cut.MarkupMatches(
$@"
<label
  class=""pf-c-switch""
  for=""no-label-switch-is-checked""
>
  <input
    aria-label=""""
    aria-labelledby=""no-label-switch-is-checked-on""
    aria-invalid=""false""
    checked=""""
    class=""pf-c-switch__input""
    id=""no-label-switch-is-checked""
    type=""checkbox""
  />
  <span
    class=""pf-c-switch__toggle""
  >
    <div
      aria-hidden=""true""
      class=""pf-c-switch__toggle-icon""
    >
      <svg
        fill=""currentColor""
        height=""1em""
        width=""1em""
        viewBox=""{CheckIcon.IconDefinition.ViewBox}""
        aria-hidden=""true""
        role=""img""
      >
        <path d=""{CheckIcon.IconDefinition.SvgPath}""></path>
      </svg>
    </div>
  </span>
</label>
");
    }
    
    [Fact]
    public void NoLabelSwitchIsNotCheckedTest()
    {
        // Arrange
        using var ctx = new TestContext();
        var check = false;

        // Act
        var cut = ctx.RenderComponent<Switch>(parameters => parameters
            .AddUnmatched("id", "no-label-switch-is-not-checked")
            .Add(p => p.Value, check)
        );

        // Assert
        cut.MarkupMatches(
$@"
<label
  class=""pf-c-switch""
  for=""no-label-switch-is-not-checked""
>
  <input
    aria-label=""""
    aria-labelledby=""no-label-switch-is-not-checked-on""
    aria-invalid=""false""
    class=""pf-c-switch__input""
    id=""no-label-switch-is-not-checked""
    type=""checkbox""
  />
  <span
    class=""pf-c-switch__toggle""
  >
    <div
      aria-hidden=""true""
      class=""pf-c-switch__toggle-icon""
    >
      <svg
        fill=""currentColor""
        height=""1em""
        width=""1em""
        viewBox=""{CheckIcon.IconDefinition.ViewBox}""
        aria-hidden=""true""
        role=""img""
      >
        <path d=""{CheckIcon.IconDefinition.SvgPath}""></path>
      </svg>
    </div>
  </span>
</label>

");
    }
    
    [Fact]
    public void IsCheckedAndDisabledTest()
    {
        // Arrange
        using var ctx = new TestContext();

        // Act
        var cut = ctx.RenderComponent<Switch>(parameters => parameters
            .AddUnmatched("id", "switch-is-checked-and-disabled")
            .Add(p => p.Value, true)
            .Add(p => p.IsDisabled, true)
        );

        // Assert
        cut.MarkupMatches(
$@"
<label
  class=""pf-c-switch""
  for=""switch-is-checked-and-disabled""
>
  <input
    aria-label=""""
    aria-labelledby=""switch-is-checked-and-disabled-on""
    aria-invalid=""false""
    checked=""""
    class=""pf-c-switch__input""
    disabled=""""
    id=""switch-is-checked-and-disabled""
    type=""checkbox""
  />
  <span
    class=""pf-c-switch__toggle""
  >
    <div
      aria-hidden=""true""
      class=""pf-c-switch__toggle-icon""
    >
      <svg
        fill=""currentColor""
        height=""1em""
        width=""1em""
        viewBox=""{CheckIcon.IconDefinition.ViewBox}""
        aria-hidden=""true""
        role=""img""
      >
        <path d=""{CheckIcon.IconDefinition.SvgPath}""></path>
      </svg>
    </div>
  </span>
</label>

");
    }
    
    [Fact]
    public void IsNotCheckedAndDisabledTest()
    {
        // Arrange
        using var ctx = new TestContext();

        // Act
        var cut = ctx.RenderComponent<Switch>(parameters => parameters
            .AddUnmatched("id", "switch-is-not-checked-and-disabled")
            .Add(p => p.Value, false)
            .Add(p => p.IsDisabled, true)
        );

        // Assert
        cut.MarkupMatches(
$@"
<label
  class=""pf-c-switch""
  for=""switch-is-not-checked-and-disabled""
>
  <input
    aria-label=""""
    aria-labelledby=""switch-is-not-checked-and-disabled-on""
    aria-invalid=""false""
    class=""pf-c-switch__input""
    disabled=""""
    id=""switch-is-not-checked-and-disabled""
    type=""checkbox""
  />
  <span
    class=""pf-c-switch__toggle""
  >
    <div
      aria-hidden=""true""
      class=""pf-c-switch__toggle-icon""
    >
      <svg
        fill=""currentColor""
        height=""1em""
        width=""1em""
        viewBox=""{CheckIcon.IconDefinition.ViewBox}""
        aria-hidden=""true""
        role=""img""
      >
        <path d=""{CheckIcon.IconDefinition.SvgPath}""></path>
      </svg>
    </div>
  </span>
</label>

");
    }
    
    [Fact]
    public void ShouldThrowWhenNoIdIsGivenTest()
    {
        // Arrange
        using var ctx = new TestContext();

        // Act
        var ex = Assert.Throws<InvalidOperationException>(() => {
            ctx.RenderComponent<Switch>(parameters => parameters
                .Add(p => p.Value, true));
        });
        Assert.Equal("Switch: id is required to make it accessible.", ex.Message);
    }
    
    [Fact]
    public void ShouldThrowWhenNoAriaLabelOrLabelGivenTest()
    {
        // Arrange
        using var ctx = new TestContext();

        // Act
        var ex = Assert.Throws<InvalidOperationException>(() => {
            ctx.RenderComponent<Switch>(parameters => parameters
                .AddUnmatched("id", "switch-1")
                .Add(p => p.AriaLabel, null)
                .Add(p => p.Value, true));
        });
        Assert.Equal("Switch: Switch requires either a label or an aria-label to be specified.", ex.Message);
    }

    [Fact]
    public void ShouldNotThrowExceptionWhenLabelIsGivenButNoAriaLabelTest()
    {
        // Arrange
        using var ctx = new TestContext();

        // Act
        var exception = Record.Exception(() => {
            ctx.RenderComponent<Switch>(parameters => parameters
                .AddUnmatched("id", "switch-1")
                .Add(p => p.Label, "swtich-test")
                .Add(p => p.Value, true));
        });

        Assert.Null(exception);            
    }         
        
    [Fact]
    public void ShouldNotThrowExceptionWhenAriaLabelIsGivenButNoLabelTest()
    {
        // Arrange
        using var ctx = new TestContext();

        // Act
        var exception = Record.Exception(() => {
            ctx.RenderComponent<Switch>(parameters => parameters
                .AddUnmatched("id", "switch-1")
                .Add(p => p.AriaLabel, "swtich-test")
                .Add(p => p.Value, true));
        });

        Assert.Null(exception);            
    }
    
    [Fact]
    public void WithReverseModifierTest()
    {
        // Arrange
        using var ctx = new TestContext();

        // Act
        var cut = ctx.RenderComponent<Switch>(parameters => parameters
            .AddUnmatched("id", "reversed-switch")
            .Add(p => p.Label, "reversed switch")
            .Add(p => p.IsReversed, true)
            .Add(p => p.Value, true)
        );

        // Assert
        cut.MarkupMatches(
@"
<label
  class=""pf-c-switch pf-m-reverse""
  for=""reversed-switch""
>
  <input
    id=""reversed-switch""
    class=""pf-c-switch__input""
    type=""checkbox""
    aria-labelledby=""reversed-switch-on""
    aria-label=""""
    aria-invalid=""false""
    checked=""""
  >
  <span class=""pf-c-switch__toggle""></span>
  <span
    class=""pf-c-switch__label pf-m-on""
    id=""reversed-switch-on""
    aria-hidden=""true""
  >
    reversed switch
  </span>
  <span
    class=""pf-c-switch__label pf-m-off""
    id=""reversed-switch-off""
    aria-hidden=""true""
  >
    reversed switch
  </span>
</label>
");
    }        
}
