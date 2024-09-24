namespace Windows_Explorer
{
    public partial class WindowExplorer : Form
    {
        public WindowExplorer()
        {
            InitializeComponent();
            listView.View = View.Details;

            // Thêm các cột "Name", "Type", "Size", "Date modified"
            listView.Columns.Add("Name", 200); // 200 là chiều rộng của cột
            listView.Columns.Add("Type", 100);
            listView.Columns.Add("Size", 100);
            listView.Columns.Add("Date modified", 150);

            // Tùy chọn: Cho phép người dùng thay đổi kích thước các cột
            listView.AllowColumnReorder = true;
            listView.FullRowSelect = true; // Chọn toàn bộ dòng
            listView.GridLines = true; // Hiển thị lưới
        }
        private void LoadFiles(string folderPath)
        {
            DirectoryInfo dirInfo = new DirectoryInfo(folderPath);
            foreach (FileInfo file in dirInfo.GetFiles())
            {
                // Tạo một ListViewItem cho mỗi file
                ListViewItem item = new ListViewItem(file.Name); // Tên file
                item.SubItems.Add(file.Extension); // Loại file (Type)
                item.SubItems.Add(file.Length.ToString()); // Kích thước file (Size)
                item.SubItems.Add(file.LastWriteTime.ToString()); // Ngày chỉnh sửa (Date modified)

                // Thêm item vào ListView
                listView.Items.Add(item);
            }
        }
        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void WindowExplorer_Load(object sender, EventArgs e)
        {

        }
    }
}
