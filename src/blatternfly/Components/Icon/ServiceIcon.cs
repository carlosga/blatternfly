namespace Blatternfly.Components;

public sealed class ServiceIcon : BaseIcon
{
    private static readonly string _svgPath = "M1298.8,371.8 L1178.8,250.1 C1168.7,240 1151.5,247.2 1151.5,261.4 L1151.5,319.3 L1012.6,319.4 C940.6,168.4 786.5,64 608,64 C360.6,64 160,264.6 160,512 C160,533.6 161.5,554.9 164.5,575.7 L16,575.7 C7.2,575.7 0,582.9 0,591.7 L0,687.7 C0,696.5 7.2,703.7 16,703.7 L203,703.7 C274.8,855.2 429.2,960 608,960 C855.4,960 1056,759.4 1056,512 C1056,490.1 1054.4,468.6 1051.4,447.5 L1151.6,447.5 L1151.6,505.3 C1151.6,519.6 1168.9,526.7 1178.9,516.6 L1298.8,394.5 C1301.8,391.4 1304,388.2 1304,383.4 C1304,378.6 1302,375 1298.8,371.8 Z M961.8,661.5 C942.5,707.2 914.8,748.3 879.5,783.6 C844.2,818.9 803.1,846.6 757.4,865.9 C710.1,885.9 659.8,896.1 607.9,896.1 C556,896.1 505.7,886 458.4,865.9 C412.7,846.6 371.6,818.9 336.3,783.6 C312.3,759.6 291.7,732.8 275,703.7 L575.8,703.7 L575.8,761.5 C575.8,775.8 593.1,782.9 603.1,772.8 L725,650.7 C731.3,644.5 731.2,634.3 725,628.1 L603.3,506.5 C593.2,496.4 576,503.6 576,517.8 L576,575.7 L229.2,575.7 C225.7,554.8 224,533.6 224,512 C224,460.1 234.1,409.8 254.2,362.5 C273.5,316.8 301.2,275.7 336.5,240.4 C371.8,205.1 412.9,177.4 458.6,158.1 C505.8,138.1 556.1,128 608,128 C659.9,128 710.2,138.1 757.5,158.2 C803.2,177.5 844.3,205.2 879.6,240.5 C903.4,264.3 923.7,290.7 940.4,319.5 L656,319.6 C647.2,319.6 640,326.8 640,335.6 L640,431.5 C640,440.3 647.2,447.5 656,447.5 L986.6,447.5 C990.2,468.7 992,490.2 992,512 C992,563.9 981.9,614.2 961.8,661.5 Z";
    public static readonly IconDefinition IconDefinition = new(name: "ServiceIcon", height: 1024, width: 1304, svgPath: _svgPath, transform: null, offsetY: "", offsetX: "");

    protected override IconDefinition Definition { get => IconDefinition; }
}
