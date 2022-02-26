using Blatternfly.Components;

namespace Blatternfly.Demo.Pages.Components.Table;

public class Expandable<T, K>
{
  public T          Parent     { get; set; }
  public K          Child      { get; set; }
  public ExpandType Expand     { get; set; }
  public bool       IsExpanded { get => Expand is not null && Expand.IsExpanded; }
}
