using Blatternfly.Components;
using Bunit;
using Xunit;

namespace Blatternfly.UnitTests.Components
{
    public class HelperTextTests
    {
        [Fact]
        public void DefaultTest()
        {
            // Arrange
            using var ctx = new TestContext();

            // Act
            var cut = ctx.RenderComponent<HelperText>(parameters => parameters
                .Add<HelperTextItem>(p => p.ChildContent, itemparams => itemparams
                    .Add(p => p.ChildContent, "help test text")
                )
            );

            // Assert
            cut.MarkupMatches(
@"
<div
  class=""pf-c-helper-text""
>
  <div
    class=""pf-c-helper-text__item""
  >
    <span
      class=""pf-c-helper-text__item-text""
    >
      help test text
    </span>
  </div>
</div>
");
        }  
        
        [Fact]
        public void VariantTest()
        {
            // Arrange
            using var ctx = new TestContext();

            // Act
            var cut = ctx.RenderComponent<HelperText>(parameters => parameters
                .Add(p => p.Component, HelperTextComponent.ul)
                .Add<HelperTextItem>(p => p.ChildContent, itemparams => itemparams
                    .Add(p => p.Component, HelperTextItemComponent.li)
                    .Add(p =>p.ChildContent, "help test text 1")
                )
                .Add<HelperTextItem>(p => p.ChildContent, itemparams => itemparams
                    .Add(p => p.Component, HelperTextItemComponent.li)
                    .Add(p =>p.ChildContent, "help test text 2")
                )
            );

            // Assert
            cut.MarkupMatches(
@"
<ul
  class=""pf-c-helper-text""
>
  <li
    class=""pf-c-helper-text__item""
  >
    <span
      class=""pf-c-helper-text__item-text""
    >
      help test text 1
    </span>
  </li>
  <li
    class=""pf-c-helper-text__item""
  >
    <span
      class=""pf-c-helper-text__item-text""
    >
      help test text 2
    </span>
  </li>
</ul>
");
        }             
        
        [Fact]
        public void WithIconTest()
        {
            // Arrange
            using var ctx = new TestContext();

            // Act
            var cut = ctx.RenderComponent<HelperText>(parameters => parameters
                .Add<HelperTextItem>(p => p.ChildContent, itemparams => itemparams
                    .Add<CheckIcon>(p => p.Icon)
                    .Add(p => p.ChildContent, "help test text")
                )
            );

            // Assert
            cut.MarkupMatches(
@$"
<div
  class=""pf-c-helper-text""
>
  <div
    class=""pf-c-helper-text__item""
  >
    <span
      aria-hidden=""true""
      class=""pf-c-helper-text__item-icon""
    >
      <svg
        aria-hidden=""true""
        fill=""currentColor""
        height=""1em""
        role=""img""
        style=""vertical-align: -0.125em""
        viewBox=""{CheckIcon.IconDefinition.ViewBox}""
        width=""1em""
      >
        <path
          d=""{CheckIcon.IconDefinition.SvgPath}""
        />
      </svg>
    </span>
    <span
      class=""pf-c-helper-text__item-text""
    >
      help test text
    </span>
  </div>
</div>

");
        }

        [Fact]
        public void IsDynamicTest()
        {
            // Arrange
            using var ctx = new TestContext();

            // Act
            var cut = ctx.RenderComponent<HelperText>(parameters => parameters
                .Add<HelperTextItem>(p => p.ChildContent, itemparams => itemparams
                    .Add(p => p.IsDynamic, true)
                    .Add(p => p.ChildContent, "help test text")
                )
            );

            // Assert
            cut.MarkupMatches(
@$"
<div
  class=""pf-c-helper-text""
>
  <div
    class=""pf-c-helper-text__item pf-m-dynamic""
  >
    <span
      aria-hidden=""true""
      class=""pf-c-helper-text__item-icon""
    >
      <svg
        aria-hidden=""true""
        fill=""currentColor""
        height=""1em""
        role=""img""
        style=""vertical-align: -0.125em""
        viewBox=""{MinusIcon.IconDefinition.ViewBox}""
        width=""1em""
      >
        <path
          d=""{MinusIcon.IconDefinition.SvgPath}""
        />
      </svg>
    </span>
    <span
      class=""pf-c-helper-text__item-text""
    >
      help test text
    </span>
  </div>
</div>
");
        }
    }
}
