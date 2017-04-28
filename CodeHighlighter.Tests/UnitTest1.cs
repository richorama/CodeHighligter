using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Linq;
using CodeHighlighter.Runner;
using global::CodeHighlighter.Runner;

namespace CodeHighlighter.Tests
{


    namespace CodeHighlighter.Tests
    {
        [TestClass]
        [Highlight("Class")]
        public class Test1
        {
            [TestMethod]
            public void TestClassInspection()
            {
                var reports = Inspector.Inspect(typeof(Test1));
                Assert.AreEqual(1, reports.Where(x => x.Type.Name == "Test1" && x.Attribute.Message == "Class").Count());
                foreach (var report in reports)
                {
                    Console.WriteLine(report.ToString());
                }
            }

            [TestMethod]
            [Highlight("Method")]
            public void TestMethodInspection()
            {
                var reports = Inspector.Inspect(typeof(Test1));
                Assert.AreEqual(1, reports.Where(x => x.Type.Name == "Test1" && x.Attribute.Message == "Method").Count());
                foreach (var report in reports)
                {
                    Console.WriteLine(report.ToString());
                }
            }

            [Highlight("Property")]
            public string ProprtyExample { get; set; }

            [TestMethod]
            public void TestPropertyInspection()
            {
                var reports = Inspector.Inspect(typeof(Test1));
                Assert.AreEqual(1, reports.Where(x => x.Type.Name == "Test1" && x.Attribute.Message == "Property").Count());
                foreach (var report in reports)
                {
                    Console.WriteLine(report.ToString());
                }
            }

            /*
            [TestMethod]
            public void TestArgumentInspection()
            {
                var reports = Inspector.Inspector.Inspect(typeof(Test1));
                Assert.AreEqual(1, reports.Where(x => x.Type.Name == "Test1" && x.Attribute.Message == "Argument").Count());
                foreach (var report in reports)
                {
                    Console.WriteLine(report.ToString());
                }
            }*/

            public void MethodWithArugment([Highlight("Argument")] string foo)
            {
                throw new NotImplementedException();
            }

        }
    }

}
