using System.Text;

namespace Blatternfly
{
    public abstract class FormatBreakpointStyles<T>
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
        
        protected abstract string BaseStyle { get; }

        internal string CssStyle
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
                    builder.AppendFormat("--{0}:{1};", BaseStyle, Default);
                }
                if (Small is not null)
                {
                    builder.AppendFormat("--{0}-on-sm:{1};", BaseStyle, Small);
                }
                if (Medium is not null)
                {
                    builder.AppendFormat("--{0}-on-md:{1};", BaseStyle, Medium);
                }
                if (Large is not null)
                {
                    builder.AppendFormat("--{0}-on-lg:{1};", BaseStyle, Large);
                }
                if (ExtraLarge is not null)
                {
                    builder.AppendFormat("--{0}-on-xl:{1};", BaseStyle, ExtraLarge);
                }
                if (ExtraLarge2 is not null)
                {
                    builder.AppendFormat("--{0}-on-2xl:{1};", BaseStyle, ExtraLarge2);
                }
                return builder.ToString();
            }
        }
    }
}
