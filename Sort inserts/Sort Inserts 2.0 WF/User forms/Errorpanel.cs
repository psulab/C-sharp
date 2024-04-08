using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Sort_Inserts_2._0_WF.User_forms
{
    public partial class Errorpanel : Form
    {
        public bool errorpanel
        {
            get { return error1.Visible; }
            set { error1.Visible = value; }
        }
        public bool warningpanel
        {
            get { return warning1.Visible; }
            set { warning1.Visible = value; }
        }
        public bool savepanel
        {
            get { return save1.Visible; }
            set { save1.Visible = value; }
        }
        public bool errorfilingpanel
        {
            get { return errorfilling1.Visible; }
            set { errorfilling1.Visible = value; }
        }
        public bool yesbutton
        {
            get { return button_yes.Visible; }
            set { button_yes.Visible = value; }
        }
        public bool nobutton
        {
            get { return button_no.Visible; }
            set { button_no.Visible = value; }
        }
        public bool closebutton
        {
            get { return button_close.Visible; }
            set { button_close.Visible = value; }
        }

        Form1 a;

        public Errorpanel(Form1 parent)
        {
            InitializeComponent();
            a = parent;
        }
        private void Errorpanel_Load(object sender, EventArgs e)
        {
            this.Opacity = 0;
            timer_animates.Start();
        }
        private void button_exit_Click(object sender, EventArgs e)
        {
            timer_animatee.Start();            
        }
                      
        private void timer_animates_Tick(object sender, EventArgs e)
        {
            this.Opacity += 0.1;
            a.Opacity -= 0.03;

            if (this.Opacity == 1.0)
            {
                timer_animates.Stop();
            }
        }
        private void timer_animatee_Tick(object sender, EventArgs e)
        {
            this.Opacity -= 0.1;
            a.Opacity += 0.03;

            if (this.Opacity == 0.0)
            {
                timer_animatee.Stop();
                a.savebutton = false;
                this.Close();
            }
        }
                
        private void button_yes_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < a.count; i++)
            {
                a.finalstr_mas[i] = a.arrtextbox[i].Text;
                a.arrtextbox[i].ReadOnly = true;
                a.arrtextbox[i].TabStop = false;
            }
            timer_animatee.Start();
            a.timer_writedown.Start();
        }
        private void button_no_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < a.count; i++)
            {
                a.arrtextbox[i].ReadOnly = true;
                a.arrtextbox[i].TabStop = false;
            }
            timer_animatee.Start();
            a.timer_writedown.Start();
        }
        private void button_close_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < a.count; i++)
            {
                a.arrtextbox[i].ReadOnly = true;
                a.arrtextbox[i].TabStop = false;
            }
            timer_animatee.Start();
            a.sortoutbutton = false;
            a.timer_writedown.Start();
        }
    }
}
