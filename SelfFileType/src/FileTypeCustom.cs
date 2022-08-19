using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SelfFileType.src.types;

namespace SelfFileType.src
{
    public class FileTypeCustom : FileTypeBaseSite
    {
        public string CustomDescription { get; set; }
        public string CustomExtensionName { get; set; }
        public string CustomIcon { get; set; }
        public List<string> CustomUrls { get; set; }

        public override string Description()
        {
            return CustomDescription;
        }

        public override string ExtensionName()
        {
            return CustomExtensionName;
        }

        public override string Icon()
        {
            return CustomIcon;
        }

        public override bool MatchingURL(string url)
        {
            if (CustomUrls == null) return false;
            foreach (var item in CustomUrls)
            {
                if (url.Contains(item))
                {
                    return true;
                }
            }
            return false;
        }

        public override string GenerateFileName(string url)
        {
            string name = base.GenerateFileName(url);
            
            return name;
        }
    }
}
