using Microsoft.VisualStudio.TestTools.UnitTesting;
using SelfFileType.src.types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SelfFileType.src.types.Tests
{
    [TestClass()]
    public class FileTypeSankakucomplexTests
    {
        FileTypeSankakucomplex sank = new FileTypeSankakucomplex();

        [TestMethod()]
        public void GenerateFileNameTest()
        {
            Assert.AreEqual("Sankaku Channel", sank.GenerateFileName("sankakucomplex"));
            Assert.AreEqual("Sankaku Channel", sank.GenerateFileName("https://chan.sankakucomplex.com/"));
            Assert.AreEqual("Post-123", sank.GenerateFileName("https://chan.sankakucomplex.com/post/show/123"));
            Assert.AreEqual("Post-123", sank.GenerateFileName("https://chan.sankakucomplex.com/cn/post/show/123"));
        }

        [TestMethod()]
        public void GenerateFileNameTest_Tags()
        {
            Assert.AreEqual("tags=123", sank.GenerateFileName("https://chan.sankakucomplex.com/cn/?tags=123"));
        }
    }
}