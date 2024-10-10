using System;
using System.Net.Sockets;
using System.Text;
using System.IO;
using System.Threading;
using System.Windows.Forms;

namespace PrivateChatAndFilesharing
{
    public partial class Client : Form
    {
        private TcpClient client;
        private NetworkStream stream;

        public Client()
        {
            InitializeComponent();
        }

        private void Client_Load(object sender, EventArgs e)
        {
            ConnectToServer();
        }

        private void ConnectToServer()
        {
            try
            {
                client = new TcpClient("127.0.0.1", 5000);
                stream = client.GetStream();
                AddMessage("Đã kết nối đến máy chủ...");
                Thread listenThread = new Thread(ListenForMessages);
                listenThread.IsBackground = true; // Đảm bảo thread này dừng khi form đóng
                listenThread.Start();
            }
            catch (Exception ex)
            {
                AddMessage($"Lỗi kết nối: {ex.Message}");
            }
        }

        private void ListenForMessages()
        {
            byte[] buffer = new byte[1024];
            int bytesRead;

            while (true)
            {
                try
                {
                    bytesRead = stream.Read(buffer, 0, buffer.Length);
                    if (bytesRead == 0) break; // Ngắt nếu không còn dữ liệu

                    string message = Encoding.UTF8.GetString(buffer, 0, bytesRead);
                    AddMessage("Máy chủ: " + message);
                }
                catch (Exception ex)
                {
                    AddMessage($"Lỗi nhận tin nhắn: {ex.Message}");
                    break; // Thoát khi có lỗi
                }
            }
        }

        private void AddMessage(string message)
        {
            if (InvokeRequired)
            {
                Invoke(new Action<string>(AddMessage), message);
                return;
            }
            LsvMessage.Items.Add(new ListViewItem(message));
        }

        private async void btnSend_Click(object sender, EventArgs e)
        {
            await SendMessageAsync();
        }

        private async Task SendMessageAsync()
        {
            string message = txbMessage.Text;
            byte[] messageData = Encoding.UTF8.GetBytes(message);
            await stream.WriteAsync(messageData, 0, messageData.Length);
            AddMessage("Bạn: " + message);
            txbMessage.Clear();
        }

        private async void btnShareFile_Click(object sender, EventArgs e)
        {
            await ShareFileAsync();
        }

        private async Task ShareFileAsync()
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                string filePath = openFileDialog.FileName;
                byte[] fileData = await File.ReadAllBytesAsync(filePath);
                string fileName = Path.GetFileName(filePath);
                byte[] fileNameBytes = Encoding.UTF8.GetBytes(fileName);
                byte[] fileNameLength = BitConverter.GetBytes(fileNameBytes.Length);

                try
                {
                    // Gửi độ dài tên file
                    await stream.WriteAsync(fileNameLength, 0, fileNameLength.Length);
                    // Gửi tên file
                    await stream.WriteAsync(fileNameBytes, 0, fileNameBytes.Length);
                    // Gửi nội dung file
                    await stream.WriteAsync(fileData, 0, fileData.Length);

                    AddMessage("Bạn đã gửi file: " + fileName);
                }
                catch (Exception ex)
                {
                    AddMessage($"Lỗi khi gửi file: {ex.Message}");
                }
            }
        }

        private void Client_FormClosed(object sender, FormClosedEventArgs e)
        {
            stream?.Close();
            client?.Close();
        }
    }
}
