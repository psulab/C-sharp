using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Text;
using System.IO;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Text_editor
{
    public partial class EditorText : Form
    {
        /* Доступ к элементам из другого потока */
        public delegate void MyDelegate(string text);
        public delegate void MyDelegateNoParameters();
        public EditorText()
        {
            InitializeComponent();            
        }

        private PrivateFontCollection fontCollection;
        private FontFamily family;

        private const int PORT = 8080;
        private TcpClient client;
        private NetworkStream stream;
        private BinaryReader reader;
        private BinaryWriter writer;
        private Thread readData;

        private void Text_editor_Load(object sender, EventArgs e)
        {
            /* Установка шрифта */
            fontCollection = new PrivateFontCollection();
            fontCollection.AddFontFile("..\\..\\fonts\\Comfortaa-Medium.ttf"); // файл шрифта
            family = fontCollection.Families[0];
            
            LabelFonts(label1);
            LabelFonts(label2);
            LabelFonts(labelError);
            LabelFonts(labelDisconnected);
            LabelAdviceFonts(labelAdvice);
            RichTextBoxFonts(richTextBox1);

            Height = 0;
            timer_form.Start();

            try
            {
                client = new TcpClient("127.0.0.1", PORT);
                //label1.Text = "Клиент запущен";
                stream = client.GetStream(); //поток для чтения и записи
                reader = new BinaryReader(stream); //Поток для записи данных
                writer = new BinaryWriter(stream); //Поток для чтение данных

                /*Поток чтение данных*/
                readData = new Thread(() => ReadData());
                readData.IsBackground = true;
                readData.Start();
            }
            catch (Exception)
            {
                richTextBox1.Visible = false;
                labelError.Visible = true;
                timer_error.Start();
            }
        }

        /*Поток чтение данных*/
        private void ReadData()
        {
            try
            {
                while (true)
                {
                    /*Чтение данных*/
                    string readMessage = reader.ReadString();
                    BeginInvoke(new MyDelegate(EditTextBox), readMessage); //сообщение сервера

                    Thread.Sleep(20);
                }
            }
            catch (Exception)
            {
                BeginInvoke(new MyDelegateNoParameters(EditTextBox));
                BeginInvoke(new MyDelegateNoParameters(EditLabel));
            }
        }
        public void EditTextBox(string text) //изменение TextBox
        {
            richTextBox1.Text = text;
            richTextBox1.SelectionStart = richTextBox1.TextLength;
        }
        public void EditTextBox() //изменение TextBox
        {
            richTextBox1.Visible = false;
        }
        public void EditLabel() //изменение Label
        {
            labelDisconnected.Visible = true;
            timer_error.Start();
        }

        /*Запись данных*/
        private void richTextBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            /*Запись данных*/
            int caretIndex = richTextBox1.SelectionStart; //текущие положение каретки
            writer.Write(e.KeyChar.ToString() + caretIndex.ToString());
            writer.Flush();
        }

        /*Закрыть/Скрыть окно*/
        private void button_close_Click(object sender, EventArgs e)
        {
            if (client == null)
            {
                Application.Exit();
            }
            else
            {
                readData.Abort();
                reader.Close();
                writer.Close();
                stream.Close();
                client.Close();

                Application.Exit();
            }
        }
        private void button_minimize_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
        }

        /* Анимация */
        private void timer_form_Tick(object sender, EventArgs e)
        {
            Height += 40;

            if (Height == 600)
            {
                timer_form.Stop();

                timer_logo.Start();

                label1.Visible = true;
                label2.Visible = true;
            }
        }
        private void timer_logo_Tick(object sender, EventArgs e)
        {           

            label1.Left -= 3;
            label2.Left += 3;

            if (label1.Left == 12 && label2.Left == 72)
            {
                timer_logo.Stop();   
                timer_button.Start();                
            }            
        }
        private void timer_button_Tick(object sender, EventArgs e)
        {
            if (button_minimize.Top != 12)
            {
                if (!button_minimize.Visible)
                {
                    button_minimize.Visible = true;
                }
                button_minimize.Top -= 3;
            }
            else if (button_close.Top != 12)
            {
                if (!button_close.Visible)
                {
                    button_close.Visible = true;
                }
                button_close.Top -= 3;
            }
            else
            {
                timer_button.Stop();
                timer_text_editor.Start();
            }

        }
        private void timer_text_editor_Tick(object sender, EventArgs e)
        {
            panel_footer.Height += 37;

            if (panel_footer.Height == 519)
            {
                timer_text_editor.Stop();
            }
        }
        private void timer_error_Tick(object sender, EventArgs e)
        {
            panelError.Top -= 20;

            if (panelError.Top == 418)
            {
                timer_error.Stop();
            }
        }

        /* Шрифт */
        private void LabelFonts(Label label)
        {
            label.Font = new Font(family, 14); //Comfortaa-Light
        }
        private void LabelAdviceFonts(Label label)
        {
            label.Font = new Font(family, 11); //Comfortaa-Light
        }
        private void RichTextBoxFonts(RichTextBox richTextBox)
        {
            richTextBox.Font = new Font(family, 12); //Comfortaa-Light
        }
    }
}

// Устанавливаем нужный шрифт
//PrivateFontCollection fontCollection = new PrivateFontCollection();
//fontCollection.AddFontFile("..\\..\\fonts\\Finland Rounded Thin.otf"); // файл шрифта
//FontFamily family = fontCollection.Families[0];
//// Создаём шрифт и используем далее
//Font font = new Font(family, 16);
//richTextBox.Font = font;

//class DragControls : Component
//{
//    private Control handleControl;

//    public Control SelectControl
//    {
//        get
//        {
//            return handleControl;
//        }
//        set
//        {
//            handleControl = value;
//            handleControl.MouseDown += new MouseEventHandler(DragFormControl_MouseDown);
//        }
//    }

//    [DllImport("user32.dll")]
//    public static extern int SendMessage(IntPtr a, uint msg, uint wParam, uint lParam);
//    [DllImport("user32.dll")]
//    public static extern bool ReleaseCapture();

//    private void DragFormControl_MouseDown(object sender, MouseEventArgs e)
//    {
//        if (e.Button == MouseButtons.Left)
//        {
//            ReleaseCapture();
//            SendMessage(SelectControl.FindForm().Handle, 161, 2, 0);
//        }
//    }
//}