using System.Collections.Generic;
using Microsoft.AspNetCore.Components;

namespace Blatternfly.Components
{
    public abstract class BaseComponent : ComponentBase
    {
        [Parameter(CaptureUnmatchedValues = true)]
        public IReadOnlyDictionary<string, object> AdditionalAttributes { get; set; }

        [Parameter] public virtual RenderFragment ChildContent { get; set; }

        /// Visibility at various breakpoints.
        [Parameter] public Visibility Visibility { get; set; }
        
        protected string InternalId
        {
            get
            {
                if (AdditionalAttributes is { Count: > 0 })
                {
                    if (AdditionalAttributes.ContainsKey("id"))
                    {
                        return AdditionalAttributes["id"]?.ToString();
                    }
                }
                return null;
            }
        }

        protected string InternalName
        {
            get
            {
                if (AdditionalAttributes is { Count: > 0 })
                {
                    if (AdditionalAttributes.ContainsKey("id"))
                    {
                        return AdditionalAttributes["id"]?.ToString();
                    }
                }
                return null;
            }
        }

        protected string InternalCssClass
        {
            get
            {
                if (AdditionalAttributes is { Count: > 0 })
                {
                    if (AdditionalAttributes.ContainsKey("class"))
                    {
                        return AdditionalAttributes["class"]?.ToString();
                    }
                }
                return null;
            }
        }
        
        protected string VisibilityClass { get => Visibility?.CssClass; }        
    }
}
