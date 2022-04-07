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

    [Inject] private ISequentialIdGenerator SequentialIdGenerator { get; set; }
    [Inject] private IDomUtils DomUtils { get; set; }

    private string CssClass => new CssBuilder("pf-c-progress__description")
        .AddClass("pf-m-truncate", IsTitleTruncated)
        .Build();

    private ElementReference TitleRef { get; set; }

    private bool ShouldRenderTooltip { get; set; }

    protected override void BuildRenderTree(RenderTreeBuilder builder)
    {
        var index = 0;

        if (ShouldRenderTooltip)
        {
            builder.OpenComponent<Tooltip>(index++);
            builder.AddAttribute(index++, "id", $"{ParentId}-description-tooltip");
            builder.AddAttribute(index++, "Reference", $"{ParentId}-description");
            builder.AddAttribute(index++, "Position", TooltipPosition);
            builder.AddAttribute(index++, "Content", (RenderFragment)delegate(RenderTreeBuilder rfbuilder)
            {
                rfbuilder.AddContent(index++, Title);
            });
            builder.AddAttribute(index++, "ChildContent", (RenderFragment)delegate(RenderTreeBuilder rfbuilder)
            {
                index = RenderTitle(rfbuilder, index);
            });

            builder.CloseComponent();
        }
        else
        {
            index = RenderTitle(builder, index);
        }

        builder.OpenElement(index++, "div");
        builder.AddAttribute(index++, "class", "pf-c-progress__status");
        builder.AddAttribute(index++, "aria-hidden", "true");
        if (MeasureLocation is ProgressMeasureLocation.Top or ProgressMeasureLocation.Outside)
        {
            builder.OpenElement(index++, "span");
            builder.AddAttribute(index++, "class", "pf-c-progress__measure");
            if (Label is not null)
            {
                builder.AddContent(index++, Label);
            }
            else
            {
                builder.AddContent(index++, $"{Value:N0}%");
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

            builder.OpenElement(index++, "span");
            builder.AddAttribute(index++, "class", "pf-c-progress__status-icon");
            builder.OpenComponent(index++, iconType);
            builder.CloseComponent();
            builder.CloseElement();
        }
        builder.CloseElement();

        builder.OpenComponent<ProgressBar>(index++);
        builder.AddAttribute(index++, "role", "progressbar");
        builder.AddAttribute(index++, "AriaProps", AriaProps);
        builder.AddAttribute(index++, "Value", Value);
        builder.AddAttribute(index++, "MeasureLocation", MeasureLocation);
        builder.CloseComponent();
    }

    private int RenderTitle(RenderTreeBuilder builder, int index)
    {
        builder.OpenElement(index++, "div");
        builder.AddAttribute(index++, "class", CssClass);
        builder.AddAttribute(index++, "id", $"{ParentId}-description");
        builder.AddAttribute(index++, "aria-hidden", "true");
        builder.AddElementReferenceCapture(index++, __reference => TitleRef = __reference);
        builder.AddContent(index++, Title);
        builder.CloseElement();

        return index;
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
