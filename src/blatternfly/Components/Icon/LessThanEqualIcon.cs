namespace Blatternfly.Components
{
    public sealed class LessThanEqualIcon : BaseIcon
    {
        private static readonly string _svgPath = "M54.98 214.2l301.41 119.87c18.39 6.03 38.71-2.54 45.38-19.15l12.09-30.08c6.68-16.61-2.82-34.97-21.21-41l-175.44-68.05 175.56-68.09c18.29-6 27.74-24.27 21.1-40.79l-12.03-29.92c-6.64-16.53-26.86-25.06-45.15-19.06L54.98 137.89C41.21 142.41 32 154.5 32 168.07v15.96c0 13.56 9.21 25.65 22.98 30.17zM424 400H24c-13.25 0-24 10.74-24 24v48c0 13.25 10.75 24 24 24h400c13.25 0 24-10.75 24-24v-48c0-13.26-10.75-24-24-24z";
        public static readonly IconDefinition IconDefinition = new(name: "LessThanEqualIcon", height: 512, width: 448, svgPath: _svgPath, transform: null, offsetY: "", offsetX: "");

        protected override IconDefinition Definition { get => IconDefinition; }
    }
}