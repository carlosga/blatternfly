namespace Blatternfly.Components
{
    public sealed class ParkingIcon : BaseIcon
    {
        private static readonly string _svgPath = "M400 32H48C21.5 32 0 53.5 0 80v352c0 26.5 21.5 48 48 48h352c26.5 0 48-21.5 48-48V80c0-26.5-21.5-48-48-48zM240 320h-48v48c0 8.8-7.2 16-16 16h-32c-8.8 0-16-7.2-16-16V144c0-8.8 7.2-16 16-16h96c52.9 0 96 43.1 96 96s-43.1 96-96 96zm0-128h-48v64h48c17.6 0 32-14.4 32-32s-14.4-32-32-32z";
        private static readonly IconDefinition _definition = new IconDefinition(name: "ParkingIcon", height: 512, width: 448, svgPath: _svgPath, transform: "", yOffset: "", xOffset: "");

        public ParkingIcon() : base(_definition) { }
    }
}