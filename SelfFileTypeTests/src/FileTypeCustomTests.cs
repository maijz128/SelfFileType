using Microsoft.VisualStudio.TestTools.UnitTesting;
using SelfFileType.src;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SelfFileType.src.Tests
{
    [TestClass()]
    public class FileTypeCustomTests
    {
        [TestMethod()]
        public void GenerateFileNameTest()
        {
            var ftc = new FileTypeCustom();
            Assert.AreEqual("docker.com", ftc.GenerateFileName("http://www.docker.com"));
        }
    }
}