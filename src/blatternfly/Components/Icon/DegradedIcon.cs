namespace Blatternfly.Components;

public sealed class DegradedIcon : BaseIcon
{
    private static readonly string _svgPath = "M671.7,0 C703.8,0 734.6,1.1 763.9,4 C793.2,6.9 821.3,10.6 848.2,16.1 C872.57072,21.0125373 896.669847,27.1875213 920.4,34.6 C941.9,41.9 960.6,49.7 976.5,58.8 C991.9,67.9 1003.9,77.5 1011.6,87.4 C1019.3,97.3 1024,107.4 1024,117.5 L1024,265.4 C1024,276.2 1020.2,286.3 1012.5,296.4 C1004.8,306.3 992.8,315.9 977.4,325 C959.337595,334.451236 940.502821,342.346452 921.1,348.6 C897.436848,356.377909 873.326481,362.722743 848.9,367.6 C820.897405,372.974437 792.621855,376.813503 764.2,379.1 C759.8,379.5 755.4,379.8 750.9,380.1 C748.408787,375.948151 745.635606,371.972146 742.6,368.2 C730,351.9 712.6,337.4 689.6,323.8 L688.8,323.4 C670.3,312.7 648.2,303.2 621.4,294.1 L620.2,293.7 C594.308252,285.580645 568.004767,278.837874 541.4,273.5 C515,268.1 486.1,263.9 450.6,260.4 C420.6,257.4 388.3,256 351.9,256 C341.1,256 330.6,256.1 320.3,256.4 C320.042814,256.229635 319.807695,256.028104 319.6,255.8 L319.6,117.6 C319.6,107.5 323.7,97.4 331.7,87.5 C339.5,77.6 351.5,67.9 367.2,58.9 C382.6,49.9 401.2,41.7 422.6,34.7 C446.276709,27.1007865 470.38634,20.9231111 494.8,16.2 C521.9,10.9 550.5,6.9 580,4.1 C609.5,1.3 640,0 671.7,0 M1024,376.8 L1024,586.7 C1024,597.5 1020.2,607.6 1012.5,617.7 C1004.8,627.6 992.8,637.2 977.4,646.3 C959.337595,655.751236 940.502821,663.646452 921.1,669.9 C897.436848,677.677909 873.326481,684.022743 848.9,688.9 C822.14275,694.015209 795.140551,697.753462 768,700.1 L767.7,476.1 C794.940661,473.760163 822.043072,470.0219 848.9,464.9 C875.6,459.4 902.3,452.4 921.1,445.9 C939.9,439.4 961.5,430.7 977.3,422.3 C992.7,413.2 1004.7,403.6 1012.4,393.7 C1016.447,388.568447 1019.59184,382.786011 1021.7,376.6 C1022,375.5 1023.9,375.8 1024,376.8 M232.2,520.597935 C230.685589,520.579154 229.184592,520.886176 227.8,521.5 C226.72,522 225.7,522.57 224.7,523.15 L224.1,523.5 L223.4,523.9 L171.4,576.3 C170.030083,577.250162 168.955681,578.567171 168.3,580.1 C167.646697,581.718369 167.340097,583.455771 167.4,585.2 C167.379154,586.714411 167.686176,588.215408 168.3,589.6 C168.957066,590.956585 169.794664,592.218027 170.79,593.35 L171.1,593.7 L171.4,594 L282.4,704.4 L169.1,817.5 C167.730083,818.450162 166.655681,819.767171 166,821.3 C165.346697,822.918369 165.040097,824.655771 165.1,826.4 C165.079154,827.914411 165.386176,829.415408 166,830.8 C166.657066,832.156585 167.494664,833.418027 168.49,834.55 L168.8,834.9 L169.1,835.2 L221.1,887.4 C222.35498,888.705142 223.848625,889.757483 225.5,890.5 C227.118369,891.153303 228.855771,891.459903 230.6,891.4 C232.114411,891.420846 233.615408,891.113824 235,890.5 C236.347415,889.990824 237.52525,889.114377 238.4,887.97 L238.6,887.7 L238.8,887.4 L352.1,774.8 L465.3,887 C466.250162,888.369917 467.567171,889.444319 469.1,890.1 C470.478689,890.732085 471.983848,891.039958 473.5,891 C475.244839,891.068745 476.984084,890.76182 478.6,890.1 C479.956585,889.442934 481.218027,888.605336 482.35,887.61 L482.7,887.3 L483,887 L535,835.3 C536.305142,834.04502 537.357483,832.551375 538.1,830.9 C538.756858,829.636812 539.06739,828.222169 539,826.8 C539.068745,825.055161 538.76182,823.315916 538.1,821.7 C537.590824,820.352585 536.714377,819.17475 535.57,818.3 L535.3,818.1 L535,817.9 L421.8,704.8 L532.8,594.7 C534.105142,593.44502 535.157483,591.951375 535.9,590.3 C536.532085,588.921311 536.839958,587.416152 536.8,585.9 C536.868745,584.155161 536.56182,582.415916 535.9,580.8 C535.390824,579.452585 534.514377,578.27475 533.37,577.4 L533.1,577.2 L532.8,577 L481.4,524.4 C480.00074,523.482177 478.529234,522.679537 477,522 C475.381631,521.346697 473.644229,521.040097 471.9,521.1 C470.405861,521.103166 468.921356,521.339337 467.5,521.8 C466.140714,522.100301 464.928143,522.863903 464.07,523.96 L463.9,524.2 L463.7,524.4 L352.6,635.3 L241.1,523.9 C240.092509,522.704814 238.778981,521.806084 237.3,521.3 C235.645389,520.809136 233.925677,520.573098 232.2,520.597935 M351.9,320 C383.9,320 414.9,321.1 444.17,324 C473.44,326.9 501.56,330.6 528.45,336.1 C552.814192,341.012298 576.906673,347.18729 600.63,354.6 C622.12,361.9 640.82,369.7 656.71,378.8 C672.11,387.9 684.11,397.5 691.8,407.4 C699.26,416.92 703.74,426.64 703.99,436.4 L703.99,581.1 C702.99,589.9 698.79,598.2 692.39,606.6 C684.7,616.5 672.7,626.1 657.3,635.2 C639.238153,644.652423 620.403276,652.547682 601,658.8 C594.19,661.13 586.94,663.38 579.34,665.54 L577.71,666 L575.91,666.4 L575.91,764.4 C584.6,762 593,759.4 601,756.7 C620.389618,750.428205 639.21623,742.533606 657.28,733.1 C672.68,724 684.68,714.4 692.37,704.5 C696.417004,699.368447 699.561838,693.586011 701.67,687.4 C701.96,686.4 703.73,686.59 703.95,687.49 L703.95,687.6 L703.95,906.7 C703.95,917.5 700.15,927.6 692.45,937.7 C684.76,947.6 672.76,957.2 657.36,966.3 C639.304584,975.751378 620.476439,983.64662 601.08,989.9 C577.42368,997.678088 553.319957,1004.02293 528.9,1008.9 C500.904237,1014.27511 472.635307,1018.11419 444.22,1020.4 C415.13,1022.9 384.44,1024 352.22,1024 C320.53,1024 290.14,1022.8 260.65,1020.4 C232.214864,1018.40725 203.932689,1014.63318 175.97,1009.1 C148.88,1003.8 124.29,997.6 102.89,990.1 C81.63,983 63.1966667,975.133333 47.59,966.5 C32.09,957.4 20.39,947.8 12.2,937.9 C4.44,928.38 0.35,918.47 0.11,908.08 L0.11,687.8 C0.21,686.8 1.91,686.6 2.31,687.6 C12.31,712.25 43.76,739.84 123.64,762.71 L126.07,763.4 L127.87,763.9 L127.87,666.9 C119.18,664.5 110.78,661.9 102.87,659.1 C81.5833333,652 63.1233333,644.133333 47.49,635.5 C31.99,626.4 20.29,616.8 12.1,606.9 C4.34,597.38 0.25,587.47 0,577.08 L0,437.6 C0,427.5 4.1,417.4 12.1,407.5 C19.89,397.6 31.89,387.9 47.59,378.9 C62.98,369.9 81.59,361.7 102.97,354.7 C126.640248,347.101877 150.743158,340.924212 175.15,336.2 C202.24,330.9 230.83,326.9 260.33,324.1 C289.83,321.3 320.21,320 351.9,320";
    public static readonly IconDefinition IconDefinition = new(name: "DegradedIcon", height: 1024, width: 1024, svgPath: _svgPath, transform: null, offsetY: "", offsetX: "");

    protected override IconDefinition Definition { get => IconDefinition; }
}
