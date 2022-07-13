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
    public class FileTypeTaoBaoTests
    {
        FileTypeBaseSite instance = new FileTypeTaoBao();

        [TestMethod()]
        public void GenerateFileNameTest()
        {
            Assert.AreEqual("TaoBao", instance.GenerateFileName("TaoBao"));
            Assert.AreEqual("TaoBao", instance.GenerateFileName("https://www.TaoBao.com/"));
            Assert.AreEqual("TMALL", instance.GenerateFileName("https://www.tmall.com/"));
            Assert.AreEqual("Item-id=12345", instance.GenerateFileName("https://item.taobao.com/item.htm?id=12345"));
            Assert.AreEqual("Item-id=12345", instance.GenerateFileName("https://detail.tmall.com/item.htm?id=12345"));
        }
    }
}