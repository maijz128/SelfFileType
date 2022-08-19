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
            get { return mFileTypes.Count; }
        }

        public IEnumerable<FileType> FileTypes { get { return mFileTypes; } }


        List<FileType> mFileTypes;


        public FileTypeManager()
        {
            mFileTypes = new List<FileType>();

            Init();
        }


        public void handle(string file)
        {

            foreach (var item in mFileTypes)
            {
                if (item.Matching(file))
                {
                    item.Run(file);
                    break;
                }
            }
        }

        void Init()
        {

            var siteType = new FileTypeSite();
            mFileTypes.Add(siteType);
            mFileTypes.AddRange(siteType.SiteFileTypes);
        }
    }
}
