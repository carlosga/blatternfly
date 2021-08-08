namespace Blatternfly.Components
{
    public sealed class PrivateIcon : BaseIcon
    {
        public static readonly string SvgPath = "M512,0 C229.2,0 0,229.2 0,512 C0,794.8 229.2,1024 512,1024 C794.8,1024 1024,794.8 1024,512 C1024,229.2 794.8,0 512,0 L512,0 Z M832,723.3 C832,751.6 821.4,777.5 801.3,798.2 L800.9,798.6 L800.5,799 C773.2,826.3 744.4,832 725,832 L298.8,832 C279.6,832 251.1,826.3 223.6,799.3 L223.2,798.9 C202.7,778.4 191.9,752.3 191.9,723.2 L191.9,488.7 C191.9,460.3 202.5,434.4 222.5,413.8 L222.9,413.4 L223.3,413 C241.3,395 261.5,388.2 277.1,385.6 L277.1,363.2 C277.1,299.2 300.3,243.4 346.2,197.4 C368.8,174.7 394.4,157.2 422.1,145.6 C450,133.9 480.2,128 512.1,128 C543.9,128 574.2,133.9 602.1,145.6 C629.9,157.2 655.5,174.7 678.1,197.4 C723.7,243.2 746.9,299 746.9,363.2 L746.9,385.7 C767.9,389.3 785.9,398.3 800.6,412.7 C821.2,433 832.1,459.3 832.1,488.7 L832,723.3 Z M755.6,458.4 C747.2,450.1 737.2,448 725.3,448 L682.8,448 L682.8,363.2 C682.8,316.3 666.3,276.3 632.7,242.5 C599.1,208.8 558.8,192 512,192 C465.2,192 425.1,208.8 391.5,242.5 C357.9,276.2 341.1,316.1 341.1,363.2 L341.1,448 L298.8,448 C286.9,448 276.8,450 268.5,458.3 C260.2,466.8 256,476.8 256,488.7 L256,723.4 C256,735.4 260.3,745.5 268.5,753.8 C276.9,762.1 286.9,768.1 298.8,768.1 L725.1,768.1 C737,768.1 747.1,762.1 755.4,753.8 C763.7,745.3 768.1,735.3 768.1,723.4 L768.1,488.8 C768,476.8 764,466.7 755.6,458.4 L755.6,458.4 Z M597.3,448 L426.7,448 L426.7,364.9 C426.7,341.4 435.1,321.2 451.6,304.6 C468.3,287.9 488.4,279.5 512,279.5 C535.6,279.5 555.9,287.8 572.3,304.4 C589,321.1 597.4,341.2 597.4,364.8 L597.4,448 L597.3,448 Z";
        public static readonly IconDefinition IconDefinition = new(name: "PrivateIcon", height: 1024, width: 1024, svgPath: SvgPath, transform: null, yOffset: "", xOffset: "");

        protected override IconDefinition Definition { get => IconDefinition; }
    }
}
