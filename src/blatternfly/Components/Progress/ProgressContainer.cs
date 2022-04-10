using System.Threading.Tasks;
using Blatternfly.Interop;
using Blatternfly.Utilities;

namespace Blatternfly.Components;

public class ProgressContainer : BaseComponent
{
    /// Properties needed for aria support.
    [Parameter] public ProgressAriaProps AriaProps { get; set; }

    /// Progress component DOM ID.
    [Parameter] public string ParentId { get; set; }

    /// Progress title.
    [Parameter] public string Title { get; set; }

    /// Label to indicate what progress is showing.
    [Parameter] public RenderFragment Label { get; set; }

    /// Type of progress status.
    [Parameter] public ProgressVariant? Variant { get; set; }

    /// Location of progress value.
    [Parameter] public ProgressMeasureLocation MeasureLocation { get; set; } = ProgressMeasureLocation.Top;

    /// Actual progress value.
    [Parameter] public decimal Value { get; set; }

    /// Indicate whether to truncate the title.
    [Parameter] public bool IsTitleTruncated { get; set; }

    /// Position of the tooltip which is displayed if text is truncated.
    [Parameter] public TooltipPosition TooltipPosition { get; set; } = TooltipPosition.Top;

    [Inject] private IDomUtils DomUtils { get; set; }

    private string CssClass => new CssBuilder("pf-c-progress__description")
        .AddClass("pf-m-truncate", IsTitleTruncated)
        .Build();

    private ElementReference TitleRef { get; set; }

    private bool ShouldRenderTooltip { get; set; }

    protected override void BuildRenderTree(RenderTreeBuilder builder)
    {
        if (ShouldRenderTooltip)
        {
            builder.OpenComponent<Tooltip>(0);
            builder.AddAttribute(1, "id", $"{ParentId}-description-tooltip");
            builder.AddAttribute(2, "Reference", $"{ParentId}-description");
            builder.AddAttribute(3, "Position", TooltipPosition);
            builder.AddAttribute(4, "Content", (RenderFragment)delegate(RenderTreeBuilder innerBuilder)
            {
                innerBuilder.AddContent(5, Title);
            });
            builder.AddAttribute(6, "ChildContent", (RenderFragment)delegate(RenderTreeBuilder innerBuilder)
            {
                innerBuilder.OpenElement(7, "div");
                innerBuilder.AddAttribute(8, "class", CssClass);
                innerBuilder.AddAttribute(9, "id", $"{ParentId}-description");
                innerBuilder.AddAttribute(10, "aria-hidden", "true");
                innerBuilder.AddElementReferenceCapture(11, __reference => TitleRef = __reference);
                innerBuilder.AddContent(12, Title);
                innerBuilder.CloseElement();
            });

            builder.CloseComponent();
        }
        else
        {
            builder.OpenElement(13, "div");
            builder.AddAttribute(14, "class", CssClass);
            builder.AddAttribute(15, "id", $"{ParentId}-description");
            builder.AddAttribute(16, "aria-hidden", "true");
            builder.AddElementReferenceCapture(17, __reference => TitleRef = __reference);
            builder.AddContent(18, Title);
            builder.CloseElement();
        }

        builder.OpenElement(19, "div");
        builder.AddAttribute(20, "class", "pf-c-progress__status");
        builder.AddAttribute(21, "aria-hidden", "true");
        if (MeasureLocation is ProgressMeasureLocation.Top or ProgressMeasureLocation.Outside)
        {
            builder.OpenElement(22, "span");
            builder.AddAttribute(23, "class", "pf-c-progress__measure");
            if (Label is not null)
            {
                builder.AddContent(24, Label);
            }
            else
            {
                builder.AddContent(25, $"{Value:N0}%");
            }
            builder.CloseElement();
        }
        if (Variant.HasValue)
        {
            var iconType = Variant switch
            {
                ProgressVariant.Danger  => typeof(TimesCircleIcon),
                ProgressVariant.Success => typeof(CheckCircleIcon),
                ProgressVariant.Warning => typeof(ExclamationTriangleIcon),
                _                       => null
            };

            builder.OpenElement(26, "span");
            builder.AddAttribute(27, "class", "pf-c-progress__status-icon");
            builder.OpenComponent(28, iconType);
            builder.CloseComponent();
            builder.CloseElement();
        }
        builder.CloseElement();

        builder.OpenComponent<ProgressBar>(29);
        builder.AddAttribute(30, "role", "progressbar");
        builder.AddAttribute(31, "AriaProps", AriaProps);
        builder.AddAttribute(32, "Value", Value);
        builder.AddAttribute(33, "MeasureLocation", MeasureLocation);
        builder.CloseComponent();
    }

    protected override async Task OnAfterRenderAsync(bool firstRender)
    {
        await base.OnAfterRenderAsync(firstRender);

        if (firstRender)
        {
            ShouldRenderTooltip = await DomUtils.HasTruncatedWidth(TitleRef);
            if (ShouldRenderTooltip)
            {
                StateHasChanged();
            }
        }
    }
}
