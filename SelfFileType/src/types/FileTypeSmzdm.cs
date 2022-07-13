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
    public class FileTypeSmzdm : FileTypeBaseSite
    {
        public override string Description()
        {
            return @"
smzdm, 什么值得买 | 品质消费网站_网购决策中立门户
";
        }

        public override string ExtensionName()
        {
            return ".smzdm";
        }

        public override string Icon()
        {
            return "smzdm.ico";
        }


        public override bool MatchingURL(string url)
        {
            return url.Contains("smzdm.com");
        }

        public override string GenerateFileName(string url)
        {
            string name = "什么值得买";
            if (MatchingURL(url))
            {
                url = FormattingURL(url);
                var sArr = url.Split('/');

                if (url.Contains("/p/"))
                {
                    name = sArr[2];
                    if (name.Contains("?"))
                    {
                        name = name.Split('?')[0];
                    }
                    name = "Post-" + name;
                }
                else if (url.Contains("search") && url.Contains("&s="))
                {
                    //name = url.Split('?')[1];
                    name = "Search";
                }
            }
            return name;
        }
    }
}
