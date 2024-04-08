using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PBWF
{
    struct myFormat
    {
        public StringBuilder formatNumber;
        public int counterNumber;
    }
    public partial class Form1 : Form
    {
        private myFormat textFormat1, textFormat2;
        private Color imagePixelColor;
        private Random random = new Random();
        private Button[] arrButtons;
        private int buttonIndex, buttonIndexIA, waitingTime;
        private bool RVA1, RVA2, isPress, isActiveMouse, nonNumberEntered;
        private string[] fileName;

        public Form1()
        {
            InitializeComponent();

            toolTip1.ForeColor = Color.FromArgb(97, 97, 97);
            toolTip1.BackColor = Color.FromArgb(242, 242, 242);

            toolTip1.SetToolTip(button1, "Свернуть");
            toolTip1.SetToolTip(button2, "Закрыть");
            toolTip1.SetToolTip(textBox1, "      Для редактирования текущего значения,\n      заново нажмите на него.");
            toolTip1.SetToolTip(textBox2, "      Для редактирования текущего значения,\n      заново нажмите на него.");
            toolTip1.SetToolTip(button14, "      Формат числа: \u00B1\u2329целое\u232A.\u2329дробное\u232A где,\n      \u2776 [ -9  \u2264    \u2329целая часть\u232A    \u2264  9 ]\n      \u2777 [  0  \u2264  \u2329дробная часть\u232A  \u2264  9 ]");

            arrButtons = new Button[] { button1, button2, button3, button4, button5, button6, button7, button8, button9, button10, button11, button12, button13, button14, button15 };
            fileName = new string[]
            {
                "Random value.txt",
                "Keyboard.txt",
                "Mouse.txt",
                "File.txt"
            };

            // 0  button1     - свернуть окно
            // 1  button2     - закрыть окно

            // 2  button3     - случайное значение
            // 3  button4     - клавиатура
            // 4  button5     - мышка
            // 5  button6     - файл

            // 6  button7     - сгенерировать х
            // 7  button8     - сгенерировать у
            // 8  button9     - готово
            // 9  button10    - назад

            // 10 button11    - готово
            // 11 button12    - назад

            // 12 button13    - назад

            // 13 button14    - открыть
            // 14 button15    - назад
        }

        // My functions ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

        void checkPointAffiliation(float x, float y, string fileName)
        {
            float result = (x * x) + (y * y);

            if ((x >= -0.7f && x <= 1.0f) && (y >= -1.0f && y <= 1.0f))
            {
                if (result == 1.0f) // точка лежит на границе круга
                {
                    label17.Text = "Точка с координатами [ " + x.ToString() + "; " + y.ToString() + " ] находится :\n\u25CB На границе закрашенной области";
                }
                else if (result < 1.0f) // точка лежит внутри круга
                {
                    label17.Text = "Точка с координатами [ " + x.ToString() + "; " + y.ToString() + " ] находится :\n\u25CF Внутри закрашенной области";
                }
                else  // точка лежит вне круга
                {
                    label17.Text = "Точка с координатами [ " + x.ToString() + "; " + y.ToString() + " ] находится :\n\u25D9 Вне закрашенной области";
                }
            }
            else  // точка лежит вне круга
            {
                label17.Text = "Точка с координатами [ " + x.ToString() + "; " + y.ToString() + " ] находится :\n\u25D9 Вне закрашенной области";
            }

            using (BinaryWriter bw = new BinaryWriter(File.Open(fileName, FileMode.Append)))
            {
                bw.Write(label17.Text + Environment.NewLine);
            }
        }

        ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

        /* Анимация кнопки */
        private void timerButtonAnimation_Tick(object sender, EventArgs e)
        {
            if (250 == arrButtons[buttonIndex].FlatAppearance.MouseOverBackColor.A)
                timerButtonAnimation.Stop();

            arrButtons[buttonIndex].FlatAppearance.MouseOverBackColor = Color.FromArgb(
                arrButtons[buttonIndex].FlatAppearance.MouseOverBackColor.A + 5,
                arrButtons[buttonIndex].FlatAppearance.MouseOverBackColor.R,
                arrButtons[buttonIndex].FlatAppearance.MouseOverBackColor.G,
                arrButtons[buttonIndex].FlatAppearance.MouseOverBackColor.B
                );
        }

        /* Анимация интерфейса */
        private void timerInterfaceAnimation_Tick(object sender, EventArgs e)
        {
            switch (buttonIndexIA)
            {
                case 2:
                    {
                        if (820 == this.Size.Width)
                            interfaceAnimationPart2(ref panel9);
                        else
                            interfaceAnimationPart1();
                    }
                    break;
                case 3:
                    {
                        if (820 == this.Size.Width)
                            interfaceAnimationPart2(ref panel15);
                        else
                            interfaceAnimationPart1();
                    }
                    break;
                case 4:
                    {
                        if (820 == this.Size.Width)
                            interfaceAnimationPart2(ref panel23);
                        else
                            interfaceAnimationPart1();
                    }
                    break;
                case 5:
                    {
                        if (820 == this.Size.Width)
                            interfaceAnimationPart2(ref panel26);
                        else
                            interfaceAnimationPart1();
                    }
                    break;
                case 9:
                    {
                        if (500 != this.Size.Width)
                            interfaceAnimationBackPart1(ref panel9);
                        else
                            interfaceAnimationBackPart2();
                    }
                    break;
                case 10:
                    {
                        if (500 != this.Size.Width)
                            interfaceAnimationBackPart1(ref panel15);
                        else
                            interfaceAnimationBackPart2();
                    }
                    break;
                case 11:
                    {
                        if (500 != this.Size.Width)
                            interfaceAnimationBackPart1(ref panel23);
                        else
                            interfaceAnimationBackPart2();
                    }
                    break;
                case 12:
                    {
                        if (500 != this.Size.Width)
                            interfaceAnimationBackPart1(ref panel26);
                        else
                            interfaceAnimationBackPart2();
                    }
                    break;
            }
        }

        void interfaceAnimationPart1()
        {
            if (-40 == panel1.Top)
            {
                if (-500 == panel8.Left)
                {
                    if (756 == this.Size.Width)
                    {
                        panel1.Size = new Size(this.Size.Width + 64, panel1.Size.Height);
                        panel9.Location = new Point(-410, panel9.Location.Y);
                        panel15.Location = new Point(-410, panel15.Location.Y);
                        panel23.Location = new Point(-410, panel23.Location.Y);
                        panel26.Location = new Point(-410, panel26.Location.Y);
                        panel30.Location = new Point(panel30.Location.X, 450);
                    }

                    this.Size = new Size(this.Size.Width + 64, this.Size.Height);
                }
                else
                {
                    if (-450 == panel8.Left)
                        this.Location = new Point(this.Location.X - 160, this.Location.Y);

                    panel8.Left -= 50;
                }
            }
            else
            {
                panel1.Top -= 4;
            }
        }
        void interfaceAnimationPart2(ref Panel panelAnimation)
        {
            if (0 == panel30.Top)
            {
                if (0 == panelAnimation.Left)
                {
                    if (0 == panel1.Top)
                    {
                        timerInterfaceAnimation.Stop();
                        return;
                    }

                    panel1.Top += 4;
                }
                else
                {
                    panelAnimation.Left += 41;
                }
            }
            else
            {
                panel30.Top -= 45;
            }
        }

        void interfaceAnimationBackPart1(ref Panel panelAnimation)
        {
            if (-40 == panel1.Top)
            {
                if (-410 == panelAnimation.Left)
                {
                    if (450 == panel30.Top)
                    {
                        if (564 == this.Size.Width)
                        {
                            panel1.Size = new Size(this.Size.Width - 64, panel1.Size.Height);
                            panel8.Location = new Point(-500, panel8.Location.Y);

                            //panel1.Location = new Point(0, 0);
                            //panel8.Location = new Point(0, 40);
                        }

                        this.Size = new Size(this.Size.Width - 64, this.Size.Height);
                    }
                    else
                    {
                        if (405 == panel30.Top)
                            this.Location = new Point(this.Location.X + 160, this.Location.Y);

                        panel30.Top += 45;
                    }
                }
                else
                {
                    panelAnimation.Left -= 41;
                }
            }
            else
            {
                panel1.Top -= 4;
            }
        }
        void interfaceAnimationBackPart2()
        {
            if (0 == panel8.Left)
            {
                if (0 == panel1.Top)
                {
                    timerInterfaceAnimation.Stop();
                    return;
                }

                panel1.Top += 4;
            }
            else
            {
                panel8.Left += 50;
            }
        }

        /* Анимация Сгенерировать Х */
        private void timerRVAnimation1_Tick(object sender, EventArgs e)
        {
            if (0 != label5.Padding.Bottom)
            {
                label5.Padding = new Padding(label5.Padding.Left, label5.Padding.Top, label5.Padding.Right, label5.Padding.Bottom - 5);

                if (0 == label5.Padding.Bottom)
                {
                    RVA1 = true;
                    timerRVAnimation1.Stop();
                }
            }
            else if (50 != label5.Padding.Top)
            {
                label5.Padding = new Padding(label5.Padding.Left, label5.Padding.Top + 5, label5.Padding.Right, label5.Padding.Bottom);

                if (50 == label5.Padding.Top)
                {
                    label5.Padding = new Padding(0, 0, 0, 50);

                    int wholePart = random.Next(-9, 10);    // [-9/9]
                    int fractionalPart = random.Next(10);   // [0/9]
                    label5.Text = wholePart.ToString() + '.' + fractionalPart.ToString();
                }
            }
        }

        /* Анимация Сгенерировать Y */
        private void timerRVAnimation2_Tick(object sender, EventArgs e)
        {
            if (0 != label7.Padding.Bottom)
            {
                label7.Padding = new Padding(label7.Padding.Left, label7.Padding.Top, label7.Padding.Right, label7.Padding.Bottom - 5);

                if (0 == label7.Padding.Bottom)
                {
                    RVA2 = true;
                    timerRVAnimation2.Stop();
                }
            }
            else if (50 != label7.Padding.Top)
            {
                label7.Padding = new Padding(label7.Padding.Left, label7.Padding.Top + 5, label7.Padding.Right, label7.Padding.Bottom);

                if (50 == label7.Padding.Top)
                {
                    label7.Padding = new Padding(0, 0, 0, 50);

                    int wholePart = random.Next(-9, 10);    // [-9/9]
                    int fractionalPart = random.Next(10);   // [0/9]
                    label7.Text = wholePart.ToString() + '.' + fractionalPart.ToString();
                }
            }
        }

        /* Анимация результата */
        private void timerResultAnimation_Tick(object sender, EventArgs e)
        {
            if (0 == waitingTime)
            {
                if (420 == panel32.Top)
                {
                    waitingTime = 200;
                    panel32.Visible = false;
                    timerResultAnimation.Stop();
                }
                else
                {
                    panel32.Top += 4;
                }
            }
            else if (380 == panel32.Top)
            {
                waitingTime--;
            }
            else
            {
                panel32.Top -= 4;
            }
        }

        // Заголовок меню ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

        /* Свернуть окно */
        private void button1_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
            label1.Select();
        }
        private void button1_MouseEnter(object sender, EventArgs e)
        {
            button1.FlatAppearance.MouseOverBackColor = Color.FromArgb(0, 169, 169, 169);
            buttonIndex = 0;
            timerButtonAnimation.Start();
        }
        private void button1_MouseLeave(object sender, EventArgs e)
        {
            timerButtonAnimation.Stop();
        }

        /* Закрыть окно */
        private void button2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        private void button2_MouseEnter(object sender, EventArgs e)
        {
            button2.FlatAppearance.MouseOverBackColor = Color.FromArgb(0, 217, 78, 115);
            buttonIndex = 1;
            timerButtonAnimation.Start();
        }
        private void button2_MouseLeave(object sender, EventArgs e)
        {
            timerButtonAnimation.Stop();
        }

        // Главное меню ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

        /* Случайное значение */
        private void button3_Click(object sender, EventArgs e)
        {
            FileStream fs = new FileStream(fileName[0], FileMode.Create);
            fs.Close();

            RVA1 = true;
            RVA2 = true;
            panel32.Visible = false;

            label5.Text = "0.0";
            label7.Text = "0.0";

            buttonIndexIA = 2;
            timerInterfaceAnimation.Start();
        }
        private void button3_MouseEnter(object sender, EventArgs e)
        {
            button3.FlatAppearance.MouseOverBackColor = Color.FromArgb(0, 63, 191, 178);
            buttonIndex = 2;
            timerButtonAnimation.Start();
        }
        private void button3_MouseLeave(object sender, EventArgs e)
        {
            timerButtonAnimation.Stop();
        }

        /* Клавиатура */
        private void button4_Click(object sender, EventArgs e)
        {
            FileStream fs = new FileStream(fileName[1], FileMode.Create);
            fs.Close();

            panel32.Visible = false;

            textBox1.Text = "0.0";
            textBox2.Text = "0.0";

            buttonIndexIA = 3;
            timerInterfaceAnimation.Start();
        }
        private void button4_MouseEnter(object sender, EventArgs e)
        {
            button4.FlatAppearance.MouseOverBackColor = Color.FromArgb(0, 63, 191, 178);
            buttonIndex = 3;
            timerButtonAnimation.Start();
        }
        private void button4_MouseLeave(object sender, EventArgs e)
        {
            timerButtonAnimation.Stop();
        }

        /* Мышка */
        private void button5_Click(object sender, EventArgs e)
        {
            FileStream fs = new FileStream(fileName[2], FileMode.Create);
            fs.Close();

            isActiveMouse = true;
            panel32.Visible = false;

            buttonIndexIA = 4;
            timerInterfaceAnimation.Start();
        }
        private void button5_MouseEnter(object sender, EventArgs e)
        {
            button5.FlatAppearance.MouseOverBackColor = Color.FromArgb(0, 63, 191, 178);
            buttonIndex = 4;
            timerButtonAnimation.Start();
        }
        private void button5_MouseLeave(object sender, EventArgs e)
        {
            timerButtonAnimation.Stop();
        }

        /* Файл */
        private void button6_Click(object sender, EventArgs e)
        {
            FileStream fs = new FileStream(fileName[3], FileMode.Create);
            fs.Close();

            panel32.Visible = false;

            buttonIndexIA = 5;
            timerInterfaceAnimation.Start();
        }
        private void button6_MouseEnter(object sender, EventArgs e)
        {
            button6.FlatAppearance.MouseOverBackColor = Color.FromArgb(0, 63, 191, 178);
            buttonIndex = 5;
            timerButtonAnimation.Start();
        }
        private void button6_MouseLeave(object sender, EventArgs e)
        {
            timerButtonAnimation.Stop();
        }

        // Меню "Случайное значение" ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

        /* Сгенерировать Х */
        private void button7_Click(object sender, EventArgs e)
        {
            if (RVA1)
            {
                label5.Padding = new Padding(0, 0, 0, 0);
                timerRVAnimation1.Start();
                RVA1 = false;
            }
        }
        private void button7_MouseEnter(object sender, EventArgs e)
        {
            button7.FlatAppearance.MouseOverBackColor = Color.FromArgb(0, 63, 191, 178);
            buttonIndex = 6;
            timerButtonAnimation.Start();
        }
        private void button7_MouseLeave(object sender, EventArgs e)
        {
            timerButtonAnimation.Stop();
        }

        /* Сгенерировать Y */
        private void button8_Click(object sender, EventArgs e)
        {
            if (RVA2)
            {
                label7.Padding = new Padding(0, 0, 0, 0);
                timerRVAnimation2.Start();
                RVA2 = false;
            }
        }
        private void button8_MouseEnter(object sender, EventArgs e)
        {
            button8.FlatAppearance.MouseOverBackColor = Color.FromArgb(0, 63, 191, 178);
            buttonIndex = 7;
            timerButtonAnimation.Start();
        }
        private void button8_MouseLeave(object sender, EventArgs e)
        {
            timerButtonAnimation.Stop();
        }

        /* Готово */
        private void button9_Click(object sender, EventArgs e)
        {
            float x = Convert.ToSingle(label5.Text, new CultureInfo("en-US"));
            float y = Convert.ToSingle(label7.Text, new CultureInfo("en-US"));

            checkPointAffiliation(x, y, fileName[0]);

            if (timerResultAnimation.Enabled)
                timerResultAnimation.Stop();

            waitingTime = 200;
            panel32.Location = new Point(50, 420); //50; 380
            panel32.Visible = true;
            timerResultAnimation.Start();
        }
        private void button9_MouseEnter(object sender, EventArgs e)
        {
            button9.FlatAppearance.MouseOverBackColor = Color.FromArgb(0, 63, 191, 178);
            buttonIndex = 8;
            timerButtonAnimation.Start();
        }
        private void button9_MouseLeave(object sender, EventArgs e)
        {
            timerButtonAnimation.Stop();
        }

        /* Назад */
        private void button10_Click(object sender, EventArgs e)
        {
            buttonIndexIA = 9;
            timerInterfaceAnimation.Start();
        }
        private void button10_MouseEnter(object sender, EventArgs e)
        {
            button10.FlatAppearance.MouseOverBackColor = Color.FromArgb(0, 218, 218, 218);
            buttonIndex = 9;
            timerButtonAnimation.Start();
        }
        private void button10_MouseLeave(object sender, EventArgs e)
        {
            timerButtonAnimation.Stop();
        }

        // Меню "Клавиатура" ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

        /* Текстовое поле 1 */
        private void textBox1_Click(object sender, EventArgs e)
        {
            textFormat1.counterNumber = 0;
            isPress = false;

            textBox1.MaxLength = 3;
            textBox1.SelectAll();
        }
        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (isPress)
            {
                nonNumberEntered = true;
                return;
            }

            isPress = true;
            nonNumberEntered = false;

            if (e.KeyCode == Keys.OemMinus || e.KeyCode == Keys.Subtract)
            {
                if (textFormat1.counterNumber == 0)
                {
                    textBox1.MaxLength = 4;
                }
                else
                {
                    textFormat1.counterNumber--;
                    nonNumberEntered = true;
                }
            }
            else if (e.KeyCode == Keys.Delete)
            {
                textFormat1.counterNumber--;
                e.Handled = true;
            }
            else if (Control.ModifierKeys == Keys.Shift)
            {
                textFormat1.counterNumber--;
                nonNumberEntered = true;
            }
            else if (e.KeyCode < Keys.D0 || e.KeyCode > Keys.D9)
            {
                if (e.KeyCode < Keys.NumPad0 || e.KeyCode > Keys.NumPad9)
                {
                    textFormat1.counterNumber--;
                    nonNumberEntered = true;
                }
            }

            textFormat1.counterNumber++;
        }
        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (true == nonNumberEntered)
                e.Handled = true;
        }
        private void textBox1_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.OemMinus || e.KeyCode == Keys.Subtract)
            {
                if (textBox1.Text.IndexOf('.').Equals(-1))
                {
                    textBox1.Text += "0";
                    textBox1.Select(textBox1.TextLength - 1, textBox1.TextLength);
                }
            }
            else if ((e.KeyCode >= Keys.D0 && e.KeyCode <= Keys.D9) || (e.KeyCode >= Keys.NumPad0 && e.KeyCode <= Keys.NumPad9))
            {
                if (textBox1.Text.IndexOf('.').Equals(-1))
                {
                    textBox1.Text += ".0";
                    textBox1.Select(textBox1.TextLength - 1, textBox1.TextLength);
                }
            }

            isPress = false;
        }

        /* Текстовое поле 2 */
        private void textBox2_Click(object sender, EventArgs e)
        {
            textFormat2.counterNumber = 0;
            isPress = false;

            textBox2.MaxLength = 3;
            textBox2.SelectAll();
        }
        private void textBox2_KeyDown(object sender, KeyEventArgs e)
        {
            if (isPress)
            {
                nonNumberEntered = true;
                return;
            }

            isPress = true;
            nonNumberEntered = false;

            if (e.KeyCode == Keys.OemMinus || e.KeyCode == Keys.Subtract)
            {
                if (textFormat2.counterNumber == 0)
                {
                    textBox2.MaxLength = 4;
                }
                else
                {
                    textFormat2.counterNumber--;
                    nonNumberEntered = true;
                }
            }
            else if (e.KeyCode == Keys.Delete)
            {
                textFormat2.counterNumber--;
                e.Handled = true;
            }
            else if (Control.ModifierKeys == Keys.Shift)
            {
                textFormat2.counterNumber--;
                nonNumberEntered = true;
            }
            else if (e.KeyCode < Keys.D0 || e.KeyCode > Keys.D9)
            {
                if (e.KeyCode < Keys.NumPad0 || e.KeyCode > Keys.NumPad9)
                {
                    textFormat2.counterNumber--;
                    nonNumberEntered = true;
                }
            }

            textFormat2.counterNumber++;
        }
        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (true == nonNumberEntered)
                e.Handled = true;
        }
        private void textBox2_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.OemMinus || e.KeyCode == Keys.Subtract)
            {
                if (textBox2.Text.IndexOf('.').Equals(-1))
                {
                    textBox2.Text += "0";
                    textBox2.Select(textBox2.TextLength - 1, textBox2.TextLength);
                }
            }
            else if ((e.KeyCode >= Keys.D0 && e.KeyCode <= Keys.D9) || (e.KeyCode >= Keys.NumPad0 && e.KeyCode <= Keys.NumPad9))
            {
                if (textBox2.Text.IndexOf('.').Equals(-1))
                {
                    textBox2.Text += ".0";
                    textBox2.Select(textBox2.TextLength - 1, textBox2.TextLength);
                }
            }

            isPress = false;
        }

        /* Готово */
        private void button11_Click(object sender, EventArgs e)
        {
            float x = Convert.ToSingle(textBox1.Text, new CultureInfo("en-US"));
            float y = Convert.ToSingle(textBox2.Text, new CultureInfo("en-US"));

            checkPointAffiliation(x, y, fileName[1]);

            if (timerResultAnimation.Enabled)
                timerResultAnimation.Stop();

            waitingTime = 200;
            panel32.Location = new Point(50, 420); //50; 380
            panel32.Visible = true;
            timerResultAnimation.Start();
        }
        private void button11_MouseEnter(object sender, EventArgs e)
        {
            button11.FlatAppearance.MouseOverBackColor = Color.FromArgb(0, 63, 191, 178);
            buttonIndex = 10;
            timerButtonAnimation.Start();
        }
        private void button11_MouseLeave(object sender, EventArgs e)
        {
            timerButtonAnimation.Stop();
        }

        /* Назад */
        private void button12_Click(object sender, EventArgs e)
        {
            buttonIndexIA = 10;
            timerInterfaceAnimation.Start();
        }
        private void button12_MouseEnter(object sender, EventArgs e)
        {
            button12.FlatAppearance.MouseOverBackColor = Color.FromArgb(0, 218, 218, 218);
            buttonIndex = 11;
            timerButtonAnimation.Start();
        }
        private void button12_MouseLeave(object sender, EventArgs e)
        {
            timerButtonAnimation.Stop();
        }

        // Меню "Мышка" ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

        /* Назад */
        private void button13_Click(object sender, EventArgs e)
        {
            isActiveMouse = false;

            buttonIndexIA = 11;
            timerInterfaceAnimation.Start();
        }
        private void button13_MouseEnter(object sender, EventArgs e)
        {
            button13.FlatAppearance.MouseOverBackColor = Color.FromArgb(0, 218, 218, 218);
            buttonIndex = 12;
            timerButtonAnimation.Start();
        }
        private void button13_MouseLeave(object sender, EventArgs e)
        {
            timerButtonAnimation.Stop();
        }

        /* Система координат (pictureBox6) */
        private void pictureBox6_MouseClick(object sender, MouseEventArgs e)
        {
            if (isActiveMouse)
            {
                label17.Text = "Данная точка находится :\n\u25D9 Вне закрашенной области";

                using (BinaryWriter bw = new BinaryWriter(File.Open(fileName[2], FileMode.Append)))
                {
                    bw.Write(label17.Text + Environment.NewLine);
                }

                if (timerResultAnimation.Enabled)
                    timerResultAnimation.Stop();

                waitingTime = 200;
                panel32.Location = new Point(50, 420); //50; 380
                panel32.Visible = true;
                timerResultAnimation.Start();
            }
        }
        private void pictureBox6_MouseMove(object sender, MouseEventArgs e)
        {
            if (isActiveMouse)
            {
                try
                {
                    Bitmap bitmap = new Bitmap(pictureBox6.ClientSize.Width, pictureBox6.ClientSize.Height);
                    pictureBox6.DrawToBitmap(bitmap, pictureBox6.ClientRectangle);
                    Color pixelColor = bitmap.GetPixel(Convert.ToInt32(e.X), Convert.ToInt32(e.Y));
                    button13.BackColor = pixelColor;
                    button13.ForeColor = Color.FromArgb(242, 242, 242);

                    if (pixelColor.Equals(Color.FromArgb(242, 242, 242)))
                        button13.ForeColor = Color.FromArgb(97, 97, 97);

                    button13.Text = "RGB [" + pixelColor.R.ToString() + ' ' + pixelColor.G.ToString() + ' ' + pixelColor.B.ToString() + "]";
                    bitmap.Dispose();
                }
                catch (Exception)
                {
                    ;
                }
            }
        }

        /* Система координат (pictureBox7) */
        private void pictureBox7_MouseClick(object sender, MouseEventArgs e)
        {
            if (isActiveMouse)
            {
                if (imagePixelColor == Color.FromArgb(242, 242, 242)) // точка лежит вне круга
                {
                    label17.Text = "Данная точка находится :\n\u25D9 Вне закрашенной области";
                }
                else if(
                    imagePixelColor == Color.FromArgb(206, 206, 206) ||
                    imagePixelColor == Color.FromArgb(196, 196, 196) ||
                    imagePixelColor == Color.FromArgb(178, 178, 178) ||
                    imagePixelColor == Color.FromArgb(169, 169, 169)
                    ) // точка лежит внутри круга
                {
                    label17.Text = "Данная точка находится :\n\u25CF Внутри закрашенной области";
                }
                else // точка лежит на границе круга
                {
                    label17.Text = "Данная точка находится :\n\u25CB На границе закрашенной области";
                }


                using (BinaryWriter bw = new BinaryWriter(File.Open(fileName[2], FileMode.Append)))
                {
                    bw.Write(label17.Text + Environment.NewLine);
                }

                if (timerResultAnimation.Enabled)
                    timerResultAnimation.Stop();

                waitingTime = 200;
                panel32.Location = new Point(50, 420); //50; 380
                panel32.Visible = true;
                timerResultAnimation.Start();
            }
        }
        private void pictureBox7_MouseMove(object sender, MouseEventArgs e)
        {
            if (isActiveMouse)
            {
                try
                {
                    Bitmap bitmap = new Bitmap(pictureBox7.ClientSize.Width, pictureBox7.ClientSize.Height);
                    pictureBox7.DrawToBitmap(bitmap, pictureBox7.ClientRectangle);
                    Color pixelColor = bitmap.GetPixel(Convert.ToInt32(e.X), Convert.ToInt32(e.Y));
                    imagePixelColor = pixelColor;
                    button13.BackColor = pixelColor;
                    button13.ForeColor = Color.FromArgb(242, 242, 242);

                    if (pixelColor.Equals(Color.FromArgb(242, 242, 242)))
                        button13.ForeColor = Color.FromArgb(97, 97, 97);

                    button13.Text = "RGB [" + pixelColor.R.ToString() + ' ' + pixelColor.G.ToString() + ' ' + pixelColor.B.ToString() + "]";
                    bitmap.Dispose();
                }
                catch (Exception)
                {
                    ;
                }
            }
        }

        private void pictureBox_MouseLeave(object sender, EventArgs e)
        {
            button13.BackColor = Color.FromArgb(242, 242, 242);
            button13.Text = "Назад";
        }

        // Меню "Мышка" ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

        /* Открыть */
        private void button14_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                float x = 0.0f, y = 0.0f;
                int editCounter = 2;

                try
                {
                    using (BinaryReader br = new BinaryReader(openFileDialog1.OpenFile()))
                    {
                        myFormat textFormat;
                        textFormat.formatNumber = new StringBuilder("0.0");
                        textFormat.counterNumber = 0;

                        while (br.PeekChar() > -1)
                        {
                            char symbol = br.ReadChar();

                            if (0 == textFormat.counterNumber && symbol == '-')
                            {
                                textFormat.formatNumber.Insert(0, symbol);
                                textFormat.counterNumber++;
                            }
                            else if (symbol >= 48 && symbol <= 57)
                            {
                                textFormat.formatNumber.Replace('0', symbol, textFormat.counterNumber, 1);
                                textFormat.counterNumber += 2;

                                if (textFormat.formatNumber.Length < textFormat.counterNumber && Convert.ToBoolean(editCounter--))
                                {
                                    x = Convert.ToSingle(textFormat.formatNumber.ToString(), new CultureInfo("en-US"));
                                    swap(ref x, ref y);

                                    textFormat.formatNumber = new StringBuilder("0.0");
                                    textFormat.counterNumber = 0;

                                    if (!Convert.ToBoolean(editCounter))
                                        break;
                                }
                            }
                        }
                    }

                    if (!Convert.ToBoolean(editCounter))
                    {
                        checkPointAffiliation(x, y, fileName[3]);
                    }
                    else
                    {
                        label17.Text = "Координаты точки не найдены, пожалуйста\nпроверьте правильность входных данных.";

                        using (BinaryWriter bw = new BinaryWriter(File.Open(fileName[3], FileMode.Append)))
                        {
                            bw.Write(label17.Text + Environment.NewLine);
                        }
                    }
                }
                catch (Exception)
                {
                    label17.Text = "Файл был открыт с ошибкой, пожалуйста\nпроверьте правильность входных данных.";

                    using (BinaryWriter bw = new BinaryWriter(File.Open(fileName[3], FileMode.Append)))
                    {
                        bw.Write(label17.Text + Environment.NewLine);
                    }
                }
            }

            if (timerResultAnimation.Enabled)
                timerResultAnimation.Stop();

            waitingTime = 200;
            panel32.Location = new Point(50, 420); //50; 380
            panel32.Visible = true;
            timerResultAnimation.Start();
        }
        private void button14_MouseEnter(object sender, EventArgs e)
        {
            button14.FlatAppearance.MouseOverBackColor = Color.FromArgb(0, 63, 191, 178);
            buttonIndex = 13;
            timerButtonAnimation.Start();
        }
        private void button14_MouseLeave(object sender, EventArgs e)
        {
            timerButtonAnimation.Stop();
        }

        /* Назад */
        private void button15_Click(object sender, EventArgs e)
        {
            buttonIndexIA = 12;
            timerInterfaceAnimation.Start();
        }
        private void button15_MouseEnter(object sender, EventArgs e)
        {
            button15.FlatAppearance.MouseOverBackColor = Color.FromArgb(0, 218, 218, 218);
            buttonIndex = 14;
            timerButtonAnimation.Start();
        }
        private void button15_MouseLeave(object sender, EventArgs e)
        {
            timerButtonAnimation.Stop();
        }

        /* Swap */
        void swap(ref float a, ref float b)
        {
            float temp = a;
            a = b;
            b = temp;
        }

        /* Всплывающие подсказки */
        private void toolTip_Draw(object sender, DrawToolTipEventArgs e)
        {
            if (e.AssociatedControl == button1 || e.AssociatedControl == button2)
            {
                e.DrawBackground();

                using (Font font = new Font("Segoe UI", 10))
                {
                    using (StringFormat stringFormat = new StringFormat())
                    {
                        stringFormat.Alignment = StringAlignment.Center;
                        stringFormat.LineAlignment = StringAlignment.Center;
                        stringFormat.FormatFlags = StringFormatFlags.NoWrap;
                        stringFormat.HotkeyPrefix = System.Drawing.Text.HotkeyPrefix.None;

                        e.Graphics.DrawString(e.ToolTipText, font, new SolidBrush(Color.DarkGray), e.Bounds, stringFormat);
                    }
                }
            }
            else
            {
                e.DrawBackground();

                using (Font font = new Font("Segoe UI", 10))
                {
                    using (StringFormat stringFormat = new StringFormat())
                    {
                        stringFormat.Alignment = StringAlignment.Near;
                        stringFormat.LineAlignment = StringAlignment.Center;
                        stringFormat.FormatFlags = StringFormatFlags.NoWrap;
                        stringFormat.HotkeyPrefix = System.Drawing.Text.HotkeyPrefix.None;

                        e.Graphics.DrawString(e.ToolTipText, font, new SolidBrush(Color.FromArgb(97, 97, 97)), e.Bounds, stringFormat);
                    }
                }
            }
        }
        private void toolTip_Popup(object sender, PopupEventArgs e)
        {
            if (e.AssociatedControl == button1 || e.AssociatedControl == button2)
                e.ToolTipSize = new Size(80, 40);
            else if (e.AssociatedControl == textBox1 || e.AssociatedControl == textBox2)
                e.ToolTipSize = new Size(300, 60);
            else
                e.ToolTipSize = new Size(300, 80);
        }
    }
}

