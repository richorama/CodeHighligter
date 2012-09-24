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
            foreach (var item in attributes.Select(x => new HighlightReport(x, type)))
            {
                yield return item;
            }

            foreach (var member in type.GetMembers())
            {
                foreach (var report in member.GetCustomAttributes(typeof(HighlightAttribute), false).Select(x => new HighlightReport(x as HighlightAttribute, member, type)))
                {
                    yield return report;
                }
            }

        }

    }
}
