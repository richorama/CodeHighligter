using CodeHighlighter.Runner;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Linq;


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

  

    }
}

