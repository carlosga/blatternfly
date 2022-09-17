namespace Blatternfly.Components;

public partial class TableRow : ComponentBase
{
    [CascadingParameter] private Table ParentTable { get; set; }

    /// <summary>Additional attributes that will be applied to the component.</summary>
    [Parameter(CaptureUnmatchedValues = true)] public IReadOnlyDictionary<string, object> AdditionalAttributes { get; set; }

    /// <summary>Content rendered inside the component.</summary>
    [Parameter] public RenderFragment ChildContent { get; set; }

    /// <summary>Flag indicating the Tr is hidden.</summary>
    [Parameter] public bool IsHidden { get; set; }

    /// <summary>Only applicable to Tr within the Tbody: Makes the row expandable and determines if it's expanded or not.</summary>
    [Parameter] public bool? IsExpanded { get; set; }

    /// <summary>Only applicable to Tr within the Tbody: Whether the row is editable.</summary>
    [Parameter] public bool IsEditable { get; set; }

    /// <summary>Flag which adds hover styles for the table row.</summary>
    [Parameter] public bool IsHoverable { get; set; }

    /// <summary>Flag indicating the row is selected - adds selected styling.</summary>
    [Parameter] public bool IsRowSelected { get; set; }

    /// <summary>Flag indicating the row is striped.</summary>
    [Parameter] public bool IsStriped { get; set; }

    /// <summary>Flag indicating the row will act as a border. This is typically used for a table with a nested and sticky header.</summary>
    [Parameter] public bool IsBorderRow { get; set; }

    /// <summary>An event handler for the row.</summary>
    [Parameter] public EventCallback<MouseEventArgs> OnRowClick { get; set; }

    /// <summary>Flag indicating that the row is selectable.</summary>
    [Parameter] public bool IsSelectable { get; set; }

    /// <summary>Flag indicating the spacing offset of the first cell should be reset.</summary>
    [Parameter] public bool ResetOffset { get; set; }

    private string CssClass => new CssBuilder()
        .AddClass("pf-c-table__expandable-row"  , IsExpanded.HasValue)
        .AddClass("pf-m-expanded"               , IsExpanded.GetValueOrDefault())
        .AddClass("pf-m-inline-editable"        , IsEditable)
        .AddClass("pf-m-hoverable"              , IsHoverable)
        .AddClass("pf-m-selected"               , IsRowSelected)
        .AddClass("pf-m-striped"                , IsStriped)
        .AddClass("pf-m-border-row"             , IsBorderRow)
        .AddClass("pf-m-first-cell-offset-reset", ResetOffset)
        .AddClassFromAttributes(AdditionalAttributes)
        .Build();

    private bool   HiddenRow { get => IsHidden || (IsExpanded.HasValue && !IsExpanded.Value); }
    private string TabIndex  { get => IsHoverable ? "0" : null; }

    private string ComputedAriaLabel { get => IsRowSelected ? "Row selected" : null; }

    private string PassedAriaLabel { get => AdditionalAttributes.GetPropertyValue("aria-label"); }
    private string AriaLabel
    {
        get => !string.IsNullOrEmpty(PassedAriaLabel)
            ? PassedAriaLabel
                : !IsSelectable && !HiddenRow
                    ? ComputedAriaLabel
                        : null;
    }

    protected override void OnInitialized()
    {
        base.OnInitialized();

        ParentTable?.RegisterSelectableRow();
    }
}