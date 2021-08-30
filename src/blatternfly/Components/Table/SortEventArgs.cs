namespace Blatternfly.Components
{
    public readonly struct SortEventArgs
    {
        public int ColumnIndex { get; }
        public SortByDirection SortByDirection { get; }
        
        public SortEventArgs(int columnIndex, SortByDirection direction)
        {
            ColumnIndex     = columnIndex;
            SortByDirection = direction;
        }
    }
}
