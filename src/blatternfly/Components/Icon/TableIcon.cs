namespace Blatternfly.Components;

/// <summary>TableIcon icon.</summary>
public sealed class TableIcon : BaseIcon
{
    private static readonly string _svgPath = "M464 32H48C21.49 32 0 53.49 0 80v352c0 26.51 21.49 48 48 48h416c26.51 0 48-21.49 48-48V80c0-26.51-21.49-48-48-48zM224 416H64v-96h160v96zm0-160H64v-96h160v96zm224 160H288v-96h160v96zm0-160H288v-96h160v96z";
    internal static readonly IconDefinition IconDefinition = new(name: "TableIcon", height: 512, width: 512, svgPath: _svgPath, transform: null, offsetY: "", offsetX: "");

    protected override IconDefinition Definition { get => IconDefinition; }
}
