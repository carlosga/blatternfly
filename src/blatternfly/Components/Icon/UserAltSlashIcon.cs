namespace Blatternfly.Components
{
    public sealed class UserAltSlashIcon : BaseIcon
    {
        private static readonly string _svgPath = "M633.8 458.1L389.6 269.3C433.8 244.7 464 198.1 464 144 464 64.5 399.5 0 320 0c-67.1 0-123 46.1-139 108.2L45.5 3.4C38.5-2 28.5-.8 23 6.2L3.4 31.4c-5.4 7-4.2 17 2.8 22.4l588.4 454.7c7 5.4 17 4.2 22.5-2.8l19.6-25.3c5.4-6.8 4.1-16.9-2.9-22.3zM198.4 320C124.2 320 64 380.2 64 454.4v9.6c0 26.5 21.5 48 48 48h382.2L245.8 320h-47.4z";
        private static readonly IconDefinition _definition = new IconDefinition(name: "UserAltSlashIcon", height: 512, width: 640, svgPath: _svgPath, transform: "", yOffset: "", xOffset: "");

        public UserAltSlashIcon() : base(_definition) { }
    }
}