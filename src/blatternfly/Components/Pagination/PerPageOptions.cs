namespace Blatternfly.Components
{
    public sealed class PerPageOptions
    {
        public string Title { get; set; }
        public int Value { get; set; }

        internal string Action { get => $"per-page-{Value}"; } 
    }
}
