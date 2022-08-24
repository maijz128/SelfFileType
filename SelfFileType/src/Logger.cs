using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SelfFileType.src
{
    public class Logger
    {
        public static Logger Instance
        {
            get
            {
                if (mInstance == null)
                {
                    mInstance = new Logger();
                }
                return mInstance;
            }
        }
        private static Logger mInstance;
        private static StreamWriter logWriter;

        public Logger()
        {
            var logFileName = AppDomain.CurrentDomain.BaseDirectory + "/log.txt";
            // var logFile = new ClassLib.LogUtil(logFileName);
            logWriter = new StreamWriter(logFileName);
            logWriter.AutoFlush = true;
            //Console.SetOut(logWriter);

        }

        public void WriteLine(object obj)
        {
            Console.WriteLine(obj);
            logWriter.WriteLine(obj);
        }

        public void WriteLine(string[] strs)
        {
            Console.WriteLine(strs);
            logWriter.WriteLine(strs);
        }
    }
}
