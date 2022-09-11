namespace Blatternfly.Components;

public partial class DataListItem : ComponentBase
{
    [CascadingParameter] private DataList Parent { get; set; }

    /// <summary>Additional attributes that will be applied to the component.</summary>
    [Parameter(CaptureUnmatchedValues = true)] public IReadOnlyDictionary<string, object> AdditionalAttributes { get; set; }

    /// <summary>Content rendered inside the component.</summary>
    [Parameter] public RenderFragment ChildContent { get; set; }

    /// <summary>Flag to show if the expanded content of the DataList item is visible.</summary>
    [Parameter] public bool IsExpanded { get; set; }

    /// <summary>Adds accessible text to the DataList item.</summary>
    [Parameter] public string AriaLabelledBy { get; set; }

    /// <summary>Aria label to apply to the selectable input if one is rendered.</summary>
    [Parameter] public string SelectableInputAriaLabel { get; set; }

    private string CssClass => new CssBuilder("pf-c-data-list__item")
        .AddClass("pf-m-expanded"  , IsExpanded)
        .AddClass("pf-m-selectable", IsSelectable)
        .AddClass("pf-m-selected"  , !string.IsNullOrEmpty(SelectedDataListItemId) && IsSelected)
        .AddClassFromAttributes(AdditionalAttributes)
        .Build();

    private string InternalId             { get => AdditionalAttributes?.GetPropertyValue(HtmlAttributes.Id); }
    private string TabIndex               { get => IsSelectable ? "0" : null; }
    private string SelectedDataListItemId { get => Parent?.SelectedDataListItemId; }
    private string AriaSelected           { get => !string.IsNullOrEmpty(SelectedDataListItemId) && IsSelected ? "true" : null; }
    private bool IsSelected               { get => SelectedDataListItemId == InternalId; }
    private bool IsSelectable             { get => Parent is not null && Parent.IsSelectable; }
    private bool AllowRowSelection        { get => Parent is not null && Parent.AllowRowSelection; }

    private async Task OnSelectionChanged(ChangeEventArgs args)
    {
        await Parent.SelectableRowChange(InternalId);
    }

    private async Task SelectDataListItem(MouseEventArgs args)
    {
        if (!IsSelectable)
        {
            return;
        }

        await Parent.SelectItem(InternalId);
    }

    private async Task OnKeyDown(KeyboardEventArgs args)
    {
        if (!IsSelectable)
        {
            return;
        }

        if (args.Key == Keys.Enter)
        {
            await Parent.SelectItem(InternalId);
        }
    }
}
