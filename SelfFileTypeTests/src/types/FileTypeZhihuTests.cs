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
    public class FileTypeZhihuTests
    {
        FileTypeBaseSite instance = new FileTypeZhihu();
        [TestMethod()]
        public void GenerateFileNameTest()
        {
            Assert.AreEqual("ZhiHu", instance.GenerateFileName("ZhiHuaa"));
            Assert.AreEqual("ZhiHu", instance.GenerateFileName("https://www.zhihu.com/"));
            Assert.AreEqual("ZhiHu", instance.GenerateFileName("https://www.zhihu.com/abc"));
            Assert.AreEqual("question_1111", instance.GenerateFileName("https://www.zhihu.com/question/1111"));
            Assert.AreEqual("question_1111_answer_2222", instance.GenerateFileName("https://www.zhihu.com/question/1111/answer/2222"));
            Assert.AreEqual("user_abc", instance.GenerateFileName("https://www.zhihu.com/people/user_abc"));
            Assert.AreEqual("p_12345", instance.GenerateFileName("https://abc.zhihu.com/p/12345"));
        }
    }
}