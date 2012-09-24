using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CodeHighlighter.Inspector
{
    public class HighlightReport
    {

        public HighlightReport(HighlightAttribute attribute, Type type)
        {
            this.Attribute = attribute;
            this.Type = type;
        }

        public HighlightAttribute Attribute { get; private set; }

        public Type Type { get; private set; }

        public override string ToString()
        {
            return string.Format(@"{0} ""{1}"" {2}", this.Type.FullName, this.Attribute.Message, this.Attribute.Reason != HighlightReasons.Unspecified ? "(" + this.Attribute.Reason + ")" : "");
        }
    }
}
