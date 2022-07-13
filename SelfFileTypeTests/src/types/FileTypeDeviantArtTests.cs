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
    public class FileTypeDeviantArtTests
    {
        FileTypeBaseSite instance = new FileTypeDeviantArt();

        [TestMethod()]
        public void GenerateFileNameTest()
        {
            Assert.AreEqual("DeviantArt", instance.GenerateFileName("DeviantArt"));
            Assert.AreEqual("DeviantArt", instance.GenerateFileName("https://www.deviantart.com/"));
            Assert.AreEqual("abc", instance.GenerateFileName("https://www.deviantart.com/abc"));
            Assert.AreEqual("artwork-name-123456789", instance.GenerateFileName("https://www.deviantart.com/artist-name/art/artwork-name-123456789"));
            Assert.AreEqual("Search-q=abc", instance.GenerateFileName("https://www.deviantart.com/search?q=abc"));
        }
    }
}