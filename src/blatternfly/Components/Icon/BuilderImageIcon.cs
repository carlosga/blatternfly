namespace Blatternfly.Components
{
    public sealed class BuilderImageIcon : BaseIcon
    {
        private static readonly string _svgPath = "M903.7,237.64 L511.5,378.4 L119.9,237.94 L512.2,95 L903.7,237.64 Z M126.8,719.64 L285.1,662.9 L445.6,733.33 L445.6,894.33 L126.8,719.64 Z M96,329.35 L225.2,375.71 L96,422.06 L96,329.35 Z M199.9,625.35 L96,662.73 L96,579.91 L199.9,625.35 Z M445.5,454.73 L445.5,619.37 L111.9,484.2 L319.9,409.57 L445.5,454.73 Z M738.3,662.73 L897,719.57 L573.6,897 L573.6,735.16 L738.3,662.73 Z M798,375.51 L928,329 L928,422.21 L798,375.51 Z M928,579.41 L928,662.83 L823.4,625.36 L928,579.41 Z M703.2,409.47 L911.3,484.1 L573.6,621.17 L573.6,456 L703.2,409.47 Z M1024,239.64 C1023.39305,204.05641 1000.93137,172.522598 967.5,160.32 C825.5,108.573333 683.5,56.8566667 541.5,5.17 C522.437353,-1.72320177 501.562647,-1.72320177 482.5,5.17 L56.5,160.42 C23.1452849,172.665955 0.715338236,204.115519 0,239.64 L0,694.55 L0.1,694.55 C1.2,725.55 18.9,765.18 44.6,779.96 L470.6,1013.44 C496.404128,1027.52063 527.595872,1027.52063 553.4,1013.44 C639.6,966.18 841.7,855.44 979.4,779.96 C1006.1,765.38 1022.9,725.62 1024,694.55 L1024,239.64 Z";
        private static readonly IconDefinition _definition = new IconDefinition(name: "BuilderImageIcon", height: 1024, width: 1024, svgPath: _svgPath, transform: "", yOffset: "", xOffset: "");

        public BuilderImageIcon() : base(_definition) { }
    }
}