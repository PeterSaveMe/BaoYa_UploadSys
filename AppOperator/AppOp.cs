using System;
using System.Diagnostics;
using System.IO;
using System.Windows;

namespace BaoYa_UploadSystem.AppOperator
{
    public static class AppOp
    {
        public static void StartApp(string AppName, bool isWaitForExit = true)
        {
            if (!File.Exists(AppName))
            {
                MessageBox.Show($"{AppName} 不存在.");
                return;
            }
            Process process = new Process();
            process.StartInfo.FileName = AppName;
            process.Start();
            // 等待应用程序退出
            if (isWaitForExit)
            {
                process.WaitForExit();
            }
            Console.WriteLine($"{AppName} has exited.");
        }
    }
}