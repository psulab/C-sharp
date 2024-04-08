using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Sort_Inserts_2._0_WF
{
    public partial class Form1 : Form
    {
        public bool savebutton
        {
            get { return button_save.Visible; }
            set { button_save.Visible = value; }
        }
        public bool sortoutbutton
        {
            get { return button_sortout.Visible; }
            set { button_sortout.Visible = value; }
        }

        public TextBox[] arrtextbox;
        Panel[] arrpanel;

        public Form1()
        {
            InitializeComponent();
            arrtextbox = Controls.OfType<TextBox>().ToArray();
            arrpanel = Controls.OfType<Panel>().ToArray();

            for (int i = 0; i < arrtextbox.Length; i++)
            {
                TextBox text = new TextBox();               
                for (int j = i+1; j < arrtextbox.Length; j++)
                {
                    if (arrtextbox[i].TabIndex > arrtextbox[j].TabIndex)
                    {
                        text = arrtextbox[i];
                        arrtextbox[i] = arrtextbox[j];
                        arrtextbox[j] = text;
                    }                    
                }
                arrtextbox[i].TabStop = false;
                arrtextbox[i].ReadOnly = true;
            }

            for (int i = 0; i < arrpanel.Length; i++)
            {
                Panel panel = new Panel();
                for (int j = i + 1; j < arrpanel.Length; j++)
                {
                    if (arrpanel[i].TabIndex > arrpanel[j].TabIndex)
                    {
                        panel = arrpanel[i];
                        arrpanel[i] = arrpanel[j];
                        arrpanel[j] = panel;
                    }
                }
            }
        }
        private void Form1_Load(object sender, EventArgs e)
        {            
            pictureBox1.Top = -32;
            panel_animate.Left = 50;
            button_openfile.Enabled = false;
            timer_animatelogo.Start();
        }
        private void button_exit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        private void button_minimize_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
        }
        private void button_help_Click(object sender, EventArgs e)
        {
            help1.picture1 = false;
            help1.picture2 = false;
            help1.Height = this.Height;
            timer_help.Start();
        }

        public string[] finalstr_mas;
        public int count;
        bool animate = true;

        private void button_openfile_Click(object sender, EventArgs e)
        {
            OpenFileDialog open_file = new OpenFileDialog();

            string str = null;            

            if (open_file.ShowDialog() == DialogResult.OK)
            {
                string filename = open_file.FileName; // храниться путь к файлу
                str = File.ReadAllText(filename); // сюда считываеься всё что было в файле
            }

            if (str == "") // если не чего не было записанно
            {
                User_forms.Errorpanel error = new User_forms.Errorpanel(this);
                error.errorpanel = true;
                error.ShowDialog();
            }
            else if (str != null) // было записанно
            {
                animate = true;
                bool space = false,
                     dot = false;
                int counter = 0;

                string finalstr = null;

                // фильтруеться строка и остаються только числа которые записываються в новую строку - finalstr
                for (int i = 0; i < str.Length; i++)
                {
                    if (counter > 19)
                    {
                        break;
                    }
                    if ((i != str.Length - 1) && space && (str[i] == ' ' || str[i] == ','))
                    {
                        finalstr += str[i];
                        space = false;
                        counter++;
                    }
                    else if ((i != str.Length - 1) && dot && (str[i] == '.') && (str[i + 1] >= 48 && str[i + 1] <= 57))
                    {
                        finalstr += str[i];
                        dot = false;
                    }
                    else if ((str[i] == '-') || (str[i] >= 48 && str[i] <= 57))
                    {
                        finalstr += str[i];
                        space = true;
                        dot = true;
                    }
                }

                // минимум чилел = 10 максимум = 20
                if (counter < 9 || counter > 19)
                {
                    User_forms.Errorpanel error = new User_forms.Errorpanel(this);
                    error.warningpanel = true;
                    error.ShowDialog();
                }
                else
                {
                    button_editing.Enabled = false;
                    button_sortout.Visible = false;
                    //button_editing.Enabled = true;

                    //очищает весь текст со всех textbox
                    for (int i = 0; i < arrtextbox.Length; i++)
                    {
                        arrtextbox[i].Clear();
                    }

                    if (counter > 9)
                    {
                        for (int i = 10; i < arrtextbox.Length; i++)
                        {
                            arrtextbox[i].Visible = arrpanel[i].Visible = true;                           
                        }

                        for (int i = counter+1; i < arrtextbox.Length; i++)
                        {
                            arrtextbox[i].Visible = arrpanel[i].Visible = false;
                        }

                        this.Height = 204;
                        timer_increase.Start();
                    }
                    else
                    {
                        if (this.Height != 204)
                        {
                            timer_reduce.Start();
                        }
                    }
                                        
                    finalstr_mas = new string[counter + 1]; // динамический массив из строк

                    //записывает в finalstr_mas чиста из финальной строки
                    for (int i = 0, c = 0; i < finalstr.Length; i++)
                    {
                        if (finalstr[i] == ' ' || finalstr[i] == ',')
                        {
                            c++;
                            continue;
                        }
                        finalstr_mas[c] += finalstr[i];
                    }

                    count = counter + 1;
                    timer_writedown.Start(); // анимация заполнения textbox
                }

            }
        }
        private void button_editing_Click(object sender, EventArgs e)
        {
            button_save.Visible = true;
            button_sortout.Visible = false;

            for (int i = 0; i < count; i++)
            {
                arrtextbox[i].ReadOnly = false;
                arrtextbox[i].TabStop = true;
            }

            for (int i = count; i < arrtextbox.Length; i++)
            {
                arrtextbox[i].ReadOnly = true;
                arrtextbox[i].TabStop = false;
            }

            arrtextbox[0].Focus();
        }
        private void button_save_Click(object sender, EventArgs e)
        {
            bool cafi = true;
            for (int i = 0; i < count; i++)
            {
                if (arrtextbox[i].Text == "")
                {
                    cafi = false;
                    break;
                }

                int dot = 0;

                for (int j = 0; j < arrtextbox[i].Text.Length; j++)
                {                    
                    if (arrtextbox[i].Text[j] == '-' && j != 0)
                    {
                        i = count + 1;
                        cafi = false;
                        break;                       
                    }
                    else if (arrtextbox[i].Text[j] == '.')
                    {
                        dot++;
                        if (j == 0 || j == arrtextbox[i].Text.Length - 1 || dot > 1 || arrtextbox[i].Text[j - 1] == '-' )
                        {
                            i = count + 1;
                            cafi = false;
                            break;
                        }                                        
                    }                    
                    else if (arrtextbox[i].Text[j] != '-' && arrtextbox[i].Text[j] != '.' && (arrtextbox[i].Text[j] < 48 || arrtextbox[i].Text[j] > 57))
                    {
                        i = count + 1;
                        cafi = false;
                        break;
                    }
                }                
            }

            User_forms.Errorpanel error = new User_forms.Errorpanel(this);

            if (cafi)
            {
                error.savepanel = true;
                error.yesbutton = true;
                error.nobutton = true;
            }
            else
            {
                error.errorfilingpanel = true;
                error.closebutton = true;
            }          
            
            error.ShowDialog();
        }
        private void button_sortout_Click(object sender, EventArgs e)
        {
            double[] sort_inserts = new double[count];

            for (int i = 0; i < count; i++)
            {
                sort_inserts[i] = Convert.ToDouble(finalstr_mas[i]);
            }

            // алгоритм сортировки
            for (int i = 0; i < count-1; i++)
            {
                if (sort_inserts[i] > sort_inserts[i + 1])
                {
                    for (int j = 0; j < i + 1; j++)
                    {
                        if (sort_inserts[j] > sort_inserts[i + 1])
                        {
                            double swap = sort_inserts[j];
                            sort_inserts[j] = sort_inserts[i + 1];
                            for (int k = i + 1; k > j + 1; k--)
                            {
                                sort_inserts[k] = sort_inserts[k - 1];
                            }
                            sort_inserts[j + 1] = swap;
                            break;
                        }
                    }
                }
            }

            for (int i = 0; i < count; i++)
            {
                finalstr_mas[i] = Convert.ToString(sort_inserts[i]);
            }

            button_editing.Enabled = false;
            button_sortout.Visible = false;
            animate = false;
            timer_writedown.Start();
        }
        private void button_saveresult_Click(object sender, EventArgs e)
        {
            string str = null;

            for (int i = 0; i < count; i++)
            {
                str += finalstr_mas[i];
                str += ' ';
            }

            SaveFileDialog save_file = new SaveFileDialog();            

            if (save_file.ShowDialog() == DialogResult.OK)
            {
                string filename = save_file.FileName; // храниться путь к файлу
                File.WriteAllText(filename, str); // по указонному пути(filename) считывает всё что было в str
            }
        }

        int index = 0, counter = 0;        
        private void timer_animatelogo_Tick(object sender, EventArgs e)
        {
            if (panel_animate.Left != -160)
            {
                panel_animate.Left -= 14;
            }
            else if (pictureBox1.Top != 12)
            {
                pictureBox1.Top += 4;
            }
            else if (counter < 104)
            {
                if (counter < 100)
                {
                    arrtextbox[index].Left--;
                    arrtextbox[index].Top++;
                }
                counter++;
                if (counter % 5 == 0)
                {
                    index++;
                }
                if (index > 0)
                {
                    arrtextbox[index - 1].Left++;
                    arrtextbox[index - 1].Top--;
                }              
            }
            else if (this.Height != 204)
            {
                this.Height -= 4;
            }
            else
            {
                index = counter = 0;
                button_openfile.Enabled = true;               
                timer_animatelogo.Stop();
            }
        }
        private void timer_increase_Tick(object sender, EventArgs e)
        {
            this.Height += 4;
            if (this.Height == 260)
            {
                timer_increase.Stop();
            }
        }
        private void timer_reduce_Tick(object sender, EventArgs e)
        {
            this.Height -= 4;
            if (this.Height == 204)
            {
                timer_reduce.Stop();
            }
        }
        private void timer_writedown_Tick(object sender, EventArgs e)
        {
            if (index < count)
            {
                if (counter < count*5)
                {
                    arrtextbox[index].Left--;
                    arrtextbox[index].Top++;
                }
                counter++;
                if (counter % 5 == 0)
                {
                    index++;
                    arrtextbox[index - 1].Text = finalstr_mas[index - 1];
                }
                if (index != 0 && index < count)
                {                    
                    arrtextbox[index - 1].Left++;
                    arrtextbox[index - 1].Top--;
                }
            }
            else if (counter < count * 5 + 5)
            {
                arrtextbox[index - 1].Left++;
                arrtextbox[index - 1].Top--;
                counter++;
            }
            else
            {
                index = counter = 0;                

                if (animate)
                {
                    button_editing.Enabled = true;
                    button_sortout.Enabled = true;
                    button_saveresult.Visible = false;
                    button_sortout.Top = 67;
                    button_sortout.Visible = true;
                    timer_upsortout.Start();
                }
                else
                {
                    button_sortout.Visible = false;
                    button_saveresult.Top = 67;
                    button_saveresult.Visible = true;
                    timer_savetofile.Start();
                }
                
                timer_writedown.Stop();                
            }
        }
        private void timer_upsortout_Tick(object sender, EventArgs e)
        {
            button_sortout.Top -= 5;

            if (button_sortout.Top == 12)
            {
                timer_upsortout.Stop();
            }
        }
        private void timer_savetofile_Tick(object sender, EventArgs e)
        {
            button_saveresult.Top -= 5;

            if (button_saveresult.Top == 12)
            {
                timer_savetofile.Stop();
            }
        }
        private void timer_help_Tick(object sender, EventArgs e)
        {
            help1.Top -= 20;

            if (help1.Top == 0)
            {
                help1.picture1 = true;
                help1.picture2 = true;
                timer_help.Stop();
            }
        }
    }
}
