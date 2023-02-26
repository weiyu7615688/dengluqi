
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using System.Globalization;
using System.Linq;
using System.Net.NetworkInformation;
using System.Drawing;
using SecureRemotePassword;
using System.Security.Cryptography;
using System.Net.Sockets;

namespace IoNetWork
{
    #region 枚举数据
    /// <summary>
    /// 应用程序的状态
    /// </summary>
    public enum AppState
    {
        /// <summary>
        /// 启动中
        /// </summary>
        Starting,
        /// <summary>
        /// 启动完成
        /// </summary>
        Started,
        /// <summary>
        /// 关闭中
        /// </summary>
        Stoping,
        /// <summary>
        /// 关闭完成
        /// </summary>
        Stoped,
        /// <summary>
        /// 状态错误
        /// </summary>
        Error
    }

    /// <summary>
    /// 数据库操作返回值
    /// </summary>
    public enum MysqlResult
    {
        /// <summary>
        /// 数据库出错
        /// </summary>
        Error,
        /// <summary>
        /// 数据已存在
        /// </summary>
        Has,
        /// <summary>
        /// 不符合
        /// </summary>
        Wrong,
        /// <summary>
        /// 操作成功
        /// </summary>
        Yes,
    }

    /// <summary>
    /// 游戏版本
    /// </summary>
    public enum GVersion
    {
        /// <summary>
        /// 艾泽拉斯
        /// </summary>
        AZS = 1,
        /// <summary>
        /// 燃烧的远征
        /// </summary>
        TBC,
        /// <summary>
        /// 巫妖王之怒
        /// </summary>
        WLK,
        /// <summary>
        /// 大地的裂变
        /// </summary>
        CTM
    }
    #endregion

    #region 静态帮助类
    /// <summary>
    /// 静态帮助类
    /// </summary>
    public static class NetHelper
    {
        #region 静态全局变量
        /// <summary>
        /// 服务端口
        /// </summary>
        public static string NetPort { get; set; }

        /// <summary>
        /// 最大连接
        /// </summary>
        public static string NetMaxConn { get; set; }

        /// <summary>
        /// 本地端口
        /// </summary>
        public static string NetBPort { get; set; }

        /// <summary>
        /// 转发端口
        /// </summary>
        public static string NetZPort { get; set; }

        /// <summary>
        /// 登录端口
        /// </summary>
        public static string NetDPort { get; set; }

        /// <summary>
        /// 电信地址
        /// </summary>
        public static string NetTelecomIp { get; set; }

        /// <summary>
        /// 移动地址
        /// </summary>
        public static string NetMobileIp { get; set; }

        /// <summary>
        /// 联通地址
        /// </summary>
        public static string NetUnicomIp { get; set; }

        /// <summary>
        /// 分区名字
        /// </summary>
        public static string NetNameList { get; set; }

        /// <summary>
        /// 多开数量
        /// </summary>
        public static string NetContents { get; set; }

        /// <summary>
        /// 注册
        /// </summary>
        public static string NetRegister { get; set; }

        /// <summary>
        /// 解卡
        /// </summary>
        public static string NetStuck { get; set; }

        /// <summary>
        /// 改密
        /// </summary>
        public static string NetCgPassword { get; set; }

        /// <summary>
        /// 数据库地址
        /// </summary>
        public static string NetDBHost { get; set; }

        /// <summary>
        /// 数据库账号
        /// </summary>
        public static string NetDBRoot { get; set; }

        /// <summary>
        /// 数据库密码
        /// </summary>
        public static string NetDBPass { get; set; }

        /// <summary>
        /// 数据库端口
        /// </summary>
        public static string NetDBPort { get; set; }

        /// <summary>
        /// 账号库名
        /// </summary>
        public static string NetDBAuth { get; set; }

        /// <summary>
        /// 角色库名
        /// </summary>
        public static string NetDBChar { get; set; }

        /// <summary>
        /// 游戏版本
        /// </summary>
        public static string NetGameVe { get; set; }

        /// <summary>
        /// 补丁名字
        /// </summary>
        public static string NetPName { get; set; }

        /// <summary>
        /// 补丁MD5
        /// </summary>
        public static string NetPMd { get; set; }

        /// <summary>
        /// 补丁网络路径
        /// </summary>
        public static string NetPUrl { get; set; }

        /// <summary>
        /// 赞助网络地址
        /// </summary>
        public static string NetShopUrl { get; set; }

        /// <summary>
        /// 官网地址
        /// </summary>
        public static string NetGwUrl { get; set; }

        /// <summary>
        /// 公告的内容
        /// </summary>
        public static string NetGText { get; set; }

