﻿namespace Blatternfly.UnitTests.Components;

public class FormSectionTests
{
    [Fact]
    public void DefaultTest()
    {
        // Arrange
        using var ctx = Helper.CreateTestContext();

        // Act
        var cut = ctx.RenderComponent<FormSection>();

        // Assert
        cut.MarkupMatches(@"<section class=""pf-c-form__section"" role=""group"" />");
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
        using var ctx = Helper.CreateTestContext();
        var element = titleElement.ToString();

        // Act
        var cut = ctx.RenderComponent<FormSection>(parameters => parameters
            .Add(p => p.Title, "Title")
            .Add(p => p.TitleElement, titleElement)
        );

        // Assert
        cut.MarkupMatches(
$@"
<section
  aria-labelledby=""pf-form-section-title-1""
  class=""pf-c-form__section""
  role=""group""
>
  <{element}
    class=""pf-c-form__section-title""
    id=""pf-form-section-title-1""
  >
    Title
  </{element}>
</section>
");
    }
}
