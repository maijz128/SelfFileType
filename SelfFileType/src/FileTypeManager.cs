using SelfFileType.src.types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SelfFileType.src
{
    class FileTypeManager
    {
        public int Count
        {
            get { return _FileTypes.Count; }
        }

        public IEnumerable<FileType> FileTypes { get { return _FileTypes; } }


        List<FileType> _FileTypes;


        public FileTypeManager()
        {
            _FileTypes = new List<FileType>();

            Init();
        }


        public void handle(string file)
        {
            foreach (var item in _FileTypes)
            {
                if (item.Matching(file))
                {
                    item.Run(file);
                }
            }
        }

        void Init()
        {
            _FileTypes.Add(new FileTypeSite());

        }
    }
}
