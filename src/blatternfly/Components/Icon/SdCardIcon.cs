namespace Blatternfly.Components;

/// <summary>SdCardIcon icon.</summary>
public sealed class SdCardIcon : BaseIcon
{
    private static readonly string _svgPath = "M320 0H128L0 128v320c0 35.3 28.7 64 64 64h256c35.3 0 64-28.7 64-64V64c0-35.3-28.7-64-64-64zM160 160h-48V64h48v96zm80 0h-48V64h48v96zm80 0h-48V64h48v96z";
    internal static readonly IconDefinition IconDefinition = new(name: "SdCardIcon", height: 512, width: 384, svgPath: _svgPath, transform: null, offsetY: "", offsetX: "");

    protected override IconDefinition Definition { get => IconDefinition; }
}
