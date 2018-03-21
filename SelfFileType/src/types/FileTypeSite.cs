using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SelfFileType.src.types
{
    class FileTypeSite : FileType
    {
        public string Description()
        {
            return @"
*.site

格式：文本

内容：每一行都只能为URL

运行：使用默认浏览器打开所有URL

";
        }

        public string ExtensionName()
        {
            return ".site";
        }

        public string Icon()
        {
            return "browser.ico";
        }

        public bool Matching(string file)
        {
            return Path.GetExtension(file) == ExtensionName();
        }

        public void Run(string file)
        {
            if (File.Exists(file))
            {
                string aLine;
                StreamReader strReader = new StreamReader(file);
                while (true)
                {
                    aLine = strReader.ReadLine();
                    if (aLine != null)
                    {
                        Console.Out.WriteLine(aLine);
                        //调用系统默认的浏览器   
                        System.Diagnostics.Process.Start( aLine);
                    }
                    else
                    {
                        break;
                    }
                }

            }
        }
    }
}
