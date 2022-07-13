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
    public class FileTypeSmzdmTests
    {
        FileTypeBaseSite instance = new FileTypeSmzdm();
        [TestMethod()]
        public void GenerateFileNameTest()
        {
            Assert.AreEqual("什么值得买", instance.GenerateFileName("smzdm"));
            Assert.AreEqual("什么值得买", instance.GenerateFileName("https://www.smzdm.com/"));
            Assert.AreEqual("什么值得买", instance.GenerateFileName("https://www.smzdm.com/abc"));
            Assert.AreEqual("Post-a111111", instance.GenerateFileName("https://post.smzdm.com/p/a111111/"));
            Assert.AreEqual("Search", instance.GenerateFileName("https://search.smzdm.com/?c=home&s=%E7%94%B5%E9%A5%AD%E7%85%B2&v=b"));
        }
    }
}