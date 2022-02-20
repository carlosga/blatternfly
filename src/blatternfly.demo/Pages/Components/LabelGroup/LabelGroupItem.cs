using Blatternfly.Components;
using Microsoft.AspNetCore.Components;

namespace Blatternfly.Demo.Pages.Components.LabelGroup;

public class LabelGroupItem
{
    public string Text { get; set; }
    public LabelColor? Color { get; set; }
    public RenderFragment Icon { get; set; }
}
