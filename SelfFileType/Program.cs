using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using SelfFileType.src;

namespace SelfFileType
{
    static class Program
    {
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main(string[] args)
        {

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);


            if (args != null && args.Length > 0)
            {
                Logger.Instance.WriteLine(args);

                var fileTypeManager = new FileTypeManager();
                try
                {
                    foreach (var item in args)
                    {
                        fileTypeManager.handle(item);
                    }
                }
                catch (Exception e)
                {
                    Logger.Instance.WriteLine(e.ToString());
                }

            }
            else
            {
                Application.Run(new Form1());
            }

        }
    }
}
