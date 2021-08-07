namespace Blatternfly.Components
{
    public sealed class DoorClosedIcon : BaseIcon
    {
        private static readonly string _svgPath = "M624 448H512V50.8C512 22.78 490.47 0 464 0H175.99c-26.47 0-48 22.78-48 50.8V448H16c-8.84 0-16 7.16-16 16v32c0 8.84 7.16 16 16 16h608c8.84 0 16-7.16 16-16v-32c0-8.84-7.16-16-16-16zM415.99 288c-17.67 0-32-14.33-32-32s14.33-32 32-32 32 14.33 32 32c.01 17.67-14.32 32-32 32z";
        private static readonly IconDefinition _definition = new(name: "DoorClosedIcon", height: 512, width: 640, svgPath: _svgPath, transform: null, yOffset: "", xOffset: "");

        protected override IconDefinition Definition { get => _definition; }
    }
}
