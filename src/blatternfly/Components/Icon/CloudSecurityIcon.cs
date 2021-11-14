namespace Blatternfly.Components;

public sealed class CloudSecurityIcon : BaseIcon
{
    private static readonly string _svgPath = "M409.7,128.000273 C465.8,128.000273 516.7,143.900547 562.4,176.000547 C608.1,208.100547 641.6,249.700547 662.5,301.600547 C687.4,279.100547 716.9,267.700547 751,267.700547 C788.7,267.700547 821,281.400547 847.2,308.700547 C874.1,335.900547 887.3,368.800547 887.3,407.500547 C887.46515,434.180158 879.892917,460.335623 865.5,482.800547 C911.4,493.767214 949.3,518.200547 979.2,556.100547 C1009.06667,594.033881 1024,637.500547 1024,686.500547 C1024,744.400547 1004.2,793.700547 964.1,834.700547 C924.302,874.993547 876.6632,895.586537 820.89251,895.994368 L819.2,896.000547 L238.9,896.000547 C173.133333,895.933881 116.9,872.000547 70.2,824.200547 C23.4,776.333881 0,718.800547 0,651.600547 C0,603.667214 12.6333333,559.800547 37.9,520.000547 C63.2333333,480.067214 96.5,450.300547 137.7,430.700547 C137,420.500547 136.6,412.600547 136.6,407.200547 C136.6,330.200547 163.2,264.200547 216.6,209.700547 C270.033333,155.133881 334.4,127.900547 409.7,128.000273 Z M512,320.000547 C476.9,320.000547 446.8,332.600547 421.6,357.900547 C396.4,383.200547 383.8,413.100547 383.8,448.400547 L383.8,511.400547 L352.1,511.400547 C343.2,511.400547 335.6,513.500547 329.4,519.700547 C323.305993,525.712407 319.913649,533.940645 320,542.500547 L320,735.000547 C319.859734,743.570758 323.260479,751.819372 329.4,757.800547 C335.7,764.000547 343.2,768.000547 352.1,768.000547 L671.8,768.000547 C680.7,768.000547 688.3,764.000547 694.5,757.800547 C700.594007,751.788687 703.986351,743.56045 703.9,735.000547 L704.1,542.600547 C704.289931,534.020996 700.881339,525.753347 694.7,519.800547 C688.4,513.600547 680.9,511.400547 672,511.400547 L640.1,511.400547 L640.1,448.400547 C640.1,413.200547 627.7,383.200547 602.5,357.900547 C577.3,332.600547 547.1,320.000547 512,320.000547 Z M512,385.700547 C529.7,385.700547 544.9,391.900547 557.2,404.400547 C569.461938,416.250691 576.267978,432.65035 576,449.700547 L576,512.000547 L448,512.000547 L448,449.700547 C448,414.354323 476.653776,385.700547 512,385.700547 Z";
    public static readonly IconDefinition IconDefinition = new(name: "CloudSecurityIcon", height: 1024, width: 1024, svgPath: _svgPath, transform: null, offsetY: "", offsetX: "");

    protected override IconDefinition Definition { get => IconDefinition; }
}