        /// <summary>
        /// 是否转发
        /// </summary>
        public static string NetForward { get; set; }

        /// <summary>
        /// 是否加密模块
        /// </summary>
        public static string NetModKey { get; set; }

        /// <summary>
        /// 补丁密钥
        /// </summary>
        public static string MpqKey { get; set; }
        #endregion

        //只读变量 以下涉及重要数据 尽可能的不要使用太简单的字符 如果是双向的话 注意与客户端约定一致

        /// <summary>
        /// 全局分割符^
        /// </summary>
        public static readonly string NetSplitOne = "^";

        /// <summary>
        /// 注册符Reg
        /// </summary>
        public static readonly string NetReg = "Reg";

        /// <summary>
        /// 解卡符Player
        /// </summary>
        public static readonly string NetPlayer = "Player";

        /// <summary>
        /// 改密符Pass
        /// </summary>
        public static readonly string NetPass = "Pass";

        /// <summary>
        /// 约定的消息头HkTool
        /// </summary>
        public static readonly string NetPacketHead = "HkTool";

        /// <summary>
        /// 心跳符KeepAlive
        /// </summary>
        public static readonly string NetKa = "KeepAlive";

        /// <summary>
        /// 配置符LoginGetConfigToOne
        /// </summary>
        public static readonly string NetConfig = "LoginGetConfigToOne";

        /// <summary>
        /// 心跳包
        /// </summary>
        public static readonly string NetKeep = NetPacketHead + NetSplitOne + NetKa + NetSplitOne;

        /// <summary>
        /// 详细配置包
        /// </summary>
        public static readonly string NetLoginGetConfig = NetPacketHead + NetSplitOne + NetConfig + NetSplitOne;

        /// <summary>
        /// 所有消息加密解密的密钥
        /// </summary>
        public static readonly string SymmetricKey = "!!!@@@###$$$";

        /// <summary>
        /// 补丁加密的密钥 对应WOWFUN 这个dll的代码的密钥 保持一致
        /// </summary>
        public static readonly string MpqTheKey = "112233445566";

        /// <summary>
        /// 头
        /// </summary>
        public static readonly int Header = 3;

        /// <summary>
        /// 数据
        /// </summary>
        public static readonly int Encrypt = 512;

        /// <summary>
        /// VC++底层库文件
        /// </summary>
        public static readonly string DllAsPath = Application.StartupPath + "\\Hk-SocketAs.dll";

        /// <summary>
        /// 自定义封禁文件 ...\\Bans.txt
        /// </summary>
        public static readonly string BanPath = Application.StartupPath + "\\Bans.txt";

        /// <summary>
        /// 自定义公告文件 ...\\GText.txt
        /// </summary>
        public static readonly string GTextPath = Application.StartupPath + "\\GText.txt";

        /// <summary>
        /// 最小连接的时间差 表示在多少秒内不可以多次连接 秒
        /// </summary>
        public static readonly uint NetAcceptTime = 5;

        /// <summary>
        /// 同一IP最大连接
        /// </summary>
        public static readonly uint NetInIps = 100;

        /// <summary>
        /// 断开处于静默连接时长的 一般设置30 秒
        /// </summary>
        public static readonly uint NetSilenceTime = 30;

        /// <summary>
        /// 心跳时间检测间隔 一般设置30 秒
        /// </summary>
        public static readonly int NetKeepTime = 30;

        /// <summary>
        /// 释放资源最大列
        /// </summary>
        public static readonly uint RCount = 1024;

        #region 动态缩放窗体
        /// <summary>
        /// 初始坐标记录X
        /// </summary>
        public static float CurrX { get; set; }

        /// <summary>
        /// 初始坐标记录Y
        /// </summary>
        public static float CurrY { get; set; }

        /// <summary>
        /// 获得控件的长度 宽度 位置 字体大小的数据
        /// </summary>
        public static void SetTag(Control AllCons)
        {
            foreach (Control Con in AllCons.Controls)
            {
                //获取或设置包含有关控件的数据的对象
                Con.Tag = Con.Width + ":" + Con.Height + ":" + Con.Left + ":" + Con.Top + ":" + Con.Font.Size;
                //递归算法
                if (Con.Controls.Count > 0)
                    SetTag(Con);
            }
        }

