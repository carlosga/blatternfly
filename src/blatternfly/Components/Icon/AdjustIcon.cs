namespace Blatternfly.Components;

/// <summary>AdjustIcon icon.</summary>
public sealed class AdjustIcon : BaseIcon
{
    private static readonly string _svgPath = "M8 256c0 136.966 111.033 248 248 248s248-111.034 248-248S392.966 8 256 8 8 119.033 8 256zm248 184V72c101.705 0 184 82.311 184 184 0 101.705-82.311 184-184 184z";
    internal static readonly IconDefinition IconDefinition = new(name: "AdjustIcon", height: 512, width: 512, svgPath: _svgPath, transform: null, offsetY: "", offsetX: "");

    protected override IconDefinition Definition { get => IconDefinition; }
}
