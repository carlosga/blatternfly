namespace Blatternfly.Components;

/// <summary>MessagesIcon icon.</summary>
public sealed class MessagesIcon : BaseIcon
{
    private static readonly string _svgPath = "M673.94,372.5 L684.14,351.9 C684.14,351.9 719.85,271.8 638.54,247.2 C563,224.5 285.16,140.7 246.15,128.9 L253.35,72.9 C258,37.6 234.15,0 198.74,0 C163.33,0 129.83,28.7 125.33,64 L1,1024 L130.13,1024 L180.24,637.5 L393.48,575.9 L389.78,589.8 C389.78,589.8 386.18,675 493.78,642.8 C550.62,625.8 952,456.1 952,456.1 L673.94,372.5 Z";
    internal static readonly IconDefinition IconDefinition = new(name: "MessagesIcon", height: 1024, width: 952, svgPath: _svgPath, transform: null, offsetY: "", offsetX: "");

    protected override IconDefinition Definition { get => IconDefinition; }
}
