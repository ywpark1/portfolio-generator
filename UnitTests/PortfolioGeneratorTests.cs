using System;
using Xunit;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Portfolio_generator_console;

namespace UnitTests
{
    [TestClass]
    public class PortfolioGeneratorTests
    {
        [TestMethod]
        public void TestDeleteFiles()
        {
            string templateDir = Path.Combine (Directory.GetCurrentDirectory ().ToString (), "templates");
            string[] files = Directory.GetDirectories (templateDir);
            
            string expected = null; // expected result after the deletion

            Console.Write("Please enter the file you want to delete: ");
            var fileName = Console.ReadLine();
            var path = path.Combine(templateDir, files);
            
            HtmlGenerator.deleteFiles(path);

            string actual = path;

            Assert.AreEqual(expected, actual, "File not deleted correctly."); // compares the expected result with the actual result
        }
    }
}