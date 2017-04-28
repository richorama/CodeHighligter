using Microsoft.Samples.SimplePDBReader;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace CodeHighlighter.Runner
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
            var location = GetLocation(type);

            var attributes = type.GetCustomAttributes(typeof(HighlightAttribute), false) as HighlightAttribute[];
            foreach (var item in attributes.Select(x => new HighlightReport(x, type, location)))
            {
                yield return item;
            }

            foreach (var member in type.GetMembers())
            {
                foreach (var report in member.GetCustomAttributes(typeof(HighlightAttribute), false)
                    .Select(x => new HighlightReport(x as HighlightAttribute, member, type, location)))
                {
                    yield return report;
                }
            }

        }

        private static string GetLocation(Type type)
        {

            foreach (var method in type.GetMethods())
            {
                var location = string.Empty;
                try
                {
                    using (var symbolProvider = new SymbolProvider("./", SymbolProvider.SymSearchPolicies.AllowOriginalPathAccess))
                    {
                        var sourceLocation = symbolProvider.GetSourceLoc(method, 0);
                        if (!string.IsNullOrWhiteSpace(sourceLocation.Url))
                        {
                            return sourceLocation.Url;
                        }
                    }
                }
                catch
                {

                }
            }
            return null;
        }

    }
}
