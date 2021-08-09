namespace Blatternfly.Components
{
    public sealed class SecurityIcon : BaseIcon
    {
        private static readonly string _svgPath = "M861.5,0 L34.5,0 C15.4,0 0,14.3 0,32 L0,452.1 C0,768 387.7,1024 448.5,1024 C509.3,1024 896,768 896,452.2 L896,32 C896,14.3 880.6,0 861.5,0 Z M490.7,768 L405.3,768 C393.5,767.8 384.2,757.5 384,744.7 L384,663.3 C384.2,650.5 393.6,640.3 405.3,640 L490.7,640 C502.5,640.2 511.8,650.5 512,663.3 L512,744.7 L512.1,744.7 C511.8,757.5 502.4,767.8 490.7,768 Z M543.9,162.7 L517.2,514.4 C515.8,530.9 502,544 485.3,544 L410.6,544 C394,544 380.1,531.2 378.7,514.7 L352.1,163 C350.5,144.3 365.3,128.3 384,128.3 L512,128 C530.7,128 545.4,144 543.9,162.7 Z";
        public static readonly IconDefinition IconDefinition = new(name: "SecurityIcon", height: 1024, width: 896, svgPath: _svgPath, transform: null, offsetY: "", offsetX: "");

        protected override IconDefinition Definition { get => IconDefinition; }
    }
}