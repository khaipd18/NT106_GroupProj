using System;
using System.Collections.Generic; // Để sử dụng List
using System.IO;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Windows_Explorer
{
    public partial class WindowExplorer : Form
    {
        private string copiedFilePath = null;
        private bool isCut = false;

        // Lưu lịch sử đường dẫn
        private List<string> pathHistory = new List<string>();
        private int currentPathIndex = -1;

        public WindowExplorer()
        {
            InitializeComponent();
            listView.View = View.Details;

            // Thêm cột
            listView.Columns.Add("Name", 200);
            listView.Columns.Add("Type", 100);
            listView.Columns.Add("Size", 100);
            listView.Columns.Add("Date modified", 150);

            // Cho phép kéo cột và chọn toàn bộ hàng
            listView.AllowColumnReorder = true;
            listView.FullRowSelect = true;
            listView.GridLines = true;

            // Gắn sự kiện MouseDoubleClick để mở thư mục
            listView.MouseDoubleClick += ListView_MouseDoubleClick;
        }

        private void WindowExplorer_Load(object sender, EventArgs e)
        {
            // Mặc định hiển thị nội dung thư mục C:\
            PathtxtBox.Text = "C:\\";
            LoadFiles(PathtxtBox.Text);
            UpdatePathHistory(PathtxtBox.Text); // Cập nhật lịch sử đường dẫn
        }

        private void LoadFiles(string folderPath)
        {
            listView.Items.Clear();
            DirectoryInfo dirInfo = new DirectoryInfo(folderPath);

            // Tải các thư mục
            foreach (DirectoryInfo dir in dirInfo.GetDirectories())
            {
                ListViewItem item = new ListViewItem(dir.Name);
                item.Tag = dir.FullName;
                item.SubItems.Add("Folder");
                item.SubItems.Add("");
                item.SubItems.Add(dir.LastWriteTime.ToString());
                listView.Items.Add(item);
            }

            // Tải các tệp
            foreach (FileInfo file in dirInfo.GetFiles())
            {
                ListViewItem item = new ListViewItem(file.Name);
                item.Tag = file.FullName;
                item.SubItems.Add(file.Extension);
                item.SubItems.Add(file.Length.ToString());
                item.SubItems.Add(file.LastWriteTime.ToString());
                listView.Items.Add(item);
            }
        }

        private void OpenBtn_Click(object sender, EventArgs e)
        {
            using (var folderDialog = new FolderBrowserDialog())
            {
                if (folderDialog.ShowDialog() == DialogResult.OK)
                {
                    PathtxtBox.Text = folderDialog.SelectedPath;
                    LoadFiles(folderDialog.SelectedPath);
                    UpdatePathHistory(folderDialog.SelectedPath); // Cập nhật lịch sử đường dẫn
                }
            }
        }

        private void ListView_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (listView.SelectedItems.Count > 0)
            {
                ListViewItem selectedItem = listView.SelectedItems[0];
                string selectedPath = selectedItem.Tag.ToString();

                // Mở thư mục khi nhấn đúp chuột
                if (Directory.Exists(selectedPath))
                {
                    PathtxtBox.Text = selectedPath;
                    LoadFiles(selectedPath);
                    UpdatePathHistory(selectedPath); // Cập nhật lịch sử đường dẫn
                }
            }
        }

        private void UpdatePathHistory(string newPath)
        {
            // Xóa các đường dẫn sau chỉ số hiện tại nếu di chuyển đến thư mục mới
            if (currentPathIndex < pathHistory.Count - 1)
            {
                pathHistory.RemoveRange(currentPathIndex + 1, pathHistory.Count - currentPathIndex - 1);
            }

            // Thêm đường dẫn mới vào lịch sử
            pathHistory.Add(newPath);
            currentPathIndex = pathHistory.Count - 1;
        }

        private void BackBtn_Click(object sender, EventArgs e)
        {
            if (currentPathIndex > 0)
            {
                currentPathIndex--;
                string previousPath = pathHistory[currentPathIndex];
                PathtxtBox.Text = previousPath;
                LoadFiles(previousPath);
            }
        }

        private void ForwardBtn_Click(object sender, EventArgs e)
        {
            if (currentPathIndex < pathHistory.Count - 1)
            {
                currentPathIndex++;
                string nextPath = pathHistory[currentPathIndex];
                PathtxtBox.Text = nextPath;
                LoadFiles(nextPath);
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
                LoadFiles(PathtxtBox.Text); // Làm mới danh sách tệp
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
                LoadFiles(PathtxtBox.Text); // Làm mới danh sách tệp
            }
        }

        private void NewFolderToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(PathtxtBox.Text))
            {
                string newFolderPath = Path.Combine(PathtxtBox.Text, "New Folder");
                Directory.CreateDirectory(newFolderPath);
                LoadFiles(PathtxtBox.Text); // Làm mới danh sách tệp
            }
        }
    }
}