        /// <summary>
        /// 实现控件以及字体的缩放
        /// </summary>
        public static void SetControls(float Newx, float Newy, Control AllCons)
        {
            foreach (Control Con in AllCons.Controls)
            {
                string[] MyTag = Con.Tag.ToString().Split(new char[] { ':' });
                float At = Convert.ToSingle(MyTag[0]) * Newx;
                Con.Width = (int)At;
                At = Convert.ToSingle(MyTag[1]) * Newy;
                Con.Height = (int)(At);
                At = Convert.ToSingle(MyTag[2]) * Newx;
                Con.Left = (int)(At);
                At = Convert.ToSingle(MyTag[3]) * Newy;
                Con.Top = (int)(At);
                float CurrentSize = Convert.ToSingle(MyTag[4]) * Newy;
                Con.Font = new Font(Con.Font.Name, CurrentSize, Con.Font.Style, Con.Font.Unit);
                //递归算法
                if (Con.Controls.Count > 0)
                    SetControls(Newx, Newy, Con);
            }
        }
        #endregion

        #region 常用方法函数
        /// <summary>
        /// TCP端口是否被占用
        /// </summary>
        public static bool TcpPortInUse(int Port)
        {
            bool InUse = false;

            IPGlobalProperties IpProperties = IPGlobalProperties.GetIPGlobalProperties();
            IPEndPoint[] IpEndPoints = IpProperties.GetActiveTcpListeners();

            foreach (IPEndPoint EndPoint in IpEndPoints)
            {
                if (EndPoint.Port == Port)
                {
                    InUse = true;
                    break;
                }
            }

            return InUse;
        }

        /// <summary>
        /// 获取时间戳
        /// </summary>
        /// <returns></returns>
        public static long GetCurrentTimeStamp()
        {
            TimeSpan Ts = DateTime.Now - new DateTime(1970, 1, 1, 0, 0, 0, 0);
            return Convert.ToInt64(Ts.TotalSeconds);
        }

        /// <summary>
        /// 将文件转换成byte[] 数组
        /// </summary>
        public static byte[] FileToByte(string FilePath)
        {
            FileStream FileSm = new FileStream(FilePath, FileMode.Open, FileAccess.Read);
            try
            {
                byte[] Buffur = new byte[FileSm.Length];
                FileSm.Read(Buffur, 0, (int)FileSm.Length);

                return Buffur;
            }
            catch (Exception)
            {
                return null;
            }
            finally
            {
                if (FileSm != null)
                    FileSm.Close();
            }
        }

        /// <summary>
        /// 图片转字节 即将发送 2M以下图片 可能会以8192B分送 保证快速
        /// </summary>
        public static byte[] ImageToByte(string ImgPath)
        {
            FileStream FileSm = new FileStream(ImgPath, FileMode.Open, FileAccess.Read);
            try
            {
                BinaryReader Br = new BinaryReader(FileSm);
                byte[] ImgBytesIn = Br.ReadBytes((int)FileSm.Length);
                return ImgBytesIn;
            }
            catch (Exception)
            {
                return null;
            }
            finally
            {
                if (FileSm != null)
                    FileSm.Close();
            }
        }

        /// <summary>
        /// 对称加密解密
        /// </summary>
        public static byte[] AlgorithmToByte(byte[] Byte)
        {
            var Key = Encoding.UTF8.GetBytes(SymmetricKey);
            for (int i = 0; i < Byte.Length; i++)
            {
                Byte[i] ^= Key[i % Key.Length];
            }
            return Byte;
        }

        /// <summary>
        /// 对称加密解密
        /// </summary>
        public static byte[] AlgorithmToByte(byte[] Byte, int Length)
        {
            var Key = Encoding.UTF8.GetBytes(SymmetricKey);
            for (int i = 0; i < Length; i++)
            {
                Byte[i] ^= Key[i % Key.Length];
            }
            return Byte;
        }

        /// <summary>
        /// 封禁处理 写入指定行到文件流
        /// </summary>
        public static void BanFileWriter(string sIp)
        {
            FileStream FileSm = new FileStream(BanPath, FileMode.Append, FileAccess.Write);
            StreamWriter Sw = new StreamWriter(FileSm);
            try
            {
                FileSm.Seek(0, SeekOrigin.End);
                Sw.WriteLine(sIp);
            }
            finally
            {
                if (Sw != null)
                    Sw.Close();
            }
        }

        /// <summary>
        /// 解封处理 从文件流删除指定行
        /// </summary>
        public static void UnBanFileWriter(string sIp)
        {
            string[] Lines = File.ReadAllLines(BanPath);
            List<string> RList = new List<string>();
            RList.AddRange(Lines);
            RList.Remove(sIp);
            Lines = RList.ToArray();
            File.WriteAllLines(BanPath, Lines);
        }

