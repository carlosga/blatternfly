namespace Blatternfly.Components
{
    public sealed class OutlinedArrowAltCircleLeftIcon : BaseIcon
    {
        private static readonly string _svgPath = "M8 256c0 137 111 248 248 248s248-111 248-248S393 8 256 8 8 119 8 256zm448 0c0 110.5-89.5 200-200 200S56 366.5 56 256 145.5 56 256 56s200 89.5 200 200zm-72-20v40c0 6.6-5.4 12-12 12H256v67c0 10.7-12.9 16-20.5 8.5l-99-99c-4.7-4.7-4.7-12.3 0-17l99-99c7.6-7.6 20.5-2.2 20.5 8.5v67h116c6.6 0 12 5.4 12 12z";
        private static readonly IconDefinition _definition = new(name: "OutlinedArrowAltCircleLeftIcon", height: 512, width: 512, svgPath: _svgPath, transform: "", yOffset: "", xOffset: "");

        protected override IconDefinition Definition { get => _definition; }
    }
}