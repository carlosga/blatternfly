using System.Text;

namespace Blatternfly.Layouts
{
    public sealed class FlexOrder
    {
        public int? Default { get; set; }
        public int? Medium { get; set; }
        public int? Large { get; set; }
        public int? ExtraLarge { get; set; }
        public int? ExtraLarge2 { get; set; }

        internal bool IsEmpty
        {
            get => !Default.HasValue
                && !Medium.HasValue
                && !Large.HasValue
                && !ExtraLarge.HasValue
                && !ExtraLarge2.HasValue;
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

                if (Default.HasValue)
                {
                    builder.AppendFormat("--pf-l-flex--item--Order:{0};", Default);
                }
                if (Medium.HasValue)
                {
                    builder.AppendFormat("--pf-l-flex--item--Order-on-md:{0};", Medium);
                }
                if (Large.HasValue)
                {
                    builder.AppendFormat("--pf-l-flex--item--Order-on-lg:{0};", Large);
                }
                if (ExtraLarge.HasValue)
                {
                    builder.AppendFormat("--pf-l-flex--item--Order-on-xl:{0};", ExtraLarge);
                }
                if (ExtraLarge2.HasValue)
                {
                    builder.AppendFormat("--pf-l-flex--item--Order-on-2xl:{0};", ExtraLarge2);
                }
                return builder.ToString();
            }
        }
    }
}