        public static int DoEncryption(string Path)
        {
            try
            {
                var Key = Encoding.UTF8.GetBytes(MpqTheKey);
                byte[] RByte = File.ReadAllBytes(Path);

                if (RByte.Length <= 0)
                    return 2;

                if (RByte[0] == 0x5E && RByte[1] == 0x24 && RByte[2] == 0x26)
                    return 3;

                RByte[0] = 0x5E;
                RByte[1] = 0x24;
                RByte[2] = 0x26;

                for (int i = Header; i < Encrypt; i++)
                {
                    RByte[i] ^= Key[i % Key.Length];
                }

                File.WriteAllBytes(Path, RByte);
                return 1;
            }
            catch (Exception)
            {
                return 0;
            }
        }

        #endregion
    }
    #endregion

    #region Mysql处理类
    /// <summary>
    /// Mysql处理类
    /// </summary>
    public class InitMySql
    {
        private string ConStringAuth;
        private string ConStringChar;

        MySqlConnection AuthConn;
        MySqlConnection CharConn;

        public InitMySql()
        {
            
        }

        public void StartMySql(string Host, string Port, string AName, string CName, string Root, string Pass)
        {
            ConStringAuth = string.Format("server={0};port={1};database={2};user={3};password={4};charset=utf8;pooling=true", Host, Port, AName, Root, Pass);
            ConStringChar = string.Format("server={0};port={1};database={2};user={3};password={4};charset=utf8;pooling=true", Host, Port, CName, Root, Pass);
            AuthConn = new MySqlConnection(ConStringAuth);
            CharConn = new MySqlConnection(ConStringChar);
        }

        public void StopMySql()
        {
            AuthConn.Close();
            CharConn.Close();
            AuthConn.Dispose();
            CharConn.Dispose();
        }
        /// <summary>
        ///注册函数
        /// </summary>
        public MysqlResult RegisterUser(string UserName, string Pass, string Security, string IpAddress)
        {
            try
            {
                AuthConn.Open();
                string Query = string.Format("SELECT * From account WHERE username='{0}';", UserName);
                MySqlCommand QCmd = new MySqlCommand(Query, AuthConn);
                object Result = QCmd.ExecuteScalar();
                if (Result != null)
                {
                    AuthConn.Close();
                    return MysqlResult.Has;
                }

                string VeStr = "2";
                switch (Convert.ToUInt32(NetHelper.NetGameVe))
                {
                    case (uint)GVersion.CTM:
                        VeStr = "3";
                        break;
                    case (uint)GVersion.WLK:
                        VeStr = "2";
                        break;
                    case (uint)GVersion.TBC:
                        VeStr = "1";
                        break;
                    case (uint)GVersion.AZS:
                        VeStr = "0";
                        break;
                    default:
                        VeStr = "2";
                        break;
                }

                string Insert = string.Empty;

                if (Convert.ToUInt32(NetHelper.NetGameVe) == (uint)GVersion.TBC)
                    Insert = string.Format("INSERT INTO account (username, salt, verifier, email, last_ip, expansion) VALUES ('{0}','{1}','{2}','{3}','{4}','{5}');", UserName, salt, verifier, Security, IpAddress, VeStr);
                else
                    Insert = string.Format("INSERT INTO account (username, salt, verifier, email, last_ip, expansion) VALUES ('{0}','{1}','{2}','{3}','{4}','{5}');", UserName, salt, verifier, Security, IpAddress, VeStr);

                MySqlCommand ICmd = new MySqlCommand(Insert, AuthConn);
                if (ICmd.ExecuteNonQuery() < 1)
                {
                    AuthConn.Close();
                    return MysqlResult.Error;
                }

                //记录一份备忘 保存到自己定义的表
                string SaveInsert = string.Format("INSERT INTO _passworld (User, Password, Security, Ip) VALUES ('{0}','{1}','{2}','{3}');", UserName, Pass, Security, IpAddress);
                MySqlCommand SaveCmd = new MySqlCommand(SaveInsert, AuthConn);
                if (SaveCmd.ExecuteNonQuery() < 1)
                {
                    AuthConn.Close();
                    return MysqlResult.Error;
                }

                AuthConn.Close();
                return MysqlResult.Yes;
            }
            catch (MySqlException Ex)
            {
                AuthConn.Close();
                ConsoleHelper.WriteLine(true, ">> 数据库错误: " + Ex.Message);
                return MysqlResult.Error;
            }
        }

