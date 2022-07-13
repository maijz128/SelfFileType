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
    class FileTypeTwitter : FileTypeBaseSite
    {
        public override string Description()
        {
            return @"
twitter, Twitter（推特）是一家美国社交网络及微博客服务的公司，致力于服务公众对话。
";
        }

        public override string ExtensionName()
        {
            return ".twitter";
        }

        public override string Icon()
        {
            return "twitter.ico";
        }

        public override bool MatchingURL(string url)
        {
            return url.Contains("twitter.com");
        }

        public override string GenerateFileName(string url)
        {
            string name = "twitter";
            if (MatchingURL(url))
            {
                url = FormattingURL(url);
                if (url.Contains("/status/"))
                {
                    name = url.Split('/')[3];
                    if (name.Contains("?"))
                    {
                        name = name.Split('?')[0];
                    }
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
