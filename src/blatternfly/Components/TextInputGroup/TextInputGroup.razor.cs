namespace Blatternfly.Components;

public partial class TextInputGroup : ComponentBase
{
  /// <summary>Additional attributes that will be applied to the component.</summary>
  [Parameter(CaptureUnmatchedValues = true)] public IReadOnlyDictionary<string, object> AdditionalAttributes { get; set; }

  /// <summary>Content rendered inside the component.</summary>
  [Parameter] public RenderFragment ChildContent { get; set; }

  /// <summary>Adds disabled styling and a disabled context value which text input group main hooks into for the input itself.</summary>
  [Parameter] public bool IsDisabled { get; set; }

  /// <summary>Flag to indicate the toggle has no border or background.</summary>
  [Parameter] public bool IsPlain { get; set; }

  private string CssClass => new CssBuilder("pf-c-text-input-group")
    .AddClass("pf-m-disabled", IsDisabled)
    .AddClass("pf-m-plain"   , IsPlain)
    .AddClassFromAttributes(AdditionalAttributes)
    .Build();
}