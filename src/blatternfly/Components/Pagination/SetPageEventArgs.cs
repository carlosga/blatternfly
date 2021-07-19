using System;

namespace Blatternfly.Components
{
    public sealed class SetPageEventArgs : EventArgs
    {
        public int NewPage { get; }
        public int PerPage { get; }
        public int StartIdx { get; }
        public int EndIdx { get; }

        internal SetPageEventArgs(int newPage, int perPage, int startIdx, int endIdx)
        {
            NewPage  = newPage;
            PerPage  = perPage;
            StartIdx = startIdx;
            EndIdx   = endIdx;
        }
    }
}
