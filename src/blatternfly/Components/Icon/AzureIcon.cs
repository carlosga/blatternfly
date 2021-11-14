namespace Blatternfly.Components;

public sealed class AzureIcon : BaseIcon
{
    private static readonly string _svgPath = "m88.33 0-47.66 41.33-40.67 73h36.67zm6.34 9.67-20.34 57.33 39 49-75.66 13h124z";
    public static readonly IconDefinition IconDefinition = new(name: "AzureIcon", height: 150, width: 160, svgPath: _svgPath, transform: null, offsetY: "", offsetX: "");

    protected override IconDefinition Definition { get => IconDefinition; }
}
