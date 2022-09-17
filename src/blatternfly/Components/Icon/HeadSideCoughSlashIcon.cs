namespace Blatternfly.Components;

/// <summary>HeadSideCoughSlashIcon icon.</summary>
public sealed class HeadSideCoughSlashIcon : BaseIcon
{
    private static readonly string _svgPath = "M454.11,319.21c19.56-3.81,31.62-25,23.11-44.21-21-47.12-48.5-151.75-73.12-186.75A208.13,208.13,0,0,0,234.1,0H192A190.64,190.64,0,0,0,84.18,33.3L45.46,3.38A16,16,0,0,0,23,6.19L3.37,31.46A16,16,0,0,0,6.18,53.91L594.53,508.63A16,16,0,0,0,617,505.82l19.64-25.27a16,16,0,0,0-2.81-22.45ZM313.39,210.45,263.61,172c5.88-7.14,14.43-12,24.36-12a32.06,32.06,0,0,1,32,32C320,199,317.24,205.17,313.39,210.45ZM616,304a24,24,0,1,0-24-24A24,24,0,0,0,616,304Zm-64,64a24,24,0,1,0-24-24A24,24,0,0,0,552,368ZM288,384a32,32,0,0,1,32-32h19.54L20.73,105.59A190.86,190.86,0,0,0,0,192c0,56.75,24.75,107.62,64,142.88V512H288V480h64a64,64,0,0,0,64-64H320A32,32,0,0,1,288,384Zm328-24a24,24,0,1,0,24,24A24,24,0,0,0,616,360Z";
    internal static readonly IconDefinition IconDefinition = new(name: "HeadSideCoughSlashIcon", height: 512, width: 640, svgPath: _svgPath, transform: null, offsetY: "", offsetX: "");

    protected override IconDefinition Definition { get => IconDefinition; }
}
