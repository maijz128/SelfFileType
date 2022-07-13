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
    public class FileTypeTaoBao: FileTypeBaseSite
    {
        public override string Description()
        {
            return @"
taobao, 淘宝网 - 淘！我喜欢
";
        }

        public override string ExtensionName()
        {
            return ".taobao";
        }

        public override string Icon()
        {
            return "taobao.ico";
        }

        public override bool MatchingURL(string url)
        {
            return url.Contains("taobao.com") || 
                url.Contains("tmall.com");
        }

        public override string GenerateFileName(string url)
        {
            string name = "TaoBao";
            if (MatchingURL(url))
            {
                //url = FormattingURL(url);

                if (url.Contains("tmall.com"))
                {
                    name = "TMALL"; 
                }

                Uri myUri = new Uri(url);

                if (url.Contains("/item.htm"))
                {
                    string param1 = HttpUtility.ParseQueryString(myUri.Query).Get("id");
                    name = "Item-id=" + param1;

                }
            }
            return name;
        }
    }
}
