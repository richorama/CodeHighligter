using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CodeHighlighter
{
    public class HighlightAttribute : Attribute
    {
        public HighlightAttribute(string message, HighlightReasons reason = HighlightReasons.Unspecified)
        {
            this.Message = message;
            this.Reason = reason;
        }

        public string Message { get; private set; }

        public HighlightReasons Reason { get; private set; }

    }
}
