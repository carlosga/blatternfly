using Blatternfly.Components;
using Bunit;
using Xunit;

namespace Blatternfly.UnitTests.Components
{
    public class ButtonTests
    {
        [Theory]
        [InlineData(ButtonVariant.Control)]
        [InlineData(ButtonVariant.Danger)]
        [InlineData(ButtonVariant.Inline)]
        [InlineData(ButtonVariant.Link)]
        [InlineData(ButtonVariant.Plain)]
        [InlineData(ButtonVariant.Primary)]
        [InlineData(ButtonVariant.Secondary)]
        [InlineData(ButtonVariant.Tertiary)]
        [InlineData(ButtonVariant.Warning)]
        public void ButtonVariantTest(ButtonVariant variant)
        {
            // Arrange
            using var ctx = new TestContext();
            var modifier = variant.ToString().ToLower();

            // Act
            var cut = ctx.RenderComponent<Button>(parameters => parameters
                .Add(p => p.Variant, variant)
                .Add(p => p.AriaLabel, modifier)
                .AddChildContent($"{modifier} Button")
            );

            // Assert
            cut.MarkupMatches(
@$"
<button
  aria-disabled=""false""
  aria-label=""{modifier}""
  class=""pf-c-button pf-m-{modifier}""
  type=""button""
>
  {modifier}
    Button
</button>
");
        }
        
        [Fact(DisplayName = "it adds an aria-label to plain buttons")]
        public void PlainButtonWithAriaLabel()
        {
            // Arrange
            using var ctx = new TestContext();
            var ariaLabel = "aria-label test";

            // Act
            var cut = ctx.RenderComponent<Button>(parameters => parameters
                .Add(p => p.AriaLabel, "aria-label test")
            );

            // Assert
            Assert.Equal(ariaLabel, cut.Instance.AriaLabel);
            cut.MarkupMatches(
@$"
<button
  aria-disabled=""false""
  aria-label=""{ariaLabel}""
  class=""pf-c-button pf-m-primary""
  type=""button""
></button>
");
        }
        
        [Fact]
        public void LinkWithIconTest()
        {
            // Arrange
            using var ctx = new TestContext();
 
            // Act
            var cut = ctx.RenderComponent<Button>(parameters => parameters
                .Add(p => p.Variant, ButtonVariant.Link)
                .Add<CartArrowDownIcon>(p => p.Icon)
                .AddChildContent("Block Button")
            );

            // Assert
            cut.MarkupMatches(
@"
<button
  aria-disabled=""false""
  class=""pf-c-button pf-m-link""
  type=""button""
>
  <span
    class=""pf-c-button__icon pf-m-start""
  >
    <svg
      aria-hidden=""true""
      fill=""currentColor""
      height=""1em""
      role=""img""
      style=""vertical-align: -0.125em;""
      viewBox=""0 0 576 512""
      width=""1em""
    >
      <path
        d=""M504.717 320H211.572l6.545 32h268.418c15.401 0 26.816 14.301 23.403 29.319l-5.517 24.276C523.112 414.668 536 433.828 536 456c0 31.202-25.519 56.444-56.824 55.994-29.823-.429-54.35-24.631-55.155-54.447-.44-16.287 6.085-31.049 16.803-41.548H231.176C241.553 426.165 248 440.326 248 456c0 31.813-26.528 57.431-58.67 55.938-28.54-1.325-51.751-24.385-53.251-52.917-1.158-22.034 10.436-41.455 28.051-51.586L93.883 64H24C10.745 64 0 53.255 0 40V24C0 10.745 10.745 0 24 0h102.529c11.401 0 21.228 8.021 23.513 19.19L159.208 64H551.99c15.401 0 26.816 14.301 23.403 29.319l-47.273 208C525.637 312.246 515.923 320 504.717 320zM403.029 192H360v-60c0-6.627-5.373-12-12-12h-24c-6.627 0-12 5.373-12 12v60h-43.029c-10.691 0-16.045 12.926-8.485 20.485l67.029 67.029c4.686 4.686 12.284 4.686 16.971 0l67.029-67.029c7.559-7.559 2.205-20.485-8.486-20.485z""
      />
    </svg>
  </span>
  Block Button
</button>
");
        }
        
        [Fact]
        public void IsBlockTest()
        {
            // Arrange
            using var ctx = new TestContext();

            // Act
            var cut = ctx.RenderComponent<Button>(parameters => parameters
                .Add(p => p.IsBlock, true)
                .AddChildContent("Block Button")
            );

            // Assert
            cut.MarkupMatches(
@"
<button
  aria-disabled=""false""
  class=""pf-c-button pf-m-primary pf-m-block""
  type=""button""
>
  Block Button
</button>
");
        }
        
        [Fact]
        public void IsDisabledTest()
        {
            // Arrange
            using var ctx = new TestContext();

            // Act
            var cut = ctx.RenderComponent<Button>(parameters => parameters
                .Add(p => p.IsDisabled, true)
                .AddChildContent("Disabled Button")
            );

            // Assert
            cut.MarkupMatches(
@"
<button
  aria-disabled=""true""
  class=""pf-c-button pf-m-primary pf-m-disabled""
  disabled=""true""
  type=""button""
>
  Disabled Button
</button>
");
        }
        
        [Fact]
        public void IsDangerSecondaryTest()
        {
            // Arrange
            using var ctx = new TestContext();

            // Act
            var cut = ctx.RenderComponent<Button>(parameters => parameters
                .Add(p => p.Variant, ButtonVariant.Secondary)
                .Add(p => p.IsDanger, true)
                .AddChildContent("Danger Secondary Button")
            );

            // Assert
            cut.MarkupMatches(
                @"
<button
  aria-disabled=""false""
  class=""pf-c-button pf-m-secondary pf-m-danger""
  type=""button""
>
  Danger Secondary Button
</button>
");
        }
        
        [Fact]
        public void IsDangerLinkTest()
        {
            // Arrange
            using var ctx = new TestContext();

            // Act
            var cut = ctx.RenderComponent<Button>(parameters => parameters
                .Add(p => p.Variant, ButtonVariant.Link)
                .Add(p => p.IsDanger, true)
                .AddChildContent("Danger Link Button")
            );

            // Assert
            cut.MarkupMatches(
                @"
<button
  aria-disabled=""false""
  class=""pf-c-button pf-m-link pf-m-danger""
  type=""button""
>
  Danger Link Button
</button>
");
        }  
        
        [Fact]
        public void IsAriaDisabledButtonTest()
        {
            // Arrange
            using var ctx = new TestContext();

            // Act
            var cut = ctx.RenderComponent<Button>(parameters => parameters
                .Add(p => p.IsAriaDisabled, true)
                .AddChildContent("Disabled yet focusable button")
            );

            // Assert
            cut.MarkupMatches(
@"
<button
  aria-disabled=""true""
  class=""pf-c-button pf-m-primary pf-m-aria-disabled""
  type=""button""
>
  Disabled yet focusable button
</button>
");
        } 
        
        [Fact]
        public void IsAriaDisabledLinkTest()
        {
            // Arrange
            using var ctx = new TestContext();

            // Act
            var cut = ctx.RenderComponent<Button>(parameters => parameters
                .Add(p => p.Component, "a")
                .Add(p => p.IsAriaDisabled, true)
                .AddChildContent("Disabled yet focusable link button")
            );

            // Assert
            cut.MarkupMatches(
@"
<a
  aria-disabled=""true""
  class=""pf-c-button pf-m-primary pf-m-aria-disabled""
>
  Disabled yet focusable link button
</a>
");
        }
        
        [Fact]
        public void IsInlineTest()
        {
            // Arrange
            using var ctx = new TestContext();

            // Act
            var cut = ctx.RenderComponent<Button>(parameters => parameters
                .Add(p => p.Variant, ButtonVariant.Link)
                .Add(p => p.IsInline, true)
                .AddChildContent("Hovered Button")
            );

            // Assert
            cut.MarkupMatches(
@"
<button
  aria-disabled=""false""
  class=""pf-c-button pf-m-link pf-m-inline""
  type=""button""
>
  Hovered Button
</button>
");
        }
        
        [Fact]
        public void IsSmallTest()
        {
            // Arrange
            using var ctx = new TestContext();

            // Act
            var cut = ctx.RenderComponent<Button>(parameters => parameters
                .Add(p => p.IsSmall, true)
                .AddChildContent("Small Button")
            );

            // Assert
            cut.MarkupMatches(
@"
<button
  aria-disabled=""false""
  class=""pf-c-button pf-m-primary pf-m-small""
  type=""button""
>
  Small Button
</button>
");
        }
        
        [Fact]
        public void IsLargeTest()
        {
            // Arrange
            using var ctx = new TestContext();

            // Act
            var cut = ctx.RenderComponent<Button>(parameters => parameters
                .Add(p => p.IsLarge, true)
                .AddChildContent("Large Button")
            );

            // Assert
            cut.MarkupMatches(
                @"
<button
  aria-disabled=""false""
  class=""pf-c-button pf-m-primary pf-m-large""
  type=""button""
>
  Large Button
</button>
");
        }        
        
        [Fact]
        public void IsLoading()
        {
            // Arrange
            using var ctx = new TestContext();

            // Act
            var cut = ctx.RenderComponent<Button>(parameters => parameters
                .Add(p => p.IsLoading, true)
                .Add(p => p.SpinnerAriaValueText, "Loading")
                .AddChildContent("Loading Button")
            );

            // Assert
            cut.MarkupMatches(
                @"
<button
  aria-disabled=""false""
  class=""pf-c-button pf-m-primary pf-m-progress pf-m-in-progress""
  type=""button""
>
  <span
    class=""pf-c-button__progress""
  >
    <span
      aria-valuetext=""Loading""
      class=""pf-c-spinner pf-m-md""
      role=""progressbar""
    >
      <span class=""pf-c-spinner__clipper""></span>
      <span class=""pf-c-spinner__lead-ball""></span>
      <span class=""pf-c-spinner__tail-ball""></span>
    </span>
  </span>
  Loading Button
</button>
");
        }
        
        [Fact(DisplayName = "allows passing in a string as the component")]
        public void CustomComponentTest()
        {
            // Arrange
            using var ctx = new TestContext();
            var component = "a";

            // Act
            var cut = ctx.RenderComponent<Button>(parameters => parameters
                .Add(p => p.Component, "a")
            );

            // Assert
            Assert.Equal(component, cut.Instance.Component);
            cut.MarkupMatches(
                @"<a aria-disabled=""false"" class=""pf-c-button pf-m-primary""></a>");
        }
        
        [Fact]
        public void AriaDisabledTabIndexTest()
        {
            // Arrange
            using var ctx = new TestContext();

            // Act
            var cut = ctx.RenderComponent<Button>(parameters => parameters
                .Add(p => p.Component, "a")
                .Add(p => p.IsDisabled, true)
                .AddChildContent("Disabled Anchor Button")
            );

            // Assert
            cut.MarkupMatches(
@"
<a
  aria-disabled=""true""
  class=""pf-c-button pf-m-primary pf-m-disabled""
  tabIndex=""-1""
>
  Disabled Anchor Button
</a>
");
        }             
        
        [Fact]
        public void TabIndexTest()
        {
            // Arrange
            using var ctx = new TestContext();

            // Act
            var cut = ctx.RenderComponent<Button>(parameters => parameters
                .Add(p => p.TabIndex, 0)
            );

            // Assert
            cut.MarkupMatches(
@"<button   
  aria-disabled=""false"" 
  class=""pf-c-button pf-m-primary"" 
  tabIndex=""0"" 
  type=""button"">
</button>");
        }        
    }
}
