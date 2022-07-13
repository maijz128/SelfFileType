﻿using SelfFileType.ClassLib;
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
    class FileTypeSite : FileTypeBaseSite
    {
        public List<FileTypeBaseSite> SiteFileTypes { get; private set; }

        public override string Description()
        {
            return @"
site, 使用默认浏览器打开所有URL (&E)
";
        }

        public override string ExtensionName()
        {
            return ".site";
        }

        public override string Icon()
        {
            return "browser.ico";
        }

        public override bool ShellNew()
        {
            return true;
        }

        public FileTypeSite()
        {
            this.SiteFileTypes = new List<FileTypeBaseSite>() {
                new FileTypeArtstation(),
                new FileTypeBangumi(),
                new FileTypeBilibili(),
                new FileTypeDeviantArt(),
                new FileTypeDiscord(),
                new FileTypeGitHub(),
                new FileTypeGoogle(),
                new FileTypePatreon(),
                new FileTypePixiv(),
                new FileTypePornhub(),
                new FileTypeSankakucomplex(),
                new FileTypeSmzdm(),
                new FileTypeSteam(),
                new FileTypeTaoBao(),
                new FileTypeTwitter(),
                new FileTypeYouTube(),
                new FileTypeZhihu(),
            };
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

        protected override bool WriteURL(string file)
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

                    string extension = null;
                    string name = null;


                    foreach (var item in this.SiteFileTypes)
                    {
                        if (item.MatchingURL(url))
                        {
                            name = item.GenerateFileName(url);
                            extension = item.ExtensionName();
                            break;
                        }
                    }


                    if (name == null)
                    {
                        name = FormattingURL(url);
                        name = name.Split('/')[0];
                    }

                    RenameFile(file, name, extension);
                    return true;
                }
            }
            
            return false;
        }



    }
}
