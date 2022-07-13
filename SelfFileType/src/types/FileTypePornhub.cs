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
    public class FileTypePornhub : FileTypeBaseSite
    {
        public override string Description()
        {
            return @"
pornhub, 免费色情视频及性爱影片 – A片，X级，色情片分享网站 | Pornhub
";
        }

        public override string ExtensionName()
        {
            return ".pornhub";
        }

        public override string Icon()
        {
            return "pornhub.ico";
        }


        public override bool MatchingURL(string url)
        {
            return url.Contains("pornhub.com");
        }

        public override string GenerateFileName(string url)
        {
            string name = "Pornhub";
            if (MatchingURL(url))
            {
                url = FormattingURL(url);
                var sArr = url.Split('/');

                if (url.Contains("?viewkey="))
                {
                    name = url.Split('?')[1];
                }
                else if (url.Contains("/model/"))
                {
                    name = sArr[2];
                }
                else if (url.Contains("/search?"))
                {
                    name = url.Split('?')[1];
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
