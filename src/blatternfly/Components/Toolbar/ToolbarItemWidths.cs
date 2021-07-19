using System.Text;

namespace Blatternfly.Components
{
    public sealed class ToolbarItemWidths
    {
        public string Default { get; set; }
        public string Small { get; set; }
        public string Medium { get; set; }
        public string Large { get; set; }
        public string ExtraLarge { get; set; }
        public string ExtraLarge2 { get; set; }

        private bool IsEmpty
        {
            get => string.IsNullOrEmpty(Default)
                && string.IsNullOrEmpty(Small)
                && string.IsNullOrEmpty(Medium)
                && string.IsNullOrEmpty(Large)
                && string.IsNullOrEmpty(ExtraLarge)
                && string.IsNullOrEmpty(ExtraLarge2);
        }

        internal string CssStyle
        {
            get
            {
                if (IsEmpty)
                {
                    return null;
                }

                var builder = new StringBuilder();

                if (!string.IsNullOrEmpty(Default))
                {
                    builder.AppendFormat("--pf-c-toolbar__item--Width:{0};", Default);
                }
                if (!string.IsNullOrEmpty(Small))
                {
                    builder.AppendFormat("--pf-c-toolbar__item--Width-on-sm:{0};", Small);
                }
                if (!string.IsNullOrEmpty(Medium))
                {
                    builder.AppendFormat("--pf-c-toolbar__item--Width-on-md:{0};", Medium);
                }
                if (!string.IsNullOrEmpty(Large))
                {
                    builder.AppendFormat("--pf-c-toolbar__item--Width-on-lg:{0};", Large);
                }
                if (!string.IsNullOrEmpty(ExtraLarge))
                {
                    builder.AppendFormat("--pf-c-toolbar__item--Width-on-xl:{0};", ExtraLarge);
                }
                if (!string.IsNullOrEmpty(ExtraLarge2))
                {
                    builder.AppendFormat("--pf-c-toolbar__item--Width-on-2xl:{0};", ExtraLarge2);
                }
                return builder.ToString();
            }
        }
    }
}
