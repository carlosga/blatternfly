namespace Blatternfly.Components;

public sealed class TenantIcon : BaseIcon
{
    private static readonly string _svgPath = "M512.1,0 C229.7,0 0,229.8 0,512 C0,794.3 229.8,1024 512.1,1024 C794.4,1024 1024,794.3 1024,512 C1024,229.7 794.4,0 512.1,0 Z M512,960 C264.9,960 64,759.2 64,512 C64,265 264.9,64 512,64 C759,64 960,264.9 960,512 C960,759.1 759,960 512,960 Z M672,544 C601.3,544 544,601.3 544,672 C544,742.7 601.3,800 672,800 C742.7,800 800,742.7 800,672 C800,601.3 742.7,544 672,544 Z M672,752 C627.9,752 592,716.1 592,672 C592,627.9 627.9,592 672,592 C716.1,592 752,627.9 752,672 C752,716.1 716.1,752 672,752 Z M352,544 C281.3,544 224,601.3 224,672 C224,742.7 281.3,800 352,800 C422.7,800 480,742.7 480,672 C480,601.3 422.7,544 352,544 Z M352,752 C307.9,752 272,716.1 272,672 C272,627.9 307.9,592 352,592 C396.1,592 432,627.9 432,672 C432,716.1 396.1,752 352,752 Z M672,224 C601.3,224 544,281.3 544,352 C544,422.7 601.3,480 672,480 C742.7,480 800,422.7 800,352 C800,281.3 742.7,224 672,224 Z M672,432 C627.9,432 592,396.1 592,352 C592,307.9 627.9,272 672,272 C716.1,272 752,307.9 752,352 C752,396.1 716.1,432 672,432 Z M480,352 C480,422.7 422.7,480 352,480 C281.3,480 224,422.7 224,352 C224,281.3 281.3,224 352,224 C422.7,224 480,281.3 480,352";
    public static readonly IconDefinition IconDefinition = new(name: "TenantIcon", height: 1024, width: 1024, svgPath: _svgPath, transform: null, offsetY: "", offsetX: "");

    protected override IconDefinition Definition { get => IconDefinition; }
}