        /// <summary>
        ///解卡函数
        /// </summary>
        public MysqlResult UnlockName(string UserName, string Pass, string Name)
        {
            try
            {
                AuthConn.Open();
                string Query1 = string.Format("SELECT id FROM account WHERE (username='{0}' AND sha_pass_hash=SHA1(CONCAT(UPPER('{1}'),':',UPPER('{2}'))));", UserName, UserName, Pass);

                if (Convert.ToUInt32(NetHelper.NetGameVe) == (uint)GVersion.TBC)
                    Query1 = string.Format("SELECT id FROM account WHERE (username='{0}' AND pass_hash=SHA1(CONCAT(UPPER('{1}'),':',UPPER('{2}'))));", UserName, UserName, Pass);

                MySqlCommand QCmd1 = new MySqlCommand(Query1, AuthConn);
                MySqlDataReader Reader1 = QCmd1.ExecuteReader();

                string AccId = "";
                if (Reader1.Read())
                {
                    AccId = Reader1["id"].ToString();
                }
                else
                {
                    Reader1.Close();
                    AuthConn.Close();
                    return MysqlResult.Has;
                }

                Reader1.Close();
                AuthConn.Close();

                CharConn.Open();
                string Query2 = string.Format("SELECT guid FROM characters WHERE (account='{0}' AND name='{1}');", AccId, Name);
                MySqlCommand QCmd2 = new MySqlCommand(Query2, CharConn);
                MySqlDataReader Reader2 = QCmd2.ExecuteReader();
                string Guid = "";
                if (Reader2.Read())
                {
                    Guid = Reader2["guid"].ToString();
                }
                else
                {
                    Reader2.Close();
                    CharConn.Close();
                    return MysqlResult.Wrong;
                }

                Reader2.Close();

                //默认加基森 不能在某个版本到不了的地方
                string Update = string.Format("UPDATE characters SET position_x='-7177.47', position_y='-3785.53', position_z='9.37', map='1' WHERE (guid='{0}');", Guid);
                MySqlCommand UCmd = new MySqlCommand(Update, CharConn);
                if (UCmd.ExecuteNonQuery() < 1)
                {
                    CharConn.Close();
                    return MysqlResult.Error;
                }

                CharConn.Close();
                return MysqlResult.Yes;
            }
            catch (MySqlException Ex)
            {
                AuthConn.Close();
                CharConn.Close();
                ConsoleHelper.WriteLine(true, ">> 数据库错误: " + Ex.Message);
                return MysqlResult.Error;
            }
        }

        /// <summary>
        ///改密函数
        /// </summary>
        public MysqlResult ChangePass(string UserName, string Pass, string Security)
        {
            try
            {
                AuthConn.Open();
                string Query = string.Format("SELECT username FROM account WHERE (username='{0}' AND email='{1}');", UserName, Security);
                MySqlCommand QCmd = new MySqlCommand(Query, AuthConn);
                object Result = QCmd.ExecuteScalar();
                if (Result == null)
                {
                    AuthConn.Close();
                    return MysqlResult.Wrong;
                }

                string Update = string.Format("UPDATE account SET  sha_pass_hash=SHA1(CONCAT(UPPER('{0}'),':',UPPER('{1}'))), sessionkey='', v='', s='' WHERE username='{2}';", UserName, Pass, UserName);

                if (Convert.ToUInt32(NetHelper.NetGameVe) == (uint)GVersion.TBC)
                    Update = string.Format("UPDATE account SET  pass_hash=SHA1(CONCAT(UPPER('{0}'),':',UPPER('{1}'))), token_key='' WHERE username='{2}';", UserName, Pass, UserName);

                MySqlCommand UCmd = new MySqlCommand(Update, AuthConn);
                if (UCmd.ExecuteNonQuery() < 1)
                {
                    AuthConn.Close();
                    return MysqlResult.Error;
                }

                //更新自定义的表
                string UpdatePass = string.Format("UPDATE _passworld SET Password='{0}' WHERE user='{1}';", Pass, UserName);
                MySqlCommand UpPassCmd = new MySqlCommand(UpdatePass, AuthConn);
                if (UpPassCmd.ExecuteNonQuery() < 1)
                {
                    AuthConn.Close();
                    return MysqlResult.Error;
                }

                AuthConn.Close();
                return MysqlResult.Yes;
            }
            catch (MySqlException Ex)
            {
                AuthConn.Close();
                ConsoleHelper.WriteLine(true, ">> 数据库错误: " + Ex.Message);
                return MysqlResult.Error;
            }
        }

    }
    #endregion

    #region 控制台颜色-配置文件读写-类
    /// <summary>
    /// 控制台任务队列帮助类
    /// </summary>
    public static class FunHelper
    {
        static FunHelper()
        {
            Task.Factory.StartNew(() =>
            {
                while (true)
                {
                    ActionQueue.TryDequeue(out Action Act);
                    Act?.Invoke();
                    if (Act == null)
                        Thread.Sleep(10);
                }
            });
            Task.Factory.StartNew(() =>
            {
                while (true)
                {
                    FunQueue.TryDequeue(out Func<string> Fun);
                    Fun?.Invoke();
                    if (Fun == null)
                        Thread.Sleep(10);
                }
            });
        }

