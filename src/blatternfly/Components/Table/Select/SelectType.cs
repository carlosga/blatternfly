namespace Blatternfly.Components
{
    public sealed class SelectType
    {
        /// The selectable variant.
        public RowSelectVariant Variant { get; set; } = RowSelectVariant.Checkbox;
        
        /// Whether the cell is selected.
        public bool IsSelected { get; set; }
        
        /// Flag indicating the select checkbox in the th is disabled.
        public bool IsHeaderSelectDisabled { get; set; }
        
        /// Whether to disable the selection.
        public bool Disable { get; set; }
        
        /// The row index.
        public int RowIndex { get; set; }        
    }
}
