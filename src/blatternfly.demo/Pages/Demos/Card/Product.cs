using System.Collections.Generic;

namespace Blatternfly.Demo.Pages.Demos.Card;

public sealed class Product
{
    private static readonly Dictionary<string, string> s_icons = new()
    {
        { "pfIcon"         , "assets/images/pf-logo-small.svg" },
        { "activeMQIcon"   , "assets/images/activemq-core_200x150.png" },
        { "avroIcon"       , "assets/images/camel-avro_200x150.png" },
        { "dropBoxIcon"    , "assets/images/camel-dropbox_200x150.png" },
        { "infinispanIcon" , "assets/images/camel-infinispan_200x150.png" },
        { "saxonIcon"      , "assets/images/camel-saxon_200x150.png" },
        { "sparkIcon"      , "assets/images/camel-spark_200x150.png" },
        { "swaggerIcon"    , "assets/images/camel-swagger-java_200x150.png" },
        { "azureIcon"      , "assets/images/FuseConnector_Icons_AzureServices.png" },
        { "restIcon"       , "assets/images/FuseConnector_Icons_REST.png" }
    };

    public int Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public string Icon { get; set; }

    public bool IsChecked { get; set; }
    public string StrId { get => $"check-{Id}"; }
    public string IconAlt { get => $"{Name} icon"; }
    public string IconSrc { get => s_icons[Icon];}
}
