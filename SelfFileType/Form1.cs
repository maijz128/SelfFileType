using SelfFileType.ClassLib;
using SelfFileType.src;
using SelfFileType.src.types;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SelfFileType
{
    public partial class Form1 : Form
    {
        FileTypeManager _FileTypeManager;
        public Form1()
        {
            InitializeComponent();
            Init();
        }

        void Init()
        {
            _FileTypeManager = new FileTypeManager();

            this.tabControl1.Controls.Clear();

            ImageList myImages = new ImageList();
            tabControl1.ImageList = myImages;

            var iconFolder = System.AppDomain.CurrentDomain.BaseDirectory + @"\icon\";

            int i = 0;
            foreach (var item in _FileTypeManager.FileTypes)
            {

                var tabPage = new System.Windows.Forms.TabPage()
                {
                    Text = item.ExtensionName(),
                    Tag = item
                };

                string imageToLoad = iconFolder + item.Icon();
                myImages.Images.Add(Image.FromFile(imageToLoad));

                this.tabControl1.Controls.Add(tabPage);

                tabPage.ImageIndex = i;
                i++;
            }


            ShowDescription();


            

            
        }


        FileType CurrentFileType()
        {
            try
            {
                return (FileType)this.tabControl1.SelectedTab.Tag;
            }
            catch (Exception)
            {
                return null;
            }
        }

        void ShowDescription()
        {
            var fileType = CurrentFileType();
            if (fileType != null)
            {
                this.richTextBox_Desc.Text = fileType.Description();
            }
        }

        void Register(FileType fileType)
        {
            var iconFolder = System.AppDomain.CurrentDomain.BaseDirectory + @"\icon\";

            var extname = fileType.ExtensionName(); // 例子：".osf"
            if (!FileTypeRegister.FileTypeRegistered(extname))
            {
                FileTypeRegInfo fileTypeRegInfo = new FileTypeRegInfo(extname);
                fileTypeRegInfo.Description = fileType.Description();
                fileTypeRegInfo.ExePath = Application.ExecutablePath;
                fileTypeRegInfo.ExtendName = extname;
                fileTypeRegInfo.IconPath = iconFolder + fileType.Icon();
                fileTypeRegInfo.ShellNew = fileType.ShellNew();
                fileTypeRegInfo.ShellNewTemplate = fileType.ShellNewTemplate();

                // 注册  
                FileTypeRegister.RegisterFileType(fileTypeRegInfo);
            }
        }

        void Unregister(FileType fileType)
        {
            var extname = fileType.ExtensionName(); // 例子：".osf"

            // 取消注册  
            FileTypeRegister.UnregisterFileType(extname);
        }

        private void buttonRegister_Click(object sender, EventArgs e)
        {
            var fileType = CurrentFileType();
            if (fileType != null)
            {
                Register(fileType);
            }
        }

        private void buttonUnregister_Click(object sender, EventArgs e)
        {
            var fileType = CurrentFileType();
            if (fileType != null)
            {
                Unregister(fileType);
            }
        }

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            ShowDescription();
        }
    }
}
