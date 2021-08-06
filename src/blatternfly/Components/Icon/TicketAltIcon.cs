namespace Blatternfly.Components
{
    public sealed class TicketAltIcon : BaseIcon
    {
        private static readonly string _svgPath = "M128 160h320v192H128V160zm400 96c0 26.51 21.49 48 48 48v96c0 26.51-21.49 48-48 48H48c-26.51 0-48-21.49-48-48v-96c26.51 0 48-21.49 48-48s-21.49-48-48-48v-96c0-26.51 21.49-48 48-48h480c26.51 0 48 21.49 48 48v96c-26.51 0-48 21.49-48 48zm-48-104c0-13.255-10.745-24-24-24H120c-13.255 0-24 10.745-24 24v208c0 13.255 10.745 24 24 24h336c13.255 0 24-10.745 24-24V152z";
        private static readonly IconDefinition _definition = new(name: "TicketAltIcon", height: 512, width: 576, svgPath: _svgPath, transform: "", yOffset: "", xOffset: "");

        protected override IconDefinition Definition { get => _definition; }
    }
}