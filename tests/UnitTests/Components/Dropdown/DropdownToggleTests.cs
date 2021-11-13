namespace Blatternfly.UnitTests.Components;

public class DropdownToggleTests
{
    [Fact]
    public void OnHoverTest()
    {
        // Arrange
        using var ctx = new TestContext();
        
        // Setup Javascript interop
        ctx.SetupJavascriptInterop();

        // Act
        var cut = ctx.RenderComponent<DropdownToggle>(parameters => parameters
            .AddUnmatched("id", "Dropdown Toggle")
            .AddChildContent("Dropdown")
        );

        // Assert
        cut.MarkupMatches(
$@"
<button
  aria-expanded=""false""
  class=""pf-c-dropdown__toggle""
  id=""Dropdown Toggle""
  type=""button""
>
  <span
    class=""pf-c-dropdown__toggle-text""
  >
    Dropdown
  </span>
  <span
    class=""pf-c-dropdown__toggle-icon""
  >
    <svg
      aria-hidden=""true""
      fill=""currentColor""
      height=""1em""
      role=""img""
      style=""vertical-align: -0.125em""
      viewBox=""{CaretDownIcon.IconDefinition.ViewBox}""
      width=""1em""
    >
      <path
        d=""{CaretDownIcon.IconDefinition.SvgPath}""
      />
    </svg>
  </span>
</button>
");            
    }
    
    [Fact]
    public void IsActiveTest()
    {
        // Arrange
        using var ctx = new TestContext();

        // Setup Javascript interop
        ctx.SetupJavascriptInterop();

        // Act
        var cut = ctx.RenderComponent<DropdownToggle>(parameters => parameters
            .AddUnmatched("id", "Dropdown Toggle")
            .Add(p => p.IsActive, true)
            .AddChildContent("Dropdown")
        );

        // Assert
        cut.MarkupMatches(
$@"
<button
  aria-expanded=""false""
  class=""pf-c-dropdown__toggle pf-m-active""
  id=""Dropdown Toggle""
  type=""button""
>
  <span
    class=""pf-c-dropdown__toggle-text""
  >
    Dropdown
  </span>
  <span
    class=""pf-c-dropdown__toggle-icon""
  >
    <svg
      aria-hidden=""true""
      fill=""currentColor""
      height=""1em""
      role=""img""
      style=""vertical-align: -0.125em""
      viewBox=""{CaretDownIcon.IconDefinition.ViewBox}""
      width=""1em""
    >
      <path
        d=""{CaretDownIcon.IconDefinition.SvgPath}""
      />
    </svg>
  </span>
</button>
");            
    }            
}
