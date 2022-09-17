namespace Blatternfly.Components;

/// <summary>HeadSideMaskIcon icon.</summary>
public sealed class HeadSideMaskIcon : BaseIcon
{
    private static readonly string _svgPath = "M.15,184.42C-2.17,244.21,23,298.06,64,334.88V512H224V316.51L3.67,156.25A182.28,182.28,0,0,0,.15,184.42ZM509.22,275c-21-47.12-48.5-151.75-73.12-186.75A208.11,208.11,0,0,0,266.11,0H200C117,0,42.48,50.57,13.25,123.65L239.21,288H511.76A31.35,31.35,0,0,0,509.22,275ZM320,224a32,32,0,1,1,32-32A32.07,32.07,0,0,1,320,224Zm16,144H496l16-48H256V512H401.88a64,64,0,0,0,60.71-43.76L464,464H336a16,16,0,0,1,0-32H474.67l10.67-32H336a16,16,0,0,1,0-32Z";
    internal static readonly IconDefinition IconDefinition = new(name: "HeadSideMaskIcon", height: 512, width: 512, svgPath: _svgPath, transform: null, offsetY: "", offsetX: "");

    protected override IconDefinition Definition { get => IconDefinition; }
}
