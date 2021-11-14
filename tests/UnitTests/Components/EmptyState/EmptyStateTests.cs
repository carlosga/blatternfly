namespace Blatternfly.UnitTests.Components;

public class EmptyStateTests
{
    [Fact]
    public void DefaultTest()
    {
        // Arrange
        using var ctx = new TestContext();

        // Act
        var cut = ctx.RenderComponent<EmptyState>(parameters => parameters
            .Add<Title>(p => p.ChildContent, titleparams => titleparams
                .Add(p => p.HeadingLevel, HeadingLevel.h5)
                .Add(p => p.Size, TitleSizes.Large)
                .AddChildContent("HTTP Proxies")
            )
            .Add<EmptyStateBody>(p => p.ChildContent, bodyparams => bodyparams
                .AddChildContent("Defining HTTP Proxies that exist on your network allows you to perform various actions through those proxies.")
            )
            .Add<Button>(p => p.ChildContent, buttonparams => buttonparams
                .Add(p => p.Variant, ButtonVariant.Primary)
                .AddChildContent("New HTTP Proxy")
            )
            .Add<EmptyStateSecondaryActions>(p => p.ChildContent, actionsparams => actionsparams
                .Add<Button>(p => p.ChildContent, actionparams => actionparams
                    .Add(p => p.Variant, ButtonVariant.Link)
                    .Add(p => p.AriaLabel, "learn more action")
                    .AddChildContent("Learn more about this in the documentation.")
                )
            )
        );

        // Assert
        cut.MarkupMatches(
@"
<div
  class=""pf-c-empty-state""
>
  <div
    class=""pf-c-empty-state__content""
  >
    <h5
      class=""pf-c-title pf-m-lg""
    >
      HTTP Proxies
    </h5>
    <div
      class=""pf-c-empty-state__body""
    >
      Defining HTTP Proxies that exist on your network allows you to perform various actions through those proxies.
    </div>
    <button
      aria-disabled=""false""
      class=""pf-c-button pf-m-primary""
      type=""button""
    >
      New HTTP Proxy
    </button>
    <div 
      class=""pf-c-empty-state__secondary""
    >
      <button 
        aria-disabled=""false"" 
        aria-label=""learn more action""
        class=""pf-c-button pf-m-link"" 
        type=""button"" 
      >
        Learn more about this in the documentation.
      </button>
    </div>
  </div>
</div>
");
    }
    
    [Theory]
    [InlineData(EmptyStateVariant.ExtraSmall)]
    [InlineData(EmptyStateVariant.Small)]
    [InlineData(EmptyStateVariant.Large)]
    [InlineData(EmptyStateVariant.ExtraLarge)]
    [InlineData(EmptyStateVariant.Full)]
    public void WithVariantTest(EmptyStateVariant variant)
    {
        // Arrange
        using var ctx = new TestContext();
        var variantCssClass = variant switch
        {
            EmptyStateVariant.ExtraSmall => "pf-m-xs",
            EmptyStateVariant.Small      => "pf-m-sm",
            EmptyStateVariant.Large      => "pf-m-lg",
            EmptyStateVariant.ExtraLarge => "pf-m-xl",
            _                            => ""
        };

        // Act
        var cut = ctx.RenderComponent<EmptyState>(parameters => parameters
            .Add(p => p.Variant, variant)
            .Add<Title>(p => p.ChildContent, titleparams => titleparams
                .Add(p => p.HeadingLevel, HeadingLevel.h5)
                .Add(p => p.Size, TitleSizes.Large)
                .AddChildContent("HTTP Proxies")
            )
        );

        // Assert
        cut.MarkupMatches(
$@"
<div
  class=""pf-c-empty-state {variantCssClass}""
>
  <div
    class=""pf-c-empty-state__content""
  >
    <h5
      class=""pf-c-title pf-m-lg""
    >
      HTTP Proxies
    </h5>
  </div>
</div>
");
    }

    [Fact]
    public void IsFullHeightTest()
    {
        // Arrange
        using var ctx = new TestContext();
        // Act
        var cut = ctx.RenderComponent<EmptyState>(parameters => parameters
            .Add(p => p.IsFullHeight, true)
            .Add(p => p.Variant, EmptyStateVariant.Large)
            .Add<Title>(p => p.ChildContent, titleparams => titleparams
                .Add(p => p.HeadingLevel, HeadingLevel.h3)
                .Add(p => p.Size, TitleSizes.Medium)
                .AddChildContent("EmptyState large")
            )
        );

        // Assert
        cut.MarkupMatches(
@"
<div
  class=""pf-c-empty-state pf-m-lg pf-m-full-height""
>
  <div
    class=""pf-c-empty-state__content""
  >
    <h3
      class=""pf-c-title pf-m-md""
    >
      EmptyState large
    </h3>
  </div>
</div>
");
    }
}
