namespace Blatternfly.Components;

public class WizardBody : BaseComponent
{
    /// Set to true to remove the default body padding.
    [Parameter] public bool HasNoBodyPadding { get; set; }

    /// An aria-label to use for the main element.
    [Parameter] public string AriaLabel { get; set; }

    /// Sets the aria-labelledby attribute for the main element.
    [Parameter] public string AriaLabelledby { get; set; }

    /// Component used as the primary content container.
    [Parameter] public string MainComponent { get; set; } = "div";

    private string MainBodyCssClass => new CssBuilder("pf-c-wizard__main-body")
        .AddClass("pf-m-no-padding", HasNoBodyPadding)
        .Build();

    protected override void BuildRenderTree(RenderTreeBuilder builder)
    {
        builder.OpenElement(0, MainComponent);
        builder.AddAttribute(1, "class", "pf-c-wizard__main");
        builder.AddAttribute(2, "aria-label", AriaLabel);
        builder.AddAttribute(3, "aria-labelledby", AriaLabelledby);
        builder.AddMultipleAttributes(4, AdditionalAttributes);

        builder.OpenElement(5, "div");
        builder.AddAttribute(6, "class", MainBodyCssClass);
        builder.AddContent(7, ChildContent);
        builder.CloseElement();

        builder.CloseElement();
    }
}
