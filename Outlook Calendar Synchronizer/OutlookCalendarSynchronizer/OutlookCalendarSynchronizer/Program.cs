using System;
using System.Reflection;
using System.Windows.Forms;
using Microsoft.Win32;

namespace OutlookCalendarSynchronizer
{
    internal static class Program
    {
        /// <summary>
        /// Главная точка входа для приложения.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            if (IsFirstRun())
            {
                AddToStartup();
            }

            Application.Run(new MainForm());
        }

        public static void AddToStartup()
        {
            using (var key = Registry.CurrentUser.OpenSubKey(@"SOFTWARE\Microsoft\Windows\CurrentVersion\Run", true))
            {
                key?.SetValue(Assembly.GetExecutingAssembly().GetName().Name, $"\"{Assembly.GetExecutingAssembly().Location}\"");
            }
        }

        public static bool IsFirstRun()
        {
            using (var key = Registry.CurrentUser.CreateSubKey($@"SOFTWARE\{Assembly.GetExecutingAssembly().GetName().Name}"))
            {
                if (key?.GetValue("AutoUpload") == null)
                {
                    key.SetValue("AutoUpload", 1, RegistryValueKind.DWord);
                    return true;
                }
            }
            return false;
        }
    }
}
