using System.Collections.Generic;
using Microsoft.AspNetCore.Components;

namespace Blatternfly.Components;

public abstract class BaseComponent : ComponentBase
{
    [Parameter(CaptureUnmatchedValues = true)]
    public IReadOnlyDictionary<string, object> AdditionalAttributes { get; set; }

    [Parameter] public virtual RenderFragment ChildContent { get; set; }

    protected string InternalId { get => GetPropertyValue("id"); }

    protected string InternalName { get => GetPropertyValue("name"); }

    protected string InternalCssClass { get => GetPropertyValue("class"); }

    protected string InternalCssStyle { get => GetPropertyValue("style"); }

    protected string GetPropertyValue(string propertyName)
    {
        if (AdditionalAttributes is { Count: > 0 })
        {
            if (AdditionalAttributes.TryGetValue(propertyName, out var propertyValue))
            {
                return propertyValue as string;
            }
        }
        return null;
    }
}
