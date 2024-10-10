using Private_Chat___Filesharing;
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


            Thread serverThread = new Thread(() =>
            {
                Application.Run(new Server()); // Chạy form Server
            });

            serverThread.IsBackground = true; // Đảm bảo khi form chính tắt, thread này sẽ tắt
            serverThread.Start(); // Khởi chạy form Server trên thread riêng

            // Chạy form Client trên thread chính
            Application.Run(new Client());

            // Khi form Client đóng, kết thúc ứng dụng
            serverThread.Join(); // Đảm bảo Server thread cũng hoàn tất trước khi thoát
        }
    }
}
