namespace Blatternfly.Components;

public class WizardBody : ComponentBase
{
    /// Content rendered inside the component.
    [Parameter] public RenderFragment ChildContent { get; set; }

    /// Set to true to remove the default body padding.
    [Parameter] public bool HasNoBodyPadding { get; set; }

    /// An aria-label to use for the main element.
    [Parameter] public string AriaLabel { get; set; }

    /// Sets the aria-labelledby attribute for the main element.
    [Parameter] public string AriaLabelledby { get; set; }

    /// Component used as the primary content container.
    [Parameter] public string MainComponent { get; set; } = "div";

    /// The currently active WizardStep
    [Parameter] public WizardStep ActiveStep { get; set; }

    /// Flag indicating whether the wizard body has a drawer.
    [Parameter] public bool HasDrawer { get; set; }

    /// Flag indicating the wizard drawer is expanded.
    [Parameter] public bool IsDrawerExpanded { get; set; }

    private string MainBodyCssClass => new CssBuilder("pf-c-wizard__main-body")
        .AddClass("pf-m-no-padding", HasNoBodyPadding)
        .Build();

    private bool WrapperWithDrawer
    {
        get => HasDrawer && ActiveStep is not null && ActiveStep.DrawerPanelContent is not null;
    }

    protected override void BuildRenderTree(RenderTreeBuilder builder)
    {
        builder.OpenElement(0, MainComponent);
        builder.AddAttribute(1, "class", "pf-c-wizard__main");
        builder.AddAttribute(2, "aria-label", AriaLabel);
        builder.AddAttribute(3, "aria-labelledby", AriaLabelledby);

        builder.OpenComponent<WizardDrawerWrapper>(4);
        builder.AddAttribute(5, "HasDrawer", WrapperWithDrawer);
        builder.AddAttribute(6, "Wrapper", (RenderFragment)delegate(RenderTreeBuilder innerBuilder)
        {
            innerBuilder.OpenComponent<Drawer>(7);
            innerBuilder.AddAttribute(8, "IsInline", true);
            innerBuilder.AddAttribute(9, "IsExpanded", IsDrawerExpanded);

            innerBuilder.OpenComponent<DrawerContent>(10);

            innerBuilder.AddAttribute(11, "PanelContent", ActiveStep.DrawerPanelContent);
            innerBuilder.AddContent(12, ChildContent);

            innerBuilder.CloseComponent();

            innerBuilder.CloseComponent();
        });

        builder.OpenElement(13, "div");
        builder.AddAttribute(14, "class", MainBodyCssClass);
        builder.AddContent(15, ChildContent);
        builder.CloseElement();

        builder.CloseComponent();

        builder.CloseElement();
    }
}
