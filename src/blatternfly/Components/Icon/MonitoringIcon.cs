namespace Blatternfly.Components;

/// <summary>MonitoringIcon icon.</summary>
public sealed class MonitoringIcon : BaseIcon
{
    private static readonly string _svgPath = "M1088,64 L1088,831.91 L640,831.91 L640,896 L832,896.56 L832,960 L256,960 L256,896.56 L448,896 L448,831.91 L0,831.91 L0,64 L1088,64 Z M960,192 L128,192 L128,704 L960,704 L960,192 Z M848.33,301.46 C869.02,322.16 867.08,350.6 848.33,369.34 L658,559.7 C639.255091,578.443665 608.864909,578.443665 590.12,559.7 L465.65,435.24 L305.94,595 C287.151529,613.484918 256.972593,613.362033 238.33528,594.72472 C219.697967,576.087407 219.575082,545.908471 238.06,527.12 L431.71,333.42 L432.41,332.71 C441.412061,323.705883 453.62271,318.647251 466.355,318.647251 C479.08729,318.647251 491.297939,323.705883 500.3,332.71 L624,457.87 L780.45,301.46 C799.2,282.71 827.64,280.76 848.33,301.46 Z";
    internal static readonly IconDefinition IconDefinition = new(name: "MonitoringIcon", height: 1024, width: 1088, svgPath: _svgPath, transform: null, offsetY: "", offsetX: "");

    protected override IconDefinition Definition { get => IconDefinition; }
}
