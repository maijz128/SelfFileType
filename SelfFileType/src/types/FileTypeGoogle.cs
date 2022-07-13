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
    class FileTypeGoogle : FileTypeBaseSite
    {
        public override string Description()
        {
            return @"
google, Google - 搜索。
";
        }

        public override string ExtensionName()
        {
            return ".google";
        }

        public override string Icon()
        {
            return "google.ico";
        }

        public override bool MatchingURL(string url)
        {
            return url.Contains("google.com");
        }

        public override string GenerateFileName(string url)
        {
            string name = "Google";
            if (MatchingURL(url))
            {
                url = FormattingURL(url);
                if (url.Contains("?q="))
                {
                    name = url.Split('=')[1];
                    if (name.Contains("&"))
                    {
                        name = name.Split('&')[0];
                    }
                }
            }
            return name;
        }
    }
}
