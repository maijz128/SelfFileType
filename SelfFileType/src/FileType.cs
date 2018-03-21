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

        bool Matching(string file);

        void Run(string file);

    }
}
