namespace Blatternfly.Components
{
    public sealed class InProgressIcon : BaseIcon
    {
        private static readonly string _svgPath = "M513.417211,16.013668 L513.417211,112.013668 C513.406007,120.539653 520.082422,127.576718 528.597211,128.013668 C732.697211,136.513668 896.147211,305.013668 896.147211,511.343668 C896.147211,723.013668 724.007211,895.163668 512.417211,895.163668 C437.186239,895.277345 363.602574,873.135095 300.927211,831.523668 C294.58293,827.2982 286.138663,828.135095 280.747211,833.523668 L211.807211,902.353668 C208.502935,905.676185 206.82123,910.280199 207.20607,914.950237 C207.590911,919.620275 210.00361,923.886884 213.807211,926.623668 C300.709573,989.398037 405.213535,1023.13146 512.417211,1023.01398 C794.537211,1023.01398 1023.91724,793.433668 1023.91724,511.413668 C1024.00721,235.103668 804.007211,9.22366802 529.897211,0.00645736761 C525.571205,-0.116171039 521.377128,1.51204372 518.271915,4.52681369 C515.166702,7.54158367 513.415263,11.6857144 513.417211,16.013668 M97.1272107,212.923668 C64.2190689,258.479443 39.0698895,309.162997 22.6972107,362.923668 C21.2705092,367.756559 22.2039184,372.979173 25.2163356,377.018685 C28.2287528,381.058197 32.9681443,383.442545 38.0072107,383.453683 L139.407211,383.453683 C145.970195,383.46249 151.873012,379.462528 154.297211,373.363668 C164.307669,347.593304 177.068112,322.977652 192.357211,299.943668 C196.579666,293.633658 195.741339,285.216847 190.357211,279.863668 L121.497211,211.013668 C118.186635,207.662531 113.567544,205.940538 108.871166,206.30669 C104.174788,206.672841 99.8783994,209.089927 97.1272107,212.913668 M112.907211,511.433663 L17.0072107,511.433663 C12.679257,511.433663 8.5351263,513.183159 5.52035633,516.288373 C2.50558635,519.393586 0.877371594,523.587662 1.00721065,527.913668 C4.13104542,629.408217 37.6085847,727.635936 97.1172107,809.913668 C99.8539943,813.717268 104.120603,816.129968 108.790642,816.514809 C113.46068,816.899649 118.064693,815.217944 121.387211,811.913668 L190.217211,743.073668 C195.605784,737.682216 196.442679,729.237949 192.217211,722.893668 C153.520825,664.580171 131.611534,596.745437 128.887211,526.813668 C128.553964,518.220138 121.487197,511.427209 112.887211,511.433663";
        public static readonly IconDefinition IconDefinition = new(name: "InProgressIcon", height: 1024, width: 1024, svgPath: _svgPath, transform: null, offsetY: "", offsetX: "");

        protected override IconDefinition Definition { get => IconDefinition; }
    }
}