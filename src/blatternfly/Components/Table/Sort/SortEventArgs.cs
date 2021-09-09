namespace Blatternfly.Components
{
    public sealed class SortEventArgs
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
