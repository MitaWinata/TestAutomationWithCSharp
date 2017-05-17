using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Remote;
using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Appium.Android;
using System.Diagnostics;
using System.Reflection;
using System.IO;

namespace SupportLibraries
{
    public static class Helpers
    {
        private static string appiumLogPath = Path.Combine(
                GetTestResultFolder(),
                "appiumLog"
                + DateTime.Now.ToString("yyyy-MM-ddTHHmmss")
                + ".log"
            );
        private static string appLogPath = Path.Combine(
                GetTestResultFolder(),
                "appLog"
                + DateTime.Now.ToString("yyyy-MM-ddTHHmmss")
                + ".log"
            );
        public static int StartAppiumServer(string serverAddress,
                                            string serverPort,
                                            string boostrapPort,
                                            string phoneUUID)
        {
            KillProcess("node");
            string path = Path.Combine(
                GetTestBinaryAbsolutePath() +
                @"/../../../../SupportLibraries/scripts",
                "StartAppiumServer.bat"
            );

            ProcessStartInfo info = new ProcessStartInfo(
                                          path
                                        );
            info.WindowStyle = ProcessWindowStyle.Hidden;
            info.Arguments = serverAddress + " " +
                serverPort + " " +
                boostrapPort + " " +
                phoneUUID + " " +
                appiumLogPath;
            info.UseShellExecute = false;
            Process p = Process.Start(info);
            System.Threading.Thread.Sleep(5000);
            return p.Id;
        }
        public static void KillProcess(string processName)
        {
            var process = Process.GetProcessesByName(processName);
            foreach (Process nextProcess in process)
            {
                nextProcess.Kill();
            }
        }
        public static void GetScreenShoot(
            AndroidDriver<AndroidElement> driver,
            string filePath)
        {
            driver.GetScreenshot().SaveAsFile(filePath,
                            System.Drawing.Imaging.ImageFormat.Jpeg);
        }
        public static void isAppInstalled(string packageName)
        {
            Process adb = executeADBCommand(
                                "shell pm list packages | grep " 
                                + packageName);

        }

        public static Process executeADBCommand(
           string command
        )
        {
            ProcessStartInfo procStartInfo = new ProcessStartInfo(
                                            "cmd", "/c adb " + command);
            procStartInfo.RedirectStandardOutput = true;
            procStartInfo.UseShellExecute = false;
            procStartInfo.CreateNoWindow = true;
            Process proc = new Process();
            proc.StartInfo = procStartInfo;
            proc.Start();
            return proc;
        }

        public static void CollectAppLog(string packageName)
        {
            executeADBCommand("logcat -d > " + appLogPath
                               + " " + packageName);
        }
        public static string GetTestResultFolder()
        {
            return Path.Combine(
                   GetTestBinaryAbsolutePath() +
                   @"/../../../../TestResults/"
               );
        }
        public static string GetBinaryPath()
        {
            string binaryName = Path.GetFileName(Assembly.GetExecutingAssembly().Location);
            return Path.Combine(
                GetTestBinaryAbsolutePath() + @"\..\" + binaryName
            );
        }
        public static string GetTestBinaryAbsolutePath()
        {
            return ((new Uri(Assembly.GetExecutingAssembly().CodeBase)).AbsolutePath);
        }
    }
}