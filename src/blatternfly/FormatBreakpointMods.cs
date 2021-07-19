using System.Text;

namespace Blatternfly
{
    public abstract class FormatBreakpointMods<T>
    {
        public T Default { get; set; }
        public T Small { get; set; }
        public T Medium { get; set; }
        public T Large { get; set; }
        public T ExtraLarge { get; set; }
        public T ExtraLarge2 { get; set; }

        private bool IsEmpty
        {
            get => Default is null
                && Small is null
                && Medium is null
                && Large is null
                && ExtraLarge is null
                && ExtraLarge2 is null;
        }

        internal string CssClass
        {
            get
            {
                if (IsEmpty)
                {
                    return null;
                }

                var builder = new StringBuilder();

                if (Default is not null)
                {
                    builder.AppendFormat("pf-{0}-{1} ", Prefix, ToString(Default));
                }
                if (Small is not null)
                {
                    builder.AppendFormat("pf-{0}-{1}-on-sm ", Prefix, ToString(Small));
                }
                if (Medium is not null)
                {
                    builder.AppendFormat("pf-{0}-{1}-on-md ", Prefix, ToString(Medium));
                }
                if (Large is not null)
                {
                    builder.AppendFormat("pf-{0}-{1}-on-lg ", Prefix, ToString(Large));
                }
                if (ExtraLarge is not null)
                {
                    builder.AppendFormat("pf-{0}-{1}-on-xl ", Prefix, ToString(ExtraLarge));
                }
                if (ExtraLarge2 is not null)
                {
                    builder.AppendFormat("pf-{0}-{1}-on-2xl", Prefix, ToString(ExtraLarge2));
                }
                return builder.ToString();
            }
        }

        protected abstract string Prefix { get; }

        protected abstract string ToString(T value);
    }
}
