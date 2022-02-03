namespace Blatternfly.UnitTests.Components;

public class ModalTests
{
    [Fact]
    public void WithoutTitleAndAriaLabelAndAriaLabelledByTest()
    {
        // Arrange
        using var ctx = Helper.CreateTestContext();

        // Act
        var ex = Assert.Throws<InvalidOperationException>(() => ctx.RenderComponent<Modal>());

        // Assert
        Assert.Equal("Modal: Specify at least one of: title, aria-label, aria-labelledby.", ex.Message);
    }

    [Fact]
    public void WithoutAriaLabelAndAriaLabelledAndWithHasNoBodyWrapperByTest()
    {
        // Arrange
        using var ctx = Helper.CreateTestContext();

        // Act
        var ex = Assert.Throws<InvalidOperationException>(() => ctx.RenderComponent<Modal>(parameters => parameters
            .Add(p => p.Title, "This is a Modal title")
            .Add(p => p.HasNoBodyWrapper, true)
        ));

        // Assert
        Assert.Equal("Modal: When using hasNoBodyWrapper or setting a custom header, ensure you assign an accessible name to the the modal container with aria-label or aria-labelledby.", ex.Message);
    }

    [Fact]
    public void WithoutAriaLabelAndAriaLabelledAndWithHeaderTest()
    {
        // Arrange
        using var ctx = Helper.CreateTestContext();

        // Act
        var ex = Assert.Throws<InvalidOperationException>(() => ctx.RenderComponent<Modal>(parameters => parameters
            .Add(p => p.Title, "This is a Modal title")
            .Add(p => p.Header, "This is a Modal header")
        ));

        // Assert
        Assert.Equal("Modal: When using hasNoBodyWrapper or setting a custom header, ensure you assign an accessible name to the the modal container with aria-label or aria-labelledby.", ex.Message);
    }
}
