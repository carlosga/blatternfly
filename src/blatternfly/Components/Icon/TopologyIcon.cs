namespace Blatternfly.Components;

public sealed class TopologyIcon : BaseIcon
{
    private static readonly string _svgPath = "M877.8,0 C797.1,0 731.5,65.6 731.5,146.3 C731.5,175.1 739.7,201.8 754.1,224.5 L670,310.5 C626.5,276.4 571.7,256 512,256 C477.8,256 445.1,262.7 415.3,274.9 L388.6,239.6 C375.1,221.3 350.9,216.1 334.9,228.2 C318.7,240.1 316.4,264.8 329.6,283.1 L351.9,312.3 C293.4,359.2 256,431.2 256,512 C256,534.7 259,556.7 264.5,577.7 L239,590.9 C219.8,600.3 210.7,622.9 218.4,641.2 C226.1,659.5 248.3,666.8 267.3,657.7 L292.9,644.4 C329.1,704.2 389.1,748 459.8,762.6 L453.8,835.6 C413.5,847.1 384,884.1 384,928 C384,981 427,1024 480,1024 C533,1024 576,981 576,928 C576,888.3 551.9,854.3 517.6,839.7 L523.5,767.8 C605.3,764.2 677.2,722.1 721.4,659.2 L789.8,705.8 C808.1,718.4 832.1,714.9 842.8,698 C853.5,680.9 847.3,656.9 828.8,644.6 L754.6,594.1 C763.3,568.3 768,540.7 768,512 C768,456.6 750.4,405.3 720.5,363.5 L807.4,274.8 C828.2,286.2 852.2,292.9 877.8,292.9 C958.5,292.9 1024.1,227.3 1024.1,146.6 C1024.1,65.9 958.5,0 877.8,0 Z M528,928 C528,954.5 506.5,976 480,976 C453.5,976 432,954.5 432,928 C432,901.5 453.5,880 480,880 C506.5,880 528,901.5 528,928 Z M512,640 C441.3,640 384,582.7 384,512 C384,441.3 441.3,384 512,384 C582.7,384 640,441.3 640,512 C640,582.7 582.8,640 512,640 Z M877.8,224 C834.8,224 800.1,189.3 800.1,146.3 C800.1,103.3 834.8,68.6 877.8,68.6 C920.8,68.6 955.5,103.3 955.5,146.3 C955.5,189.3 920.8,224 877.8,224 Z M900.8,712.3 C943.6,669.5 1013.1,669.5 1055.9,712.3 C1077.3,733.7 1088,761.8 1088,789.9 C1088,818 1077.3,846 1055.9,867.5 C1013.1,910.3 943.6,910.3 900.8,867.5 C858,824.6 858,755.2 900.8,712.3 M256,2.3 C316.6,2.3 365.7,51.4 365.7,112 C365.7,172.6 316.6,221.7 256,221.7 C195.4,221.7 146.3,172.6 146.3,112 C146.3,51.4 195.4,2.3 256,2.3 M96,608 C149,608 192,651 192,704 C192,757 149,800 96,800 C43,800 0,757 0,704 C0,651 43,608 96,608";
    public static readonly IconDefinition IconDefinition = new(name: "TopologyIcon", height: 1024, width: 1088, svgPath: _svgPath, transform: null, offsetY: "", offsetX: "");

    protected override IconDefinition Definition { get => IconDefinition; }
}
