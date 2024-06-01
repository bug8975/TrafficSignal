using log4net.Config;
using System;
using System.IO;
using System.Windows.Forms;

namespace TrafficSignal
{
    static class Program
    {
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main()
        {
            // 初始化log4net
            var logConfigFile = new FileInfo(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Config", "log4net.config"));
            if (logConfigFile.Exists)
            {
                XmlConfigurator.ConfigureAndWatch(logConfigFile);
            }
            else
            {
                MessageBox.Show("日志配置文件未找到，请确保log4net.config文件存在于Config目录下。", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Views.MySqlContextView());
        }
    }
}
