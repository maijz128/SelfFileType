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
    public class FileTypeBilibiliTests
    {
        [TestMethod()]
        public void GenerateFileNameTest()
        {
            var bili = new FileTypeBilibili();
            Assert.AreEqual("bilibili", bili.GenerateFileName(""));
            Assert.AreEqual("bilibili", bili.GenerateFileName("http://bilibili.com/afsdfasf"));
            Assert.AreEqual("abc", bili.GenerateFileName("http://bilibili.com/video/abc"));
            Assert.AreEqual("abc", bili.GenerateFileName("http://bilibili.com/video/abc?123123"));
            Assert.AreEqual("cv1111111", bili.GenerateFileName("http://bilibili.com/read/cv1111111/"));
        }

        [TestMethod()]
        public void FormattingURLTest()
        {
            var bili = new FileTypeBilibili();
            Assert.AreEqual("", bili.FormattingURL(""));
            Assert.AreEqual("bilibili.com", bili.FormattingURL("http://bilibili.com"));
            Assert.AreEqual("bilibili.com", bili.FormattingURL("https://bilibili.com"));
            Assert.AreEqual("bilibili.com", bili.FormattingURL("https://www.bilibili.com"));
            Assert.AreEqual("bilibili.com", bili.FormattingURL("https://bilibili.com/"));
        }

    }
}