using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;

namespace CodeHighlighter.Tests
{
    [TestFixture]
    [Highlight("Test")]
    public class Test1
    {
        [Test]
        public void TestClassInspection()
        {
            var reports = Inspector.Inspector.Inspect(typeof(Test1));
            Assert.AreEqual(1, reports.Where(x => x.Type.Name == "Test1" && x.Attribute.Message == "Test").Count());
            foreach (var report in reports)
            {
                Console.WriteLine(report.ToString());
            }
        }

    }
}
