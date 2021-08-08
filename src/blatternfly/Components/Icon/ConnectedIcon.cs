namespace Blatternfly.Components
{
    public sealed class ConnectedIcon : BaseIcon
    {
        public static readonly string SvgPath = "M164.205055,860.745249 C148.733045,860.838628 133.985899,854.195111 123.805055,842.544257 C-14.7040912,683.356495 -39.4049666,454.743708 61.9050547,269.644257 C79.2208597,238.233782 99.8013724,208.737282 123.305055,181.644257 C142.773092,159.304339 176.665137,156.97622 199.005055,176.444257 C221.344973,195.912295 223.673092,229.804339 204.205055,252.144257 C185.73115,273.409387 169.542309,296.556414 155.905055,321.204257 C76.284152,466.765473 95.8003635,646.522153 204.805055,771.604257 C218.6725,787.501143 221.960918,810.039426 213.213717,829.23587 C204.466515,848.432314 185.300453,860.745249 164.205055,860.704257 M862.305055,857.704257 C841.38711,857.664169 822.402887,845.461026 813.680654,826.448276 C804.958421,807.435527 808.091354,785.085982 821.705055,769.204257 C949.320125,620.203968 948.554345,400.212503 819.905055,252.104257 C807.156654,237.709139 803.099548,217.586468 809.274083,199.376133 C815.448617,181.165799 830.90788,167.660496 849.782516,163.987725 C868.657153,160.314955 888.052595,167.037965 900.605055,181.604257 C1064.18702,369.743318 1065.25072,649.325935 903.105055,838.704257 C892.94742,850.711731 878.03257,857.657371 862.305055,857.704257 M622.005055,511.744257 C622.005055,572.385123 572.84592,621.544257 512.205055,621.544257 C451.564189,621.544257 402.405055,572.385123 402.405055,511.744257 C402.405055,451.103392 451.564189,401.944257 512.205055,401.944257 C572.834488,401.971848 621.977464,451.114824 622.005055,511.744257 M721.705055,703.644257 C704.64083,703.605747 689.019526,694.063383 681.195263,678.898616 C673.371001,663.733849 674.647316,645.473157 684.505055,631.544257 C735.18401,559.780377 735.023639,463.838313 684.105055,392.244257 C669.46951,371.699265 674.260064,343.179804 694.805056,328.544259 C715.350048,313.908713 743.869508,318.699266 758.505055,339.244257 C831.942334,442.463696 832.262987,580.78545 759.305055,684.344257 C750.573021,696.412993 736.601337,703.584628 721.705055,703.644257 M301.105055,703.444257 C286.228641,703.430877 272.284228,696.197679 263.705055,684.044257 C191.42292,581.096562 191.303009,443.918163 263.405055,340.844257 C277.705055,320.244257 306.305055,315.244257 327.105055,329.644257 C347.7097,344.191543 352.711823,372.641119 338.305055,393.344257 C313.605055,428.244257 300.905055,469.544257 300.905055,512.444257 C300.802505,555.080048 313.940659,596.695848 338.505055,631.544257 C345.495017,641.460463 348.243215,653.75422 346.141024,665.702923 C344.038833,677.651626 337.259738,688.269203 327.305055,695.204257 C319.580013,700.479172 310.458986,703.333844 301.105055,703.404257";
        public static readonly IconDefinition IconDefinition = new(name: "ConnectedIcon", height: 1024, width: 1024, svgPath: SvgPath, transform: null, yOffset: "", xOffset: "");

        protected override IconDefinition Definition { get => IconDefinition; }
    }
}
