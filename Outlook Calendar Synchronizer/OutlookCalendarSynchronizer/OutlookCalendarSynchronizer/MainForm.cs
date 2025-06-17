using System;
using System.IO;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Net.Http;
using Microsoft.Win32;
using System.Reflection;
using System.Windows.Forms;
using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.Office.Interop.Outlook;

namespace OutlookCalendarSynchronizer
{
    public partial class MainForm : Form
    {
        private static readonly HttpClient client = new HttpClient { Timeout = TimeSpan.FromSeconds(10) };
        private List<List<(string CalendarName, AppointmentItem Appointment)>> calendarEvents;
        private const string DefaultAccountText = "Учётная запись";
        private const string DefaultUrlText = "URL-адрес сервера";
        private bool dragging = false;
        private Point dragCursorPoint;
        private Point dragFormPoint;
        private bool isBusy = false;
        private int calendarIndex;
        private string serverUrl;
        private int eventIndex;

        public MainForm()
        {
            InitializeComponent();
        }

        // Пользовательские методы
        // ----------------------------------------------------------------------------------------------

        private List<List<(string CalendarName, AppointmentItem Appointment)>> GetCalendarEvents(string accountName)
        {
            Microsoft.Office.Interop.Outlook.Application outlookApp = new Microsoft.Office.Interop.Outlook.Application();
            NameSpace outlookNamespace = outlookApp.GetNamespace("MAPI");
            List<(string CalendarName, AppointmentItem Appointment)> calendarEvents = new List<(string, AppointmentItem)>();
            Folders folders = outlookNamespace.Folders;

            foreach (MAPIFolder folder in folders)
            {
                if (folder.Name.Equals(accountName, StringComparison.Ordinal) ||
                    Path.GetFileNameWithoutExtension(folder.Store.FilePath).Equals(accountName, StringComparison.Ordinal))
                {
                    calendarEvents.AddRange(GetCalendarItems(folder));
                }
            }

            outlookNamespace.Logoff();

            var groupedEvents = calendarEvents
                .GroupBy(e => e.CalendarName)
                .Select(g => g.OrderByDescending(e => e.Appointment.Start).ToList())
                .ToList();

            return groupedEvents;
        }

        private List<(string CalendarName, AppointmentItem Appointment)> GetCalendarItems(MAPIFolder folder)
        {
            Items items = folder.Items;
            List<(string CalendarName, AppointmentItem Appointment)> calendarEvents = new List<(string, AppointmentItem)>();

            foreach (object item in items)
            {
                if (item is AppointmentItem appointment)
                {
                    calendarEvents.Add((folder.Name, appointment));
                }
            }

            Parallel.ForEach(folder.Folders.Cast<MAPIFolder>(), subFolder =>
            {
                calendarEvents.AddRange(GetCalendarItems(subFolder));
            });

            return calendarEvents;
        }

        public static void SaveToRegistry(string subKey, string valueName, string value)
        {
            try
            {
                using (var key = Registry.CurrentUser.CreateSubKey($@"SOFTWARE\{Assembly.GetExecutingAssembly().GetName().Name}\{subKey}"))
                {
                    key?.SetValue(valueName, value);
                }
            }
            catch
            {
                // TODO:..
            }
        }

        public static string GetFromRegistry(string subKey, string valueName)
        {
            try
            {
                using (var key = Registry.CurrentUser.OpenSubKey($@"SOFTWARE\{Assembly.GetExecutingAssembly().GetName().Name}\{subKey}"))
                {
                    return key?.GetValue(valueName) as string;
                }
            }
            catch
            {
                return null;
            }
        }

        private async Task<bool> CheckServerUrl(string url)
        {
            if (!Uri.TryCreate(url, UriKind.Absolute, out _))
            {
                return false;
            }

            try
            {
                var content = new StringContent(string.Empty, Encoding.UTF8, "text/plain");
                return (await client.PostAsync(url, content)).IsSuccessStatusCode;
            }
            catch
            {
                return false;
            }
        }

        // Кнопка "Закрыть"
        // ----------------------------------------------------------------------------------------------
        private void buttonClose_Click(object sender, EventArgs e)
        {
            System.Windows.Forms.Application.Exit();
        }

