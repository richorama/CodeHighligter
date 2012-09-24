using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;

namespace CodeHighlighter.Inspector
{
    public static class Inspector
    {

        public static IEnumerable<HighlightReport> Inspect(Assembly assembly)
        {
            foreach (var type in assembly.GetTypes())
            {
                foreach (var report in Inspect(type))
                {
                    yield return report;
                }
            }
        }

        public static IEnumerable<HighlightReport> Inspect(Type type)
        {
            var attributes = type.GetCustomAttributes(typeof(HighlightAttribute), false) as HighlightAttribute[];
            return attributes.Select(x => new HighlightReport(x, type));
        }

    }
}
