namespace Blatternfly.Components
{
    public sealed class PficonHistoryIcon : BaseIcon
    {
        public static readonly string SvgPath = "M1024,510.7002 C1024,797.0002 794.9,1024.0002 512.3,1024.0002 C383.7,1024.0002 266,976.3002 176,897.5992 C162.1,885.4002 161.4,864.0002 174.4,850.9002 L219.6,805.5992 C231.4,793.8002 250.3,793.0992 263,803.9002 C330.1,861.2002 417.1,896.0002 512.1,896.0002 C723.8,896.0992 896,723.8002 896,512.0002 C896,300.2002 723.6,128.0002 512,128.0002 C406.2,128.0002 310.5,171.1002 241,240.5002 L329.8,329.3002 C350,349.5002 335.7,384.0002 307.2,384.0002 L32.5,384.0002 C14.8,384.1002 0,369.7002 0,352.0002 L0,77.3002 C0,48.8002 35,34.5002 55.1,54.7002 L150.6,150.2002 C242.4,58.4002 368.7,0.0002 508.2,0.0002 C789,0.0002 1024,226.2002 1024,510.7002";
        public static readonly IconDefinition IconDefinition = new(name: "PficonHistoryIcon", height: 1024, width: 1024, svgPath: SvgPath, transform: null, yOffset: "", xOffset: "");

        protected override IconDefinition Definition { get => IconDefinition; }
    }
}
