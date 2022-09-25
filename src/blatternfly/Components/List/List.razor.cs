namespace Blatternfly.Components;

public partial class List : ComponentBase
{
    /// <summary>Additional attributes that will be applied to the component.</summary>
    [Parameter(CaptureUnmatchedValues = true)] public IReadOnlyDictionary<string, object> AdditionalAttributes { get; set; }

    /// <summary>Content rendered inside the component.</summary>
    [Parameter] public RenderFragment ChildContent { get; set; }

    /// <summary>Adds list variant styles.</summary>
    [Parameter] public ListVariant Variant { get; set; } = ListVariant.None;

    /// <summary>Modifies the list to add borders between items.</summary>
    [Parameter] public bool IsBordered { get; set; }

    /// <summary>Modifies the list to include plain styling.</summary>
    [Parameter] public bool IsPlain { get; set; }

    /// <summary>Modifies the size of the icons in the list.</summary>
    [Parameter] public ListIconSize IconSize { get; set; } = ListIconSize.Default;

    /// <summary>Sets the way items are numbered if variant is set to ordered.</summary>
    [Parameter] public OrderType Type { get; set; } = OrderType.Number;

    /// <summary>List component (ol/ul)</summary>
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
