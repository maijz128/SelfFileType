using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SelfFileType.src.types
{
    interface FileType
    {
        string ExtensionName();

        string Icon();

        string Description();

        /**
         * 是否出现在文件夹右键新建菜单
         */
        bool ShellNew();
        /**
         * 右键新建的模版内容
         */
        string ShellNewTemplate();


        bool Matching(string file);

        string Run(string file);

    }
}
