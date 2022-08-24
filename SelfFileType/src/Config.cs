using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SelfFileType.src
{
    public class Config
    {
        public static Config Instance { 
            get
            {
                if (mInstance == null)
                {
                    mInstance = new Config();
                }
                return mInstance;
            }
        }
        private static Config mInstance;


        public string GetIconFolder()
        {
            var appFolder = System.AppDomain.CurrentDomain.BaseDirectory;
            var iconFolder = "icon";
            return Path.Combine(appFolder, iconFolder);
        }

        public string GetCustomFolder()
        {
            var appFolder = System.AppDomain.CurrentDomain.BaseDirectory;
            var iconFolder = "custom";
            return Path.Combine(appFolder, iconFolder);
        }
    }
}
