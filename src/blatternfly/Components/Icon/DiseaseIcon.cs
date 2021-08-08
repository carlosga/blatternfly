namespace Blatternfly.Components
{
    public sealed class DiseaseIcon : BaseIcon
    {
        public static readonly string SvgPath = "M472.29 195.9l-67.06-23c-19.28-6.6-33.54-20.92-38.14-38.31l-16-60.45c-11.58-43.77-76.57-57.13-110-22.62L195 99.24c-13.26 13.71-33.54 20.93-54.2 19.31l-71.9-5.62c-52-4.07-86.93 44.89-59 82.84l38.54 52.42c11.08 15.07 12.82 33.86 4.64 50.24l-28.43 57C4 396.67 47.46 440.29 98.11 429.23l70-15.28c20.11-4.39 41.45 0 57.07 11.73l54.32 40.83c39.32 29.56 101 7.57 104.45-37.22l4.7-61.86c1.35-17.8 12.8-33.87 30.63-43l62-31.74c44.84-22.96 39.55-80.17-8.99-96.79zM160 256a32 32 0 1 1 32-32 32 32 0 0 1-32 32zm128 96a32 32 0 1 1 32-32 32 32 0 0 1-32 32zm16-128a16 16 0 1 1 16-16 16 16 0 0 1-16 16z";
        public static readonly IconDefinition IconDefinition = new(name: "DiseaseIcon", height: 512, width: 512, svgPath: SvgPath, transform: null, yOffset: "", xOffset: "");

        protected override IconDefinition Definition { get => IconDefinition; }
    }
}
