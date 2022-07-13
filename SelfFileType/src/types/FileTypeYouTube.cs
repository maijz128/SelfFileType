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
    public class FileTypeYouTube : FileTypeBaseSite
    {
        public override string Description()
        {
            return @"
youtube, 在YouTube 上盡情享受自己喜愛的影片和音樂、上傳原創內容，並與親朋好友和全世界觀眾分享你的影片。
";
        }

        public override string ExtensionName()
        {
            return ".youtube";
        }

        public override string Icon()
        {
            return "youtube.ico";
        }


        public override bool MatchingURL(string url)
        {
            return url.Contains("youtube.com");
        }

        public override string GenerateFileName(string url)
        {
            string name = "YouTube";
            if (MatchingURL(url))
            {
                url = FormattingURL(url);
                var sArr = url.Split('/');

                if (url.Contains("/c/"))
                {
                    name = sArr[sArr.Length - 1];
                    if (name.Contains("?"))
                    {
                        name = name.Split('?')[0];
                    }
                }
                else if (url.Contains("/watch?"))
                {
                    name = "Watch-" + url.Split('?')[1];
                }
            }
            return name;
        }
    }
}
