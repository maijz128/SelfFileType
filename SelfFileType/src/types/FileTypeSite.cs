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
    class FileTypeSite : FileType
    {
        public string Description()
        {
            return @"
site, 使用默认浏览器打开所有URL (&E)
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

        public string Run(string file)
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
                    if (GitHub(file) == false && WriteURL(file) == false)
                    {
                        EditFile(file);
                    }
                }
            }
            return outputLog.ToString();
        }


        void EditFile(string file)
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

        bool GitHub(string file)
        {
            string str = Clipboard.GetText();
            //string str = "https://github.com/maijz128";
            if (str != null)
            {
                if (str.Contains("github.com"))
                {
                    using (StreamWriter outfile = new StreamWriter(file))
                    {
                        outfile.Write(str);
                    }
                    RenameFile(file, "GitHub");
                    return true;
                }

            }
            return false;
        }

        bool WriteURL(string file)
        {
            string str = Clipboard.GetText();
            if (!string.IsNullOrWhiteSpace(str))
            {
                if (IsUrl(str))
                {
                    using (StreamWriter outfile = new StreamWriter(file))
                    {
                        outfile.Write(str);
                    }

                    var name = str.Replace("\\", "/");
                    name = name.Replace("http://", "");
                    name = name.Replace("https://", "");
                    name = name.Replace("www.", "");
                    name = name.Split('/')[0];
                    RenameFile(file, name);
                    return true;
                }
            }
            
            return false;
        }


        void RenameFile(string file, string newFileName)
        {
            FileInfo fileInfo = new FileInfo(file);
            string dirName = fileInfo.DirectoryName;
            string extension = fileInfo.Extension;
            string newFile = Path.Combine(dirName, newFileName + extension);
            if (File.Exists(newFile))
            {
                // "文件夹中存在此名称文件，请更改文件名。"
            }
            else
            {
                fileInfo.MoveTo(newFile);
            }
        }

        bool isSite(string line)
        {
            string line_format = line.Trim().ToLower();
            return line_format.StartsWith("http://") || line_format.StartsWith("https://");
        }

        bool isDiskPath(string line)
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
            try
            {
                string Url = @"^http(s)?://([\w-]+\.)+[\w-]+(/[\w- ./?%&=]*)?$";
                return Regex.IsMatch(str, Url);
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public bool ShellNew()
        {
            return true;
        }

        public string ShellNewTemplate()
        {
            return "";
        }
    }
}
