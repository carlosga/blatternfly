namespace Blatternfly.UnitTests.Components;

public class ModalContentTests
{
    [Fact]
    public void IsOpenTest()
    {
        // Arrange
        using var ctx = new TestContext();

        // Setup Javascript interop
        ctx.AddServices();

        // Act
        var cut = ctx.RenderComponent<ModalContent>(parameters => parameters
            .Add(p => p.Title, "Test Modal Content title")
            .Add(p => p.IsOpen, true)
            .Add(p => p.BoxId, "boxId")
            .Add(p => p.LabelId, "labelId")
            .Add(p => p.DescriptorId, "descriptorId")
            .AddChildContent("This is a ModalBox body")
        );

        // Assert
        cut.MarkupMatches(
$@"
<div class=""pf-c-backdrop"">
  <div class=""pf-l-bullseye"">
    <div id=""boxId"" role=""dialog"" aria-describedby=""descriptorId"" aria-modal=""true"" class=""pf-c-modal-box"">
      <button
        aria-disabled=""false""
        aria-label=""Close""
        class=""pf-c-button pf-m-plain""
        type=""button""
      >
        <svg
          style=""vertical-align: -0.125em;""
          fill=""currentColor""
          height=""1em""
          width=""1em""
          viewBox=""{TimesIcon.IconDefinition.ViewBox}""
          aria-hidden=""true""
          role=""img""
        >
          <path d=""{TimesIcon.IconDefinition.SvgPath}""></path>
        </svg>
      </button>
      <header class=""pf-c-modal-box__header"">
        <h1 class=""pf-c-modal-box__title"" id=""labelId"">
          <span class=""pf-c-modal-box__title-text"">Test Modal Content title</span>
        </h1>
      </header>
      <div id=""descriptorId"" class=""pf-c-modal-box__body"">This is a ModalBox body</div>                                                         </div>
  </div>
</div>
");
    }

    [Fact]
    public void WithDescriptionTest()
    {
        // Arrange
        using var ctx = new TestContext();

        // Setup Javascript interop
        ctx.AddServices();

        // Act
        var cut = ctx.RenderComponent<ModalContent>(parameters => parameters
            .Add(p => p.Title, "Test Modal Content title")
            .Add(p => p.IsOpen, true)
            .Add(p => p.Description, "This is a test description.")
            .Add(p => p.BoxId, "boxId")
            .Add(p => p.LabelId, "labelId")
            .Add(p => p.DescriptorId, "descriptorId")
            .AddChildContent("This is a ModalBox body")
        );

        // Assert
        cut.MarkupMatches(
$@"
<div class=""pf-c-backdrop"">
  <div class=""pf-l-bullseye"">
    <div id=""boxId"" role=""dialog"" aria-describedby=""descriptorId"" aria-modal=""true"" class=""pf-c-modal-box"">
      <button
        aria-disabled=""false""
        aria-label=""Close""
        class=""pf-c-button pf-m-plain""
        type=""button""
      >
        <svg
          style=""vertical-align: -0.125em;""
          fill=""currentColor""
          height=""1em""
          width=""1em""
          viewBox=""{TimesIcon.IconDefinition.ViewBox}""
          aria-hidden=""true""
          role=""img""
        >
          <path d=""{TimesIcon.IconDefinition.SvgPath}""></path>
        </svg>
      </button>
      <header class=""pf-c-modal-box__header"">
        <h1 class=""pf-c-modal-box__title"" id=""labelId"">
          <span class=""pf-c-modal-box__title-text"">Test Modal Content title</span>
        </h1>
        <div id=""descriptorId"" class=""pf-c-modal-box__description"">This is a test description.</div>
      </header>
      <div class=""pf-c-modal-box__body"">This is a ModalBox body</div>
    </div>
  </div>
</div>
");
    }

    [Fact]
    public void WithFooterTest()
    {
        // Arrange
        using var ctx = new TestContext();

        // Setup Javascript interop
        ctx.AddServices();

        // Act
        var cut = ctx.RenderComponent<ModalContent>(parameters => parameters
            .Add(p => p.Title, "Test Modal Content title")
            .Add(p => p.IsOpen, true)
            .Add(p => p.Actions, "Testing")
            .Add(p => p.BoxId, "boxId")
            .Add(p => p.LabelId, "labelId")
            .Add(p => p.DescriptorId, "descriptorId")
            .AddChildContent("This is a ModalBox body")
        );

        // Assert
        cut.MarkupMatches(
$@"
<div class=""pf-c-backdrop"">
  <div class=""pf-l-bullseye"">
    <div
      id=""boxId""
      role=""dialog""
      aria-describedby=""descriptorId""
      aria-modal=""true""
      class=""pf-c-modal-box""
    >
      <button
        aria-disabled=""false""
        aria-label=""Close""
        class=""pf-c-button pf-m-plain""
        type=""button""
      >
        <svg
          style=""vertical-align: -0.125em;""
          fill=""currentColor""
          height=""1em""
          width=""1em""
          viewBox=""{TimesIcon.IconDefinition.ViewBox}""
          aria-hidden=""true""
          role=""img""
        >
          <path d=""{TimesIcon.IconDefinition.SvgPath}""></path>
        </svg>
      </button>
      <header class=""pf-c-modal-box__header"">
        <h1 class=""pf-c-modal-box__title"" id=""labelId"">
            <span class=""pf-c-modal-box__title-text"">Test Modal Content title</span>
        </h1>
      </header>
      <div id=""descriptorId"" class=""pf-c-modal-box__body"">This is a ModalBox body</div>
      <footer class=""pf-c-modal-box__footer"">Testing</footer>
    </div>
  </div>
</div>
");
    }

    [Fact]
    public void WithCustomHeaderTest()
    {
        // Arrange
        using var ctx = new TestContext();

        // Setup Javascript interop
        ctx.AddServices();

        // Act
        var cut = ctx.RenderComponent<ModalContent>(parameters => parameters
            .Add(p => p.Title, "test-custom-header-modal")
            .Add(p => p.IsOpen, true)
            .Add(p => p.Header, "<span id=\"test-custom-header\">TEST</span>")
            .Add(p => p.Actions, "Testing footer")
            .Add(p => p.BoxId, "boxId")
            .Add(p => p.LabelId, "labelId")
            .Add(p => p.DescriptorId, "descriptorId")
            .AddChildContent("This is a ModalBox body")
        );

        // Assert
        cut.MarkupMatches(
$@"
<div class=""pf-c-backdrop"">
  <div class=""pf-l-bullseye"">
    <div
      id=""boxId""
      role=""dialog""
      aria-describedby=""descriptorId""
      aria-modal=""true""
      class=""pf-c-modal-box""
    >
      <button
        aria-disabled=""false""
        aria-label=""Close""
        class=""pf-c-button pf-m-plain""
        type=""button""
      >
        <svg
          style=""vertical-align: -0.125em;""
          fill=""currentColor""
          height=""1em""
          width=""1em""
          viewBox=""{TimesIcon.IconDefinition.ViewBox}""
          aria-hidden=""true""
          role=""img""
        >
          <path
            d=""{TimesIcon.IconDefinition.SvgPath}"">
          </path>
        </svg>
      </button>
      <header class=""pf-c-modal-box__header"">
        <span id=""test-custom-header"">TEST</span>
      </header>
      <div id=""descriptorId"" class=""pf-c-modal-box__body"">This is a ModalBox body</div>
      <footer class=""pf-c-modal-box__footer"">Testing footer</footer>
    </div>
  </div>
</div>
");
    }

    [Fact]
    public void WithCustomFooterTest()
    {
        // Arrange
        using var ctx = new TestContext();

        // Setup Javascript interop
        ctx.AddServices();

        // Act
        var cut = ctx.RenderComponent<ModalContent>(parameters => parameters
            .Add(p => p.Title, "Test Modal Custom Footer")
            .Add(p => p.IsOpen, true)
            .Add(p => p.Footer, "<span id=\"test-custom-footer\">TEST</span>")
            .Add(p => p.BoxId, "boxId")
            .Add(p => p.LabelId, "labelId")
            .Add(p => p.DescriptorId, "descriptorId")
            .AddChildContent("This is a ModalBox body")
        );

        // Assert
        cut.MarkupMatches(
$@"
<div class=""pf-c-backdrop"">
  <div class=""pf-l-bullseye"">
    <div
      id=""boxId""
      role=""dialog""
      aria-describedby=""descriptorId""
      aria-modal=""true""
      class=""pf-c-modal-box""
    >
      <button
        aria-disabled=""false""
        aria-label=""Close""
        class=""pf-c-button pf-m-plain""
        type=""button""
      >
        <svg
          style=""vertical-align: -0.125em;""
          fill=""currentColor""
          height=""1em""
          width=""1em""
          viewBox=""{TimesIcon.IconDefinition.ViewBox}""
          aria-hidden=""true""
          role=""img""
        >
          <path d=""{TimesIcon.IconDefinition.SvgPath}"">
          </path>
        </svg>
      </button>
      <header class=""pf-c-modal-box__header"">
        <h1 class=""pf-c-modal-box__title"" id=""labelId"">
          <span class=""pf-c-modal-box__title-text"">Test Modal Custom Footer</span>
        </h1>
      </header>
      <div id=""descriptorId"" class=""pf-c-modal-box__body"">This is a ModalBox body</div>
      <footer class=""pf-c-modal-box__footer""><span id=""test-custom-footer"">TEST</span></footer>
    </div>
  </div>
</div>
");
    }
}
