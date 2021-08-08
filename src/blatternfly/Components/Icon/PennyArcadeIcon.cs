namespace Blatternfly.Components
{
    public sealed class PennyArcadeIcon : BaseIcon
    {
        public static readonly string SvgPath = "M421.91 164.27c-4.49 19.45-1.4 6.06-15.1 65.29l39.73-10.61c-22.34-49.61-17.29-38.41-24.63-54.68zm-206.09 51.11c-20.19 5.4-11.31 3.03-39.63 10.58l4.46 46.19c28.17-7.59 20.62-5.57 34.82-9.34 42.3-9.79 32.85-56.42.35-47.43zm326.16-26.19l-45.47-99.2c-5.69-12.37-19.46-18.84-32.62-15.33-70.27 18.75-38.72 10.32-135.59 36.23a27.618 27.618 0 0 0-18.89 17.41C144.26 113.27 0 153.75 0 226.67c0 33.5 30.67 67.11 80.9 95.37l1.74 17.88a27.891 27.891 0 0 0-17.77 28.67l4.3 44.48c1.39 14.31 13.43 25.21 27.8 25.2 5.18-.01-3.01 1.78 122.53-31.76 12.57-3.37 21.12-15.02 20.58-28.02 216.59 45.5 401.99-5.98 399.89-84.83.01-28.15-22.19-66.56-97.99-104.47zM255.14 298.3l-21.91 5.88-48.44 12.91 2.46 23.55 20.53-5.51 4.51 44.51-115.31 30.78-4.3-44.52 20.02-5.35-11.11-114.64-20.12 5.39-4.35-44.5c178.15-47.54 170.18-46.42 186.22-46.65 56.66-1.13 64.15 71.84 42.55 104.43a86.7 86.7 0 0 1-50.75 33.72zm199.18 16.62l-3.89-39.49 14.9-3.98-6.61-14.68-57.76 15.42-4.1 17.54 19.2-5.12 4.05 39.54-112.85 30.07-4.46-44.43 20.99-5.59 33.08-126.47-17.15 4.56-4.2-44.48c93.36-24.99 65.01-17.41 135.59-36.24l66.67 145.47 20.79-5.56 4.3 44.48-108.55 28.96z";
        public static readonly IconDefinition IconDefinition = new(name: "PennyArcadeIcon", height: 512, width: 640, svgPath: SvgPath, transform: null, yOffset: "", xOffset: "");

        protected override IconDefinition Definition { get => IconDefinition; }
    }
}