        public static void OneceAsync(Action FuncAtion)
        {
            Task.Factory.StartNew(() => { FuncAtion(); });
        }

        private static void SingleWhileAsync(Action FuncAtion, int Mil)
        {
            Task.Factory.StartNew(() =>
            {
                while (true)
                {
                    FuncAtion();
                    Thread.Sleep(Mil);
                }
            });
        }

        public static void WhileAsync(Action FuncAtion, int Mil, bool Muti = false)
        {
            if (!Muti)
                SingleWhileAsync(FuncAtion, Mil);
            else
                Task.Factory.StartNew(() =>
                {
                    while (true)
                    {
                        Task.Factory.StartNew(() => { FuncAtion(); });
                        Thread.Sleep(Mil);
                    }
                });
        }

        public static void ForAsync(Action FuncAtion, int Num)
        {
            Task.Factory.StartNew(() => { Parallel.For(0, Num, i => { FuncAtion(); }); });
        }

        /// <summary>
        /// 无返回值的任务队列
        /// </summary>
        public static ConcurrentQueue<Action> ActionQueue { get; } = new ConcurrentQueue<Action>();

        /// <summary>
        /// 含返回值的任务队列
        /// </summary>
        public static ConcurrentQueue<Func<string>> FunQueue { get; } = new ConcurrentQueue<Func<string>>();
    }

    /// <summary>
    /// 控制台输出帮助类
    /// </summary>
    public static class ConsoleHelper
    {
        public static void WriteErr(bool ShowTime, string Msg, ConsoleColor Color = ConsoleColor.Red)
        {
            FunHelper.ActionQueue.Enqueue(() =>
            {
                var StringBr = new StringBuilder();

                if (ShowTime)
                    StringBr.Append(">> " + DateTime.Now.ToString() + " ");

                StringBr.Append(Msg);
                var NowColor = Console.ForegroundColor;
                Console.ForegroundColor = Color;
                Console.WriteLine(StringBr.ToString());
                Console.ForegroundColor = NowColor;
            });

            Logger.Write(DateTime.Now, MsgType.Error, Msg);
        }

        public static void WriteLine(bool ShowTime, string Msg, ConsoleColor Color = ConsoleColor.Yellow)
        {
            FunHelper.ActionQueue.Enqueue(() =>
            {
                var StringBr = new StringBuilder();

                if (ShowTime)
                    StringBr.Append(">> " + DateTime.Now.ToString() + " ");

                StringBr.Append(Msg);
                var NowColor = Console.ForegroundColor;
                Console.ForegroundColor = Color;
                Console.WriteLine(StringBr.ToString());
                Console.ForegroundColor = NowColor;
            });

            Logger.Write(DateTime.Now, MsgType.Information, Msg);
        }
    }

    /// <summary>
    /// 配置文件类 var TestINI = new DataINI(Application.StartupPath + "\\Test.ini"); TestINI.GetString("项", "键");
    /// </summary>
    public class DataINI
    {
        private readonly List<string> CurrBuffer = new List<string>();
        private readonly Dictionary<string, Dictionary<string, string>> CurrData = new Dictionary<string, Dictionary<string, string>>();

        /// <summary>
        /// 路径
        /// </summary>
        private string Path { get; set; }

        /// <summary>
        /// 初始化
        /// </summary>
        public DataINI()
        {
            Path = null;
        }

        /// <summary>
        /// 初始化 带路径
        /// </summary>
        public DataINI(string FileName) : this()
        {
            ReadFile(FileName);
        }

        /// <summary>
        /// 清空
        /// </summary>
        public void Clear()
        {
            CurrBuffer.Clear();
            CurrData.Clear();
        }

        /// <summary>
        /// 读取文件内容
        /// </summary>
        public bool ReadFile(string FileName)
        {
            CurrBuffer.Clear();
            Path = FileName;
            return AppendFile(FileName);
        }

        /// <summary>
        /// 追加到容器
        /// </summary>
        public bool AppendFile(string FileName)
        {
            try
            {
                var InLines = File.ReadAllLines(FileName, Encoding.Default);
                foreach (var Line in InLines)
                {
                    CurrBuffer.Add(Line);
                }
                DoParse();
            }
            catch
            {
                return false;
            }
            return true;
        }

        /// <summary>
        /// 读取所有行到容器
        /// </summary>
        public bool ReadLines(IEnumerable<string> InLines)
        {
            CurrBuffer.Clear();
            return AppendLines(InLines);
        }

