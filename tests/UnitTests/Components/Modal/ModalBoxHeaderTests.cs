namespace Blatternfly.UnitTests.Components;

public class ModalBoxHeaderTests
{
    [Fact]
    public void DefaultTest()
    {
        // Arrange
        using var ctx = Helper.CreateTestContext();

        // Act
        var cut = ctx.RenderComponent<ModalBoxHeader>(parameters => parameters
            .AddChildContent("This is a ModalBox header")
        );

        // Assert
        cut.MarkupMatches(
@"
<header
  class=""pf-c-modal-box__header""
>
  This is a ModalBox header
</header>
");
    }

    [Fact]
    public void WithHelpTest()
    {
        // Arrange
        using var ctx = Helper.CreateTestContext();

        // Act
        var cut = ctx.RenderComponent<ModalBoxHeader>(parameters => parameters
            .Add(p => p.Help, "test")
            .AddChildContent("This is a ModalBox header")
        );

        // Assert
        cut.MarkupMatches(
@"
<header
  class=""pf-c-modal-box__header pf-m-help""
>
  <div
    class=""pf-c-modal-box__header-main""
  >
    This is a ModalBox header
  </div>
  <div
    class=""pf-c-modal-box__header-help""
  >
    test
  </div>
</header>
");
    }
}

