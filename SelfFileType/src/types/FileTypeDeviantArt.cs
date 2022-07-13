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
    public class FileTypeDeviantArt : FileTypeBaseSite
    {
        public override string Description()
        {
            return @"
deviantart, DeviantArt（简称：DA），是一个为艺术家展示各自作品、并交流讨论而设计的社交网路服务网站。
";
        }

        public override string ExtensionName()
        {
            return ".deviantart";
        }

        public override string Icon()
        {
            return "deviantart.ico";
        }


        public override bool MatchingURL(string url)
        {
            return url.Contains("deviantart.com");
        }

        public override string GenerateFileName(string url)
        {
            string name = "DeviantArt";
            if (MatchingURL(url))
            {
                url = FormattingURL(url);
                var sArr = url.Split('/');

                if (url.Contains("/art/"))
                {
                    name = sArr[sArr.Length - 1];
                    if (name.Contains("?"))
                    {
                        name = name.Split('?')[0];
                    }
                }
                else if (url.Contains("/search?"))
                {
                    name = "Search-" + url.Split('?')[1];
                }
                else if (sArr.Length == 2)
                {
                    var s = sArr[sArr.Length - 1];
                    if (MatchingURL(s) == false)
                    {
                        name = s;
                    }
                }
            }
            return name;
        }
    }
}
