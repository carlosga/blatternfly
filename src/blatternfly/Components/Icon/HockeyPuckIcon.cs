namespace Blatternfly.Components;

/// <summary>HockeyPuckIcon icon.</summary>
public sealed class HockeyPuckIcon : BaseIcon
{
    private static readonly string _svgPath = "M0 160c0-53 114.6-96 256-96s256 43 256 96-114.6 96-256 96S0 213 0 160zm0 82.2V352c0 53 114.6 96 256 96s256-43 256-96V242.2c-113.4 82.3-398.5 82.4-512 0z";
    internal static readonly IconDefinition IconDefinition = new(name: "HockeyPuckIcon", height: 512, width: 512, svgPath: _svgPath, transform: null, offsetY: "", offsetX: "");

    protected override IconDefinition Definition { get => IconDefinition; }
}
