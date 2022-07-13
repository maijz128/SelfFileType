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
    class FileTypeGitHub : FileTypeBaseSite
    {
        public override string Description()
        {
            return @"
github, GitHub是一个面向开源及私有软件项目的托管平台。
";
        }

        public override string ExtensionName()
        {
            return ".github";
        }

        public override string Icon()
        {
            return "github.ico";
        }

        public override bool MatchingURL(string url)
        {
            return url.Contains("github.com");
        }

        public override string GenerateFileName(string url)
        {
            string name = "github";
            if (MatchingURL(url))
            {
                url = FormattingURL(url);
                if (url.Contains("/"))
                {
                    var user_name = url.Split('/')[1];
                    var project_name = url.Split('/')[2];
                    name = project_name + " _by_ " + user_name;
                }
            }
            return name;
        }
    }
}
