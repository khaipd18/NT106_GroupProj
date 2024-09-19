using System;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace PictureViewer
{
    public partial class Form1 : Form
    {
        private string[] imageFiles; 
        private int currentIndex = 0; 

        public Form1()
        {
            InitializeComponent();
        }

        // nút Open Folder 
        private void btnOpenFolder_Click(object sender, EventArgs e)
        {
            using (FolderBrowserDialog folderBrowserDialog = new FolderBrowserDialog())
            {
                if (folderBrowserDialog.ShowDialog() == DialogResult.OK)
                {
                    string folderPath = folderBrowserDialog.SelectedPath;
                    LoadImagesFromFolder(folderPath);
                }
            }
        }

        // load ảnh từ thư mục
        private void LoadImagesFromFolder(string folderPath)
        {
            imageFiles = Directory.GetFiles(folderPath, "*.*")
                                  .Where(f => f.EndsWith(".jpg") || f.EndsWith(".jpeg") || f.EndsWith(".png"))
                                  .ToArray();

            if (imageFiles.Length > 0)
            {
                DisplayThumbnails(); // Hiển thị danh sách các hình thu nhỏ
                currentIndex = 0;
                DisplayImage(currentIndex); // Hiển thị ảnh đầu tiên trong PictureBox
            }
        }

        // Hiển thị hình ảnh dựa trên chỉ số
        private void DisplayImage(int index)
        {
            if (imageFiles != null && imageFiles.Length > 0 && index >= 0 && index < imageFiles.Length)
            {
                pictureBoxMain.Image = Image.FromFile(imageFiles[index]);
            }
        }

        // Hiển thị các hình thu nhỏ
        private void DisplayThumbnails()
        {
            flowLayoutPanelThumbnails.Controls.Clear(); 

            foreach (string filePath in imageFiles)
            {
                PictureBox thumbnail = new PictureBox();
                thumbnail.Image = Image.FromFile(filePath);
                thumbnail.SizeMode = PictureBoxSizeMode.Zoom;
                thumbnail.Size = new Size(100, 100); 
                thumbnail.Click += (sender, e) =>
                {
                    currentIndex = Array.IndexOf(imageFiles, filePath);
                    DisplayImage(currentIndex); 
                };
                flowLayoutPanelThumbnails.Controls.Add(thumbnail);
            }
        }

        // phím mũi tên trái phải 
        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (imageFiles != null && imageFiles.Length > 0)
            {
                if (e.KeyCode == Keys.Right)
                {
                    if (currentIndex < imageFiles.Length - 1)
                    {
                        currentIndex++;
                        DisplayImage(currentIndex);
                    }
                }
                else if (e.KeyCode == Keys.Left)
                {
                    if (currentIndex > 0)
                    {
                        currentIndex--;
                        DisplayImage(currentIndex);
                    }
                }
            }
        }
    }
}
