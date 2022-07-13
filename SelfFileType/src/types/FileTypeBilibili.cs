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
    public class FileTypeBilibili : FileTypeBaseSite
    {
        public override string Description()
        {
            return @"
bilibili, 哔哩哔哩弹幕视频网 - ( ゜- ゜)つロ 乾杯~
";
        }

        public override string ExtensionName()
        {
            return ".bilibili";
        }

        public override string Icon()
        {
            return "bilibili.ico";
        }


        public override bool MatchingURL(string url)
        {
            return url.Contains("bilibili.com");
        }

        public override string GenerateFileName(string url)
        {
            string name = "bilibili";
            if (MatchingURL(url))
            {
                url = FormattingURL(url);

                if (url.Contains("/video/"))
                {
                    name = url.Split('/')[2];
                }
                else if (url.Contains("/read/cv"))
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
