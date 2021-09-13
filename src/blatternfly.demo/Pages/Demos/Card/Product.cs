namespace Blatternfly.Demo.Pages.Demos.Card
{
    public sealed class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Icon { get; set; }
        
        public bool IsChecked { get; set; }
        public string StrId { get => $"check-{Id}"; }
    }
}
