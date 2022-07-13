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
    class FileTypeBangumi : FileTypeBaseSite
    {
        public override string Description()
        {
            return @"
bangumi, Bangumi 番组计划
";
        }

        public override string ExtensionName()
        {
            return ".bangumi";
        }

        public override string Icon()
        {
            return "bangumi.ico";
        }


        public override bool MatchingURL(string url)
        {
            return url.Contains("bangumi.tv");
        }

        public override string GenerateFileName(string url)
        {
            string name = "bgm.tv";
            if (MatchingURL(url))
            {
                url = FormattingURL(url);
                if (url.Contains("/subject/"))
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

        public override string Run(string file)
        {
            StringBuilder outputLog = new StringBuilder();
            if (File.Exists(file))
            {
                bool hasContent = false;
                string aLine;
                StreamReader strReader = new StreamReader(file);
                do
                {
                    aLine = strReader.ReadLine();
                    if (!string.IsNullOrWhiteSpace(aLine))
                    {
                        Console.Out.WriteLine(aLine);
                        hasContent = true;
                    }
                } while (aLine != null);
                strReader.Close();

                // 没有内容就打开编辑
                if (!hasContent)
                {
                    // 如果剪贴板内容是URL，就写入剪贴板内容。
                    if (WriteURL(file) == false)
                    {
                        //EditFile(file);
                    }
                }
                OpenBrowser(file);

            }
            return outputLog.ToString();
        }


        void OpenBrowser(string file)
        {
            //调用系统默认的浏览器   
            var aLine = "https://bangumi.tv/subject/";
            FileInfo fileInfo = new FileInfo(file);
            aLine += fileInfo.Name.Replace(ExtensionName(), "");
            System.Diagnostics.Process.Start(aLine);
        }
    }
}
