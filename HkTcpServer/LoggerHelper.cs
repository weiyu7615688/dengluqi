using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Windows.Forms;

namespace IoNetWork
{
    /*
     * 使用方法
     *  Logger.Write("Test");
     * Logger.Write(DateTime.Now, MsgType.Error, "Test");
     */

    #region 消息类型枚举
    /// <summary>  
    /// 日志消息类型的枚举  
    /// </summary>  
    public enum MsgType
    {
        /// <summary>
        /// 普通类型
        /// </summary>
        Information,
        /// <summary>
        /// 警告类型
        /// </summary>
        Warning,
        /// <summary>
        /// 错误类型
        /// </summary>
        Error,
        /// <summary>
        /// 成功类型
        /// </summary>
        Success,
        /// <summary>
        /// 致命类型
        /// </summary>
        Fatal
    }
    #endregion

    /// <summary>
    /// 日志类 不阻塞线程
    /// </summary>
    public class Logger
    {
        public static void Write(string MsgText)
        {
            Write(DateTime.Now, MsgType.Information, MsgText);
        }

        /// <summary>
        /// 写日志基础方法 时间/消息类型/内容
        /// </summary>
        public static void Write(DateTime MsgDataTime, MsgType MType, string MsgText)
        {
            QueueManager WQueue = new QueueManager();
            WQueue.WriteToQueue(MsgDataTime, MType, MsgText);
        }

        #region 应用框架的日志队列类
        /// <summary>  
        /// 应用框架的日志类  
        /// </summary>  
        private class QueueManager : IDisposable
        {
            /// <summary>
            /// 日志对象的缓存队列
            /// </summary>
            private static Queue<LogMsg> MsgQueues;

            /// <summary>
            /// 日志文件保存的路径
            /// </summary>
            private static readonly string LogPath = Application.StartupPath + "\\AppLogs\\";

            /// <summary>
            /// 日志写入文件线程的状态 true为正在写入 
            /// </summary>
            private static bool LogState = false;

            /// <summary>
            /// 日志文件生命周期的时间标记  
            /// </summary>
            private static DateTime TimeSign;

            /// <summary>
            /// 日志文件写入流对象
            /// </summary>
            private static StreamWriter Writer;

            /// <summary>
            /// 委托器
            /// </summary>
            private delegate void WorkDelegate();
            private static WorkDelegate WorkDg;

            /// <summary>
            /// 初始化日志队列类
            /// </summary>
            public QueueManager()
            {
                if (MsgQueues == null)
                {
                    if (!Directory.Exists(LogPath))
                        Directory.CreateDirectory(LogPath);

                    MsgQueues = new Queue<LogMsg>();
                    WorkDg = new WorkDelegate(Work);
                }
            }

            /// <summary>
            /// 写入新日志 根据指定的日志对象Msg
            /// </summary>
            private void WriteToQueue(LogMsg Msger)
            {
                if (Msger != null)
                {
                    lock (MsgQueues)
                    {
                        MsgQueues.Enqueue(Msger);
                    }
                }
                if (MsgQueues.Count > 0 && !LogState)
                {
                    LogState = true;
                    WorkDg.BeginInvoke(null, null);
                }
            }

            /// <summary>
            /// 日志写入文件线程执行的工作方法
            /// </summary>
            private void Work()
            {
                //判断队列中是否存在待写入的日志
                while (MsgQueues.Count > 0)
                {
                    LogMsg Msger = null;
                    lock (MsgQueues)
                    {
                        Msger = MsgQueues.Dequeue();
                    }
                    if (Msger != null)
                    {
                        WriteToFile(Msger);
                    }
                }
                LogState = false;
                FileClose();
            }

            /// <summary>
            /// 通过判断文件的到期时间标记将决定是否创建新文件
            /// </summary>
            private static string GetFilename()
            {
                DateTime Now = DateTime.Now;
                string Format = "yyyy-MM-dd'.log'";
                TimeSign = new DateTime(Now.Year, Now.Month, Now.Day);
                TimeSign = TimeSign.AddDays(1);
                return Now.ToString(Format);
            }

            /// <summary>
            /// 写入日志文本到文件的方法
            /// </summary>
            private void WriteToFile(LogMsg Msger)
            {
                try
                {
                    if (Writer == null)
                        FileOpen();

                    //判断文件到期标志 如果当前文件到期则关闭当前文件创建新的日志文件
                    if (DateTime.Now >= TimeSign)
                    {
                        FileClose();
                        FileOpen();
                    }

                    if (Writer != null)
                    {
                        string TypeText = string.Empty;
                        switch (Msger.Type)
                        {
                            case MsgType.Information:
                                TypeText = "日志类型<普通>";
                                break;
                            case MsgType.Warning:
                                TypeText = "日志类型<警告>";
                                break;
                            case MsgType.Error:
                                TypeText = "日志类型<错误>";
                                break;
                            case MsgType.Success:
                                TypeText = "日志类型<普通>";
                                break;
                            case MsgType.Fatal:
                                TypeText = "日志类型<致命>";
                                break;
                            default:
                                TypeText = "日志类型<普通>";
                                break;
                        }
                        Writer.WriteLine(string.Format("{0}", Msger.Datetime) + "\t" + TypeText + "\t" + Msger.Text);
                        Writer.Flush();
                    }
                }
                catch (Exception/* Ex*/)
                {
                    //ConsoleHelper.WriteErr(true, "日志错误 错误信息\n" + Ex.Message);
                }
            }

            /// <summary>
            /// 打开文件准备写入
            /// </summary>
            private void FileOpen()
            {
                Writer = new StreamWriter(LogPath + GetFilename(), true, Encoding.UTF8);
            }

            /// <summary>
            /// 关闭打开的日志文件
            /// </summary>
            private void FileClose()
            {
                if (Writer != null)
                {
                    Writer.Flush();
                    Writer.Close();
                    Writer.Dispose();
                    Writer = null;
                }
            }


            /// <summary>
            /// 写入新日志 根据指定的日志时间 日志内容和信息类型写入新日志
            /// </summary>
            public void WriteToQueue(DateTime MsgDataTime, MsgType MType, string MsgText)
            {
                WriteToQueue(new LogMsg(MsgDataTime, MType, MsgText));
            }

            /// <summary>  
            /// 销毁日志对象  
            /// </summary>  
            public void Dispose()
            {
                LogState = false;
            }

            #endregion

            #region 日志记录的对象实例
            /// <summary>  
            /// 日志记录的对象  
            /// </summary>  
            private class LogMsg
            {
                /// <summary>
                /// 创建新的日志记录实例
                /// </summary>
                public LogMsg(DateTime MsgDataTime, MsgType MType, string MsgText)
                {
                    Datetime = MsgDataTime;
                    Type = MType;
                    Text = MsgText;
                }

                /// <summary>
                /// 获取或设置日志记录的时间
                /// </summary>
                public DateTime Datetime { get; private set; }

                /// <summary>
                /// 获取或设置日志记录的消息类型
                /// </summary>
                public MsgType Type { get; private set; }

                /// <summary>
                /// 获取或设置日志记录的文本内容
                /// </summary>
                public string Text { get; private set; }
            }
        }
        #endregion
    }
}
