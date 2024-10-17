using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Text.Json;

namespace PrivateChatAndFilesharing
{
    public partial class Client : Form
    {
        public Client()
        {
            InitializeComponent();
            CheckForIllegalCrossThreadCalls = false;
            Connect();
        }

        private void Client_Load(object sender, EventArgs e)
        {
        }

        private void btnSend_Click(object sender, EventArgs e)
        {
            SendMessage();
            AddMessage(txbMessage.Text);
        }

        private void btnSendFile_Click(object sender, EventArgs e)
        {
            SendFile();
        }

        IPEndPoint IP;
        Socket client;

        // Khởi tạo kết nối
        void Connect()
        {
            IP = new IPEndPoint(IPAddress.Parse("127.0.0.1"), 9999);
            client = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.IP);

            try
            {
                client.Connect(IP);
            }
            catch
            {
                MessageBox.Show("Không thể kết nối đến Server", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            Thread listen = new Thread(Receive);
            listen.IsBackground = true;
            listen.Start();
        }

        // Đóng kết nối
        void Close()
        {
            client.Close();
        }

        // Gửi tin đi
        void SendMessage()
        {
            if (txbMessage.Text != string.Empty)
                client.Send(Serialize(txbMessage.Text));
        }

        // Gửi tệp
        void SendFile()
        {
            using (OpenFileDialog ofd = new OpenFileDialog())
            {
                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    string filePath = ofd.FileName;
                    byte[] fileData = File.ReadAllBytes(filePath);
                    string fileName = Path.GetFileName(filePath);

                    // Gửi tên tệp trước
                    client.Send(Serialize(fileName));

                    // Gửi dữ liệu tệp
                    client.Send(fileData);
                    AddMessage($"Đã gửi tệp: {fileName}");
                }
            }
        }

        // Thêm message vào khung chat
        void AddMessage(string s)
        {
            LsvMessage.Items.Add(new ListViewItem() { Text = s });
            txbMessage.Clear();
        }

        // Nhận tin
        void Receive()
        {
            try
            {
                while (true)
                {
                    byte[] data = new byte[1024 * 5000];
                    client.Receive(data);

                    // Kiểm tra xem dữ liệu nhận có phải là tên tệp không
                    string message = (string)Deserialize(data);
                    if (IsFileName(message))
                    {
                        ReceiveFile(message);
                    }
                    else
                    {
                        AddMessage(message);
                    }
                }
            }
            catch
            {
                Close();
            }
        }

        // Kiểm tra nếu dữ liệu nhận là tên tệp
        bool IsFileName(string message)
        {
            // Giả định rằng nếu message chứa '.' thì đó là tên tệp
            return message.Contains(".");
        }

        // Nhận tệp
        void ReceiveFile(string fileName)
        {
            byte[] fileData = new byte[1024 * 5000]; // Kích thước tối đa tệp
            int receivedBytes = client.Receive(fileData);
            byte[] actualFileData = new byte[receivedBytes];

            Array.Copy(fileData, actualFileData, receivedBytes);
            File.WriteAllBytes($"received_{fileName}", actualFileData); // Lưu tệp vào đĩa

            AddMessage($"Đã nhận tệp: {fileName}");
        }

        // Phân mảnh gói tin thành byte để gửi đi
        byte[] Serialize(object obj)
        {
            return JsonSerializer.SerializeToUtf8Bytes(obj);
        }

        // Gom mảnh lại
        object Deserialize(byte[] data)
        {
            var jsonString = Encoding.UTF8.GetString(data);
            return JsonSerializer.Deserialize<object>(jsonString);
        }

        // Đóng form ngắt kết nối
        private void Client_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (client != null)
                client.Close(); 

            Application.Exit();  
        }

    }
}