//void interfaceAnimationPart1()
//{
//    if (-40 == panel1.Top)
//    {
//        if (-500 == panel8.Left)
//        {
//            if (820 == this.Size.Width)
//                timerInterfaceAnimation.Stop();

//            this.Size = new Size(this.Size.Width + 64, this.Size.Height);
//        }
//        else
//        {
//            if (-450 == panel8.Left)
//                this.Location = new Point(this.Location.X - 160, this.Location.Y);

//            panel8.Left -= 50;
//        }
//    }
//    else
//    {
//        panel1.Top -= 4;
//    }
//}

//void interfaceAnimationPart2(ref Panel panelAnimation)
//{
//    if (0 == panel30.Top)
//    {
//        if (0 == panel1.Top)
//        {
//            if (0 == panelAnimation.Left)
//            {
//                timerInterfaceAnimation.Stop();
//                return;
//            }

//            panelAnimation.Left += 41;
//        }
//        else
//        {
//            panel1.Top += 4;
//        }
//    }
//    else
//    {
//        panel30.Top += 45;
//    }
//}

//void interfaceAnimationBackPart1(ref Panel panelAnimation)
//{
//    if (-40 == panel1.Top)
//    {
//        if (-410 == panelAnimation.Left)
//        {
//            if (450 == panel30.Top)
//            {
//                if (500 == this.Size.Width)

