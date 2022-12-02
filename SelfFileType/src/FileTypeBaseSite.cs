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
    public abstract class FileTypeBaseSite : FileType
    {
        public virtual string Description()
        {
            return @"
site, 使用默认浏览器打开所有URL (&E)
";
        }

        public virtual string ExtensionName()
        {
            return ".site";
        }

        public virtual string Icon()
        {
            return "browser.ico";
        }

        public virtual bool Matching(string file)
        {
            return Path.GetExtension(file) == ExtensionName();
        }

        public virtual bool MatchingURL(string url)
        {
            return url.Contains(ExtensionName());
        }

        public virtual string Run(string file)
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

                        if (isSite(aLine))
                        {
                            //调用系统默认的浏览器   
                            System.Diagnostics.Process.Start(aLine);
                            outputLog.AppendLine("open " + aLine);
                        }
                        else if (isDiskPath(aLine))
                        {
                            System.Diagnostics.Process.Start(aLine);
                        }
                        else
                        {
                            string output;
                            CmdHelper.RunCmd(aLine, out output);
                            outputLog.AppendLine(output);
                        }
                    }
                } while (aLine != null);
                strReader.Close();

                // 没有内容就打开编辑
                if (!hasContent)
                {
                    // 如果剪贴板内容是URL，就写入剪贴板内容。
                    if (WriteURL(file) == false)
                    {
                        EditFile(file);
                    }
                }
            }
            return outputLog.ToString();
        }


        public virtual string GenerateFileName(string url)
        {
            var name = "";
            name = FormattingURL(url);
            name = name.Split('/')[0];
            return name;
        }

        public string FormattingURL(string url)
        {
            var name = "";
            name = url.Replace("\\", "/");
            name = name.Replace("http://", "");
            name = name.Replace("https://", "");
            name = name.Replace("www.", "");
            // 去掉末尾 '/' 字符
            if (name.EndsWith("/"))    
            {
                name = name.Substring(0, name.Length - 1);
            }
            return name;
        }

        protected void EditFile(string file)
        {
            //var fileTypeRegInfo = FileTypeRegister.GetFileTypeRegInfo(".txt");
            //if (fileTypeRegInfo != null)
            //{
            //    var exePath = fileTypeRegInfo.ExePath;
            //    
            //}
            var process = Process.Start("notepad++.exe", "\"" + file + "\"");
            if (process == null)
            {
                System.Diagnostics.Process.Start("NOTEPAD.EXE", "\"" + file + "\"");
            }
        }

        protected virtual bool WriteURL(string file)
        {
            string str = Clipboard.GetText();
            if (!string.IsNullOrWhiteSpace(str))
            {
                var url = str.Trim();
                if (IsUrl(url))
                {
                    using (StreamWriter outfile = new StreamWriter(file))
                    {
                        outfile.Write(url);
                    }

                    var name = GenerateFileName(url); 
                    RenameFile(file, name);
                    return true;
                }
            }
            
            return false;
        }

        protected virtual bool Write(string file)
        {
            string str = Clipboard.GetText();
            if (!string.IsNullOrWhiteSpace(str))
            {
                var url = str.Trim();
                using (StreamWriter outfile = new StreamWriter(file))
                {
                    outfile.Write(url);
                }

                var name = GenerateFileName(url);
                RenameFile(file, name);
                return true;
            }

            return false;
        }


        protected void RenameFile(string file, string newFileName, string extension = null)
        {
            FileInfo fileInfo = new FileInfo(file);
            string dirName = fileInfo.DirectoryName;
            newFileName = newFileName.Replace("/", ".");
            if (extension == null)
            {
                extension = fileInfo.Extension;
            }
            string newFile = Path.Combine(dirName, newFileName + extension);
            if (File.Exists(newFile))
            {
                // "文件夹中存在此名称文件，请更改文件名。"
                Console.WriteLine("Error: Rename File (文件夹中存在此名称文件，请更改文件名。) - " + newFile);

                var guid = System.Guid.NewGuid().ToString().Split('-')[0];
                newFile = Path.Combine(dirName, newFileName + $" ({guid})" + extension);
            }

            Console.WriteLine("Rename File: " + newFile);
            Logger.Instance.WriteLine("Rename File: " + newFile);
            fileInfo.MoveTo(newFile);
        }

        protected bool isSite(string line)
        {
            string line_format = line.Trim().ToLower();
            return line_format.StartsWith("http://") || line_format.StartsWith("https://");
        }

        protected bool isDiskPath(string line)
        {
            var pattern = @"[a-zA-Z]:(\\([0-9a-zA-Z]+))+|(\/([0-9a-zA-Z]+))+";
            var result = Regex.Match(line, pattern);
            return result.Success;
        }

        /// <summary>
        /// 判断一个字符串是否为url
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static bool IsUrl(string str)
        {
            str = str.Trim();
            str = str.Split('?')[0];
            try
            {
                string Url = @"^http(s)?://([\w-]+\.)+[\w-]+(/[\w- ./?%&=]*)?$";
                return Regex.IsMatch(str, Url);
            }
            catch (Exception)
            {
                return false;
            }
        }

        /// <summary>
        /// 是否出现在右键新建菜单
        /// </summary>
        /// <returns></returns>
        public virtual bool ShellNew()
        {
            return false;
        }

        public virtual string ShellNewTemplate()
        {
            return "";
        }
    }
}
