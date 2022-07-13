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
    public class FileTypeArtstation : FileTypeBaseSite
    {
        public override string Description()
        {
            return @"
artstation, ArtStation是综合CG视觉艺术网站，为用户展示图片、视频、模型等CG设计作品。
";
        }

        public override string ExtensionName()
        {
            return ".artstation";
        }

        public override string Icon()
        {
            return "artstation.ico";
        }


        public override bool MatchingURL(string url)
        {
            return url.Contains("artstation.com");
        }

        public override string GenerateFileName(string url)
        {
            string name = "ArtStation";
            if (MatchingURL(url))
            {
                url = FormattingURL(url);
                var sArr = url.Split('/');

                if (url.Contains("/artwork/"))
                {
                    name = sArr[sArr.Length - 1];
                    if (name.Contains("?"))
                    {
                        name = name.Split('?')[0];
                    }
                    name = "Artwork-" + name;
                }
                else if (url.Contains("/search?"))
                {
                    name = "Search-" + url.Split('?')[1];
                }
                else if (sArr.Length == 1)
                {
                    if (sArr[sArr.Length - 1] != "artstation.com")
                    {
                        name = sArr[sArr.Length - 1];
                    }
                }
            }
            return name;
        }
    }
}
