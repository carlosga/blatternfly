namespace Blatternfly.UnitTests.Components;

public class FormAlertTests
{
    [Fact]
    public void DefaultTest()
    {
        // Arrange
        using var ctx = Helper.CreateTestContext();

        // Act
        var cut = ctx.RenderComponent<FormAlert>();

        // Assert
        cut.MarkupMatches(@"<div class=""pf-c-form__alert"" />");
    }
}
