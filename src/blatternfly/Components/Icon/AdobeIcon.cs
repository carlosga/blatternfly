namespace Blatternfly.Components
{
    public sealed class AdobeIcon : BaseIcon
    {
        private static readonly string _svgPath = "M315.5 64h170.9v384L315.5 64zm-119 0H25.6v384L196.5 64zM256 206.1L363.5 448h-73l-30.7-76.8h-78.7L256 206.1z";
        private static readonly IconDefinition _definition = new(name: "AdobeIcon", height: 512, width: 512, svgPath: _svgPath, transform: "", yOffset: "", xOffset: "");

        protected override IconDefinition Definition { get => _definition; }
    }
}