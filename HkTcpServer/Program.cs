using System;
using System.IO;
using System.Windows.Forms;

namespace IoNetWork
{
    class Program
    {
        [STAThread]
        static void Main()
        {
            ConsoleHelper.WriteLine(false, "");

            if (!File.Exists(NetHelper.DllAsPath))
            {
                ConsoleHelper.WriteErr(false, "指定C++动态库文件 Hk-SocketAs.dll 不存在 无法启动 请检查后再启动");
                MessageBox.Show(null, "指定C++动态库文件 Hk-SocketAs.dll 不存在 无法启动 请检查后再启动", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (!NetWorkLib.GetHPSocketVersion().Equals("1.0.0.2"))
            {
                ConsoleHelper.WriteErr(false, "指定C++动态库文件 Hk-SocketAs.dll 版本不对应 无法启动 请检查后再启动");
                MessageBox.Show(null, "指定C++动态库文件 Hk-SocketAs.dll 版本不对应 无法启动 请检查后再启动", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (!File.Exists(NetHelper.BanPath))
            {
                ConsoleHelper.WriteErr(false, "指定的封禁列表文件不存在 请创建 Bans.txt文件");
                MessageBox.Show(null, "指定的封禁列表文件不存在\n请创建 Bans.txt文件", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (!File.Exists(NetHelper.GTextPath))
            {
                ConsoleHelper.WriteErr(false, "指定的游戏公告文件不存在 请创建 GText.txt文件");
                MessageBox.Show(null, "指定的游戏公告文件不存在\n请创建 GText.txt文件", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            ConsoleHelper.WriteLine(false, "--------------------请配置相关项目后 [启动服务]--------------------");
            ConsoleHelper.WriteLine(false, "");
            ConsoleHelper.WriteLine(false, "--------------------请配置相关项目后 [启动服务]--------------------");
            ConsoleHelper.WriteLine(false, "");
            Console.CursorVisible = false;

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new HkNetForm());
        }
    }
}
