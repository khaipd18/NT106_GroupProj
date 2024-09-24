using System;
using System.IO;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Windows_Explorer
{
    public partial class WindowExplorer : Form
    {
        private string copiedFilePath = null;
        private bool isCut = false;

        public WindowExplorer()
        {
            InitializeComponent();
            listView.View = View.Details;

            // Add columns
            listView.Columns.Add("Name", 200);
            listView.Columns.Add("Type", 100);
            listView.Columns.Add("Size", 100);
            listView.Columns.Add("Date modified", 150);

            // Allow column reordering and full row selection
            listView.AllowColumnReorder = true;
            listView.FullRowSelect = true;
            listView.GridLines = true; // Show grid lines
        }

        private void LoadFiles(string folderPath)
        {
            listView.Items.Clear(); // Xóa các mục hiện có
            DirectoryInfo dirInfo = new DirectoryInfo(folderPath);

            // Tải các thư mục
            foreach (DirectoryInfo dir in dirInfo.GetDirectories())
            {
                ListViewItem item = new ListViewItem(dir.Name); // Tên thư mục
                item.Tag = dir.FullName; // Lưu đường dẫn đầy đủ vào Tag
                item.SubItems.Add("Folder"); // Loại (Folder)
                item.SubItems.Add(""); // Kích thước (không áp dụng cho thư mục)
                item.SubItems.Add(dir.LastWriteTime.ToString()); // Ngày chỉnh sửa
                listView.Items.Add(item);
            }

            // Tải các tệp
            foreach (FileInfo file in dirInfo.GetFiles())
            {
                ListViewItem item = new ListViewItem(file.Name); // Tên tệp
                item.Tag = file.FullName; // Lưu đường dẫn đầy đủ vào Tag
                item.SubItems.Add(file.Extension); // Loại tệp
                item.SubItems.Add(file.Length.ToString()); // Kích thước tệp
                item.SubItems.Add(file.LastWriteTime.ToString()); // Ngày chỉnh sửa
                listView.Items.Add(item);
            }
        }


        private void OpenBtn_Click(object sender, EventArgs e)
        {
            using (var folderDialog = new FolderBrowserDialog())
            {
                if (folderDialog.ShowDialog() == DialogResult.OK)
                {
                    PathtxtBox.Text = folderDialog.SelectedPath; // Display selected path
                    LoadFiles(folderDialog.SelectedPath); // Load files from the selected path
                }
            }
        }

        private void CopyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (listView.SelectedItems.Count > 0)
            {
                copiedFilePath = listView.SelectedItems[0].Tag.ToString();
            }
        }

        private void CutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (listView.SelectedItems.Count > 0)
            {
                copiedFilePath = listView.SelectedItems[0].Tag.ToString();
                isCut = true;
            }
        }

        private async void PasteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (copiedFilePath != null && PathtxtBox.Text != string.Empty)
            {
                string destPath = Path.Combine(PathtxtBox.Text, Path.GetFileName(copiedFilePath));
                if (isCut)
                {
                    File.Move(copiedFilePath, destPath);
                    isCut = false;
                }
                else
                {
                    await CopyFileAsync(copiedFilePath, destPath);
                }
                LoadFiles(PathtxtBox.Text); // Refresh the file list
            }
        }

        private async Task CopyFileAsync(string sourcePath, string destPath)
        {
            using (FileStream sourceStream = new FileStream(sourcePath, FileMode.Open, FileAccess.Read, FileShare.Read, bufferSize: 4096, useAsync: true))
            using (FileStream destStream = new FileStream(destPath, FileMode.Create, FileAccess.Write, FileShare.None, bufferSize: 4096, useAsync: true))
            {
                await sourceStream.CopyToAsync(destStream);
            }
        }

        private void DeleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (listView.SelectedItems.Count > 0)
            {
                string filePath = listView.SelectedItems[0].Tag.ToString();
                File.Delete(filePath);
                LoadFiles(PathtxtBox.Text); // Refresh the file list
            }
        }

        private void NewFolderToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(PathtxtBox.Text))
            {
                string newFolderPath = Path.Combine(PathtxtBox.Text, "New Folder");
                Directory.CreateDirectory(newFolderPath);
                LoadFiles(PathtxtBox.Text); // Refresh the file list
            }
        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Optional: Handle selection changes if needed
        }

        private void WindowExplorer_Load(object sender, EventArgs e)
        {
            // Optional: Code to execute when the form loads
        }
    }
}
