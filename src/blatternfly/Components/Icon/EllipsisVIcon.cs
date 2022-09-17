namespace Blatternfly.Components;

/// <summary>EllipsisVIcon icon.</summary>
public sealed class EllipsisVIcon : BaseIcon
{
    private static readonly string _svgPath = "M96 184c39.8 0 72 32.2 72 72s-32.2 72-72 72-72-32.2-72-72 32.2-72 72-72zM24 80c0 39.8 32.2 72 72 72s72-32.2 72-72S135.8 8 96 8 24 40.2 24 80zm0 352c0 39.8 32.2 72 72 72s72-32.2 72-72-32.2-72-72-72-72 32.2-72 72z";
    internal static readonly IconDefinition IconDefinition = new(name: "EllipsisVIcon", height: 512, width: 192, svgPath: _svgPath, transform: null, offsetY: "", offsetX: "");

    protected override IconDefinition Definition { get => IconDefinition; }
}
