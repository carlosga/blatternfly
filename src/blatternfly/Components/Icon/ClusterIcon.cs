namespace Blatternfly.Components
{
    public sealed class ClusterIcon : BaseIcon
    {
        private static readonly string _svgPath = "M1013.1,330.877049 C1005.8,323.577049 997.2,319.977049 987.4,319.977049 L36.6,319.977049 C26.6,319.977049 18.2,323.577049 10.9,330.877049 C3.6,338.177049 0,346.777049 0,356.577049 L0,475.277049 C0,485.277049 3.6,493.677049 10.7,501.077049 C18,508.377049 26.4,511.977049 36.4,511.977049 L987.4,511.977049 C997.4,511.977049 1005.8,508.377049 1013.1,501.077049 C1020.4,493.777049 1024,485.377049 1024,475.377049 L1024,356.577049 C1024,346.577049 1020.4,338.177049 1013.1,330.877049 Z M128,447.977049 L64,447.977049 L64,383.977049 L128,383.977049 L128,447.977049 Z M256,447.977049 L192,447.977049 L192,383.977049 L256,383.977049 L256,447.977049 Z M384,447.977049 L320,447.977049 L320,383.977049 L384,383.977049 L384,447.977049 Z M512,447.977049 L448,447.977049 L448,383.977049 L512,383.977049 L512,447.977049 Z M960,447.977049 L896,447.977049 L896,383.977049 L960,383.977049 L960,447.977049 Z M0,245.177049 C0,235.977049 1.2,234.677049 9.6,226.477049 C9.6,226.477049 151.09,86.2970491 161.6,74.0070491 C172.11,61.7170491 185.5,64.2070491 185.5,64.2070491 L840.62,64.2070491 C840.62,64.2070491 852.42,62.8070491 863.11,74.4070491 C873.61,85.9970491 1013.5,226.407049 1013.5,226.407049 C1021.9,234.807049 1024,236.107049 1024,245.207049 C1024,254.807049 1012.3,256.007049 1000.7,256.007049 L22.1,256.007049 C10.8,256.077049 0,254.377049 0,245.177049 Z M1013.1,842.877049 C1005.8,835.577049 997.2,831.977049 987.4,831.977049 L36.6,831.977049 C26.6,831.977049 18.2,835.577049 10.9,842.877049 C3.6,850.177049 0,858.777049 0,868.577049 L0,987.277049 C0,997.277049 3.6,1005.67705 10.7,1013.07705 C18,1020.37705 26.4,1023.97705 36.4,1023.97705 L987.4,1023.97705 C997.4,1023.97705 1005.8,1020.37705 1013.1,1013.07705 C1020.4,1005.77705 1024,997.377049 1024,987.377049 L1024,868.577049 C1024,858.577049 1020.4,850.177049 1013.1,842.877049 Z M128,959.977049 L64,959.977049 L64,895.977049 L128,895.977049 L128,959.977049 Z M256,959.977049 L192,959.977049 L192,895.977049 L256,895.977049 L256,959.977049 Z M384,959.977049 L320,959.977049 L320,895.977049 L384,895.977049 L384,959.977049 Z M512,959.977049 L448,959.977049 L448,895.977049 L512,895.977049 L512,959.977049 Z M960,959.977049 L896,959.977049 L896,895.977049 L960,895.977049 L960,959.977049 Z M1013.1,586.877049 C1005.8,579.577049 997.2,575.977049 987.4,575.977049 L36.6,575.977049 C26.6,575.977049 18.2,579.577049 10.9,586.877049 C3.6,594.177049 0,602.777049 0,612.577049 L0,731.277049 C0,741.277049 3.6,749.677049 10.7,757.077049 C18,764.377049 26.4,767.977049 36.4,767.977049 L987.4,767.977049 C997.4,767.977049 1005.8,764.377049 1013.1,757.077049 C1020.4,749.777049 1024,741.377049 1024,731.377049 L1024,612.577049 C1024,602.577049 1020.4,594.177049 1013.1,586.877049 Z M128,703.977049 L64,703.977049 L64,639.977049 L128,639.977049 L128,703.977049 Z M256,703.977049 L192,703.977049 L192,639.977049 L256,639.977049 L256,703.977049 Z M384,703.977049 L320,703.977049 L320,639.977049 L384,639.977049 L384,703.977049 Z M512,703.977049 L448,703.977049 L448,639.977049 L512,639.977049 L512,703.977049 Z M960,703.977049 L896,703.977049 L896,639.977049 L960,639.977049 L960,703.977049 Z";
        private static readonly IconDefinition _definition = new IconDefinition(name: "ClusterIcon", height: 1024, width: 1024, svgPath: _svgPath, transform: "", yOffset: "", xOffset: "");

        public ClusterIcon() : base(_definition) { }
    }
}