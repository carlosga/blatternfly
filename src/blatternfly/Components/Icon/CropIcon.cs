namespace Blatternfly.Components
{
    public sealed class CropIcon : BaseIcon
    {
        private static readonly string _svgPath = "M488 352h-40V109.25l59.31-59.31c6.25-6.25 6.25-16.38 0-22.63L484.69 4.69c-6.25-6.25-16.38-6.25-22.63 0L402.75 64H192v96h114.75L160 306.75V24c0-13.26-10.75-24-24-24H88C74.75 0 64 10.74 64 24v40H24C10.75 64 0 74.74 0 88v48c0 13.25 10.75 24 24 24h40v264c0 13.25 10.75 24 24 24h232v-96H205.25L352 205.25V488c0 13.25 10.75 24 24 24h48c13.25 0 24-10.75 24-24v-40h40c13.25 0 24-10.75 24-24v-48c0-13.26-10.75-24-24-24z";
        public static readonly IconDefinition IconDefinition = new(name: "CropIcon", height: 512, width: 512, svgPath: _svgPath, transform: null, offsetY: "", offsetX: "");

        protected override IconDefinition Definition { get => IconDefinition; }
    }
}