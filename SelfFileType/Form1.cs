using SelfFileType.ClassLib;
using SelfFileType.src;
using SelfFileType.src.types;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SelfFileType
{
    public partial class Form1 : Form
    {
        enum FileTypeColumn
        {
            FileType,
            Registered,
            ShellNew,
            Description,
        }


        FileTypeManager mFileTypeManager;

        public Form1()
        {
            InitializeComponent();
            Init();

        }

        private void Form1_Load(object sender, EventArgs e)
        {
        }

        void Init()
        {
            mFileTypeManager = new FileTypeManager();
            InitMyListView();

            listView1.KeyDown += ListView1_KeyDown;
        }

        private void ListView1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F5)
            {
                RefreshListViewItem();
            }
        }

        void InitMyListView()
        {
            // Create a new ListView control.
            ListView listView1 = this.listView1;

            // Set the view to show details.
            listView1.View = View.Details;
            // Allow the user to edit item text.
            listView1.LabelEdit = true;
            // Allow the user to rearrange columns.
            listView1.AllowColumnReorder = true;
            // Display check boxes.
            listView1.CheckBoxes = false;
            // Select the item and subitems when selection is made.
            listView1.FullRowSelect = true;
            // Display grid lines.
            listView1.GridLines = true;
            // Sort the items in the list in ascending order.
            listView1.Sorting = SortOrder.Ascending;


            // Create columns for the items and subitems.
            // Width of -2 indicates auto-size.
            ListViewAddColumns(FileTypeColumn.FileType, HorizontalAlignment.Left);
            ListViewAddColumns(FileTypeColumn.Registered, HorizontalAlignment.Center);
            ListViewAddColumns(FileTypeColumn.ShellNew, HorizontalAlignment.Center);
            ListViewAddColumns(FileTypeColumn.Description, HorizontalAlignment.Left);

            AddViewItems(listView1);

            listView1.SelectedIndexChanged += ListView1_SelectedIndexChanged;
        }

        private void ListView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listView1.SelectedItems.Count > 0)
            {
                ListViewItem firstSelectedItem = listView1.SelectedItems[0];
                FileType fileType = (FileType)firstSelectedItem.Tag;
                ShowDescription(fileType);

                if (listView1.SelectedItems.Count == 1)
                {
                    var extname = fileType.ExtensionName();
                    var reged = FileTypeRegister.FileTypeRegistered(extname);

                    this.buttonRegister.Enabled = !reged;
                    this.buttonUnregister.Enabled = reged;
                }
            }
        }

        void ListViewAddColumns(FileTypeColumn ftc, HorizontalAlignment ha)
        {
            listView1.Columns.Add(Enum.GetName(typeof(FileTypeColumn), ftc), -2, ha);
        }


        void AddViewItems(ListView listView)
        {
            listView.Items.Clear();

            List<ListViewItem> items = new List<ListViewItem>();

            ImageList myImages = new ImageList();
            myImages.ImageSize = new Size(48, 48);
            myImages.ColorDepth = ColorDepth.Depth32Bit;
            listView.LargeImageList = myImages;
            listView.SmallImageList = myImages;


            int i = 0;
            foreach (var fileType in mFileTypeManager.FileTypes)
            {

                var fitem = BuildViewItem(fileType);

                var icon = LoadIcon(fileType);
                myImages.Images.Add(icon);

                items.Add(fitem);

                CheckRegistered(fitem);

                fitem.ImageIndex = i;
                i++;
            }

            listView.Items.AddRange(items.ToArray());
        }

        ListViewItem BuildViewItem(FileType fileType)
        {
            ListViewItem item = new ListViewItem(fileType.ExtensionName());
            item.SubItems.Add("NO");
            item.SubItems.Add(fileType.ShellNew() ? "Yes" : "NO");
            item.SubItems.Add(fileType.Description());
            item.Tag = fileType;
            item.SubItems[0].Font = new Font(item.SubItems[0].Font.Name
                , 12, System.Drawing.FontStyle.Regular); ;
            return item;
        }

        Image LoadIcon(FileType fileType)
        {
            var iconFolder = Config.Instance.GetIconFolder();
            string icon = Path.Combine(iconFolder, fileType.Icon());
            if (File.Exists(icon))
            {
                return Image.FromFile(icon);
            }
            return Properties.Resources.icon_not_found_2;
        }

        void RefreshListViewItem()
        {
            AddViewItems(listView1);
        }

        void CheckRegistered()
        {
            foreach (ListViewItem item in listView1.Items)
            {
                CheckRegistered(item);
            }
        }

        void CheckRegistered(ListViewItem item)
        {
            FileType fileType = (FileType)item.Tag;
            var extname = fileType.ExtensionName();
            var reged = FileTypeRegister.FileTypeRegistered(extname);
            int columnIndex = (int)FileTypeColumn.Registered;
            item.SubItems[columnIndex].ForeColor = reged ? Color.Green : Color.DarkRed;
            item.SubItems[columnIndex].Text = reged ? "Yes✔" : "No❌";

            item.UseItemStyleForSubItems = false;
        }

        IEnumerable<FileType> SelectedFileType()
        {
            List<FileType> fts = new List<FileType>();
            foreach (ListViewItem item in this.listView1.SelectedItems)
            {
                fts.Add((FileType) item.Tag);
            }
            return fts;
        }

        void ShowDescription(FileType fileType)
        {
           this.richTextBox_Desc.Text = fileType.Description().Trim();
        }

        void Register(IEnumerable<FileType> fileTypes)
        {
            foreach (var item in fileTypes)
            {
                Register(item);
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

        void Unregister(IEnumerable<FileType> fileType)
        {
            foreach (var item in fileType)
            {
                Unregister(item);
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
            var fileType = SelectedFileType();
            Register(fileType);
            CheckRegistered();
        }

        private void buttonUnregister_Click(object sender, EventArgs e)
        {
            var fileType = SelectedFileType();
            Unregister(fileType);
            CheckRegistered();
        }


    }
}
