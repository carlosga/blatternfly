namespace Blatternfly.Components
{
    public sealed class SubscriptIcon : BaseIcon
    {
        private static readonly string _svgPath = "M496 448h-16V304a16 16 0 0 0-16-16h-48a16 16 0 0 0-14.29 8.83l-16 32A16 16 0 0 0 400 352h16v96h-16a16 16 0 0 0-16 16v32a16 16 0 0 0 16 16h96a16 16 0 0 0 16-16v-32a16 16 0 0 0-16-16zM336 64h-67a16 16 0 0 0-13.14 6.87l-79.9 115-79.9-115A16 16 0 0 0 83 64H16A16 16 0 0 0 0 80v48a16 16 0 0 0 16 16h33.48l77.81 112-77.81 112H16a16 16 0 0 0-16 16v48a16 16 0 0 0 16 16h67a16 16 0 0 0 13.14-6.87l79.9-115 79.9 115A16 16 0 0 0 269 448h67a16 16 0 0 0 16-16v-48a16 16 0 0 0-16-16h-33.48l-77.81-112 77.81-112H336a16 16 0 0 0 16-16V80a16 16 0 0 0-16-16z";
        private static readonly IconDefinition _definition = new(name: "SubscriptIcon", height: 512, width: 512, svgPath: _svgPath, transform: null, yOffset: "", xOffset: "");

        protected override IconDefinition Definition { get => _definition; }
    }
}
