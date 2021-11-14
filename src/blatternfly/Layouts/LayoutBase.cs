using System.Collections.Generic;

namespace Blatternfly.Layouts;

public abstract class LayoutBase : ComponentBase
{
    [Parameter(CaptureUnmatchedValues = true)]
    public IReadOnlyDictionary<string, object> AdditionalAttributes { get; set; }

    [Parameter] public virtual RenderFragment ChildContent { get; set; }

    protected string InternalCssClass  { get => GetPropertyValue("class"); }

    protected string InternalCssStyle  { get => GetPropertyValue("style"); }

    protected string GetPropertyValue(string propertyName)
    {
        if (AdditionalAttributes is { Count: > 0 })
        {
            if (AdditionalAttributes.ContainsKey(propertyName))
            {
                return (string)AdditionalAttributes[propertyName];
            }
        }
        return null;
    }
}
