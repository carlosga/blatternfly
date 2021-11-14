using System;

namespace Blatternfly.Components;

public sealed class PerPageSelectEventArgs : EventArgs
{
    public int NewPerPage { get; }
    public int NewPage { get; }
    public int StartIdx { get; }
    public int EndIdx { get; }

    internal PerPageSelectEventArgs(int newPerPage, int newPage, int startIdx, int endIdx)
    {
        NewPerPage = newPerPage;
        NewPage    = newPage;
        StartIdx   = startIdx;
        EndIdx     = endIdx;
    }
}
