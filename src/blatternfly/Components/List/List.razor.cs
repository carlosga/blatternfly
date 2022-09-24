namespace Blatternfly.Components;

public partial class List : ComponentBase
{
    /// Additional attributes that will be applied to the component.
    [Parameter(CaptureUnmatchedValues = true)] public IReadOnlyDictionary<string, object> AdditionalAttributes { get; set; }

    /// Content rendered inside the component.
    [Parameter] public RenderFragment ChildContent { get; set; }

    /// Adds list variant styles.
    [Parameter] public ListVariant Variant { get; set; } = ListVariant.None;

    /// Modifies the list to add borders between items.
    [Parameter] public bool IsBordered { get; set; }

    /// Modifies the list to include plain styling.
    [Parameter] public bool IsPlain { get; set; }

    /// Modifies the size of the icons in the list.
    [Parameter] public ListIconSize IconSize { get; set; } = ListIconSize.Default;

    /// Sets the way items are numbered if variant is set to ordered.
    [Parameter] public OrderType Type { get; set; } = OrderType.Number;

    [Parameter] public ListComponent Component { get; set; } = ListComponent.ul;

    private string CssClass => new CssBuilder("pf-c-list")
        .AddClass("pf-m-inline"   , Variant is ListVariant.Inline)
        .AddClass("pf-m-bordered" , IsBordered)
        .AddClass("pf-m-plain"    , IsPlain)
        .AddClass("pf-m-icon-lg"  , IconSize is ListIconSize.Large)
        .AddClassFromAttributes(AdditionalAttributes)
        .Build();

    private string ListOrderType
    {
        get => Type switch
        {
            OrderType.Number               => "1",
            OrderType.LowercaseLetter      => "a",
            OrderType.UppercaseLetter      => "A",
            OrderType.LowercaseRomanNumber => "i",
            OrderType.UppercaseRomanNumber => "I",
            _                              => null
        };
    }
}
