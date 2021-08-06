namespace Blatternfly.Components
{
    public sealed class LockIcon : BaseIcon
    {
        private static readonly string _svgPath = "M400 224h-24v-72C376 68.2 307.8 0 224 0S72 68.2 72 152v72H48c-26.5 0-48 21.5-48 48v192c0 26.5 21.5 48 48 48h352c26.5 0 48-21.5 48-48V272c0-26.5-21.5-48-48-48zm-104 0H152v-72c0-39.7 32.3-72 72-72s72 32.3 72 72v72z";
        private static readonly IconDefinition _definition = new(name: "LockIcon", height: 512, width: 448, svgPath: _svgPath, transform: "", yOffset: "", xOffset: "");

        protected override IconDefinition Definition { get => _definition; }
    }
}