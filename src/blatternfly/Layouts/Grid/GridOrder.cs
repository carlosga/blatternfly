using System.Text;

namespace Blatternfly.Layouts
{
    public sealed class GridOrder
    {
        public string Default     { get;set; }
        public string Medium      { get;set; }
        public string Large       { get;set; }
        public string ExtraLarge  { get;set; }
        public string ExtraLarge2 { get;set; }

        private bool IsEmpty
        {
            get => string.IsNullOrEmpty(Default)
                && string.IsNullOrEmpty(Medium)
                && string.IsNullOrEmpty(Large)
                && string.IsNullOrEmpty(ExtraLarge)
                && string.IsNullOrEmpty(ExtraLarge2);
        }

        internal string OrderClass
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
                    builder.AppendFormat("--pf-l-grid--item--Order:{0} ", Default);
                }
                if (!string.IsNullOrEmpty(Medium))
                {
                    builder.AppendFormat("--pf-l-grid--item--Order-on-md:{0} ", Medium);
                }
                if (!string.IsNullOrEmpty(Large))
                {
                    builder.AppendFormat("--pf-l-grid--item--Order-on-lg:{0} ", Large);
                }
                if (!string.IsNullOrEmpty(ExtraLarge))
                {
                    builder.AppendFormat("--pf-l-grid--item--Order-on-xl:{0} ", ExtraLarge);
                }
                if (!string.IsNullOrEmpty(ExtraLarge2))
                {
                    builder.AppendFormat("--pf-l-grid--item--Order-on-2xl:{0}", ExtraLarge2);
                }
                return builder.ToString();
            }
        }
    }
}
