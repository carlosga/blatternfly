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
            var index     = 0;
            var component = TitleElement switch
            {
                TitleElement.div => "div",
                TitleElement.h1  => "h1",
                TitleElement.h2  => "h2",
                TitleElement.h3  => "h3",
                TitleElement.h4  => "h4",
                TitleElement.h5  => "h5",
                TitleElement.h6  => "h6",
                _                => null
            };

            builder.OpenElement(index++, "section");
            builder.AddMultipleAttributes(index++, AdditionalAttributes);
            builder.AddAttribute(index++, "class", "pf-c-form__section");

            if (Title is not null)
            {
                builder.OpenElement(index++, component);
                builder.AddAttribute(index++, "class", "pf-c-form__section-title");
                builder.AddContent(index++, Title);
                builder.CloseElement();
            }
            builder.AddContent(index++, ChildContent);

            builder.CloseElement();
        }
    }
}
