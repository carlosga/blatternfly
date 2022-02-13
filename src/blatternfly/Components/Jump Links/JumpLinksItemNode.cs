using System.Collections.Generic;

namespace Blatternfly.Components;

internal sealed class JumpLinksItemNode
{
    internal JumpLinksItem JumpLink { get; set; }

    internal List<JumpLinksItem> Children { get; set; }
}
