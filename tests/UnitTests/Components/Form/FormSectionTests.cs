using Blatternfly.Components;
using Bunit;
using Xunit;

namespace Blatternfly.UnitTests.Components
{
    public class FormSectionTests
    {
        [Fact]
        public void DefaultTest()
        {
            // Arrange
            using var ctx = new TestContext();

            // Act
            var cut = ctx.RenderComponent<FormSection>();

            // Assert
            cut.MarkupMatches(@"<section class=""pf-c-form__section"" />");
        }
        
        [Theory]
        [InlineData(TitleElement.div)]
        [InlineData(TitleElement.h1)]
        [InlineData(TitleElement.h2)]
        [InlineData(TitleElement.h3)]
        [InlineData(TitleElement.h4)]
        [InlineData(TitleElement.h5)]
        [InlineData(TitleElement.h6)] 
        public void WithTitleTest(TitleElement titleElement)
        {
            // Arrange
            using var ctx = new TestContext();
            var element = titleElement.ToString();

            // Act
            var cut = ctx.RenderComponent<FormSection>(parameters => parameters
                .Add(p => p.Title, "Title")
                .Add(p => p.TitleElement, titleElement)
            );

            // Assert
            cut.MarkupMatches(
@$"
<section
  class=""pf-c-form__section""
>
  <{element}
    class=""pf-c-form__section-title""
  >
    Title
  </{element}>
</section>
");
        }        
    }
}
