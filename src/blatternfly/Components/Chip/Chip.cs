using Blatternfly.Interop;
using Microsoft.AspNetCore.Components.CompilerServices;

namespace Blatternfly.Components;

public class Chip : ComponentBase
{
    /// Additional attributes that will be applied to the component.
    [Parameter(CaptureUnmatchedValues = true)] public IReadOnlyDictionary<string, object> AdditionalAttributes { get; set; }

    /// Content rendered inside the component.
    [Parameter] public RenderFragment ChildContent { get; set; }

    /// Html element reference.
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

    /// Css property expressed in percentage or any css unit that overrides the default value of the max-width of the chip's text.
    [Parameter] public string TextMaxWidth { get; set; }

    [Inject] private IComponentIdGenerator ComponentIdGenerator { get; set; }
    [Inject] private IDomUtils DomUtils { get; set; }

    private string CssClass => new CssBuilder("pf-c-chip")
        .AddClass("pf-m-overflow", IsOverflowChip)
        .AddClassFromAttributes(AdditionalAttributes)
        .Build();

    private string CssStyle => new StyleBuilder()
        .AddStyle("--pf-c-chip__text--MaxWidth", TextMaxWidth, !string.IsNullOrEmpty(TextMaxWidth))
        .AddStyleFromAttributes(AdditionalAttributes)
        .Build();

    private string InternalId       { get => AdditionalAttributes.GetPropertyValue(HtmlAttributes.Id); }
    private string Id               { get; set; }
    private bool   IsTooltipVisible { get; set; }
    private string TooltipId        { get; set; }

    protected override void OnInitialized()
    {
        base.OnInitialized();

        Id        = InternalId ?? ComponentIdGenerator.Generate("pf-c-chip");
        TooltipId = $"{Id}-tooltip";
    }

    protected override void BuildRenderTree(RenderTreeBuilder builder)
    {
        if (IsOverflowChip)
        {
            builder.OpenElement(0, Component);
            builder.AddAttribute(1, "style", CssStyle);
            builder.AddAttribute(2, "class", CssClass);
            builder.AddAttribute(3, "onclick", EventCallback.Factory.Create(this, OnClick));

            if (Component == "button")
            {
                builder.AddAttribute(4, "type", "button");
            }

            builder.OpenElement(5, "span");
            builder.AddAttribute(6, "class", "pf-c-chip__text");
            builder.AddContent(7, ChildContent);
            builder.CloseElement();

            builder.CloseElement();
        }
        else if (IsTooltipVisible)
        {
            builder.OpenComponent<Tooltip>(8);
            builder.AddAttribute(9, "id", TooltipId);
            builder.AddAttribute(10, "Reference", RuntimeHelpers.TypeCheck(Id));
            builder.AddAttribute(11, "Position", RuntimeHelpers.TypeCheck((TooltipPosition?)TooltipPosition));
            builder.AddAttribute(12, "Content", (RenderFragment)delegate(RenderTreeBuilder innerBuilder)
            {
                innerBuilder.AddContent(13, ChildContent);
            });
            builder.AddAttribute(14, "ChildContent", (RenderFragment)delegate(RenderTreeBuilder innerBuilder)
            {
                RenderInnerChip(innerBuilder, 15);
            });
            builder.CloseComponent();
        }
        else
        {
            RenderInnerChip(builder, 16);
        }
    }

    private void RenderInnerChip(RenderTreeBuilder builder, int index)
    {
        builder.OpenElement(index++, Component);
        builder.AddAttribute(index++, "style", CssStyle);
        builder.AddAttribute(index++, "class", CssClass);

        if (Component == "button")
        {
            builder.AddAttribute(index++, "type", "button");
        }

        builder.OpenElement(index++, "span");
        builder.AddAttribute(index++, "class", "pf-c-chip__text");
        builder.AddAttribute(index++, "id", Id);
        builder.AddElementReferenceCapture(index++, __reference => Element = __reference);
        builder.AddContent(index++, ChildContent);
        builder.CloseElement();

        if (!IsReadOnly)
        {
            builder.OpenComponent<Button>(index++);
            builder.AddAttribute(index++, "OnClick", EventCallback.Factory.Create(this, OnClick));
            builder.AddAttribute(index++, "Variant", ButtonVariant.Plain);
            builder.AddAttribute(index++, "AriaLabel", CloseBtnAriaLabel);
            builder.AddAttribute(index++, "id", $"remove_{Id}");
            builder.AddAttribute(index++, "aria-labelledby", $"remove_{Id} {Id}");
            builder.AddAttribute(index++, "ChildContent", (RenderFragment)delegate(RenderTreeBuilder innerBuilder)
            {
                innerBuilder.OpenComponent<TimesIcon>(index++);
                innerBuilder.AddAttribute(index++, "aria-hidden", "true");
                innerBuilder.CloseComponent();
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
            IsTooltipVisible = await DomUtils.HasTruncatedWidthAsync(Element);
            if (IsTooltipVisible)
            {
                StateHasChanged();
            }
        }
    }
}