        /// <summary>
        /// 追加所有行到容器
        /// </summary>
        public bool AppendLines(IEnumerable<string> InLines)
        {
            CurrBuffer.AddRange(InLines);
            DoParse();
            return true;
        }

        /// <summary>
        /// 保存操作
        /// </summary>
        public bool Save()
        {
            if (Path != null)
                return SaveAs(Path);

            return false;
        }

        /// <summary>
        /// 保存到文件
        /// </summary>
        public bool SaveAs(string FileName)
        {
            using (StreamWriter File = new StreamWriter(FileName, false, Encoding.UTF8))
            {
                File.Close();
                return true;
            }
        }

        /// <summary>
        /// 判断项是否存在
        /// </summary>
        public bool HasSection(string Section)
        {
            return CurrData.ContainsKey(Section);
        }

        /// <summary>
        /// 判断键位和键值
        /// </summary>
        public bool HasProperty(string Section, string Property)
        {
            if (HasSection(Section))
            {
                return CurrData[Section].ContainsKey(Property);
            }

            return false;
        }

        /// <summary>
        /// 删除项
        /// </summary>
        public void DeleteSection(string Section)
        {
            CurrData.Remove(Section);
        }

        /// <summary>
        /// 删除键
        /// </summary>
        public void DeleteProperty(string Section, string Property)
        {
            if (HasSection(Section))
            {
                CurrData[Section].Remove(Property);
            }
        }

        /// <summary>
        /// 获取字符类型的值
        /// </summary>
        public string GetString(string Section, string Property, string Defval = null)
        {
            if (CurrData.ContainsKey(Section) && CurrData[Section].ContainsKey(Property))
            {
                return CurrData[Section][Property];
            }
            return Defval;
        }

        /// <summary>
        /// 获取数字类型的值
        /// </summary>
        public int GetInt(string Section, string Property, int Defval = 0)
        {
            return GetString(Section, Property, Defval.ToString()).ToInt();
        }

        /// <summary>
        /// 获取浮点类型的值
        /// </summary>
        public float GetFloat(string Section, string Property, float Defval = 0.0f)
        {
            return GetString(Section, Property, Defval.ToString(CultureInfo.InvariantCulture)).ToFloat();
        }

        /// <summary>
        /// 获取布尔为真的值
        /// </summary>
        public bool GetTrue(string Section, string Property, bool Defval = true)
        {
            return GetString(Section, Property, Defval.ToString()).ToTrue();
        }

        /// <summary>
        /// 获取布尔为假的值
        /// </summary>
        public bool GetFalse(string Section, string Property, bool Defval = false)
        {
            return GetString(Section, Property, Defval.ToString()).ToFalse();
        }

        /// <summary>
        /// 设置字符类型的键值
        /// </summary>
        public void SetString(string Section, string Property, string Value)
        {
            if (!CurrData.ContainsKey(Section))
                CurrData[Section] = new Dictionary<string, string>();

            CurrData[Section][Property] = Value;
        }

        /// <summary>
        /// 设置数字类型的键值
        /// </summary>
        public void SetInt(string Section, string Property, int Value)
        {
            if (!CurrData.ContainsKey(Section))
                CurrData[Section] = new Dictionary<string, string>();

            CurrData[Section][Property] = Value.ToString(CultureInfo.InvariantCulture);
        }

        /// <summary>
        /// 设置浮点类型的键值
        /// </summary>
        public void SetFloat(string Section, string Property, float Value)
        {
            if (!CurrData.ContainsKey(Section))
                CurrData[Section] = new Dictionary<string, string>();

            CurrData[Section][Property] = Value.ToString(CultureInfo.InvariantCulture);
        }

        /// <summary>
        /// 设置布尔类型的键值
        /// </summary>
        public void SetBool(string Section, string Property, bool Value)
        {
            if (!CurrData.ContainsKey(Section))
                CurrData[Section] = new Dictionary<string, string>();

            CurrData[Section][Property] = Value.ToString();
        }

        /// <summary>
        /// 读取所有项的容器
        /// </summary>
        public Dictionary<string, string> GetSection(string Section)
        {
            return CurrData.ContainsKey(Section) ? CurrData[Section] : new Dictionary<string, string>();
        }

        /// <summary>
        /// 读取所有项
        /// </summary>
        public IEnumerable<Dictionary<string, string>> GetIterativeSections(string Section)
        {
            return CurrData.Where(Sect => Sect.Key.Contains("#") && Sect.Key.Length > Section.Length && Sect.Key.Substring(0, Section.Length) == Section).Select(Vs => Vs.Value);
        }

