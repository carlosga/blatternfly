namespace Blatternfly.Components
{
    public sealed class VolumeIcon : BaseIcon
    {
        private static readonly string _svgPath = "M416,608 C135.8,608 44.3,549.9 14.5,512 C0,493.6 0,512 0,512 L0,704 C0,774.7 186.2,832 416,832 C645.8,832 832,774.7 832,704 L832,512 C832,512 832,493.6 817.5,512 C787.7,549.9 696.2,608 416,608 L416,608 Z M832,383 C832,453.7 645.8,511 416,511 C186.2,511 0,453.7 0,383 L0,256 C0,185.3 186.2,128 416,128 C645.8,128 832,185.3 832,256 L832,383 Z";
        public static readonly IconDefinition IconDefinition = new(name: "VolumeIcon", height: 1024, width: 832, svgPath: _svgPath, transform: null, offsetY: "", offsetX: "");

        protected override IconDefinition Definition { get => IconDefinition; }
    }
}