using System;
using System.Collections.Generic;
using System.IO;
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

                var logFileName = AppDomain.CurrentDomain.BaseDirectory + "/log.txt";
                // var logFile = new ClassLib.LogUtil(logFileName);
                var logWriter = new StreamWriter(logFileName);
                logWriter.AutoFlush = true; 
                Console.SetOut(logWriter);


                Console.WriteLine(args);

                var fileTypeManager = new SelfFileType.src.FileTypeManager();
                try
                {
                    foreach (var item in args)
                    {
                        fileTypeManager.handle(item);
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.ToString());
                }

            }
            else
            {
                Application.Run(new Form1());
            }

        }
    }
}
