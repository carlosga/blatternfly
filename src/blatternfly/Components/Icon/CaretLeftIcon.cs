namespace Blatternfly.Components;

/// <summary>CaretLeftIcon icon.</summary>
public sealed class CaretLeftIcon : BaseIcon
{
    private static readonly string _svgPath = "M192 127.338v257.324c0 17.818-21.543 26.741-34.142 14.142L29.196 270.142c-7.81-7.81-7.81-20.474 0-28.284l128.662-128.662c12.599-12.6 34.142-3.676 34.142 14.142z";
    internal static readonly IconDefinition IconDefinition = new(name: "CaretLeftIcon", height: 512, width: 192, svgPath: _svgPath, transform: null, offsetY: "", offsetX: "");

    protected override IconDefinition Definition { get => IconDefinition; }
}
