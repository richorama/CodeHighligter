using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
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

        public HighlightReport(HighlightAttribute attribute, MemberInfo memberInfo, Type type)
        {
            this.Attribute = attribute;
            this.Type = type;
            this.MemberInfo = memberInfo;
        }

        public HighlightAttribute Attribute { get; private set; }

        public Type Type { get; private set; }

        public override string ToString()
        {
            if (this.MemberInfo != null)
                return string.Format(@"[{4}] {0}.{3} ""{1}"" {2}", this.Type.FullName, this.Attribute.Message, this.Attribute.Reason != HighlightReasons.Unspecified ? "(" + this.Attribute.Reason + ")" : "", this.MemberInfo.Name, this.MemberInfo.MemberType);
            else 
                return string.Format(@"[Class] {0} ""{1}"" {2}", this.Type.FullName, this.Attribute.Message, this.Attribute.Reason != HighlightReasons.Unspecified ? "(" + this.Attribute.Reason + ")" : "");
        }

        public PropertyInfo PropertyInfo { get; private set; }

        public MemberInfo MemberInfo { get; private set; }
    }
}
