namespace Blatternfly.Components
{
    public sealed class CannabisIcon : BaseIcon
    {
        public static readonly string SvgPath = "M503.47 360.25c-1.56-.82-32.39-16.89-76.78-25.81 64.25-75.12 84.05-161.67 84.93-165.64 1.18-5.33-.44-10.9-4.3-14.77-3.03-3.04-7.12-4.7-11.32-4.7-1.14 0-2.29.12-3.44.38-3.88.85-86.54 19.59-160.58 79.76.01-1.46.01-2.93.01-4.4 0-118.79-59.98-213.72-62.53-217.7A15.973 15.973 0 0 0 256 0c-5.45 0-10.53 2.78-13.47 7.37-2.55 3.98-62.53 98.91-62.53 217.7 0 1.47.01 2.94.01 4.4-74.03-60.16-156.69-78.9-160.58-79.76-1.14-.25-2.29-.38-3.44-.38-4.2 0-8.29 1.66-11.32 4.7A15.986 15.986 0 0 0 .38 168.8c.88 3.97 20.68 90.52 84.93 165.64-44.39 8.92-75.21 24.99-76.78 25.81a16.003 16.003 0 0 0-.02 28.29c2.45 1.29 60.76 31.72 133.49 31.72 6.14 0 11.96-.1 17.5-.31-11.37 22.23-16.52 38.31-16.81 39.22-1.8 5.68-.29 11.89 3.91 16.11a16.019 16.019 0 0 0 16.1 3.99c1.83-.57 37.72-11.99 77.3-39.29V504c0 4.42 3.58 8 8 8h16c4.42 0 8-3.58 8-8v-64.01c39.58 27.3 75.47 38.71 77.3 39.29a16.019 16.019 0 0 0 16.1-3.99c4.2-4.22 5.71-10.43 3.91-16.11-.29-.91-5.45-16.99-16.81-39.22 5.54.21 11.37.31 17.5.31 72.72 0 131.04-30.43 133.49-31.72 5.24-2.78 8.52-8.22 8.51-14.15-.01-5.94-3.29-11.39-8.53-14.15z";
        public static readonly IconDefinition IconDefinition = new(name: "CannabisIcon", height: 512, width: 512, svgPath: SvgPath, transform: null, yOffset: "", xOffset: "");

        protected override IconDefinition Definition { get => IconDefinition; }
    }
}
