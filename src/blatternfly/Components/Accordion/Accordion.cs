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

        /// Flag to indicate the accordion had a border.
        [Parameter] public bool IsBordered { get; set; }

        /// Display size variant.
        [Parameter] public DisplaySize DisplaySize { get; set; } = DisplaySize.Default;

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

        private string CssClass => new CssBuilder("pf-c-accordion")
            .AddClass("pf-m-bordered"   , when: IsBordered)
            .AddClass("pf-m-display-lg" , when: DisplaySize == DisplaySize.Large)
            .Build();  
  
        protected override void BuildRenderTree(RenderTreeBuilder builder)
        {
            var component = AsDefinitionList ? "dl" : "div";

            builder.OpenElement(1, component);
            builder.AddMultipleAttributes(2, AdditionalAttributes);
            builder.AddAttribute(3, "class", CssClass);
            builder.AddAttribute(4, "aria-label", AriaLabel);
            builder.OpenComponent<CascadingValue<Accordion>>(5);
            builder.AddAttribute(6, "Value", this);
            builder.AddAttribute(7, "ChildContent", ChildContent);
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
                else if (ExpandedItems.Count == 1 && ExpandedItems[0] == id)
                {
                    ExpandedItems.RemoveAt(0);
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
