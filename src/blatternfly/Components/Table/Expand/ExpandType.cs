namespace Blatternfly.Components
{
    public sealed class ExpandType
    {
        /// Flag indicating the child row associated with this cell is expanded.
        public bool IsExpanded { get; set; }
        
        /// The row index.
        public int RowIndex { get; set; }
        
        /// The column index.
        public int? ColumnIndex { get; set; }     
        
        public bool FullWidth { get; set; }
        public bool NoPadding { get; set; }
    }
}
