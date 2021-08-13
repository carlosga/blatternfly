using Blatternfly.Components;
using Bunit;
using Xunit;

namespace Blatternfly.UnitTests.Components
{
    public class ListTests
    {
        [Fact]
        public void DefaultTest()
        {
            // Arrange
            using var ctx = new TestContext();

            // Act
            var cut = ctx.RenderComponent<List>(parameters => parameters
                .Add<ListItem>(p => p.ChildContent, p => p.AddChildContent("First"))
                .Add<ListItem>(p => p.ChildContent, p => p.AddChildContent("Second"))
                .Add<ListItem>(p => p.ChildContent, p => p.AddChildContent("Third"))
            );

            // Assert
            cut.MarkupMatches(
@"
<ul class=""pf-c-list"">
  <li>First</li>
  <li>Second</li>
  <li>Third</li>
</ul>
");
        }      
        
        [Fact]
        public void IsInlineTest()
        {
            // Arrange
            using var ctx = new TestContext();

            // Act
            var cut = ctx.RenderComponent<List>(parameters => parameters
                .Add(p => p.Variant, ListVariant.Inline)
                .Add<ListItem>(p => p.ChildContent, p => p.AddChildContent("First"))
                .Add<ListItem>(p => p.ChildContent, p => p.AddChildContent("Second"))
                .Add<ListItem>(p => p.ChildContent, p => p.AddChildContent("Third"))
            );

            // Assert
            cut.MarkupMatches(
@"
<ul class=""pf-c-list pf-m-inline"">
  <li>First</li>
  <li>Second</li>
  <li>Third</li>
</ul>
");
        }          
        
        [Fact]
        public void OrderedListTest()
        {
            // Arrange
            using var ctx = new TestContext();

            // Act
            var cut = ctx.RenderComponent<List>(parameters => parameters
                .Add(p => p.Component, ListComponent.ol)
                .Add<ListItem>(p => p.ChildContent, p => p.AddChildContent("Apple"))
                .Add<ListItem>(p => p.ChildContent, p => p.AddChildContent("Banana"))
                .Add<ListItem>(p => p.ChildContent, p => p.AddChildContent("Orange"))
            );

            // Assert
            cut.MarkupMatches(
@"
<ol class=""pf-c-list"" type=""1"">
  <li>Apple</li>
  <li>Banana</li>
  <li>Orange</li>
</ol>
");
        }         
        
        [Fact]
        public void OrderedListStartsWith2ItemTest()
        {
            // Arrange
            using var ctx = new TestContext();

            // Act
            var cut = ctx.RenderComponent<List>(parameters => parameters
                .Add(p => p.Component, ListComponent.ol)
                .AddUnmatched("start", "2")
                .Add<ListItem>(p => p.ChildContent, p => p.AddChildContent("Banana"))
                .Add<ListItem>(p => p.ChildContent, p => p.AddChildContent("Orange"))
            );

            // Assert
            cut.MarkupMatches(
@"
<ol class=""pf-c-list"" type=""1"" start=""2"">
  <li>Banana</li>
  <li>Orange</li>
</ol>
");
        }
        
        [Fact]
        public void OrderedListItemsWillBeNuimberedWithUppercaseLettersTest()
        {
            // Arrange
            using var ctx = new TestContext();

            // Act
            var cut = ctx.RenderComponent<List>(parameters => parameters
                .Add(p => p.Component, ListComponent.ol)
                .Add(p => p.Type, OrderType.UppercaseLetter)
                .Add<ListItem>(p => p.ChildContent, p => p.AddChildContent("Banana"))
                .Add<ListItem>(p => p.ChildContent, p => p.AddChildContent("Orange"))
            );

            // Assert
            cut.MarkupMatches(
@"
<ol class=""pf-c-list"" type=""A"">
  <li>Banana</li>
  <li>Orange</li>
</ol>
");
        }       
    
        [Fact]
        public void InlinedOrderedListTest()
        {
            // Arrange
            using var ctx = new TestContext();

            // Act
            var cut = ctx.RenderComponent<List>(parameters => parameters
                .Add(p => p.Variant, ListVariant.Inline)
                .Add(p => p.Component, ListComponent.ol)
                .Add<ListItem>(p => p.ChildContent, p => p.AddChildContent("Apple"))
                .Add<ListItem>(p => p.ChildContent, p => p.AddChildContent("Banana"))
                .Add<ListItem>(p => p.ChildContent, p => p.AddChildContent("Orange"))
            );

            // Assert
            cut.MarkupMatches(
                @"
<ol class=""pf-c-list pf-m-inline"" type=""1"">
  <li>Apple</li>
  <li>Banana</li>
  <li>Orange</li>
</ol>
");
        }
        
        [Fact]
        public void IsBorderedTest()
        {
            // Arrange
            using var ctx = new TestContext();

            // Act
            var cut = ctx.RenderComponent<List>(parameters => parameters
                .Add(p => p.IsBordered, true)
                .Add<ListItem>(p => p.ChildContent, p => p.AddChildContent("First"))
                .Add<ListItem>(p => p.ChildContent, p => p.AddChildContent("Second"))
                .Add<ListItem>(p => p.ChildContent, p => p.AddChildContent("Third"))
            );

            // Assert
            cut.MarkupMatches(
                @"
<ul class=""pf-c-list pf-m-bordered"">
  <li>First</li>
  <li>Second</li>
  <li>Third</li>
</ul>
");
        }
        
        [Fact]
        public void IsPlainTest()
        {
            // Arrange
            using var ctx = new TestContext();

            // Act
            var cut = ctx.RenderComponent<List>(parameters => parameters
                .Add(p => p.IsPlain, true)
                .Add<ListItem>(p => p.ChildContent, p => p.AddChildContent("First"))
                .Add<ListItem>(p => p.ChildContent, p => p.AddChildContent("Second"))
                .Add<ListItem>(p => p.ChildContent, p => p.AddChildContent("Third"))
            );

            // Assert
            cut.MarkupMatches(
@"
<ul class=""pf-c-list pf-m-plain"">
  <li>First</li>
  <li>Second</li>
  <li>Third</li>
</ul>
");
        }
        
        [Fact]
        public void IconListTest()
        {
            // Arrange
            using var ctx = new TestContext();

            // Act
            var cut = ctx.RenderComponent<List>(parameters => parameters
                .Add(p => p.IsPlain, true)
                .Add<ListItem>(p => p.ChildContent, p => p
                    .AddChildContent("Apple")
                    .Add<BookOpenIcon>(p => p.Icon)
                 )
                .Add<ListItem>(p => p.ChildContent, p => p
                    .AddChildContent("Banana")
                    .Add<KeyIcon>(p => p.Icon)
                )
                .Add<ListItem>(p => p.ChildContent, p => p
                    .AddChildContent("Orange")
                    .Add<DesktopIcon>(p => p.Icon)
                )
            );

            // Assert
            cut.MarkupMatches(
@$"
<ul
  class=""pf-c-list pf-m-plain""
>
  <li
    class=""pf-c-list__item""
  >
    <span
      class=""pf-c-list__item-icon""
    >
        <svg
          style=""vertical-align: -0.125em;"" 
          fill=""currentColor"" 
          height=""1em"" 
          width=""1em"" 
          viewBox=""{BookOpenIcon.IconDefinition.ViewBox}"" 
          aria-hidden=""true"" 
          role=""img""
        >
          <path d=""{BookOpenIcon.IconDefinition.SvgPath}""></path>
        </svg>
    </span>
    Apple
  </li>
  <li
    class=""pf-c-list__item""
  >
    <span
      class=""pf-c-list__item-icon""
    >
        <svg
          style=""vertical-align: -0.125em;"" 
          fill=""currentColor"" 
          height=""1em"" 
          width=""1em"" 
          viewBox=""{KeyIcon.IconDefinition.ViewBox}"" 
          aria-hidden=""true"" 
          role=""img""
        >
          <path d=""{KeyIcon.IconDefinition.SvgPath}""></path>
        </svg>
    </span>
    Banana
  </li>
  <li
    class=""pf-c-list__item""
  >
    <span
      class=""pf-c-list__item-icon""
    >
        <svg
          style=""vertical-align: -0.125em;"" 
          fill=""currentColor"" 
          height=""1em"" 
          width=""1em"" 
          viewBox=""{DesktopIcon.IconDefinition.ViewBox}"" 
          aria-hidden=""true"" 
          role=""img""
        >
          <path d=""{DesktopIcon.IconDefinition.SvgPath}""></path>
        </svg>
    </span>
    Orange
  </li>
</ul>
");
        }     
        
        [Fact]
        public void LargeIconListTest()
        {
            // Arrange
            using var ctx = new TestContext();

            // Act
            var cut = ctx.RenderComponent<List>(parameters => parameters
                .Add(p => p.IconSize, ListIconSize.Large)
                .Add<ListItem>(p => p.ChildContent, p => p
                    .AddChildContent("Apple")
                    .Add<BookOpenIcon>(p => p.Icon)
                 )
                .Add<ListItem>(p => p.ChildContent, p => p
                    .AddChildContent("Banana")
                    .Add<KeyIcon>(p => p.Icon)
                )
                .Add<ListItem>(p => p.ChildContent, p => p
                    .AddChildContent("Orange")
                    .Add<DesktopIcon>(p => p.Icon)
                )
            );

            // Assert
            cut.MarkupMatches(
@$"
<ul
  class=""pf-c-list pf-m-icon-lg""
>
  <li
    class=""pf-c-list__item""
  >
    <span
      class=""pf-c-list__item-icon""
    >
        <svg
          style=""vertical-align: -0.125em;"" 
          fill=""currentColor"" 
          height=""1em"" 
          width=""1em"" 
          viewBox=""{BookOpenIcon.IconDefinition.ViewBox}"" 
          aria-hidden=""true"" 
          role=""img""
        >
          <path d=""{BookOpenIcon.IconDefinition.SvgPath}""></path>
        </svg>
    </span>
    Apple
  </li>
  <li
    class=""pf-c-list__item""
  >
    <span
      class=""pf-c-list__item-icon""
    >
        <svg
          style=""vertical-align: -0.125em;"" 
          fill=""currentColor"" 
          height=""1em"" 
          width=""1em"" 
          viewBox=""{KeyIcon.IconDefinition.ViewBox}"" 
          aria-hidden=""true"" 
          role=""img""
        >
          <path d=""{KeyIcon.IconDefinition.SvgPath}""></path>
        </svg>
    </span>
    Banana
  </li>
  <li
    class=""pf-c-list__item""
  >
    <span
      class=""pf-c-list__item-icon""
    >
        <svg
          style=""vertical-align: -0.125em;"" 
          fill=""currentColor"" 
          height=""1em"" 
          width=""1em"" 
          viewBox=""{DesktopIcon.IconDefinition.ViewBox}"" 
          aria-hidden=""true"" 
          role=""img""
        >
          <path d=""{DesktopIcon.IconDefinition.SvgPath}""></path>
        </svg>
    </span>
    Orange
  </li>
</ul>
");
        }          
    }
}
