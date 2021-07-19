namespace Blatternfly.Components
{
    public sealed class SpinnerAltIcon : BaseIcon
    {
        private static readonly string _svgPath = "M682.8,854.2 C675.8,857.7 668.7,861 661.4,864.1 C614.1,884.1 563.9,894.2 512,894.2 C460.1,894.2 409.8,884.1 362.6,864.1 C355.4,861.1 348.4,857.8 341.4,854.4 L265.4,959.1 C338.6,999.4 422.6,1022.3 512,1022.3 C601.5,1022.3 685.7,999.3 758.9,959 L682.8,854.2 Z M1015,414.3 L892,454.3 C894.7,472.7 896,491.3 896,510.2 C896,562.1 885.9,612.4 865.9,659.6 C847.1,704.1 820.3,744.2 786.3,778.8 L862.3,883.5 C961.8,790.1 1024,657.4 1024,510.2 C1024,477.4 1020.9,445.4 1015,414.3 L1015,414.3 Z M171.5,332.4 C189.5,297.9 212.6,266.5 240.5,238.6 C275.8,203.3 316.9,175.6 362.6,156.3 C389.8,144.8 418.1,136.5 447,131.6 L447,2.3 C270.2,24.7 121.5,137.3 48.5,292.5 L171.5,332.4 Z M575,131.3 C604.7,136.2 633.6,144.5 661.4,156.3 C707.1,175.6 748.2,203.3 783.5,238.6 C811.4,266.5 834.5,298 852.5,332.5 L975.5,292.5 C902.3,136.7 752.7,23.9 575,2 L575,131.3 Z M237.9,779.1 C203.8,744.4 177,704.2 158.2,659.7 C138.2,612.4 128.1,562.2 128.1,510.3 C128.1,491.4 129.5,472.7 132.1,454.3 L9,414.2 C3.1,445.3 0,477.4 0,510.2 C0,657.5 62.2,790.3 161.8,883.7 L237.9,779.1 Z";
        private static readonly IconDefinition _definition = new IconDefinition(name: "SpinnerAltIcon", height: 1024, width: 1024, svgPath: _svgPath, transform: "", yOffset: "", xOffset: "");

        public SpinnerAltIcon() : base(_definition) { }
    }
}