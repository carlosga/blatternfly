using Blatternfly.Components;

namespace Blatternfly.Demo.Pages.Components.Table;

public sealed class Column
{
    public int           Index          { get; set; }
    public string        Name           { get; set; }
    public SortType      Sort           { get; set; }
    public SelectType    Select         { get; set; }
    public WrapModifier? WrapModifier   { get; set; }
    public bool          IsSticky       { get; set; }
    public bool          HasRightBorder { get; set; }
    public int?          ColSpan        { get; set; }
    public int?          RowSpan        { get; set; }
    public Column[]      SubColumns     { get; set; }
}
