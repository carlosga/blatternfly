using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;
using Microsoft.AspNetCore.Components.Rendering;

namespace Blatternfly.Components
{
    public class FormSection : BaseComponent
    {
        /// Title for the section.
        [Parameter] public string Title { get; set; }

        /// Element to wrap the section title.
        [Parameter] public TitleElement TitleElement { get; set; }

        protected override void BuildRenderTree(RenderTreeBuilder builder)
        {
            var index = 0;

            builder.OpenElement(index++, "section");
            builder.AddMultipleAttributes(index++, AdditionalAttributes);
            builder.AddAttribute(index++, "class", "pf-c-form__section");

            if (Title is not null)
            {
                builder.OpenElement(index++, TitleElement.ToString());
                builder.AddAttribute(index++, "class", "pf-c-form__section-title");
                builder.AddContent(index++, Title);
                builder.CloseElement();
            }

            builder.AddContent(index++, ChildContent);

            builder.CloseElement();
        }
    }
}
