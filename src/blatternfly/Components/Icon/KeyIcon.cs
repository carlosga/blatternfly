namespace Blatternfly.Components
{
    public sealed class KeyIcon : BaseIcon
    {
        private static readonly string _svgPath = "M802,320 C748.980664,320 706,277.019336 706,224 C706,170.980664 748.980664,128 802,128 C855.019336,128 898,170.980664 898,224 C898,277.019336 855.019336,320 802,320 M704,0 C527.3,0 384,143.3 384,320 C383.937788,357.490503 390.505571,394.696657 403.4,429.9 L0,824.1 L0,1024 L192,1024 L192,896 L320,896 L320,768 L448,768 L597,622 C596.906403,621.881923 596.838304,621.745723 596.8,621.6 C631.220126,633.811107 667.47802,640.034477 704,640 C880.7,640 1024,496.7 1024,320 C1024,143.3 880.7,0 704,0";
        private static readonly IconDefinition _definition = new(name: "KeyIcon", height: 1024, width: 1024, svgPath: _svgPath, transform: null, yOffset: "", xOffset: "");

        protected override IconDefinition Definition { get => _definition; }
    }
}
