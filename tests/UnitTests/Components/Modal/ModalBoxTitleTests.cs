namespace Blatternfly.UnitTests.Components;

public class ModalBoxTitleTests
{
    [Fact]
    public void WarningVariantTest()
    {
        // Arrange
        using var ctx = new TestContext();

        // Add service configuration
        ctx.AddServices();

        // Act
        var cut = ctx.RenderComponent<ModalBoxTitle>(parameters => parameters
            .AddUnmatched("id", "boxId")
            .Add(p => p.Title, "Test Modal Box warning")
            .Add(p => p.TitleIconVariant, ModalTitleVariant.Warning)
            .AddChildContent("content")
        );

        // Assert
        cut.MarkupMatches(
$@"
<h1
  class=""pf-c-modal-box__title pf-m-icon""
  id=""boxId""
>
  <span
    class=""pf-c-modal-box__title-icon""
  >
    <svg
      style=""vertical-align: -0.125em;""
      fill=""currentColor""
      height=""1em""
      width=""1em""
      viewBox=""{ExclamationTriangleIcon.IconDefinition.ViewBox}""
      aria-hidden=""true""
      role=""img""
    >
      <path d=""{ExclamationTriangleIcon.IconDefinition.SvgPath}""></path>
    </svg>
  </span>
  <span
    class=""pf-u-screen-reader""
  >
    Warning alert:
  </span>
  <span
    class=""pf-c-modal-box__title-text""
  >
    Test Modal Box warning
  </span>
</h1>
");
    }

    [Fact]
    public void InfoVariantTest()
    {
        // Arrange
        using var ctx = new TestContext();

        // Add service configuration
        ctx.AddServices();

        // Act
        var cut = ctx.RenderComponent<ModalBoxTitle>(parameters => parameters
            .AddUnmatched("id", "boxId")
            .Add(p => p.Title, "Test Modal Box info")
            .Add(p => p.TitleIconVariant, ModalTitleVariant.Info)
            .AddChildContent("content")
        );

        // Assert
        cut.MarkupMatches(
$@"
<h1
  class=""pf-c-modal-box__title pf-m-icon""
  id=""boxId""
>
  <span
    class=""pf-c-modal-box__title-icon""
  >
    <svg
      style=""vertical-align: -0.125em;""
      fill=""currentColor""
      height=""1em""
      width=""1em""
      viewBox=""{InfoCircleIcon.IconDefinition.ViewBox}""
      aria-hidden=""true""
      role=""img""
    >
      <path d=""{InfoCircleIcon.IconDefinition.SvgPath}""></path>
    </svg>
  </span>
  <span
    class=""pf-u-screen-reader""
  >
    Info alert:
  </span>
  <span
    class=""pf-c-modal-box__title-text""
  >
    Test Modal Box info
  </span>
</h1>
");
    }

    [Fact]
    public void DangerVariantTest()
    {
        // Arrange
        using var ctx = new TestContext();

        // Add service configuration
        ctx.AddServices();

        // Act
        var cut = ctx.RenderComponent<ModalBoxTitle>(parameters => parameters
            .AddUnmatched("id", "boxId")
            .Add(p => p.Title, "Test Modal Box danger")
            .Add(p => p.TitleIconVariant, ModalTitleVariant.Danger)
            .AddChildContent("content")
        );

        // Assert
        cut.MarkupMatches(
$@"
<h1
  class=""pf-c-modal-box__title pf-m-icon""
  id=""boxId""
>
  <span
    class=""pf-c-modal-box__title-icon""
  >
    <svg
      style=""vertical-align: -0.125em;""
      fill=""currentColor""
      height=""1em""
      width=""1em""
      viewBox=""{ExclamationCircleIcon.IconDefinition.ViewBox}""
      aria-hidden=""true""
      role=""img""
    >
      <path d=""{ExclamationCircleIcon.IconDefinition.SvgPath}""></path>
    </svg>
  </span>
  <span
    class=""pf-u-screen-reader""
  >
    Danger alert:
  </span>
  <span
    class=""pf-c-modal-box__title-text""
  >
    Test Modal Box danger
  </span>
</h1>
");
    }

    [Fact]
    public void DefaultVariantTest()
    {
        // Arrange
        using var ctx = new TestContext();

        // Add service configuration
        ctx.AddServices();

        // Act
        var cut = ctx.RenderComponent<ModalBoxTitle>(parameters => parameters
            .AddUnmatched("id", "boxId")
            .Add(p => p.Title, "Test Modal Box default")
            .Add(p => p.TitleIconVariant, ModalTitleVariant.Default)
            .AddChildContent("content")
        );

        // Assert
        cut.MarkupMatches(
$@"
<h1
  class=""pf-c-modal-box__title pf-m-icon""
  id=""boxId""
>
  <span
    class=""pf-c-modal-box__title-icon""
  >
    <svg
      style=""vertical-align: -0.125em;""
      fill=""currentColor""
      height=""1em""
      width=""1em""
      viewBox=""{BellIcon.IconDefinition.ViewBox}""
      aria-hidden=""true""
      role=""img""
    >
      <path d=""{BellIcon.IconDefinition.SvgPath}""></path>
    </svg>
  </span>
  <span
    class=""pf-u-screen-reader""
  >
    Default alert:
  </span>
  <span
    class=""pf-c-modal-box__title-text""
  >
    Test Modal Box default
  </span>
</h1>
");
    }

    [Fact]
    public void SuccessVariantTest()
    {
        // Arrange
        using var ctx = new TestContext();

        // Add service configuration
        ctx.AddServices();

        // Act
        var cut = ctx.RenderComponent<ModalBoxTitle>(parameters => parameters
            .AddUnmatched("id", "boxId")
            .Add(p => p.Title, "Test Modal Box success")
            .Add(p => p.TitleIconVariant, ModalTitleVariant.Success)
            .AddChildContent("content")
        );

        // Assert
        cut.MarkupMatches(
$@"
<h1
  class=""pf-c-modal-box__title pf-m-icon""
  id=""boxId""
>
  <span
    class=""pf-c-modal-box__title-icon""
  >
    <svg
      style=""vertical-align: -0.125em;""
      fill=""currentColor""
      height=""1em""
      width=""1em""
      viewBox=""{CheckCircleIcon.IconDefinition.ViewBox}""
      aria-hidden=""true""
      role=""img""
    >
      <path d=""{CheckCircleIcon.IconDefinition.SvgPath}""></path>
    </svg>
  </span>
  <span
    class=""pf-u-screen-reader""
  >
    Success alert:
  </span>
  <span
    class=""pf-c-modal-box__title-text""
  >
    Test Modal Box success
  </span>
</h1>
");
    }

    [Fact]
    public void CustomVariantTest()
    {
        // Arrange
        using var ctx = new TestContext();

        // Add service configuration
        ctx.AddServices();

        // Act
        var cut = ctx.RenderComponent<ModalBoxTitle>(parameters => parameters
            .AddUnmatched("id", "boxId")
            .Add(p => p.Title, "Test Modal Box custom")
            .Add(p => p.TitleIconVariant, ModalTitleVariant.Custom)
            .Add<BullhornIcon>(p => p.CustomTitleIcon)
            .AddChildContent("content")
        );

        // Assert
        cut.MarkupMatches(
$@"
<h1
  class=""pf-c-modal-box__title pf-m-icon""
  id=""boxId""
>
  <span
    class=""pf-c-modal-box__title-icon""
  >
    <svg
      style=""vertical-align: -0.125em;""
      fill=""currentColor""
      height=""1em""
      width=""1em""
      viewBox=""{BullhornIcon.IconDefinition.ViewBox}""
      aria-hidden=""true""
      role=""img""
    >
      <path d=""{BullhornIcon.IconDefinition.SvgPath}""></path>
    </svg>
  </span>
  <span
    class=""pf-c-modal-box__title-text""
  >
    Test Modal Box custom
  </span>
</h1>
");
    }
}
