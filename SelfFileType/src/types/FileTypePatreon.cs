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
    class FileTypePatreon : FileTypeBaseSite
    {
        public override string Description()
        {
            return @"
patreon, Patreon是一個供內容建立者進行群眾募資的平台。它讓創作者向贊助者以每件作品或定期取得資金。
";
        }

        public override string ExtensionName()
        {
            return ".patreon";
        }

        public override string Icon()
        {
            return "patreon.ico";
        }

        public override bool MatchingURL(string url)
        {
            return url.Contains("patreon.com");
        }

        public override string GenerateFileName(string url)
        {
            string name = "patreon";
            if (MatchingURL(url))
            {
                url = FormattingURL(url);
                if (url.Contains("/posts/"))
                {
                    name = url.Split('/')[2];
                }
                else if (url.Contains("/user?u="))
                {
                    name = url.Split('=')[1];
                }
                else if (url.Contains("/"))
                {
                    name = url.Split('/')[1];
                }
            }
            return name;
        }
    }
}
