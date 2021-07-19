using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Rendering;

namespace Blatternfly.Components
{
    public class Accordion : BaseComponent
    {
        /// Adds accessible text to the Accordion.
        [Parameter] public string AriaLabel { get; set; }

        /// Heading level to use.
        [Parameter] public HeadingLevel HeadingLevel { get; set; } = HeadingLevel.h3;

        /// Flag to indicate whether use definition list or div.
        [Parameter] public bool AsDefinitionList { get; set; } = true;

        private ExpandBehavior _expandBehavior;

        [Parameter]
        public ExpandBehavior ExpandBehavior
        {
            get => _expandBehavior;
            set
            {
                if (_expandBehavior != value)
                {
                    _expandBehavior = value;
                    ExpandedItems.Clear();
                }
            }
        }

        protected override void BuildRenderTree(RenderTreeBuilder builder)
        {
            var index     = 0;
            var component = AsDefinitionList ? "dl" : "div";

            builder.OpenElement(index++, component);
            builder.AddMultipleAttributes(index++, AdditionalAttributes);
            builder.AddAttribute(index++, "class", $"pf-c-accordion {VisibilityClass}");
            builder.AddAttribute(index++, "aria-label", AriaLabel);
            builder.OpenComponent<CascadingValue<Accordion>>(index++);
            builder.AddAttribute(index++, "Value", this);
            builder.AddAttribute(index++, "ChildContent", ChildContent);
            builder.CloseComponent();
            builder.CloseElement();
        }

        internal string ContentContainer { get => AsDefinitionList ? "dd" : "div"; }

        internal string ToggleContainer { get => AsDefinitionList ? "dt" : HeadingLevel.ToString(); }

        private List<string> ExpandedItems { get; set; } = new(1);

        internal bool IsExpanded(string itemId)
        {
            return ExpandedItems.Contains(itemId);
        }

        internal void Toggle(string id)
        {
            if (ExpandBehavior == ExpandBehavior.Single)
            {
                if (ExpandedItems.Count == 0)
                {
                    ExpandedItems.Add(id);
                }
                else
                {
                    ExpandedItems[0] = id;
                }
            }
            else if (!IsExpanded(id))
            {
                ExpandedItems.Add(id);
            }
            else
            {
                ExpandedItems.Remove(id);
            }
            StateHasChanged();
        }
    }
}
