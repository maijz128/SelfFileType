using SelfFileType.ClassLib;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Web;
using System.Windows.Forms;

namespace SelfFileType.src.types
{
    public class FileTypeSteam: FileTypeBaseSite
    {
        public override string Description()
        {
            return @"
steam, Steam是Valve推出的电子游戏数字发行服务平台。
";
        }

        public override string ExtensionName()
        {
            return ".steam";
        }

        public override string Icon()
        {
            return "steam.ico";
        }

        public override bool MatchingURL(string url)
        {
            return url.Contains("steamcommunity.com") || 
                url.Contains("steampowered.com");
        }

        public override string GenerateFileName(string url)
        {
            string name = "Steam";
            if (MatchingURL(url))
            {
                Uri myUri = new Uri(url);
                url = FormattingURL(url);
                var sArr = url.Split('/');


                if (url.Contains("/app/"))
                {
                    name = "App-" + sArr[2];
                    if (url.Contains("/workshop"))
                    {
                        name = name + "-Workshop"; 
                    }
                    else if (sArr.Length == 4)
                    {
                        name = name + "-" + sArr[3];
                    }
                }
                else if (url.Contains("/sharedfiles/"))
                {
                    string id = HttpUtility.ParseQueryString(myUri.Query).Get("id");
                    name = "Sharedfiles-id=" + id;
                }
                else if (url.Contains("/search/"))
                {
                    name = "Search-" + url.Split('?')[1];
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
