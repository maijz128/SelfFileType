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
    class FileTypePixiv : FileTypeBaseSite
    {
        public override string Description()
        {
            return @"
pixiv, Pixiv是一个以插图、漫画和小说、艺术为中心的社交网络服务里的虚拟社区网站。
";
        }

        public override string ExtensionName()
        {
            return ".pixiv";
        }

        public override string Icon()
        {
            return "pixiv.ico";
        }

        public override bool MatchingURL(string url)
        {
            return url.Contains("pixiv.net");
        }

        public override string GenerateFileName(string url)
        {
            string name = "pixiv";
            if (MatchingURL(url))
            {
                url = FormattingURL(url);
                if (url.Contains("/artworks/"))
                {
                    name = url.Split('/')[2];
                }
                else if (url.Contains("/users/"))
                {
                    name = "User - " + url.Split('/')[2];
                }
            }
            return name;
        }
    }
}
