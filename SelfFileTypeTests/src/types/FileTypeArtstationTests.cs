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
    public class FileTypeArtstationTests
    {
        FileTypeArtstation instance = new FileTypeArtstation();

        [TestMethod()]
        public void GenerateFileNameTest()
        {
            Assert.AreEqual("ArtStation", instance.GenerateFileName("Artstation"));
            Assert.AreEqual("ArtStation", instance.GenerateFileName("https://www.artstation.com/"));
            Assert.AreEqual("Artwork-abc", instance.GenerateFileName("https://www.artstation.com/artwork/abc"));
            Assert.AreEqual("Search-sort_by=likes&query=abc", instance.GenerateFileName("https://www.artstation.com/search?sort_by=likes&query=abc"));
        }
    }
}