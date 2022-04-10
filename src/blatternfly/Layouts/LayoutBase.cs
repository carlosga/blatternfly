using System.Collections.Generic;

namespace Blatternfly.Layouts;

public abstract class LayoutBase : ComponentBase
{
    [Parameter(CaptureUnmatchedValues = true)]
    public IReadOnlyDictionary<string, object> AdditionalAttributes { get; set; }

    [Parameter] public virtual RenderFragment ChildContent { get; set; }
}
