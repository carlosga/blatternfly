namespace Blatternfly.Demo.Shared
{
    public sealed class RoutePath
    {
        public string Path { get; set; }

        public string Title { get; set; }

        public bool IsExpanded { get; set; }

        public RoutePath[] Children { get; set; }
    }
}