        /// <summary>
        /// 解析操作
        /// </summary>
        private void DoParse()
        {
            string CurrentSection = "", CurrentProperty = "", CurrentValue = "";
            bool Comment = false, Instring = false, InDstring = false, GotSection = false, GotProperty = false, InSection = false, Escape = false;

            foreach (var Line in CurrBuffer)
            {
                for (var i = 0; i < Line.Length; i++)
                {
                    var Chr = Line.Substring(i, 1);

                    if (Instring)
                    {
                        if (Escape)
                        {
                            Escape = false;
                            CurrentValue += Chr;
                        }
                        else if (Chr == "\\")
                        {
                            Escape = true;
                        }
                        else if (Chr == "'")
                        {
                            Instring = false;
                        }
                        else
                        {
                            CurrentValue += Chr;
                        }
                    }
                    else if (InDstring)
                    {
                        if (Escape)
                        {
                            Escape = false;
                            CurrentValue += Chr;
                        }
                        else if (Chr == "\\")
                        {
                            Escape = true;
                        }
                        else if (Chr == "\"")
                        {
                            InDstring = false;
                        }
                        else
                        {
                            CurrentValue += Chr;
                        }
                    }
                    else if (Comment)
                    {

                    }
                    else if (Chr == "'")
                    {
                        Instring = true;
                    }
                    else if (Chr == "\"")
                    {
                        InDstring = true;
                    }
                    else if (!InSection && (Chr == "#" || Chr == ";"))
                    {
                        Comment = true;
                    }
                    else if (Chr == "[" && !InSection)
                    {
                        InSection = true;
                        CurrentSection = "";
                        GotSection = false;
                    }
                    else if (Chr == "]" && InSection)
                    {
                        GotSection = true;
                        InSection = false;

                    }
                    else if (GotSection && !GotProperty && (Chr == "="))
                    {
                        GotProperty = true;
                    }
                    else
                    {
                        if ((Chr != " " && Chr != "\t") || !GotSection)
                        {
                            if (!GotSection && Chr != "\t")
                            {
                                CurrentSection += Chr;
                            }
                            else if (!GotProperty)
                            {
                                CurrentProperty += Chr;
                            }
                            else
                            {
                                if (!(CurrentValue.Length == 0 && (Chr == " " || Chr == "\t")))
                                    CurrentValue += Chr;
                            }
                        }
                        else if ((GotSection && !GotProperty && CurrentProperty.Length > 0))
                        {
                            CurrentProperty += Chr;
                        }
                    }
                }

                if (GotSection && GotProperty)
                {
                    if (!CurrData.ContainsKey(CurrentSection))
                        CurrData.Add(CurrentSection, new Dictionary<string, string>());

                    CurrData[CurrentSection][CurrentProperty.Trim()] = CurrentValue;
                }

                Comment = false;
                GotProperty = false;
                CurrentProperty = "";
                CurrentValue = "";

            }
        }
    }

    public static class InIUtils
    {
        /// <summary>
        /// 转为数字
        /// </summary>
        public static int ToInt(this string Input)
        {
            return int.TryParse(Input, out int Output) ? Output : 0;
        }

        /// <summary>
        /// 转为浮点
        /// </summary>
        public static float ToFloat(this string Input)
        {
            return float.TryParse(Input, NumberStyles.Any, CultureInfo.InvariantCulture, out float Output) ? Output : 0;
        }

        /// <summary>
        /// 转为布尔的真
        /// </summary>
        public static bool ToTrue(this string Input)
        {
            return (Input.ToLower() == "true" || Input.ToLower() == "yes" || Input.ToLower() == "on" || Input.ToLower() == "1");
        }

        /// <summary>
        /// 转为布尔的假
        /// </summary>
        public static bool ToFalse(this string Input)
        {
            return (Input.ToLower() == "false" || Input.ToLower() == "no" || Input.ToLower() == "off" || Input.ToLower() == "0");
        }

        /// <summary>
        /// 读指定键值
        /// </summary>
        public static string Get(this Dictionary<string, string> Dict, string Key, string DefaultValue = "")
        {
            return Dict.ContainsKey(Key) ? Dict[Key] : DefaultValue;
        }

        /// <summary>
        /// 读所有值
        /// </summary>
        public static Dictionary<string, string> GetIterativeProperties(this Dictionary<string, string> Dict, string Property)
        {
            return Dict.Where(Prop => Prop.Key.Contains("-") && Prop.Key.Length > Property.Length && Prop.Key.Substring(0, Property.Length) == Property).ToDictionary(Prop => Prop.Key, Prop => Prop.Value);
        }

        /// <summary>
        /// 从网络读取 暂时无用
        /// </summary>
        public static string PathFromUrl(string Url)
        {
            return "";
        }
    }
    #endregion
}