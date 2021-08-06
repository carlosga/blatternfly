namespace Blatternfly.Components
{
    public sealed class PficonSortCommonAscIcon : BaseIcon
    {
        private static readonly string _svgPath = "M256,768 L256,16 C256,7.2 248.9,0 240,0 L143.6,0 C134.8,0 128,7.2 128,16 L128,768 L17.1,767.8 C6.8,767.8 0,774.5 0,785.2 C0,791.1 1.2,792.2 3.7,795.3 L179.9,1019.3 C183,1022.3 187.4,1024 192,1024 C196.6,1024 200.6,1022.2 203.7,1019.3 L380.3,795.5 C389.1,784.3 381.1,768 366.9,768 L256,768 Z M528,768 C517.9,768 512,760.8 512,751.8 L512,656.2 C512,647.3 520.2,640 530.3,640 L1005.7,640 C1015.8,640 1024,647.2 1024,656.2 L1024,751.8 C1024,760.7 1015.8,768 1005.7,768 L528,768 Z M530.3,512 C520.1,512 512,503.8 512,493.7 L512,402.8 C512,392.7 520.2,384.5 530.3,384.5 L879.6,384.5 C889.7,384.5 897.9,392.7 897.9,402.8 L897.9,493.7 C897.9,503.8 889.7,512 879.6,512 L530.3,512 L530.3,512 Z M533,256 C521.3,256 512,247.9 512,238 L512,146 C512,136.1 521.4,128 533,128 L747,128 C758.6,128 768,136.1 768,146 L768,238 C768,247.9 758.6,256 747,256 L533,256 Z";
        private static readonly IconDefinition _definition = new(name: "PficonSortCommonAscIcon", height: 1024, width: 1024, svgPath: _svgPath, transform: "", yOffset: "", xOffset: "");

        protected override IconDefinition Definition { get => _definition; }
    }
}