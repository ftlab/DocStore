using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.IO;
using System.Xml;
using Doc.X;
using Doc.Core;

namespace Doc.Tests
{
    [TestClass]
    public class DocTests
    {
        [TestMethod]
        [DeploymentItem("Data\\sample.xml")]
        public void DOC_Xml()
        {
            Assert.IsTrue(File.Exists("sample.xml"));

            using (var stream = File.OpenRead("sample.xml"))
            using (var reader = XmlReader.Create(stream))
            using (var xreader = new XReader(reader))
            {
                while (xreader.Read()) ;
            }
        }

        [TestMethod]
        public void DOC_JSON()
        {
        }
    }
}