        private void buttonClose_MouseDown(object sender, MouseEventArgs e)
        {
            buttonClose.BackColor = Color.FromArgb(159, 35, 47);
        }

        private void buttonClose_MouseEnter(object sender, EventArgs e)
        {
            buttonClose.BackColor = Color.FromArgb(199, 44, 59);
        }

        private void buttonClose_MouseLeave(object sender, EventArgs e)
        {
            buttonClose.BackColor = Color.FromArgb(243, 243, 243);
        }

        private void buttonClose_MouseUp(object sender, MouseEventArgs e)
        {
            buttonClose.BackColor = Color.FromArgb(199, 44, 59);
        }

        // Кнопка "Свернуть"
        // ----------------------------------------------------------------------------------------------
        private void buttonMinimize_Click(object sender, EventArgs e)
        {
            Hide();
        }

        private void buttonMinimize_MouseDown(object sender, MouseEventArgs e)
        {
            buttonMinimize.BackColor = Color.FromArgb(194, 194, 194);
        }

        private void buttonMinimize_MouseEnter(object sender, EventArgs e)
        {
            buttonMinimize.BackColor = Color.FromArgb(231, 231, 231);
        }

        private void buttonMinimize_MouseLeave(object sender, EventArgs e)
        {
            buttonMinimize.BackColor = Color.FromArgb(243, 243, 243);
        }

        private void buttonMinimize_MouseUp(object sender, MouseEventArgs e)
        {
            buttonMinimize.BackColor = Color.FromArgb(231, 231, 231);
        }

        // MainForm
        // ----------------------------------------------------------------------------------------------

