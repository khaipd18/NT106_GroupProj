using System;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.IO;
using System.Threading;
using System.Windows.Forms;

namespace PrivateChatAndFilesharing
{
    public partial class Server : Form
    {
        private TcpListener server;
        private TcpClient client;
        private NetworkStream stream;

        public Server()
        {
            InitializeComponent();
        }

        private void Server_Load(object sender, EventArgs e)
        {
            StartServer();
        }

        private void StartServer()
        {
            server = new TcpListener(IPAddress.Any, 5000);
            server.Start();
            Thread serverThread = new Thread(ListenForClients);
            serverThread.Start();
            AddMessage("Máy chủ đã khởi động...");
        }

        private void ListenForClients()
        {
            while (true)
            {
                client = server.AcceptTcpClient();
                stream = client.GetStream();
                AddMessage("Máy khách đã kết nối...");
                Thread clientThread = new Thread(HandleClient);
                clientThread.Start();
            }
        }

        private void HandleClient()
        {
            byte[] buffer = new byte[1024];
            int bytesRead;

            while ((bytesRead = stream.Read(buffer, 0, buffer.Length)) > 0)
            {
                string message = Encoding.UTF8.GetString(buffer, 0, bytesRead);
                AddMessage("Máy khách: " + message);
            }

            // Xử lý nhận file
            while (true)
            {
                try
                {
                    byte[] fileNameLengthBytes = new byte[4];
                    if (stream.Read(fileNameLengthBytes, 0, 4) == 0) break;

                    int fileNameLength = BitConverter.ToInt32(fileNameLengthBytes, 0);
                    byte[] fileNameBytes = new byte[fileNameLength];
                    stream.Read(fileNameBytes, 0, fileNameLength);

                    string fileName = Encoding.UTF8.GetString(fileNameBytes);
                    AddMessage("Máy khách gửi file: " + fileName);

                    // Đọc nội dung file
                    using (MemoryStream memoryStream = new MemoryStream())
                    {
                        byte[] fileBuffer = new byte[1024];
                        int bytesReceived;

                        while ((bytesReceived = stream.Read(fileBuffer, 0, fileBuffer.Length)) > 0)
                        {
                            memoryStream.Write(fileBuffer, 0, bytesReceived);
                        }

                        string fileContent = Encoding.UTF8.GetString(memoryStream.ToArray());
                        AddMessage($"Nội dung:\n{fileContent}"); // Xuống dòng cho nội dung
                    }
                }
                catch (Exception ex)
                {
                    AddMessage($"Lỗi: {ex.Message}");
                    break; // Thoát vòng lặp khi có lỗi
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
                string fileName = Path.GetFileName(filePath);
                byte[] fileNameBytes = Encoding.UTF8.GetBytes(fileName);
                byte[] fileNameLength = BitConverter.GetBytes(fileNameBytes.Length);

                // Gửi độ dài tên file
                await stream.WriteAsync(fileNameLength, 0, fileNameLength.Length);
                // Gửi tên file
                await stream.WriteAsync(fileNameBytes, 0, fileNameBytes.Length);

                // Gửi nội dung file
                byte[] fileData = await File.ReadAllBytesAsync(filePath);
                await stream.WriteAsync(fileData, 0, fileData.Length);

                AddMessage("Máy chủ đã gửi file: " + fileName);
            }
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

        private void Server_FormClosed(object sender, FormClosedEventArgs e)
        {
            stream?.Close();
            client?.Close();
            server?.Stop();
        }
    }
}
