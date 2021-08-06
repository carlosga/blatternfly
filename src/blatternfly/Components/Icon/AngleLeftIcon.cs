namespace Blatternfly.Components
{
    public sealed class AngleLeftIcon : BaseIcon
    {
        private static readonly string _svgPath = "M31.7 239l136-136c9.4-9.4 24.6-9.4 33.9 0l22.6 22.6c9.4 9.4 9.4 24.6 0 33.9L127.9 256l96.4 96.4c9.4 9.4 9.4 24.6 0 33.9L201.7 409c-9.4 9.4-24.6 9.4-33.9 0l-136-136c-9.5-9.4-9.5-24.6-.1-34z";
        private static readonly IconDefinition _definition = new(name: "AngleLeftIcon", height: 512, width: 256, svgPath: _svgPath, transform: "", yOffset: "", xOffset: "");

        protected override IconDefinition Definition { get => _definition; }
    }
}