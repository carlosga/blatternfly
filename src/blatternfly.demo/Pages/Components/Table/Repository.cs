using Blatternfly.Components;

namespace Blatternfly.Demo.Pages.Components.Table;

public record Repository
(
    string     Name,
    string     Branches,
    string     PullRequests,
    string     Workspaces,
    string     LastCommit,
    SelectType Selection = null
);
