using Blatternfly.Components;
using Bunit;
using Xunit;

namespace Blatternfly.UnitTests.Components
{
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
  htmlFor=""switch-is-checked""
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
  htmlFor=""switch-is-not-checked""
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
  htmlFor=""switch-is-checked""
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
  htmlFor=""switch-is-not-checked""
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
    }
}
