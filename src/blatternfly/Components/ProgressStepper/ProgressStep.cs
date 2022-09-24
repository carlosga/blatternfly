namespace Blatternfly.Components;

// TODO: Split
public partial class ProgressStep : ComponentBase
{
    /// <summary>Additional attributes that will be applied to the component.</summary>
    [Parameter(CaptureUnmatchedValues = true)] public IReadOnlyDictionary<string, object> AdditionalAttributes { get; set; }

    /// <summary>Content rendered inside the component.</summary>
    [Parameter] public RenderFragment ChildContent { get; set; }

    /// <summary>Variant of the progress step. Each variant has a default icon.</summary>
    [Parameter] public ProgressStepVariant Variant { get; set; } = ProgressStepVariant.Default;

    /// <summary>Flag indicating the progress step is the current step.</summary>
    [Parameter] public bool IsCurrent { get; set; }

    /// <summary>Custom icon of a progress step. Will override default icons provided by the variant.</summary>
    [Parameter] public RenderFragment Icon { get; set; }

    /// <summary>Description text of a progress step.</summary>
    [Parameter] public string Description { get; set; }

    /// <summary>ID of the title of the progress step.</summary>
    [Parameter] public string TitleId { get; set; }

    /// <summary>Popover for a progress step.</summary>
    [Parameter] public RenderFragment PopoverRender { get; set; }

    /// <summary>@hide Forwarded reference to title container</summary>
    [Parameter] public ElementReference InnerRef { get; set; }

    /// <summary>
    /// Accessible label for the progress step. Should communicate all information being communicated by the progress
    /// step's icon, including the variant and the completed status.
    /// </summary>
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

    private string InternalId    { get => AdditionalAttributes.GetPropertyValue(HtmlElement.Id); }
    private string TitleTabIndex { get => PopoverRender is not null ? "0" : null; }
    private string TitleRole     { get => PopoverRender is not null ? "button" : null; }
    private string TitleType     { get => PopoverRender is not null ? "button" : null; }
    private string TitleAriaLabelledBy
    {
        get => !string.IsNullOrEmpty(InternalId) && !string.IsNullOrEmpty(TitleId)
            ? $"{InternalId} {TitleId}"
                : null;
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

        builder.OpenElement(15, PopoverRender is not null ? "button" : "div");
        builder.AddAttribute(16, "class", TitleCssClass);
        builder.AddAttribute(17, "id", TitleId);
        builder.AddAttribute(18, "type", TitleType);
        builder.AddAttribute(19, "aria-labelledby", @TitleAriaLabelledBy);
        builder.AddElementReferenceCapture(20, __inputReference => InnerRef = __inputReference);

        builder.AddContent(21, ChildContent);
        builder.AddContent(22, PopoverRender);

        builder.CloseElement();

        if (!string.IsNullOrEmpty(Description))
        {
            builder.OpenElement(23, "div");
            builder.AddAttribute(24, "class", "pf-c-progress-stepper__step-description");
            builder.AddContent(25, Description);
            builder.CloseElement();
        }

        builder.CloseElement();

        builder.CloseElement();
    }
}
