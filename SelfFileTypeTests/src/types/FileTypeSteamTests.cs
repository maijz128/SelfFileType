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
    public class FileTypeSteamTests
    {
        FileTypeBaseSite instance = new FileTypeSteam();

        [TestMethod()]
        public void GenerateFileNameTest()
        {
            Assert.AreEqual("Steam", instance.GenerateFileName("steam"));
            Assert.AreEqual("Steam", instance.GenerateFileName("https://www.Steam.com/"));
            Assert.AreEqual("Steam", instance.GenerateFileName("https://www.Steam.com/abc"));
            Assert.AreEqual("App-431960-Workshop", instance.GenerateFileName("https://steamcommunity.com/app/431960/workshop/"));
            Assert.AreEqual("App-431960-abc", instance.GenerateFileName("https://steamcommunity.com/app/431960/abc/"));
            Assert.AreEqual("Sharedfiles-id=11112222", instance.GenerateFileName("https://steamcommunity.com/sharedfiles/filedetails/?id=11112222"));
            Assert.AreEqual("Search-term=abc", instance.GenerateFileName("https://store.steampowered.com/search/?term=abc"));
        }
    }
}