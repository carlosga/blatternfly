namespace Blatternfly
{
    public readonly struct Size
    {
        public int Height { get; }
        public int Width { get; }
        
        public Size(int height, int width)
        {
            Height = height;
            Width = width;
        }
    }
}
