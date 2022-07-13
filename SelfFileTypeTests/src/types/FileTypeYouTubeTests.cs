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
    public class FileTypeYouTubeTests
    {
        FileTypeBaseSite instance = new FileTypeYouTube();

        [TestMethod()]
        public void GenerateFileNameTest()
        {
            Assert.AreEqual("YouTube", instance.GenerateFileName("youtube"));
            Assert.AreEqual("YouTube", instance.GenerateFileName("https://www.youtube.com/"));
            Assert.AreEqual("YouTube", instance.GenerateFileName("https://www.youtube.com/abc"));
            Assert.AreEqual("user_abc", instance.GenerateFileName("https://www.youtube.com/c/user_abc"));
            Assert.AreEqual("Watch-v=aabbccdd", instance.GenerateFileName("https://www.youtube.com/watch?v=aabbccdd"));
        }
    }
}