namespace Blatternfly.Components
{
    public sealed class OkIcon : BaseIcon
    {
        private static readonly string _svgPath = "M668.3,361.4 L465.1,564.6 L352.2,451.7 C346.210177,445.698444 338.079189,442.325817 329.6,442.325817 C321.120811,442.325817 312.989823,445.698444 307,451.7 L261.8,496.9 C255.798444,502.889823 252.425817,511.020811 252.425817,519.5 C252.425817,527.979189 255.798444,536.110177 261.8,542.1 L442.4,722.7 C448.389823,728.701556 456.520811,732.074183 465,732.074183 C473.479189,732.074183 481.610177,728.701556 487.6,722.7 L758.6,451.7 C764.601556,445.710177 767.974183,437.579189 767.974183,429.1 C767.974183,420.620811 764.601556,412.489823 758.6,406.5 L713.4,361.3 C700.916226,348.87879 680.728569,348.923552 668.3,361.4 M512.1,127.9 C300.3,127.9 128.1,300.2 128.1,511.9 C128.1,723.8 300.3,895.9 512.1,895.9 C723.9,895.9 896.1,723.7 896.1,511.9 C896.1,300.1 723.8,127.9 512.1,127.9 M512.1,1024 C229.7,1024 0,794.3 0,512 C0,229.7 229.7,0 512.1,0 C794.3,0 1024,229.7 1024,512 C1024,794.3 794.3,1024 512.1,1024";
        public static readonly IconDefinition IconDefinition = new(name: "OkIcon", height: 1024, width: 1024, svgPath: _svgPath, transform: null, offsetY: "", offsetX: "");

        protected override IconDefinition Definition { get => IconDefinition; }
    }
}