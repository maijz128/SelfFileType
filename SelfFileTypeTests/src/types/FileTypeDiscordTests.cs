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
    public class FileTypeDiscordTests
    {
        FileTypeBaseSite instance = new FileTypeDiscord();

        [TestMethod()]
        public void GenerateFileNameTest()
        {
            Assert.AreEqual("Discord", instance.GenerateFileName("Discord"));
            Assert.AreEqual("Discord", instance.GenerateFileName("https://www.discord.com/"));
            Assert.AreEqual("Discord", instance.GenerateFileName("https://www.discord.com/abc"));
            Assert.AreEqual("97830747673222222", instance.GenerateFileName("https://discord.com/channels/97830747673222222/978307507065864111"));
        }
    }
}