using SelfFileType.ClassLib;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SelfFileType.src.types
{
    public class FileTypeZhihu : FileTypeBaseSite
    {
        public override string Description()
        {
            return @"
zhihu, 知乎 - 有问题，就会有答案
";
        }

        public override string ExtensionName()
        {
            return ".zhihu";
        }

        public override string Icon()
        {
            return "zhihu.ico";
        }


        public override bool MatchingURL(string url)
        {
            return url.Contains("zhihu.com");
        }

        public override string GenerateFileName(string url)
        {
            string name = "ZhiHu";
            if (MatchingURL(url))
            {
                url = FormattingURL(url);

                if (url.Contains("/question/"))
                {
                    name = url.Split('/')[2];
                    name = "question_" + name;
                    if (url.Contains("/answer/"))
                    {
                        name += "_answer_" + url.Split('/')[4];
                    }
                }
                else if (url.Contains("/p/"))
                {
                    name = "p_" + url.Split('/')[2];
                }
                else if (url.Contains("/people/"))
                {
                    name = url.Split('/')[2];
                }

                if (name.Contains("?"))
                {
                    name = name.Split('?')[0];
                }
            }
            return name;
        }
    }
}
