using System;

namespace Blatternfly.Components;

public class Card : BaseComponent
{
    /// Sets the base component to render. defaults to article.
    [Parameter] public string Component { get; set; } = "article";

    /// Modifies the card to include compact styling.
    [Parameter] public bool IsCompact { get; set; }

    /// Modifies the card to include selectable styling.
    [Parameter] public bool IsSelectable { get; set; }

    /// Specifies the card is selectable, and applies the new raised styling on hover and select.
    [Parameter] public bool IsSelectableRaised { get; set; }

    /// Modifies the card to include selected styling.
    [Parameter] public bool IsSelected { get; set; }

    /// Modifies a raised selectable card to have disabled styling.
    [Parameter] public bool IsDisabledRaised { get; set; }

    /// Modifies the card to include flat styling.
    [Parameter] public bool IsFlat { get; set; }

    /// Modifies the card to include rounded styling.
    [Parameter] public bool IsRounded { get; set; }

    /// Modifies the card to be large. Should not be used with isCompact.
    [Parameter] public bool IsLarge { get; set; }

    /// Cause component to consume the available height of its container.
    [Parameter] public bool IsFullHeight { get; set; }

    /// Modifies the card to include plain styling; this removes border and background.
    [Parameter] public bool IsPlain { get; set; }

    /// Flag indicating if a card is expanded. Modifies the card to be expandable.
    [Parameter] public bool IsExpanded { get; set; }

    private string CssClass => new CssBuilder("pf-c-card")
        .AddClass("pf-m-compact"              , IsCompact)
        .AddClass("pf-m-expanded"             , IsExpanded)
        .AddClass("pf-m-flat"                 , IsFlat)
        .AddClass("pf-m-rounded"              , IsRounded)
        .AddClass("pf-m-display-lg"           , IsLarge)
        .AddClass("pf-m-full-height"          , IsFullHeight)
        .AddClass("pf-m-plain"                , IsPlain)
        .AddClass("pf-m-non-selectable-raised", IsDisabledRaised)
        .AddClass("pf-m-selectable-raised"    , IsSelectableRaised)
        .AddClass("pf-m-selected-raised"      , IsSelectableRaised && IsSelected)
        .AddClass("pf-m-selectable"           , IsSelectable)
        .AddClass("pf-m-selected"             , IsSelectable && IsSelected)
        .AddClassFromAttributes(AdditionalAttributes)
        .Build();

    protected override void OnParametersSet()
    {
        base.OnParametersSet();

        if (IsLarge && IsCompact)
        {
            Console.WriteLine("Card: Cannot use isCompact with isLarge.");
            IsLarge = false;
        }
    }

    protected override void BuildRenderTree(RenderTreeBuilder builder)
    {
        builder.OpenElement(0, Component);
        builder.AddMultipleAttributes(1, AdditionalAttributes);
        builder.AddAttribute(2, "class", CssClass);
        builder.AddAttribute(3, "tabindex", IsSelectableRaised || IsSelectable ? "0" : null);
        builder.OpenComponent<CascadingValue<Card>>(4);
        builder.AddAttribute(5, "Value", this);
        builder.AddAttribute(6, "ChildContent", (RenderFragment)delegate(RenderTreeBuilder innerBuilder)
        {
            innerBuilder.AddContent(7, ChildContent);
        });
        builder.CloseElement();
        builder.CloseElement();
    }
}
