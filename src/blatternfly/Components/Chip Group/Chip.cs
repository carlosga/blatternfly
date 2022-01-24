namespace Blatternfly.Components;

public class Chip : BaseComponent
{
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

    private string CssClass => new CssBuilder("pf-c-chip")
        .AddClass("pf-m-overflow", IsOverflowChip)
        .AddClassFromAttributes(AdditionalAttributes)
        .Build();

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
        var id    = !string.IsNullOrEmpty(InternalId) ? InternalId : Utils.GetUniqueId("pf-random-id-");

        builder.OpenElement(index++, Component);
        builder.AddAttribute(index++, "class", CssClass);

        if (Component == "button")
        {
            builder.AddAttribute(index++, "type", "button");
        }

        builder.OpenElement(index++, "span");
        builder.AddAttribute(index++, "class", "pf-c-chip__text");
        builder.AddAttribute(index++, "id", id);
        builder.AddContent(index++, ChildContent);
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
}
