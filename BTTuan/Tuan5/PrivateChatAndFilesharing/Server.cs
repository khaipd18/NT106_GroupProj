using System;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace Private_Chat___Filesharing
{
    public partial class Server : Form
    {
        private Socket serverSocket;
        private Socket clientSocket;
        private Thread listenThread;

        public Server()
        {
            InitializeComponent();
            StartServer();
        }

        private void StartServer()
        {
            serverSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.IP);
            serverSocket.Bind(new IPEndPoint(IPAddress.Parse("127.0.0.1"), 9999));
            serverSocket.Listen(10);

            listenThread = new Thread(ListenForClients);
            listenThread.IsBackground = true;
            listenThread.Start();
        }

        private void ListenForClients()
        {
            while (true)
            {
                clientSocket = serverSocket.Accept();
                Thread clientThread = new Thread(HandleClientComm);
                clientThread.IsBackground = true;
                clientThread.Start(clientSocket);
            }
        }

        private void HandleClientComm(object client)
        {
            Socket socket = (Socket)client;

            while (true)
            {
                try
                {
                    byte[] buffer = new byte[1024];
                    int bytesRead = socket.Receive(buffer);
                    if (bytesRead > 0)
                    {
                        string message = Encoding.UTF8.GetString(buffer, 0, bytesRead);
                        AddMessage(message);
                    }
                }
                catch
                {
                    break;
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
            LsvMessages.Items.Add(message);
        }

        private void Server_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (serverSocket != null)
                serverSocket.Close();

            if (listenThread != null && listenThread.IsAlive)
                listenThread.Abort();  

            Application.Exit(); 
        }

    }
}
