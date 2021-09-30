using System.Threading;
using System.Threading.Tasks;
using Blatternfly.Components;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Rendering;
using Microsoft.AspNetCore.Components.Web;

namespace Blatternfly.Components
{
    public class Modal : BaseComponent
    {
        /// Flag to show the modal.
        [Parameter] public bool IsOpen { get; set; }

        /// Complex header (more than just text), supersedes title for header content.
        [Parameter] public RenderFragment Header { get; set; }

        /// Optional help section for the Modal Header.
        [Parameter] public string Help { get; set; }

        /// Simple text content of the Modal Header, also used for aria-label on the body.
        [Parameter] public string Title { get; set; }

        /// Optional alert icon (or other) to show before the title of the Modal Header
        /// When the predefined alert types are used the default styling will be automatically applied.
        [Parameter] public ModalTitleVariant? TitleIconVariant { get; set; }

        /// Custom icon for the modal title.
        [Parameter] public RenderFragment CustomTitleIcon { get; set; }

        /// Optional title label text for screen readers.
        [Parameter] public string TitleLabel { get; set; }

        /// Id to use for Modal Box label.
        [Parameter] public string AriaLabelledBy { get; set; }

        /// Accessible descriptor of modal.
        [Parameter] public string AriaLabel { get; set; }

        /// Id to use for Modal Box descriptor.
        [Parameter] public string AriaDescribedBy { get; set; }

        /// Flag to show the close button in the header area of the modal.
        [Parameter] public bool ShowClose { get; set; } = true;

        /// Custom footer.
        [Parameter] public RenderFragment Footer { get; set; }

        /// Action buttons to add to the standard Modal Footer, ignored if `footer` is given.
        [Parameter] public RenderFragment Actions { get; set; }

        /// A callback for when the close button is clicked.
        [Parameter] public EventCallback OnClose { get; set; }

        /// Default width of the Modal..
        [Parameter] public string Width { get; set; }

        /// Flag to disable focus trap.
        [Parameter] public bool DisableFocusTrap { get; set; }

        /// Description of the modal.
        [Parameter] public RenderFragment Description { get; set; }

        /// Variant of the modal.
        [Parameter] public ModalVariant Variant { get; set; } = ModalVariant.Default;

        /// Alternate position of the modal.
        [Parameter] public ModalPosition? Position { get; set; }

        /// Offset from alternate position. Can be any valid CSS length/percentage.
        [Parameter] public string PositionOffset { get; set; }

        /// Flag indicating if modal content should be placed in a modal box body wrapper.
        [Parameter] public bool HasNoBodyWrapper { get; set; }

        /// Modal handles pressing of the Escape key and closes the modal.
        /// If you want to handle this yourself you can use this callback function.
        [Parameter] public EventCallback<KeyboardEventArgs> OnEscapePress { get; set; }

        private static int _currentId = 0;

        private string BoxId { get; set; }
        private string LabelId { get; set; }
        private string DescriptorId { get; set; }

        protected override void OnInitialized()
        {
            base.OnInitialized();

            var boxIdNum        = Interlocked.Increment(ref _currentId);
            var labelIdNum      = boxIdNum + 1;
            var descriptorIdNum = boxIdNum + 2;

            BoxId        = !string.IsNullOrEmpty(InternalId) ? InternalId : $"pf-modal-part-{boxIdNum}";
            LabelId      = $"pf-modal-part-{labelIdNum}";
            DescriptorId = $"pf-modal-part-{descriptorIdNum}";
        }
        
        protected override void BuildRenderTree(RenderTreeBuilder builder)
        {
		    if (!IsOpen)
		    {
			    return;
		    }

            var index = 0;
            
		    builder.OpenComponent<Portal>(index++);
		    builder.AddAttribute(index++, "IsOpen", IsOpen);
		    builder.AddAttribute(index++, "ChildContent", (RenderFragment)delegate(RenderTreeBuilder builder1)
		    {            
			    builder1.OpenComponent<ModalContent>(index++);
			    builder1.AddMultipleAttributes(index++, AdditionalAttributes);
			    builder1.AddAttribute(index++, "AriaLabel"       , AriaLabel);
			    builder1.AddAttribute(index++, "AriaDescribedBy" , AriaDescribedBy);
			    builder1.AddAttribute(index++, "AriaLabelledBy"  , AriaLabelledBy);
			    builder1.AddAttribute(index++, "BoxId"           , BoxId);
			    builder1.AddAttribute(index++, "DescriptorId"    , DescriptorId);
			    builder1.AddAttribute(index++, "DisableFocusTrap", DisableFocusTrap);
			    builder1.AddAttribute(index++, "HasNoBodyWrapper", HasNoBodyWrapper);
			    builder1.AddAttribute(index++, "IsOpen"          , IsOpen);
			    builder1.AddAttribute(index++, "LabelId"         , LabelId);
			    builder1.AddAttribute(index++, "Position"        , Position);
			    builder1.AddAttribute(index++, "PositionOffset"  , PositionOffset);
			    builder1.AddAttribute(index++, "ShowClose"       , ShowClose);
			    builder1.AddAttribute(index++, "Title"           , Title);
			    builder1.AddAttribute(index++, "TitleIconVariant", TitleIconVariant);
			    builder1.AddAttribute(index++, "TitleLabel"      , TitleLabel);
			    builder1.AddAttribute(index++, "Variant"         , Variant);
			    builder1.AddAttribute(index++, "Width"           , Width);
                builder1.AddAttribute(index++, "Help"            , Help);   
                builder1.AddAttribute(index++, "Actions"         , Actions);                    
                builder1.AddAttribute(index++, "CustomTitleIcon" , CustomTitleIcon);
                builder1.AddAttribute(index++, "Description"     , Description);   
                builder1.AddAttribute(index++, "Footer"          , Footer);
                builder1.AddAttribute(index++, "Header"          , Header);                    
			    builder1.AddAttribute(index++, "OnClose"         , EventCallback.Factory.Create(this, OnClose));
                builder1.AddAttribute(index++, "OnEscapePress"   , EventCallback.Factory.Create(this, OnEscapePressHandler));
                builder1.AddAttribute(index++, "ChildContent"    , ChildContent);
			    builder1.CloseComponent();
            });
            builder.CloseComponent();
        }
        
        private async Task OnEscapePressHandler(KeyboardEventArgs args)
        {
            if (OnEscapePress.HasDelegate)
            {
                await OnEscapePress.InvokeAsync(args);
            }
            else
            {
                await OnClose.InvokeAsync();
            }
        }
    }
}
