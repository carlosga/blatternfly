namespace Blatternfly.Components;

/// <summary>BuildIcon icon.</summary>
public sealed class BuildIcon : BaseIcon
{
    private static readonly string _svgPath = "M996.377115,171.480135 L540.537115,5.18013521 C531.409589,1.76249044 521.743498,0.00809818406 511.997115,6.72397778e-05 C501.871295,-0.0125134433 491.820803,1.74040061 482.297115,5.18013521 L27.6671155,171.370135 C11.0249457,177.434467 -0.0238641555,193.287629 0.046775475,211.000135 L0.046775475,249.000135 C0.195841208,267.102495 11.623122,283.189328 28.6671155,289.290135 L85.2071155,309.500135 C95.0094893,313.010977 105.907101,311.533188 114.420477,305.53861 C122.933853,299.544031 127.998417,289.782269 127.997115,279.370135 L127.997115,234.580135 L511.997115,95.0001352 L895.177115,235.170135 L895.177115,295.370135 C895.178887,302.102977 898.453489,308.414744 903.95698,312.293243 C909.460471,316.171742 916.505874,317.132839 922.847115,314.870135 L995.477115,289.270135 C1012.59546,283.170258 1024.01857,266.9528 1023.99715,248.780135 L1023.99715,210.870135 C1023.97475,193.258354 1012.96683,177.531031 996.427115,171.480135 M533.647115,346.370135 L511.997115,353.370135 L489.587115,348.080135 C479.853994,344.894147 469.183221,346.571799 460.897291,352.59073 C452.611361,358.609661 447.71662,368.238859 447.737051,378.480135 L447.737051,417.580135 C447.725709,431.081528 456.204913,443.131767 468.917115,447.680135 L499.577115,458.180135 C507.177328,460.919505 515.534404,460.669293 522.957115,457.480135 L554.327115,445.870135 C567.027983,441.306886 575.500688,429.265885 575.507257,415.770135 L575.507257,376.770135 C575.537565,366.523106 570.643619,356.885253 562.352331,350.863869 C554.061043,344.842484 543.381903,343.17069 533.647115,346.370135 M351.737115,359.870135 L351.737115,318.770135 C351.726919,304.92777 342.817563,292.661266 329.657115,288.370135 L265.717115,267.480135 C255.985877,264.299431 245.319589,265.977891 237.035494,271.993509 C228.751399,278.009128 223.854266,287.632278 223.86709,297.870135 L223.86709,337.000135 C223.874371,350.47567 232.322855,362.502666 244.997115,367.080135 L308.937115,390.080135 C318.749212,393.583471 329.652547,392.090624 338.161859,386.078784 C346.67117,380.066943 351.720981,370.28887 351.697115,359.870135 M991.217115,442.000135 L856.317115,394.650135 C852.839791,393.339817 849.00444,393.339817 845.527115,394.650135 L798.077115,411.550135 C783.887115,416.550135 783.887115,436.650135 798.077115,441.650135 L913.157115,483.000135 L511.997115,646.780135 L109.477115,482.780135 L223.867115,441.780135 C237.947115,436.690135 237.947115,416.690135 223.867115,411.690135 L176.607115,394.780135 C173.112329,393.58999 169.321902,393.58999 165.827115,394.780135 L33.1571155,442.370135 C13.0440455,449.54441 -0.269196877,468.728185 0.0471154616,490.080135 L0.0471154616,503.080135 C-0.847277689,523.712017 11.059679,542.763147 29.9971155,551.000135 L476.407115,747.280135 C498.111167,756.808317 522.807966,756.840942 544.537115,747.370135 L802.537115,634.470135 L994.287115,549.930135 C1013.05026,541.718274 1024.80919,522.789452 1023.85712,502.330135 L1023.85712,489.430135 C1024.36395,468.22962 1011.19974,449.100375 991.217115,442.000135 M995.527115,672.000135 L915.657115,643.810135 C911.820884,642.433761 907.604002,642.573251 903.867115,644.200135 L861.307115,662.810135 C848.027115,668.610135 848.727115,687.610135 862.307115,692.500135 L910.997115,710.000135 L511.997115,916.170135 L111.277115,709.870135 L152.437115,695.080135 C165.827115,690.280135 166.717115,671.580135 153.837115,665.580135 L112.837115,646.370135 C109.008929,644.580285 104.630262,644.368356 100.647115,645.780135 L27.9971155,671.870135 C11.3473237,677.858232 0.19240487,693.586867 0.0471154616,711.280135 L0.0471154616,730.080135 C0.0632949619,745.406045 8.42616142,759.506405 21.8671155,766.870135 L470.707115,1013.47014 C483.376418,1020.36989 497.570829,1023.98983 511.997115,1024.00014 C526.111827,1023.98457 539.988079,1020.35974 552.307115,1013.47014 L1002.19712,766.870135 C1015.63034,759.501145 1023.98494,745.401803 1023.99712,730.080135 L1023.99712,712.470135 C1023.99712,694.324323 1012.60558,678.131732 995.527115,672.000135 M799.277301,336.480135 L799.277301,297.480135 C799.312025,287.231444 794.419143,277.590499 786.126499,271.568129 C777.833854,265.54576 767.152103,263.875935 757.417115,267.080135 L693.487115,288.000135 C680.330167,292.290121 671.421636,304.551456 671.407115,318.390135 L671.407115,359.390135 C671.416959,369.788712 676.478869,379.534105 684.980399,385.521966 C693.481929,391.509827 704.362857,392.993413 714.157115,389.500135 L778.097115,366.700135 C790.819287,362.10717 799.292115,350.02599 799.277301,336.500135";
    internal static readonly IconDefinition IconDefinition = new(name: "BuildIcon", height: 1024, width: 1024, svgPath: _svgPath, transform: null, offsetY: "", offsetX: "");

    protected override IconDefinition Definition { get => IconDefinition; }
}
