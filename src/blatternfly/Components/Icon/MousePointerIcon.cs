namespace Blatternfly.Components;

/// <summary>MousePointerIcon icon.</summary>
public sealed class MousePointerIcon : BaseIcon
{
    private static readonly string _svgPath = "M302.189 329.126H196.105l55.831 135.993c3.889 9.428-.555 19.999-9.444 23.999l-49.165 21.427c-9.165 4-19.443-.571-23.332-9.714l-53.053-129.136-86.664 89.138C18.729 472.71 0 463.554 0 447.977V18.299C0 1.899 19.921-6.096 30.277 5.443l284.412 292.542c11.472 11.179 3.007 31.141-12.5 31.141z";
    internal static readonly IconDefinition IconDefinition = new(name: "MousePointerIcon", height: 512, width: 320, svgPath: _svgPath, transform: null, offsetY: "", offsetX: "");

    protected override IconDefinition Definition { get => IconDefinition; }
}
