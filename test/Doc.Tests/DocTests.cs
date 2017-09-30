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
            
        }

        [TestMethod]
        public void DOC_JSON()
        {
        }
    }
}
