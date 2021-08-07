namespace Blatternfly.Components
{
    public sealed class PficonNetworkRangeIcon : BaseIcon
    {
        private static readonly string _svgPath = "M592.7,320 C592.7,355.3 560,384 519.8,384 L446.7,384 L446.7,256 L519.8,256 C560,256 592.7,284.7 592.7,320 Z M804.9,387 C804.9,469.6 779,546.1 734.9,609 C734,610.2 733.2,611.4 732.3,612.4 L449.7,987.9 C449.7,987.9 428.9,1023.6 402.6,1023.6 C402.6,1023.6 379,1028.6 355.4,988.1 L71.6,612.4 C70.8,611.4 70.1,610.4 69.4,609.4 L69,608.9 C24.9,546.1 -1,469.5 -1,386.9 C-1,173.2 188.3,-5.68434189e-14 402,-5.68434189e-14 C615,-5.68434189e-14 804.9,173.2 804.9,387 Z M318.7,192 L254.7,192 L254.7,640 L318.7,640 L318.7,192 Z M670.7,320 C670.7,239.4 609.6,192 529,192 L382.7,192 L382.7,640 L446.7,640 L446.7,448 L529,448.2 C609.5,448.2 670.7,400.6 670.7,320 Z M956,411 C955.7,468.9 963.9,529.4 913.8,606 C912.9,607.2 912.1,608.4 911.2,609.6 L632.6,988.1 C632.6,988.1 612.3,1023.99709 571.8,1023.8 C571.8,1023.8 536.5,1027.9 515.4,998.7 C520.2,992.7 522.9,988 522.9,988 L817.5,595.1 C818.4,593.9 819.3,592.7 820.1,591.5 C864.2,528.6 878.1,469.5 878.1,386.9 C878.1,313.9 858.5,246.6 822,188.6 C805.6,166 780.6,138.1 780.6,138.1 C777.5,135.4 774.1,132.1 770.9,128.5 C768.9,126.2 766.9,123.7 765.3,121.1 C761.1,116.4 758.5,110.2 758.5,103.4 C758.5,88.8 770.4,76.9 785,76.9 C793.3,76.9 800.6,80.7 805.5,86.6 C812.5,91.4 820.8,98.6 830.7,109.5 C841.7,121.7 852.6,133.8 863.2,146.5 C918.7,212.5 956.6,300.5 956,411 L956,411 L956,411 Z";
        private static readonly IconDefinition _definition = new(name: "PficonNetworkRangeIcon", height: 1024, width: 956, svgPath: _svgPath, transform: null, yOffset: "", xOffset: "");

        protected override IconDefinition Definition { get => _definition; }
    }
}
