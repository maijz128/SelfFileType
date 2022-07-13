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
    public class FileTypePornhubTests
    {
        FileTypeBaseSite instance = new FileTypePornhub();

        [TestMethod()]
        public void GenerateFileNameTest()
        {
            Assert.AreEqual("Pornhub", instance.GenerateFileName("Pornhub"));
            Assert.AreEqual("Pornhub", instance.GenerateFileName("https://www.Pornhub.com/"));
            Assert.AreEqual("Pornhub", instance.GenerateFileName("https://www.Pornhub.com/abc"));
            Assert.AreEqual("viewkey=ph1122334455", instance.GenerateFileName("https://pornhub.com/view_video.php?viewkey=ph1122334455"));
            Assert.AreEqual("aabbccdd", instance.GenerateFileName("https://pornhub.com/model/aabbccdd"));
            Assert.AreEqual("search=abc", instance.GenerateFileName("https://pornhub.com/video/search?search=abc"));
        }
    }
}