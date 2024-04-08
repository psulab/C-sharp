using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Sort_Inserts_2._0_WF.User_controls
{
    public partial class Help : UserControl
    {
        public bool picture1
        {
            get { return pictureBox2.Enabled; }
            set { pictureBox2.Enabled = value; }
        }
        public bool picture2
        {
            get { return pictureBox4.Enabled; }
            set { pictureBox4.Enabled = value; }
        }

        public Help()
        {
            InitializeComponent();
        }

        private void button_close_Click(object sender, EventArgs e)
        {
            pictureBox2.Enabled = false;
            pictureBox4.Enabled = false;
            timer_help.Start();
        }
        private void timer_help_Tick(object sender, EventArgs e)
        {
            this.Top += 20;

            if (this.Top == 260)
            {               
                timer_help.Stop();
            }
        }
    }
}
