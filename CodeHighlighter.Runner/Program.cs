using System;
using System.IO;
using System.Reflection;

namespace CodeHighlighter.Runner
{
    class Program
    {
        static void Main(string[] args)
        {
            var path = Environment.CurrentDirectory;
            var errorCount = 0;
            if (args.Length > 0) {
                path = args[0];
            }
            foreach (var filename in Directory.EnumerateFiles(path)) 
            {
                var extension = Path.GetExtension(filename).ToLower();
                if (extension == ".exe" || extension == ".dll")
                {
                    Console.WriteLine("{0}", Path.GetFileName(filename));
                    var assembly = Assembly.LoadFile(filename);
                    foreach (var report in Inspector.Inspect(assembly))
                    {
                        Console.WriteLine(string.Format("  {0}",report));    
                    }
                }

            }
            Environment.ExitCode = errorCount;

        }
    }
}
