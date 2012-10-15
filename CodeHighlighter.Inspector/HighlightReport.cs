using System;
using System.Reflection;

namespace CodeHighlighter.Inspector
{
    public class HighlightReport
    {

        public HighlightReport(HighlightAttribute attribute, Type type, string location)
        {
            this.Attribute = attribute;
            this.Type = type;
            this.Location = location;
        }

        public HighlightReport(HighlightAttribute attribute, MemberInfo memberInfo, Type type, string location)
        {
            this.Attribute = attribute;
            this.Type = type;
            this.MemberInfo = memberInfo;
            this.Location = location;
        }

        public HighlightAttribute Attribute { get; private set; }

        public Type Type { get; private set; }

        public string Location { get; private set; }

        public override string ToString()
        {
            if (this.MemberInfo != null)
                return string.Format("[{4}] {0}.{3} \"{1}\" {2}\r\n  in {5}", this.Type.FullName, this.Attribute.Message, this.Attribute.Reason != HighlightReasons.Unspecified ? "(" + this.Attribute.Reason + ")" : "", this.MemberInfo.Name, this.MemberInfo.MemberType, this.Location);
            else
                return string.Format("[Class] {0} \"{1}\" {2}\r\n  in {3}", this.Type.FullName, this.Attribute.Message, this.Attribute.Reason != HighlightReasons.Unspecified ? "(" + this.Attribute.Reason + ")" : "", this.Location);
        }

        public PropertyInfo PropertyInfo { get; private set; }

        public MemberInfo MemberInfo { get; private set; }
    }
}
