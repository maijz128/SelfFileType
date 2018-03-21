using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace SelfFileType.ClassLib
{
    class LogUtil
    {

        string _File;

        public LogUtil(string file)
        {
            _File = file;
        }

        public void WriteLine(string line)
        {
            WriteLine(new string[] { line });
        }

        public void WriteLine(string[] lines)
        {
            using (StreamWriter writer = new StreamWriter(_File))
            {
                foreach (var line in lines)
                {
                    writer.WriteLine(line);
                }
            }
        }
    }
}
