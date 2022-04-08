using System.Collections.Generic;
using System.Threading.Tasks;
using Blatternfly;
using Blatternfly.Components;
using Blatternfly.Interop;
using Blatternfly.Utilities;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.CompilerServices;
using Microsoft.AspNetCore.Components.Rendering;
using Microsoft.AspNetCore.Components.Web;

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

    private string Id { get; set; }

    private bool IsTooltipVisible { get; set; }

    private string TooltipId { get; set; }

    private string CloseButtonId { get; set; }

    private string CloseButtonAriaLabelledBy { get; set; }

    protected override void OnInitialized()
    {
        base.OnInitialized();

        Id                        = base.InternalId ?? SequentialIdGenerator.GenerateId("pf-c-chip");
        TooltipId                 = Id + "-tooltip";
        CloseButtonId             = "remove_" + Id;
        CloseButtonAriaLabelledBy = "remove_" + Id + " " + Id;
    }

    protected override void BuildRenderTree(RenderTreeBuilder builder)
    {
        if (IsOverflowChip)
        {
            RenderOverflowChip(builder);
        }
        else if (IsTooltipVisible)
        {
            builder.OpenComponent<Tooltip>(0);
            builder.AddAttribute(1, "id", TooltipId);
            builder.AddAttribute(2, "Reference", RuntimeHelpers.TypeCheck(Id));
            builder.AddAttribute(3, "Position", RuntimeHelpers.TypeCheck((TooltipPosition?)TooltipPosition));
            builder.AddAttribute(4, "Content", (RenderFragment)delegate(RenderTreeBuilder innerBuilder)
            {
                innerBuilder.AddContent(5, ChildContent);
            });
            builder.AddAttribute(6, "ChildContent", (RenderFragment)delegate(RenderTreeBuilder innerBuilder)
            {
                RenderInnerChip(innerBuilder, 7);
            });
            builder.CloseComponent();
        }
        else
        {
            RenderInnerChip(builder, 0);
        }
    }

    private void RenderOverflowChip(RenderTreeBuilder builder)
    {
        builder.OpenElement(0, Component);
        builder.AddAttribute(1, "class", CssClass);
        builder.AddAttribute(2, "onclick", EventCallback.Factory.Create(this, OnClick));

        if (Component == "button")
        {
            builder.AddAttribute(3, "type", "button");
        }

        builder.OpenElement(4, "span");
        builder.AddAttribute(5, "class", "pf-c-chip__text");
        builder.AddContent(6, ChildContent);
        builder.CloseElement();

        builder.CloseElement();
    }

    private void RenderInnerChip(RenderTreeBuilder builder, int index)
    {
        builder.OpenElement(index++, Component);
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
            IsTooltipVisible = await DomUtils.HasTruncatedWidth(Element);
            if (IsTooltipVisible)
            {
                StateHasChanged();
            }
        }
    }
}
