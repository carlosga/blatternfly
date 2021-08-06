namespace Blatternfly.Components
{
    public sealed class ServerGroupIcon : BaseIcon
    {
        private static readonly string _svgPath = "M32,256.000568 C14.3,256.000568 0,270.300568 0,288.000568 L0,992.000568 C0,1009.70057 14.3,1024.00057 32,1024.00057 L736,1024.00057 C753.7,1024.00057 768,1009.70057 768,992.000568 L768,256.000568 L32,256.000568 Z M640,864.000568 L320,864.000568 L320,768.000568 L640,768.000568 L640,864.000568 Z M640,672.000568 L128,672.000568 L128,576.000568 L640,576.000568 L640,672.000568 Z M640,480.000568 L448,480.000568 L448,384.000568 L640,384.000568 L640,480.000568 Z M185.5,0.000283614416 C185.5,0.000283614416 170.3,-0.199431587 161.6,10.0005684 C151.1,22.3005684 9.6,162.500568 9.6,162.500568 C1.2,170.700568 0,172.000568 0,181.200568 C0,190.400568 10.8,192.100568 22.1,192.000568 L752,192.000568 L560,0.000283614416 L185.5,0.000283614416 Z M992,256.000568 L832,256.000568 L832,960.000568 L992,960.000568 C1009.7,960.000568 1024,945.700568 1024,928.000568 L1024,288.000568 C1024,270.300568 1009.7,256.000568 992,256.000568 L992,256.000568 Z M1000.7,191.900568 C1012.3,191.900568 1024,190.700568 1024,181.100568 C1024,172.000568 1021.9,170.700568 1013.5,162.300568 C1013.5,162.300568 873.6,21.8005684 863.1,10.2005684 C853.5,0.000568413277 840.6,0.000568413277 840.6,0.000568413277 L640,0.000568413277 L832,192.000568 L1000.7,192.000568 L1000.7,191.900568 Z";
        private static readonly IconDefinition _definition = new(name: "ServerGroupIcon", height: 1024, width: 1024, svgPath: _svgPath, transform: "", yOffset: "", xOffset: "");

        protected override IconDefinition Definition { get => _definition; }
    }
}