        // Обработка закрытия формы
        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing)
            {
                e.Cancel = true;
                Hide();
            }
        }

        // Перемещение формы
        private void MainForm_MouseDown(object sender, MouseEventArgs e)
        {
            dragging = true;
            dragCursorPoint = Cursor.Position;
            dragFormPoint = Location;
        }

        private void MainForm_MouseMove(object sender, MouseEventArgs e)
        {
            if (dragging)
            {
                Point dif = Point.Subtract(Cursor.Position, new Size(dragCursorPoint));
                Location = Point.Add(dragFormPoint, new Size(dif));
            }
        }

        private void MainForm_MouseUp(object sender, MouseEventArgs e)
        {
            dragging = false;
        }

        // Текстовое поле "Учётная запись"
        // ----------------------------------------------------------------------------------------------
        private void textBoxAccount_Enter(object sender, EventArgs e)
        {
            if (textBoxAccount.Text == DefaultAccountText)
            {
                textBoxAccount.Text = "";
                textBoxAccount.ForeColor = Color.Black;
            }

            textBoxBorderAccount.BackColor = Color.FromArgb(0, 120, 212);
        }

        private void textBoxAccount_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(textBoxAccount.Text))
            {
                textBoxAccount.Text = DefaultAccountText;
                textBoxAccount.ForeColor = Color.Gray;
            }
        }

        private void textBoxAccount_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Tab)
            {
                e.SuppressKeyPress = true;
                textBoxURL.Focus();
            }
        }

        // Текстовое поле "URL-адрес сервера"
        // ----------------------------------------------------------------------------------------------
        private void textBoxURL_Enter(object sender, EventArgs e)
        {
            if (textBoxURL.Text == DefaultUrlText)
            {
                serverUrl = GetFromRegistry(textBoxAccount.Text, "ServerUrl");
                textBoxURL.Text = string.IsNullOrEmpty(serverUrl) ? "" : serverUrl;
                textBoxURL.ForeColor = Color.Black;
            }

            textBoxBorderURL.BackColor = Color.FromArgb(0, 120, 212);
        }

        private void textBoxURL_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(textBoxURL.Text))
            {
                textBoxURL.Text = DefaultUrlText;
                textBoxURL.ForeColor = Color.Gray;
            }
        }

        private void textBoxURL_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Tab)
            {
                e.SuppressKeyPress = true;
                ActiveControl = null;
            }
        }

        // Кнопка "Далее"
        // ----------------------------------------------------------------------------------------------
        private async void buttonFurther_Click(object sender, EventArgs e)
        {
            if (isBusy) return;

            ActiveControl = null;

            if (string.IsNullOrWhiteSpace(textBoxAccount.Text) ||
                string.IsNullOrWhiteSpace(textBoxURL.Text) ||
                textBoxAccount.Text == DefaultAccountText ||
                textBoxURL.Text == DefaultUrlText)
            {
                return;
            }

            isBusy = true;
            textBoxURL.ReadOnly = true;
            textBoxAccount.ReadOnly = true;
            buttonFurther.Text = "Подождите...";

            calendarEvents = GetCalendarEvents(textBoxAccount.Text);
            if (calendarEvents.Count == 0)
            {
                textBoxAccount.Text = DefaultAccountText;
                textBoxAccount.ForeColor = Color.Gray;
                textBoxBorderAccount.BackColor = Color.FromArgb(199, 44, 59);
            }

            bool isUrlValid = await CheckServerUrl(textBoxURL.Text);
            if (!isUrlValid)
            {
                textBoxURL.Text = DefaultUrlText;
                textBoxURL.ForeColor = Color.Gray;
                textBoxBorderURL.BackColor = Color.FromArgb(199, 44, 59);
            }

            if (calendarEvents.Count > 0 && isUrlValid)
            {
                calendarIndex = eventIndex = 0;
                labelCalendar.Text = calendarEvents[calendarIndex][0].CalendarName;
                textBoxSubject.Text = calendarEvents[calendarIndex][eventIndex].Appointment.Subject;
                textBoxLocation.Text = calendarEvents[calendarIndex][eventIndex].Appointment.Location;
                textBoxStart.Text = calendarEvents[calendarIndex][eventIndex].Appointment.Start.ToString("dd.MM.yyyy HH:mm");
                textBoxEnd.Text = calendarEvents[calendarIndex][eventIndex].Appointment.End.ToString("dd.MM.yyyy HH:mm");
                textBoxBody.Text = calendarEvents[calendarIndex][eventIndex].Appointment.Body;

                if (string.IsNullOrEmpty(serverUrl))
                {
                    SaveToRegistry(textBoxAccount.Text, "ServerUrl", textBoxURL.Text);
                    serverUrl = textBoxURL.Text;
                }

                synchronization.Visible = true;
            }

            buttonFurther.Text = "Далее";
            textBoxAccount.ReadOnly = false;
            textBoxURL.ReadOnly = false;
            isBusy = false;
        }

        private void buttonFurther_MouseDown(object sender, MouseEventArgs e)
        {
            if (isBusy) return;
            buttonFurther.BackColor = Color.FromArgb(0, 120, 212);
        }

        private void buttonFurther_MouseEnter(object sender, EventArgs e)
        {
            if (isBusy) return;
            buttonFurther.BackColor = Color.FromArgb(0, 96, 170);
        }

        private void buttonFurther_MouseLeave(object sender, EventArgs e)
        {
            if (isBusy) return;
            buttonFurther.BackColor = Color.FromArgb(0, 120, 212);
        }

        private void buttonFurther_MouseUp(object sender, MouseEventArgs e)
        {
            if (isBusy) return;
            buttonFurther.BackColor = Color.FromArgb(0, 96, 170);
        }

        // Кнопка "Стрелка влево (Календарь)"
        // ----------------------------------------------------------------------------------------------

        private void buttonCalendarLeft_Click(object sender, EventArgs e)
        {
            if (calendarIndex < calendarEvents.Count - 1)
            {
                calendarIndex++;
                eventIndex = 0;
                labelCalendar.Text = calendarEvents[calendarIndex][0].CalendarName;
                textBoxSubject.Text = calendarEvents[calendarIndex][eventIndex].Appointment.Subject;
                textBoxLocation.Text = calendarEvents[calendarIndex][eventIndex].Appointment.Location;
                textBoxStart.Text = calendarEvents[calendarIndex][eventIndex].Appointment.Start.ToString("dd.MM.yyyy HH:mm");
                textBoxEnd.Text = calendarEvents[calendarIndex][eventIndex].Appointment.End.ToString("dd.MM.yyyy HH:mm");
                textBoxBody.Text = calendarEvents[calendarIndex][eventIndex].Appointment.Body;
            }
        }

        private void buttonCalendarLeft_MouseDown(object sender, MouseEventArgs e)
        {
            buttonCalendarLeft.BackColor = Color.FromArgb(0, 120, 212);
        }

        private void buttonCalendarLeft_MouseEnter(object sender, EventArgs e)
        {
            buttonCalendarLeft.BackColor = Color.FromArgb(0, 96, 170);
        }

        private void buttonCalendarLeft_MouseLeave(object sender, EventArgs e)
        {
            buttonCalendarLeft.BackColor = Color.FromArgb(0, 120, 212);
        }

        private void buttonCalendarLeft_MouseUp(object sender, MouseEventArgs e)
        {
            buttonCalendarLeft.BackColor = Color.FromArgb(0, 96, 170);
        }

        // Кнопка "Стрелка вправо (Календарь)"
        // ----------------------------------------------------------------------------------------------
        private void buttonCalendarRight_Click(object sender, EventArgs e)
        {
            if (calendarIndex > 0)
            {
                calendarIndex--;
                eventIndex = 0;
                labelCalendar.Text = calendarEvents[calendarIndex][0].CalendarName;
                textBoxSubject.Text = calendarEvents[calendarIndex][eventIndex].Appointment.Subject;
                textBoxLocation.Text = calendarEvents[calendarIndex][eventIndex].Appointment.Location;
                textBoxStart.Text = calendarEvents[calendarIndex][eventIndex].Appointment.Start.ToString("dd.MM.yyyy HH:mm");
                textBoxEnd.Text = calendarEvents[calendarIndex][eventIndex].Appointment.End.ToString("dd.MM.yyyy HH:mm");
                textBoxBody.Text = calendarEvents[calendarIndex][eventIndex].Appointment.Body;
            }
        }

        private void buttonCalendarRight_MouseDown(object sender, MouseEventArgs e)
        {
            buttonCalendarRight.BackColor = Color.FromArgb(0, 120, 212);
        }

        private void buttonCalendarRight_MouseEnter(object sender, EventArgs e)
        {
            buttonCalendarRight.BackColor = Color.FromArgb(0, 96, 170);
        }

        private void buttonCalendarRight_MouseLeave(object sender, EventArgs e)
        {
            buttonCalendarRight.BackColor = Color.FromArgb(0, 120, 212);
        }

        private void buttonCalendarRight_MouseUp(object sender, MouseEventArgs e)
        {
            buttonCalendarRight.BackColor = Color.FromArgb(0, 96, 170);
        }

        // Кнопка "Стрелка влево (Событие)"
        // ----------------------------------------------------------------------------------------------
        private void buttonEventLeft_Click(object sender, EventArgs e)
        {
            if (eventIndex < calendarEvents[calendarIndex].Count - 1)
            {
                eventIndex++;
                textBoxSubject.Text = calendarEvents[calendarIndex][eventIndex].Appointment.Subject;
                textBoxLocation.Text = calendarEvents[calendarIndex][eventIndex].Appointment.Location;
                textBoxStart.Text = calendarEvents[calendarIndex][eventIndex].Appointment.Start.ToString("dd.MM.yyyy HH:mm");
                textBoxEnd.Text = calendarEvents[calendarIndex][eventIndex].Appointment.End.ToString("dd.MM.yyyy HH:mm");
                textBoxBody.Text = calendarEvents[calendarIndex][eventIndex].Appointment.Body;
            }
        }

        private void buttonEventLeft_MouseDown(object sender, MouseEventArgs e)
        {
            buttonEventLeft.BackColor = Color.FromArgb(0, 120, 212);
        }

        private void buttonEventLeft_MouseEnter(object sender, EventArgs e)
        {
            buttonEventLeft.BackColor = Color.FromArgb(0, 96, 170);
        }

        private void buttonEventLeft_MouseLeave(object sender, EventArgs e)
        {
            buttonEventLeft.BackColor = Color.FromArgb(0, 120, 212);
        }

        private void buttonEventLeft_MouseUp(object sender, MouseEventArgs e)
        {
            buttonEventLeft.BackColor = Color.FromArgb(0, 96, 170);
        }

        // Кнопка "Стрелка вправо (Событие)"
        // ----------------------------------------------------------------------------------------------
        private void buttonEventRight_Click(object sender, EventArgs e)
        {
            if (eventIndex > 0)
            {
                eventIndex--;
                textBoxSubject.Text = calendarEvents[calendarIndex][eventIndex].Appointment.Subject;
                textBoxLocation.Text = calendarEvents[calendarIndex][eventIndex].Appointment.Location;
                textBoxStart.Text = calendarEvents[calendarIndex][eventIndex].Appointment.Start.ToString("dd.MM.yyyy HH:mm");
                textBoxEnd.Text = calendarEvents[calendarIndex][eventIndex].Appointment.End.ToString("dd.MM.yyyy HH:mm");
                textBoxBody.Text = calendarEvents[calendarIndex][eventIndex].Appointment.Body;
            }
        }

        private void buttonEventRight_MouseDown(object sender, MouseEventArgs e)
        {
            buttonEventRight.BackColor = Color.FromArgb(0, 120, 212);
        }

        private void buttonEventRight_MouseEnter(object sender, EventArgs e)
        {
            buttonEventRight.BackColor = Color.FromArgb(0, 96, 170);
        }

        private void buttonEventRight_MouseLeave(object sender, EventArgs e)
        {
            buttonEventRight.BackColor = Color.FromArgb(0, 120, 212);
        }

        private void buttonEventRight_MouseUp(object sender, MouseEventArgs e)
        {
            buttonEventRight.BackColor = Color.FromArgb(0, 96, 170);
        }

        // Кнопка "Синхронизировать"
        // ----------------------------------------------------------------------------------------------
        private async void buttonSynchronize_Click(object sender, EventArgs e)
        {
            if (isBusy) return;
            isBusy = true;
            buttonSynchronize.Text = "Подождите...";
            ActiveControl = null;
            string requestBody = $"{labelCalendar.Text},{textBoxSubject.Text},{textBoxLocation.Text},{textBoxStart.Text},{textBoxEnd.Text},{textBoxBody.Text}";

            try
            {
                var content = new StringContent(requestBody, Encoding.UTF8, "text/plain");
                var response = await client.PostAsync(textBoxURL.Text, content);
                buttonSynchronize.Text = response.IsSuccessStatusCode ? "Синхронизация выполнена" : "Синхронизация провалена";
                buttonSynchronize.BackColor = response.IsSuccessStatusCode ? Color.FromArgb(40, 167, 69) : Color.FromArgb(199, 44, 59);
            }
            catch
            {
                buttonSynchronize.Text = "Синхронизация провалена";
                buttonSynchronize.BackColor = Color.FromArgb(199, 44, 59);
            }

            await Task.Delay(2000);
            buttonSynchronize.Text = "Синхронизировать";
            buttonSynchronize.BackColor = Color.FromArgb(0, 120, 212);
            isBusy = false;
        }

        private void buttonSynchronize_MouseDown(object sender, MouseEventArgs e)
        {
            if (isBusy) return;
            buttonSynchronize.BackColor = Color.FromArgb(0, 120, 212);
        }

        private void buttonSynchronize_MouseEnter(object sender, EventArgs e)
        {
            if (isBusy) return;
            buttonSynchronize.BackColor = Color.FromArgb(0, 96, 170);
        }

        private void buttonSynchronize_MouseLeave(object sender, EventArgs e)
        {
            if (isBusy) return;
            buttonSynchronize.BackColor = Color.FromArgb(0, 120, 212);
        }

        private void buttonSynchronize_MouseUp(object sender, MouseEventArgs e)
        {
            if (isBusy) return;
            buttonSynchronize.BackColor = Color.FromArgb(0, 96, 170);
        }

        // Кнопка "Трей-значок"
        // ----------------------------------------------------------------------------------------------
        private void notifyIconOCS_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                Show();
                WindowState = FormWindowState.Normal;
            }
        }

        private void синхронизаторКалендарейOutlookToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Show();
            WindowState = FormWindowState.Normal;
        }

        private void выходToolStripMenuItem_Click(object sender, EventArgs e)
        {
            System.Windows.Forms.Application.Exit();
        }
    }
}

/*
 
 
 */