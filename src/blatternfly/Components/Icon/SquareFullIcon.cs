namespace Blatternfly.Components;

public sealed class SquareFullIcon : BaseIcon
{
    private static readonly string _svgPath = "M512 512H0V0h512v512z";
    public static readonly IconDefinition IconDefinition = new(name: "SquareFullIcon", height: 512, width: 512, svgPath: _svgPath, transform: null, offsetY: "", offsetX: "");

    protected override IconDefinition Definition { get => IconDefinition; }
}
