namespace Blatternfly.Components
{
    public sealed class CaretSquareRightIcon : BaseIcon
    {
        private static readonly string _svgPath = "M48 32h352c26.51 0 48 21.49 48 48v352c0 26.51-21.49 48-48 48H48c-26.51 0-48-21.49-48-48V80c0-26.51 21.49-48 48-48zm140.485 355.515l123.029-123.029c4.686-4.686 4.686-12.284 0-16.971l-123.029-123.03c-7.56-7.56-20.485-2.206-20.485 8.485v246.059c0 10.691 12.926 16.045 20.485 8.486z";
        private static readonly IconDefinition _definition = new IconDefinition(name: "CaretSquareRightIcon", height: 512, width: 448, svgPath: _svgPath, transform: "", yOffset: "", xOffset: "");

        public CaretSquareRightIcon() : base(_definition) { }
    }
}