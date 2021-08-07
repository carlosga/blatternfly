namespace Blatternfly.Components
{
    public sealed class EnhancementIcon : BaseIcon
    {
        private static readonly string _svgPath = "M561.001473,320.000669 L463.001473,320.000669 C454.717202,320.000669 448.001473,326.716398 448.001473,335.000669 L448.001473,448.000669 L335.001473,448.000669 C326.694173,448.03924 319.984846,454.793296 320.001442,463.100669 L320.001442,561.100669 C320.001442,565.069782 321.58492,568.874889 324.400878,571.672074 C327.216835,574.469258 331.032449,576.027308 335.001473,576.000669 L448.001473,576.000669 L448.001473,689.000669 C448.001473,697.284941 454.717202,704.000669 463.001473,704.000669 L561.001473,704.000669 C569.285744,704.000669 576.001473,697.284941 576.001473,689.000669 L576.001473,576.000669 L689.001473,576.000669 C692.960412,576.051464 696.77486,574.514957 699.593209,571.734186 C702.411558,568.953414 704.001504,565.159934 704.001504,561.200669 L704.001504,463.100669 C704.0181,454.793296 697.308773,448.03924 689.001473,448.000669 L576.001473,448.100669 L576.001473,335.000669 C576.001473,326.716398 569.285744,320.000669 561.001473,320.000669 Z M469.781473,22.5506693 C484.981473,-0.249330671 516.281473,-6.94933067 539.781473,7.95066933 C545.75355,11.6723498 550.839109,16.655515 554.681473,22.5506693 L624.981473,161.550669 L788.081473,75.3406693 C814.181473,65.4406693 843.481473,78.2406693 853.481473,103.640669 C856.110836,110.173406 857.238617,117.213492 856.781473,124.240669 L832.481473,281.760669 L986.381473,312.000669 C1013.28147,319.100669 1029.48147,346.300669 1022.18147,372.610669 C1020.26485,379.362841 1016.99906,385.656295 1012.58147,391.110669 L903.381473,512.000669 L1012.58147,632.910669 C1021.0338,642.981263 1025.06698,656.035336 1023.76825,669.118608 C1022.46952,682.20188 1015.94868,694.208295 1005.68147,702.420669 C1000.12004,706.859911 993.67723,710.064272 986.781473,711.820669 L828.181473,737.420669 L857.081473,899.540669 C858.781473,926.940669 837.281473,950.240669 809.481473,951.640669 C802.299495,952.112229 795.100686,951.020466 788.381473,948.440669 L627.581473,862.230669 L554.681473,1001.45067 C539.481473,1024.25067 508.181473,1030.95067 484.781473,1016.05067 C478.809396,1012.32899 473.723837,1007.34582 469.881473,1001.45067 L397.001473,862.230669 L236.201473,948.440669 C210.101473,958.340669 180.811473,945.540669 170.811473,920.140669 C168.175054,913.609729 167.043717,906.56878 167.501473,899.540669 L196.401473,737.420669 L37.7914729,711.820669 C10.6914729,704.920669 -5.50852711,677.720669 1.79147289,651.410669 C3.70809476,644.658497 6.97388689,638.365044 11.3914729,632.910669 L120.581473,512.000669 L11.1914729,391.090669 C2.80380205,380.945109 -1.1303086,367.841751 0.281843743,354.753923 C1.69399609,341.666095 8.33267438,329.70352 18.6914729,321.580669 C24.2529052,317.141428 30.6957158,313.937067 37.5914729,312.180669 L191.591473,281.780669 L167.291473,124.260669 C165.881473,97.0606693 187.181473,73.7606693 215.181473,72.3606693 C222.264582,71.9118093 229.360824,73.0035388 235.981473,75.5606693 L396.881473,161.770669 L469.781473,22.5506693 Z";
        private static readonly IconDefinition _definition = new(name: "EnhancementIcon", height: 1024, width: 1024, svgPath: _svgPath, transform: null, yOffset: "", xOffset: "");

        protected override IconDefinition Definition { get => _definition; }
    }
}
