namespace Blatternfly.Components
{
    public sealed class RepositoryIcon : BaseIcon
    {
        public static readonly string SvgPath = "M1088,608 L1088,1024 L384,1024 L384,548.5 C384,548.5 384,512 420.5,512 L661,512 C698.2,512 715.6,549.7 715.6,549.7 L729.8,576 L1056,576 C1073.7,576 1088,590.3 1088,608 L1088,608 Z M320,547.5 C320,540.2 321.1,521.1 331.3,500.6 C348.1,467 382.4,447 421.5,447 L662,447 C694.6,447 725.7,460.7 749.5,485.6 C758.3,494.8 764.7,504 768.9,511 L896,511 L896,352 C896,334.3 881.7,320 864,320 L537.8,320 L523.6,293.7 C523.6,293.7 506.2,256 469,256 L228.5,256 C192,256 192,292.5 192,292.5 L192,768 L320,768 L320,547.5 Z M128,512 L0,512 L0,36.5 C0,36.5 0,0 36.5,0 L277,0 C314.2,0 331.6,37.7 331.6,37.7 L345.8,64 L672,64 C689.7,64 704,78.3 704,96 L704,256 L575.9,256 C571.7,249 565.3,237.8 556.5,228.6 C532.7,203.7 501.6,190 469,190 L228.5,190 C189.5,190 156.1,210 139.3,243.6 C129.1,264 128,283.2 128,290.5 L128,512 Z";
        public static readonly IconDefinition IconDefinition = new(name: "RepositoryIcon", height: 1024, width: 1088, svgPath: SvgPath, transform: null, yOffset: "", xOffset: "");

        protected override IconDefinition Definition { get => IconDefinition; }
    }
}
