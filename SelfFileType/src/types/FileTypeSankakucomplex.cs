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
    public class FileTypeSankakucomplex : FileTypeBaseSite
    {
        public override string Description()
        {
            return @"
sankakucomplex, Sankaku Channel - 动画，漫画 & 游戏相关的图片 & 视频
";
        }

        public override string ExtensionName()
        {
            return ".sankakucomplex";
        }

        public override string Icon()
        {
            return "sankakucomplex.ico";
        }


        public override bool MatchingURL(string url)
        {
            return url.Contains("sankakucomplex.com");
        }

        public override string GenerateFileName(string url)
        {
            string name = "Sankaku Channel";
            if (MatchingURL(url))
            {
                url = FormattingURL(url);
                var sArr = url.Split('/');

                if (url.Contains("/post/show/"))
                {
                    name = sArr[sArr.Length - 1];
                    if (name.Contains("?"))
                    {
                        name = name.Split('?')[0];
                    }
                    name = "Post-" + name;
                }
                else if (url.Contains("?tags="))
                {
                    name = url.Split('?')[1];
                }
            }
            return name;
        }
    }
}
