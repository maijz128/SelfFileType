using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace SelfFileType.src.Tests
{
    [TestClass()]
    public class FileTypeCustomLuaTests
    {
        [TestMethod()]
        public void LuaStringTest()
        {
            string luaStr = @"
            function Icon() return 'docker.ico'; end
            function CustomFileName(url) return 'docker'; end
            ";

            var env = FileTypeCustomLua.BuildLuaEnv(luaStr);
            Assert.AreEqual(true, env.Icon != null);
            string cfn = env.CustomFileName("http://docker.com");
            Assert.AreEqual("docker", cfn);
            Assert.AreEqual(true, FileTypeCustomLua.TestLua(luaStr));

        }

        [TestMethod()]
        public void BuildForLuaStringTest()
        {
            
            string luaStr = @"
            function Description()
                return
                    'Docker 是一个开源的应用容器引擎，基于 Go 语言 并遵从 Apache2.0 协议开源。';
            end
            function ExtensionName() return '.docker'; end
            function Icon() return 'docker.ico'; end
            function Urls() return {'docker.com'}; end 
            
            ";

            var ftc = FileTypeCustomLua.BuildForLuaString(luaStr);

            Assert.AreEqual(".docker", ftc.CustomExtensionName);
            Assert.AreEqual("docker.ico", ftc.CustomIcon);
            Assert.AreEqual("docker.com", ftc.CustomUrls[0]);

            Assert.AreEqual("docker.com", ftc.GenerateFileName("http://www.docker.com"));
        }
    }
}