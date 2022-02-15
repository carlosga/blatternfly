using System.Threading.Tasks;
using Blatternfly.Interop;
using Blatternfly.Utilities;

namespace Blatternfly.Components;

public class Chip : BaseComponent
{
    public ElementReference Element { get; protected set; }

    /// Aria Label for close button.
    [Parameter] public string CloseBtnAriaLabel { get; set; } = "close";

    /// Flag indicating if the chip is an overflow chip.
    [Parameter] public bool IsOverflowChip { get; set; }

    /// Flag indicating if chip is read only.
    [Parameter] public bool IsReadOnly { get; set; }

    /// Function that is called when clicking on the chip close button.
    [Parameter] public EventCallback<MouseEventArgs> OnClick { get; set; }

    /// Component that will be used for chip. It is recommended that <button /> or <li />  are used when the chip is an overflow chip.
    [Parameter] public string Component { get; set; } = "div";

    /// Position of the tooltip which is displayed if text is truncated.
    [Parameter] public TooltipPosition TooltipPosition { get; set; } = TooltipPosition.Top;

    [Inject] private ISequentialIdGenerator SequentialIdGenerator { get; set; }
    [Inject] private IDomUtils DomUtils { get; set; }

    private string CssClass => new CssBuilder("pf-c-chip")
        .AddClass("pf-m-overflow", IsOverflowChip)
        .AddClassFromAttributes(AdditionalAttributes)
        .Build();

    private string _id;
    private bool ShouldRenderTooltip { get; set; }
    private bool IsTooltipVisible { get; set; }

    protected override void OnInitialized()
    {
        base.OnInitialized();

        _id = SequentialIdGenerator.GenerateId("pf-random-id-");
    }

    protected override void BuildRenderTree(RenderTreeBuilder builder)
    {
        if (IsOverflowChip)
        {
            RenderOverflowChip(builder);
        }
        else
        {
            RenderChip(builder);
        }
    }

    private void RenderOverflowChip(RenderTreeBuilder builder)
    {
        var index = 0;

        builder.OpenElement(index++, Component);
        builder.AddAttribute(index++, "class", CssClass);
        builder.AddAttribute(index++, "onclick", EventCallback.Factory.Create(this, OnClick));

        if (Component == "button")
        {
            builder.AddAttribute(index++, "type", "button");
        }

        builder.OpenElement(index++, "span");
        builder.AddAttribute(index++, "class", "pf-c-chip__text");
        builder.AddContent(index++, ChildContent);
        builder.CloseElement();

        builder.CloseElement();
    }

    private void RenderChip(RenderTreeBuilder builder)
    {
        var index = 0;

        if (ShouldRenderTooltip)
        {
            builder.OpenComponent<Tooltip>(index++);
            builder.AddAttribute(index++, "id", $"{_id}-tooltip");
            builder.AddAttribute(index++, "Reference", _id);
            builder.AddAttribute(index++, "Position", TooltipPosition);
            builder.AddAttribute(index++, "IsVisible", IsTooltipVisible);
            builder.AddAttribute(index++, "Content", ChildContent);
            builder.AddAttribute(index++, "ChildContent", (RenderFragment)delegate(RenderTreeBuilder rfbuilder)
            {
                RenderInnerChip(rfbuilder, index);
            });

            builder.CloseComponent();
        }
        else
        {
            RenderInnerChip(builder, index);
        }
    }

    private void RenderInnerChip(RenderTreeBuilder builder, int index)
    {
        var id = !string.IsNullOrEmpty(InternalId) ? InternalId : _id;

        builder.OpenElement(index++, Component);
        builder.AddAttribute(index++, "class", CssClass);

        if (Component == "button")
        {
            builder.AddAttribute(index++, "type", "button");
        }

        builder.OpenElement(index++, "span");
        builder.AddAttribute(index++, "class", "pf-c-chip__text");
        builder.AddAttribute(index++, "id", id);
        builder.AddAttribute(index++, "onmouseover", HandleMouseOver);
        builder.AddAttribute(index++, "onmouseout", HandleMouseOut);
        builder.AddContent(index++, ChildContent);
        builder.AddElementReferenceCapture(index++, __inputReference => Element = __inputReference);
        builder.CloseElement();

        if (!IsReadOnly)
        {
            builder.OpenComponent<Button>(index++);
            builder.AddAttribute(index++, "OnClick", EventCallback.Factory.Create(this, OnClick));
            builder.AddAttribute(index++, "Variant", ButtonVariant.Plain);
            builder.AddAttribute(index++, "AriaLabel", CloseBtnAriaLabel);
            builder.AddAttribute(index++, "id", $"remove_{id}");
            builder.AddAttribute(index++, "aria-labelledby", $"remove_{id} {id}");
            builder.AddAttribute(index++, "ChildContent", (RenderFragment)delegate(RenderTreeBuilder rfbuilder)
            {
                rfbuilder.OpenComponent<TimesIcon>(index++);
                rfbuilder.AddAttribute(index++, "aria-hidden", "true");
                rfbuilder.CloseComponent();
            });
            builder.CloseComponent();
        }

        builder.CloseElement();
    }

    protected override async Task OnAfterRenderAsync(bool firstRender)
    {
        await base.OnAfterRenderAsync(firstRender);

        if (firstRender)
        {
            var offsetSize = await DomUtils.GetOffsetSizeAsync(Element);
            var scrollSize = await DomUtils.GetScrollSizeAsync(Element);

            ShouldRenderTooltip = offsetSize.Width < scrollSize.Width;

            StateHasChanged();
        }
    }

    private void HandleMouseOver(MouseEventArgs _)
    {
        IsTooltipVisible = true;
    }

    private void HandleMouseOut(MouseEventArgs _)
    {
        IsTooltipVisible = false;
    }
}
