namespace Blatternfly.Components;

/// <summary>SkiingIcon icon.</summary>
public sealed class SkiingIcon : BaseIcon
{
    private static readonly string _svgPath = "M432 96c26.5 0 48-21.5 48-48S458.5 0 432 0s-48 21.5-48 48 21.5 48 48 48zm73 356.1c-9.4-9.4-24.6-9.4-33.9 0-12.1 12.1-30.5 15.4-45.1 8.7l-135.8-70.2 49.2-73.8c12.7-19 10.2-44.5-6-60.6L293 215.7l-107-53.1c-2.9 19.9 3.4 40 17.7 54.4l75.1 75.2-45.9 68.8L35 258.7c-11.7-6-26.2-1.5-32.3 10.3-6.1 11.8-1.5 26.3 10.3 32.3l391.9 202.5c11.9 5.5 24.5 8.1 37.1 8.1 23.2 0 46-9 63-26 9.3-9.3 9.3-24.5 0-33.8zM120 91.6l-11.5 22.5c14.4 7.3 31.2 4.9 42.8-4.8l47.2 23.4c-.1.1-.1.2-.2.3l114.5 56.8 32.4-13 6.4 19.1c4 12.1 12.6 22 24 27.7l58.1 29c15.9 7.9 35 1.5 42.9-14.3 7.9-15.8 1.5-35-14.3-42.9l-52.1-26.1-17.1-51.2c-8.1-24.2-40.9-56.6-84.5-39.2l-81.2 32.5-62.5-31c.3-14.5-7.2-28.6-20.9-35.6l-11.1 21.7h-.2l-34.4-7c-1.8-.4-3.7.2-5 1.7-1.9 2.2-1.7 5.5.5 7.4l26.2 23z";
    internal static readonly IconDefinition IconDefinition = new(name: "SkiingIcon", height: 512, width: 512, svgPath: _svgPath, transform: null, offsetY: "", offsetX: "");

    protected override IconDefinition Definition { get => IconDefinition; }
}