//                    this.Size = new Size(this.Size.Width - 64, this.Size.Height);
//            }
//            else
//            {
//                if (405 == panel30.Top)
//                    this.Location = new Point(this.Location.X + 160, this.Location.Y);

//                panel30.Top += 45;
//            }
//        }
//        else
//        {
//            panelAnimation.Left -= 41;
//        }
//    }
//    else
//    {
//        panel1.Top -= 4;
//    }
//}


//float x = Convert.ToSingle(label5.Text, new CultureInfo("en-US"));
//float y = Convert.ToSingle(label7.Text, new CultureInfo("en-US"));
//float result = (x * x) + (y * y);

//            if (result == 1.0f) // точка лежит на границе круга
//            {
//                label17.Text = "Точка с координатами [ " + label5.Text + "; " + label7.Text + " ] находится :\n\u25CB На границе закрашенной области";
//            }
//            else if (result< 1.0f) // точка лежит внутри круга
//            {
//                label17.Text = "Точка с координатами [ " + label5.Text + "; " + label7.Text + " ] находится :\n\u25CF Внутри закрашенной области";
//            }
//            else  // точка лежит вне круга
//            {
//                label17.Text = "Точка с координатами [ " + label5.Text + "; " + label7.Text + " ] находится :\n\u25D9 Вне закрашенной области";
//            }


//float x = Convert.ToSingle(label5.Text, new CultureInfo("en-US"));
//float y = Convert.ToSingle(label7.Text, new CultureInfo("en-US"));
//float result = (x * x) + (y * y);

//            if ((x >= -0.7f && x <= 1.0f) && (y >= -1.0f && y <= 1.0f))
//            {
//                if (result == 1.0f) // точка лежит на границе круга
//                {
//                    label17.Text = "Точка с координатами [ " + label5.Text + "; " + label7.Text + " ] находится :\n\u25CB На границе закрашенной области";
//                }
//                else if (result< 1.0f) // точка лежит внутри круга
//                {
//                    label17.Text = "Точка с координатами [ " + label5.Text + "; " + label7.Text + " ] находится :\n\u25CF Внутри закрашенной области";
//                }
//            }            
//            else  // точка лежит вне круга
//            {
//                label17.Text = "Точка с координатами [ " + label5.Text + "; " + label7.Text + " ] находится :\n\u25D9 Вне закрашенной области";
//            }