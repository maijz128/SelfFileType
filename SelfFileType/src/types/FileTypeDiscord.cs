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
    public class FileTypeDiscord : FileTypeBaseSite
    {
        public override string Description()
        {
            return @"
discord, Discord 是通过语音、视频和文本进行交谈的最简单方式。与您的朋友和社区交谈、聊天、闲逛并保持密切联系。
";
        }

        public override string ExtensionName()
        {
            return ".discord";
        }

        public override string Icon()
        {
            return "discord.ico";
        }


        public override bool MatchingURL(string url)
        {
            return url.Contains("discord.com");
        }

        public override string GenerateFileName(string url)
        {
            string name = "Discord";
            if (MatchingURL(url))
            {
                url = FormattingURL(url);
                if (url.Contains("/channels/"))
                {
                    name = url.Split('/')[2];
                    if (name.Contains("?"))
                    {
                        name = name.Split('?')[0];
                    }
                }
            }
            return name;
        }
    }
}
