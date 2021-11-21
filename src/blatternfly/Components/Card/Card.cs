using System;

namespace Blatternfly.Components;

public class Card : BaseComponent
{
    /// Sets the base component to render. defaults to article.
    [Parameter] public string Component { get; set; } = "article";

    /// Modifies the card to include hover styles on :hover.
    [Parameter] public bool IsHoverable { get; set; }

    /// Modifies the card to include hoverable-raised styles on :hover,
    /// this styling is included by default with isSelectableRaised.
    [Parameter] public bool IsHoverableRaised { get; set; }

    /// Modifies the card to include compact styling.
    [Parameter] public bool IsCompact { get; set; }

    /// Modifies the card to include selectable styling.
    [Parameter] public bool IsSelectable { get; set; }

    // Modifies the card to include selected styling.
    [Parameter] public bool IsSelected { get; set; }

    /// Modifies the card to include selectable-raised styling and hoverable-raised styling.
    [Parameter] public bool IsSelectableRaised { get; set; }

    /// Modifies the card to include selected-raised styling.
    [Parameter] public bool IsSelectedRaised { get; set; }

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
        .AddClass("pf-m-hoverable"        , IsHoverable)
        .AddClass("pf-m-hoverable-raised" , IsHoverableRaised)
        .AddClass("pf-m-compact"          , IsCompact)
        .AddClass("pf-m-selectable"       , IsSelectable && !IsSelectableRaised)
        .AddClass("pf-m-selected"         , IsSelected && !IsSelectedRaised && IsSelectable)
        .AddClass("pf-m-selectable-raised", IsSelectableRaised)
        .AddClass("pf-m-selected-raised"  , IsSelectedRaised && IsSelectableRaised)
        .AddClass("pf-m-expanded"         , IsExpanded)
        .AddClass("pf-m-flat"             , IsFlat)
        .AddClass("pf-m-rounded"          , IsRounded)
        .AddClass("pf-m-display-lg"       , IsLarge)
        .AddClass("pf-m-full-height"      , IsFullHeight)
        .AddClass("pf-m-plain"            , IsPlain)
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
        builder.OpenElement(1, Component);
        builder.AddMultipleAttributes(2, AdditionalAttributes);
        builder.AddAttribute(3, "class", CssClass);
        builder.AddAttribute(4, "tabindex", IsSelectableRaised || IsSelectable ? "0" : null);
        builder.OpenComponent<CascadingValue<Card>>(5);
        builder.AddAttribute(6, "Value", this);
        builder.AddAttribute(7, "ChildContent", ChildContent);
        builder.CloseElement();
        builder.CloseElement();
    }
}
