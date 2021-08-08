namespace Blatternfly.Components
{
    public sealed class ContainerNodeIcon : BaseIcon
    {
        public static readonly string SvgPath = "M22.3,576.00143 L1001.8,576.00143 C1013.2,576.00143 1020.3,570.90143 1023.1,560.50143 C1025.6,550.20143 1022.9,537.30143 1014.4,522.10143 C1014.4,522.10143 874.3,232.50143 863.8,211.00143 C856,191.90143 841.4,192.000713 841.4,192.000713 L185.6,192.000713 C185.6,192.000713 169,191.60143 161.8,209.70143 C151.3,232.30143 9.7,522.00143 9.7,522.00143 C1.2,537.10143 -1.7,550.00143 1,560.40143 C3.7,570.80143 10.8,576.00143 22.3,576.00143 Z M1013.1,650.90143 C1005.8,643.60143 997.2,640.00143 987.4,640.00143 L36.6,640.00143 C26.6,640.00143 18.2,643.60143 10.9,650.90143 C3.6,658.20143 0,666.80143 0,676.60143 L0,795.50143 C0,805.50143 3.6,813.90143 10.7,821.20143 C18,828.40143 26.4,832.00143 36.4,832.00143 L987.4,832.00143 C997.4,832.00143 1005.8,828.40143 1013.1,821.10143 C1020.4,813.80143 1024,805.40143 1024,795.40143 L1024,676.60143 C1024,666.60143 1020.4,658.20143 1013.1,650.90143 Z M128,768.00143 L64,768.00143 L64,704.00143 L128,704.00143 L128,768.00143 Z M256,768.00143 L192,768.00143 L192,704.00143 L256,704.00143 L256,768.00143 Z M384,768.00143 L320,768.00143 L320,704.00143 L384,704.00143 L384,768.00143 Z M512,768.00143 L448,768.00143 L448,704.00143 L512,704.00143 L512,768.00143 Z M960,768.00143 L896,768.00143 L896,704.00143 L960,704.00143 L960,768.00143 Z";
        public static readonly IconDefinition IconDefinition = new(name: "ContainerNodeIcon", height: 1024, width: 1024, svgPath: SvgPath, transform: null, yOffset: "", xOffset: "");

        protected override IconDefinition Definition { get => IconDefinition; }
    }
}
