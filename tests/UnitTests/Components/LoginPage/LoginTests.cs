namespace Blatternfly.UnitTests.Components;

public class LoginTests
{
    [Fact]
    public void DefaultTest()
    {
        // Arrange
        using var ctx = new TestContext();

        // Act
        var cut = ctx.RenderComponent<Login>(parameters => parameters
            .Add<LoginFooter>(p => p.Footer, footerparams => footerparams
                .AddChildContent("Footer")
            )
            .Add<LoginHeader>(p => p.Header, headerparams => headerparams
                .Add(p => p.HeaderBrand, "HeaderBrand")
                .AddChildContent("Header Text")
            )
            .AddChildContent("Main")
        );

        // Assert
        cut.MarkupMatches(
@"
<div
  class=""pf-c-login""
>
  <div
    class=""pf-c-login__container""
  >
  <header class=""pf-c-login__header"">
    HeaderBrand   Header Text
  </header>
  <main
      class=""pf-c-login__main""
    >
      Main
    </main>
    <footer class=""pf-c-login__footer"">
      Footer
    </footer>
  </div>
</div>
");
    }        
}
