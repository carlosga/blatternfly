namespace Blatternfly.Components;

public partial class SortColumn : ComponentBase
{
    /// <summary>Additional attributes that will be applied to the component.</summary>
    [Parameter(CaptureUnmatchedValues = true)] public IReadOnlyDictionary<string, object> AdditionalAttributes { get; set; }

    /// <summary>Content rendered inside the component.</summary>
    [Parameter] public RenderFragment ChildContent { get; set; }

    /// <summary>Is the currently active column.</summary>
    [Parameter] public bool IsSortedBy { get; set; }

    /// <summary>Callback called when sortable column is clicked.</summary>
    [Parameter] public EventCallback<MouseEventArgs> OnSort { get; set;}

    /// <summary>Sort direction.</summary>
    [Parameter] public SortByDirection? SortDirection { get; set; }

    /// <summary>Determines which wrapping modifier to apply to the table text.</summary>
    [Parameter] public WrapModifier? WrapModifier { get; set; }

    private string CssClass => new CssBuilder("pf-c-table__button")
        .AddClassFromAttributes(AdditionalAttributes)
        .Build();
}