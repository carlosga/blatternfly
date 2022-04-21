namespace Blatternfly.Components;

public class ProgressStep : ComponentBase
{
    /// Additional attributes that will be applied to the component.
    [Parameter(CaptureUnmatchedValues = true)] public IReadOnlyDictionary<string, object> AdditionalAttributes { get; set; }

    /// Content rendered inside the component.
    [Parameter] public RenderFragment ChildContent { get; set; }

    /// Variant of the progress step. Each variant has a default icon.
    [Parameter] public ProgressStepVariant Variant { get; set; } = ProgressStepVariant.Default;

    /// Flag indicating the progress step is the current step.
    [Parameter] public bool IsCurrent { get; set; }

    /// Custom icon of a progress step. Will override default icons provided by the variant.
    [Parameter] public RenderFragment Icon { get; set; }

    /// Description text of a progress step.
    [Parameter] public string Description { get; set; }

    /// ID of the title of the progress step.
    [Parameter] public string TitleId { get; set; }

    /// Popover for a progress step.
    [Parameter] public RenderFragment PopoverRender { get; set; }

    /// @hide Forwarded reference to title container
    [Parameter] public ElementReference InnerRef { get; set; }

    /// Accessible label for the progress step. Should communicate all information being communicated by the progress
    /// step's icon, including the variant and the completed status. */
    [Parameter] public string AriaLabel { get; set; }

    private string CssClass => new CssBuilder("pf-c-progress-stepper__step")
        .AddClass("pf-m-success", Variant is ProgressStepVariant.Success)
        .AddClass("pf-m-info"   , Variant is ProgressStepVariant.Info)
        .AddClass("pf-m-pending", Variant is ProgressStepVariant.Pending)
        .AddClass("pf-m-warning", Variant is ProgressStepVariant.Warning)
        .AddClass("pf-m-danger" , Variant is ProgressStepVariant.Danger)
        .AddClass("pf-m-current", IsCurrent)
        .AddClassFromAttributes(AdditionalAttributes)
        .Build();

    private string TitleCssClass => new CssBuilder("pf-c-progress-stepper__step-title")
        .AddClass("pf-m-help-text", PopoverRender is not null)
        .Build();

    private string InternalId    { get => AdditionalAttributes.GetPropertyValue(HtmlAttributes.Id); }
    private string TitleTabIndex { get => PopoverRender is not null ? "0" : null; }
    private string TitleRole     { get => PopoverRender is not null ? "button" : null; }
    private string TitleType     { get => PopoverRender is not null ? "button" : null; }
    private string TitleAriaLabelledBy
    {
        get => !string.IsNullOrEmpty(InternalId) && !string.IsNullOrEmpty(TitleId) ? $"{InternalId} {TitleId}" : null;
    }

    protected override void OnParametersSet()
    {
        base.OnParametersSet();

        if (string.IsNullOrEmpty(InternalId) || string.IsNullOrEmpty(TitleId))
        {
            throw new InvalidCastException(
                "ProgressStep: The titleId and id properties are required to make this component accessible, and one or both of these properties are missing.");
        }
    }

    protected override void BuildRenderTree(RenderTreeBuilder builder)
    {
        builder.OpenElement(0, "li");
        builder.AddMultipleAttributes(1, AdditionalAttributes);
        builder.AddAttribute(2, "class", CssClass);
        builder.AddAttribute(3, "aria-current", IsCurrent ? "step" : null);

        builder.OpenElement(4, "div");
        builder.AddAttribute(5, "class", "pf-c-progress-stepper__step-connector");

        builder.OpenElement(6, "span");
        builder.AddAttribute(7, "class", "pf-c-progress-stepper__step-icon");

        if (Icon is not null)
        {
            builder.AddContent(8, Icon);
        }
        else if (Variant is ProgressStepVariant.Success)
        {
            builder.OpenComponent<CheckCircleIcon>(9);
            builder.CloseComponent();
        }
        else if (Variant is ProgressStepVariant.Info)
        {
            builder.OpenComponent<ResourcesFullIcon>(10);
            builder.CloseComponent();
        }
        else if (Variant is ProgressStepVariant.Warning)
        {
            builder.OpenComponent<ExclamationTriangleIcon>(11);
            builder.CloseComponent();
        }
        else if (Variant is ProgressStepVariant.Danger)
        {
            builder.OpenComponent<ExclamationCircleIcon>(12);
            builder.CloseComponent();
        }

        builder.CloseElement();

        builder.CloseElement();

        builder.OpenElement(13, "div");
        builder.AddAttribute(14, "class", "pf-c-progress-stepper__step-main");

        builder.OpenElement(15, PopoverRender is not null ? "span" : "div");
        builder.AddAttribute(16, "class", TitleCssClass);
        builder.AddAttribute(17, "id", TitleId);
        builder.AddAttribute(18, "tabindex", TitleTabIndex);
        builder.AddAttribute(19, "role", TitleRole);
        builder.AddAttribute(20, "type", TitleType);
        builder.AddAttribute(21, "aria-labelledby", @TitleAriaLabelledBy);
        builder.AddElementReferenceCapture(22, __inputReference => InnerRef = __inputReference);

        builder.AddContent(23, ChildContent);
        builder.AddContent(24, PopoverRender);

        builder.CloseElement();

        if (!string.IsNullOrEmpty(Description))
        {
            builder.OpenElement(25, "div");
            builder.AddAttribute(26, "class", "pf-c-progress-stepper__step-description");
            builder.AddContent(27, Description);
            builder.CloseElement();
        }

        builder.CloseElement();

        builder.CloseElement();
    }
}
