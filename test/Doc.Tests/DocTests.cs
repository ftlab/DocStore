using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.IO;
using System.Xml;
using Doc.X;
using Doc.Core;
using System.Diagnostics;
using System.Text;
using Doc.J.Observer;

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
            using (var nodeReader = new XTokenReader(xReader))
            {
                foreach (var node in nodeReader.Read())
                {
                    Debug.WriteLine(node);
                }
            }
        }

        [TestMethod]
        [DeploymentItem("Data\\sample.xml")]
        public void DOC_JSON_BUILDER()
        {
            Assert.IsTrue(File.Exists("sample.xml"));

            var json = new StringBuilder();

            using (var xReader = XmlReader.Create("sample.xml"))
            using (var tokenReader = new XTokenReader(xReader))
            using (var writer = new StringWriter(json))
            {
                var visitor = new TokenObservableVisitor(
                    new JsonBuilder(writer));

                visitor.Visit(tokenReader);
            }

            Debug.WriteLine(json.ToString());
        }

        [TestMethod]
        public void DOC_JSON()
        {
        }
    }
}
