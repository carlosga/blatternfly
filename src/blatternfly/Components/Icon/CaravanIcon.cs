namespace Blatternfly.Components;

public sealed class CaravanIcon : BaseIcon
{
    private static readonly string _svgPath = "M416,208a16,16,0,1,0,16,16A16,16,0,0,0,416,208ZM624,320H576V160A160,160,0,0,0,416,0H64A64,64,0,0,0,0,64V320a64,64,0,0,0,64,64H96a96,96,0,0,0,192,0H624a16,16,0,0,0,16-16V336A16,16,0,0,0,624,320ZM192,432a48,48,0,1,1,48-48A48.05,48.05,0,0,1,192,432Zm64-240a32,32,0,0,1-32,32H96a32,32,0,0,1-32-32V128A32,32,0,0,1,96,96H224a32,32,0,0,1,32,32ZM448,320H320V128a32,32,0,0,1,32-32h64a32,32,0,0,1,32,32Z";
    public static readonly IconDefinition IconDefinition = new(name: "CaravanIcon", height: 512, width: 640, svgPath: _svgPath, transform: null, offsetY: "", offsetX: "");

    protected override IconDefinition Definition { get => IconDefinition; }
}
