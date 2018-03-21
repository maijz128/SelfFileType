using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

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
                Console.Out.WriteLine(args.Length);

                new ClassLib.LogUtil("log.txt").WriteLine(args);

                var fileTypeManager = new SelfFileType.src.FileTypeManager();
                foreach (var item in args)
                {
                    fileTypeManager.handle(item);
                }
            }
            else
            {
                Application.Run(new Form1());
            }

        }
    }
}
