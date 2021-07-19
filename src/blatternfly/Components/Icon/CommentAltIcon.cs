namespace Blatternfly.Components
{
    public sealed class CommentAltIcon : BaseIcon
    {
        private static readonly string _svgPath = "M448 0H64C28.7 0 0 28.7 0 64v288c0 35.3 28.7 64 64 64h96v84c0 9.8 11.2 15.5 19.1 9.7L304 416h144c35.3 0 64-28.7 64-64V64c0-35.3-28.7-64-64-64z";
        private static readonly IconDefinition _definition = new IconDefinition(name: "CommentAltIcon", height: 512, width: 512, svgPath: _svgPath, transform: "", yOffset: "", xOffset: "");

        public CommentAltIcon() : base(_definition) { }
    }
}