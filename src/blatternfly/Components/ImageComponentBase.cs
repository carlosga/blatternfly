using Microsoft.AspNetCore.Components;

namespace Blatternfly.Components
{
    public abstract class ImageComponentBase : BaseComponent
    {
        /// Attribute that specifies the URL of the image for the Brand.
        [Parameter] public string Source { get; set; } = string.Empty;

        /// Attribute that specifies the alternate text of the image for the Brand.
        [Parameter] public string AlternateText { get; set; }
    }
}
