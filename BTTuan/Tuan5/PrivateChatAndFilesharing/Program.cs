using System;
using System.Threading;
using System.Windows.Forms;

namespace PrivateChatAndFilesharing
{
    internal static class Program
    {
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            // Chạy form Server trên một thread riêng
            Thread serverThread = new Thread(() =>
            {
                Application.Run(new Server()); // Chạy form Server
            })
            {
                IsBackground = true // Đảm bảo khi form chính tắt, thread này sẽ tắt
            };
            serverThread.Start(); // Khởi chạy form Server

            // Chạy form Client trên thread chính
            Application.Run(new Client());

            // Khi form Client đóng, sẽ không dừng server thread
        }
    }
}
