using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.IO;
using System.Xml;
using Doc.X;
using Doc.Core;
using System.Diagnostics;

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

            using (var xReader = XmlReader.Create("sample.xml"))
            using (var nodeReader = new XNodeReader(xReader))
            {
                foreach (var node in nodeReader.Read())
                {
                    Debug.WriteLine(node);
                }
            }
        }

        [TestMethod]
        public void DOC_JSON()
        {
        }
    }
}
