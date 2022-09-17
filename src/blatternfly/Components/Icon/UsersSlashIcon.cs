namespace Blatternfly.Components;

/// <summary>UsersSlashIcon icon.</summary>
public sealed class UsersSlashIcon : BaseIcon
{
    private static readonly string _svgPath = "M132.65,212.32,36.21,137.78A63.4,63.4,0,0,0,32,160a63.84,63.84,0,0,0,100.65,52.32Zm40.44,62.28A63.79,63.79,0,0,0,128,256H64A64.06,64.06,0,0,0,0,320v32a32,32,0,0,0,32,32H97.91A146.62,146.62,0,0,1,173.09,274.6ZM544,224a64,64,0,1,0-64-64A64.06,64.06,0,0,0,544,224ZM500.56,355.11a114.24,114.24,0,0,0-84.47-65.28L361,247.23c41.46-16.3,71-55.92,71-103.23A111.93,111.93,0,0,0,320,32c-57.14,0-103.69,42.83-110.6,98.08L45.46,3.38A16,16,0,0,0,23,6.19L3.37,31.46A16,16,0,0,0,6.18,53.91L594.53,508.63A16,16,0,0,0,617,505.82l19.64-25.27a16,16,0,0,0-2.81-22.45ZM128,403.21V432a48,48,0,0,0,48,48H464a47.45,47.45,0,0,0,12.57-1.87L232,289.13C173.74,294.83,128,343.42,128,403.21ZM576,256H512a63.79,63.79,0,0,0-45.09,18.6A146.29,146.29,0,0,1,542,384h66a32,32,0,0,0,32-32V320A64.06,64.06,0,0,0,576,256Z";
    internal static readonly IconDefinition IconDefinition = new(name: "UsersSlashIcon", height: 512, width: 640, svgPath: _svgPath, transform: null, offsetY: "", offsetX: "");

    protected override IconDefinition Definition { get => IconDefinition; }
}
