namespace OutlookCalendarSynchronizer
{
    partial class MainForm
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.panel1 = new System.Windows.Forms.Panel();
            this.synchronization = new System.Windows.Forms.Panel();
            this.buttonEventRight = new System.Windows.Forms.Label();
            this.buttonCalendarLeft = new System.Windows.Forms.Label();
            this.buttonCalendarRight = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.panel11 = new System.Windows.Forms.Panel();
            this.panel12 = new System.Windows.Forms.Panel();
            this.labelCalendar = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.buttonEventLeft = new System.Windows.Forms.Label();
            this.panel8 = new System.Windows.Forms.Panel();
            this.panel7 = new System.Windows.Forms.Panel();
            this.textBoxLocation = new System.Windows.Forms.TextBox();
            this.panel9 = new System.Windows.Forms.Panel();
            this.panel10 = new System.Windows.Forms.Panel();
            this.textBoxBody = new System.Windows.Forms.TextBox();
            this.panel14 = new System.Windows.Forms.Panel();
            this.panel13 = new System.Windows.Forms.Panel();
            this.textBoxStart = new System.Windows.Forms.TextBox();
            this.panel16 = new System.Windows.Forms.Panel();
            this.panel15 = new System.Windows.Forms.Panel();
            this.textBoxEnd = new System.Windows.Forms.TextBox();
            this.panel17 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.textBoxSubject = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.buttonSynchronize = new System.Windows.Forms.Label();
            this.authorization = new System.Windows.Forms.Panel();
            this.textBoxBorderURL = new System.Windows.Forms.Panel();
            this.panel4 = new System.Windows.Forms.Panel();
            this.textBoxURL = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.buttonFurther = new System.Windows.Forms.Label();
            this.textBoxBorderAccount = new System.Windows.Forms.Panel();
            this.panel6 = new System.Windows.Forms.Panel();
            this.textBoxAccount = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.buttonMinimize = new System.Windows.Forms.Label();
            this.buttonClose = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.notifyIconOCS = new System.Windows.Forms.NotifyIcon(this.components);
            this.contextMenuOCS = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.синхронизаторКалендарейOutlookToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.выходToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.panel1.SuspendLayout();
            this.synchronization.SuspendLayout();
            this.panel11.SuspendLayout();
            this.panel12.SuspendLayout();
            this.panel8.SuspendLayout();
            this.panel7.SuspendLayout();
            this.panel9.SuspendLayout();
            this.panel10.SuspendLayout();
            this.panel14.SuspendLayout();
            this.panel13.SuspendLayout();
            this.panel16.SuspendLayout();
            this.panel15.SuspendLayout();
            this.panel17.SuspendLayout();
            this.panel2.SuspendLayout();
            this.authorization.SuspendLayout();
            this.textBoxBorderURL.SuspendLayout();
            this.panel4.SuspendLayout();
            this.textBoxBorderAccount.SuspendLayout();
            this.panel6.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.contextMenuOCS.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.synchronization);
            this.panel1.Controls.Add(this.authorization);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 32);
            this.panel1.Margin = new System.Windows.Forms.Padding(0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(602, 640);
            this.panel1.TabIndex = 5;
            // 
            // synchronization
            // 
            this.synchronization.Controls.Add(this.buttonEventRight);
            this.synchronization.Controls.Add(this.buttonCalendarLeft);
            this.synchronization.Controls.Add(this.buttonCalendarRight);
            this.synchronization.Controls.Add(this.label9);
            this.synchronization.Controls.Add(this.label8);
            this.synchronization.Controls.Add(this.label7);
            this.synchronization.Controls.Add(this.panel11);
            this.synchronization.Controls.Add(this.label4);
            this.synchronization.Controls.Add(this.label5);
            this.synchronization.Controls.Add(this.label10);
            this.synchronization.Controls.Add(this.label11);
            this.synchronization.Controls.Add(this.buttonEventLeft);
            this.synchronization.Controls.Add(this.panel8);
            this.synchronization.Controls.Add(this.panel9);
            this.synchronization.Controls.Add(this.panel14);
            this.synchronization.Controls.Add(this.panel16);
            this.synchronization.Controls.Add(this.panel17);
            this.synchronization.Controls.Add(this.label12);
            this.synchronization.Controls.Add(this.buttonSynchronize);
            this.synchronization.Location = new System.Drawing.Point(48, 16);
            this.synchronization.Margin = new System.Windows.Forms.Padding(0);
            this.synchronization.Name = "synchronization";
            this.synchronization.Size = new System.Drawing.Size(506, 576);
            this.synchronization.TabIndex = 7;
            this.synchronization.Visible = false;
            // 
            // buttonEventRight
            // 
            this.buttonEventRight.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(120)))), ((int)(((byte)(212)))));
            this.buttonEventRight.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonEventRight.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.buttonEventRight.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(243)))), ((int)(((byte)(243)))));
            this.buttonEventRight.Image = global::OutlookCalendarSynchronizer.Properties.Resources.angle_small_right;
            this.buttonEventRight.Location = new System.Drawing.Point(474, 208);
            this.buttonEventRight.Margin = new System.Windows.Forms.Padding(0);
            this.buttonEventRight.Name = "buttonEventRight";
            this.buttonEventRight.Size = new System.Drawing.Size(32, 320);
            this.buttonEventRight.TabIndex = 50;
            this.buttonEventRight.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.buttonEventRight.Click += new System.EventHandler(this.buttonEventRight_Click);
            this.buttonEventRight.MouseDown += new System.Windows.Forms.MouseEventHandler(this.buttonEventRight_MouseDown);
            this.buttonEventRight.MouseEnter += new System.EventHandler(this.buttonEventRight_MouseEnter);
            this.buttonEventRight.MouseLeave += new System.EventHandler(this.buttonEventRight_MouseLeave);
            this.buttonEventRight.MouseUp += new System.Windows.Forms.MouseEventHandler(this.buttonEventRight_MouseUp);
            // 
            // buttonCalendarLeft
            // 
            this.buttonCalendarLeft.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(120)))), ((int)(((byte)(212)))));
            this.buttonCalendarLeft.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonCalendarLeft.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.buttonCalendarLeft.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(243)))), ((int)(((byte)(243)))));
            this.buttonCalendarLeft.Image = global::OutlookCalendarSynchronizer.Properties.Resources.angle_small_left;
            this.buttonCalendarLeft.Location = new System.Drawing.Point(0, 80);
            this.buttonCalendarLeft.Margin = new System.Windows.Forms.Padding(0);
            this.buttonCalendarLeft.Name = "buttonCalendarLeft";
            this.buttonCalendarLeft.Size = new System.Drawing.Size(32, 32);
            this.buttonCalendarLeft.TabIndex = 49;
            this.buttonCalendarLeft.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.buttonCalendarLeft.Click += new System.EventHandler(this.buttonCalendarLeft_Click);
            this.buttonCalendarLeft.MouseDown += new System.Windows.Forms.MouseEventHandler(this.buttonCalendarLeft_MouseDown);
            this.buttonCalendarLeft.MouseEnter += new System.EventHandler(this.buttonCalendarLeft_MouseEnter);
            this.buttonCalendarLeft.MouseLeave += new System.EventHandler(this.buttonCalendarLeft_MouseLeave);
            this.buttonCalendarLeft.MouseUp += new System.Windows.Forms.MouseEventHandler(this.buttonCalendarLeft_MouseUp);
            // 
            // buttonCalendarRight
            // 
            this.buttonCalendarRight.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(120)))), ((int)(((byte)(212)))));
            this.buttonCalendarRight.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonCalendarRight.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.buttonCalendarRight.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(243)))), ((int)(((byte)(243)))));
            this.buttonCalendarRight.Image = global::OutlookCalendarSynchronizer.Properties.Resources.angle_small_right;
            this.buttonCalendarRight.Location = new System.Drawing.Point(474, 80);
            this.buttonCalendarRight.Margin = new System.Windows.Forms.Padding(0);
            this.buttonCalendarRight.Name = "buttonCalendarRight";
            this.buttonCalendarRight.Size = new System.Drawing.Size(32, 32);
            this.buttonCalendarRight.TabIndex = 48;
            this.buttonCalendarRight.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.buttonCalendarRight.Click += new System.EventHandler(this.buttonCalendarRight_Click);
            this.buttonCalendarRight.MouseDown += new System.Windows.Forms.MouseEventHandler(this.buttonCalendarRight_MouseDown);
            this.buttonCalendarRight.MouseEnter += new System.EventHandler(this.buttonCalendarRight_MouseEnter);
            this.buttonCalendarRight.MouseLeave += new System.EventHandler(this.buttonCalendarRight_MouseLeave);
            this.buttonCalendarRight.MouseUp += new System.Windows.Forms.MouseEventHandler(this.buttonCalendarRight_MouseUp);
            // 
            // label9
            // 
            this.label9.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(243)))), ((int)(((byte)(243)))));
            this.label9.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label9.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.label9.Location = new System.Drawing.Point(48, 32);
            this.label9.Margin = new System.Windows.Forms.Padding(0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(410, 32);
            this.label9.TabIndex = 47;
            this.label9.Text = "Выберите календарь для синхронизации событий";
            this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label8
            // 
            this.label8.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(243)))), ((int)(((byte)(243)))));
            this.label8.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label8.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.label8.Location = new System.Drawing.Point(48, 160);
            this.label8.Margin = new System.Windows.Forms.Padding(0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(410, 32);
            this.label8.TabIndex = 46;
            this.label8.Text = "Выберите событие для синхронизации";
            this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label7
            // 
            this.label7.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(243)))), ((int)(((byte)(243)))));
            this.label7.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label7.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold);
            this.label7.Location = new System.Drawing.Point(48, 128);
            this.label7.Margin = new System.Windows.Forms.Padding(0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(410, 32);
            this.label7.TabIndex = 45;
            this.label7.Text = "События";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panel11
            // 
            this.panel11.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(120)))), ((int)(((byte)(212)))));
            this.panel11.Controls.Add(this.panel12);
            this.panel11.Location = new System.Drawing.Point(48, 80);
            this.panel11.Margin = new System.Windows.Forms.Padding(0);
            this.panel11.Name = "panel11";
            this.panel11.Padding = new System.Windows.Forms.Padding(1);
            this.panel11.Size = new System.Drawing.Size(410, 32);
            this.panel11.TabIndex = 36;
            // 
            // panel12
            // 
            this.panel12.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(243)))), ((int)(((byte)(243)))));
            this.panel12.Controls.Add(this.labelCalendar);
            this.panel12.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel12.Location = new System.Drawing.Point(1, 1);
            this.panel12.Margin = new System.Windows.Forms.Padding(0);
            this.panel12.Name = "panel12";
            this.panel12.Padding = new System.Windows.Forms.Padding(4);
            this.panel12.Size = new System.Drawing.Size(408, 30);
            this.panel12.TabIndex = 8;
            // 
            // labelCalendar
            // 
            this.labelCalendar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(243)))), ((int)(((byte)(243)))));
            this.labelCalendar.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labelCalendar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.labelCalendar.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.labelCalendar.Location = new System.Drawing.Point(4, 4);
            this.labelCalendar.Margin = new System.Windows.Forms.Padding(0);
            this.labelCalendar.Name = "labelCalendar";
            this.labelCalendar.Size = new System.Drawing.Size(400, 22);
            this.labelCalendar.TabIndex = 26;
            this.labelCalendar.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label4
            // 
            this.label4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(243)))), ((int)(((byte)(243)))));
            this.label4.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label4.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.label4.Location = new System.Drawing.Point(48, 256);
            this.label4.Margin = new System.Windows.Forms.Padding(0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(60, 32);
            this.label4.TabIndex = 42;
            this.label4.Text = "Место";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label5
            // 
            this.label5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(243)))), ((int)(((byte)(243)))));
            this.label5.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label5.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.label5.Location = new System.Drawing.Point(48, 208);
            this.label5.Margin = new System.Windows.Forms.Padding(0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(60, 32);
            this.label5.TabIndex = 37;
            this.label5.Text = "Тема";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label10
            // 
            this.label10.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(243)))), ((int)(((byte)(243)))));
            this.label10.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label10.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.label10.Location = new System.Drawing.Point(48, 352);
            this.label10.Margin = new System.Windows.Forms.Padding(0);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(110, 32);
            this.label10.TabIndex = 44;
            this.label10.Text = "Окончание";
            this.label10.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label11
            // 
            this.label11.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(243)))), ((int)(((byte)(243)))));
            this.label11.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label11.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.label11.Location = new System.Drawing.Point(48, 304);
            this.label11.Margin = new System.Windows.Forms.Padding(0);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(110, 32);
            this.label11.TabIndex = 43;
            this.label11.Text = "Время начала";
            this.label11.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // buttonEventLeft
            // 
            this.buttonEventLeft.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(120)))), ((int)(((byte)(212)))));
            this.buttonEventLeft.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonEventLeft.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.buttonEventLeft.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(243)))), ((int)(((byte)(243)))));
            this.buttonEventLeft.Image = global::OutlookCalendarSynchronizer.Properties.Resources.angle_small_left;
            this.buttonEventLeft.Location = new System.Drawing.Point(0, 208);
            this.buttonEventLeft.Margin = new System.Windows.Forms.Padding(0);
            this.buttonEventLeft.Name = "buttonEventLeft";
            this.buttonEventLeft.Size = new System.Drawing.Size(32, 320);
            this.buttonEventLeft.TabIndex = 51;
            this.buttonEventLeft.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.buttonEventLeft.Click += new System.EventHandler(this.buttonEventLeft_Click);
            this.buttonEventLeft.MouseDown += new System.Windows.Forms.MouseEventHandler(this.buttonEventLeft_MouseDown);
            this.buttonEventLeft.MouseEnter += new System.EventHandler(this.buttonEventLeft_MouseEnter);
            this.buttonEventLeft.MouseLeave += new System.EventHandler(this.buttonEventLeft_MouseLeave);
            this.buttonEventLeft.MouseUp += new System.Windows.Forms.MouseEventHandler(this.buttonEventLeft_MouseUp);
            // 
            // panel8
            // 
            this.panel8.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(120)))), ((int)(((byte)(212)))));
            this.panel8.Controls.Add(this.panel7);
            this.panel8.Location = new System.Drawing.Point(108, 256);
            this.panel8.Margin = new System.Windows.Forms.Padding(0);
            this.panel8.Name = "panel8";
            this.panel8.Padding = new System.Windows.Forms.Padding(1);
            this.panel8.Size = new System.Drawing.Size(350, 32);
            this.panel8.TabIndex = 38;
            // 
            // panel7
            // 
            this.panel7.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(243)))), ((int)(((byte)(243)))));
            this.panel7.Controls.Add(this.textBoxLocation);
            this.panel7.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel7.Location = new System.Drawing.Point(1, 1);
            this.panel7.Margin = new System.Windows.Forms.Padding(0);
            this.panel7.Name = "panel7";
            this.panel7.Padding = new System.Windows.Forms.Padding(4);
            this.panel7.Size = new System.Drawing.Size(348, 30);
            this.panel7.TabIndex = 8;
            // 
            // textBoxLocation
            // 
            this.textBoxLocation.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(243)))), ((int)(((byte)(243)))));
            this.textBoxLocation.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBoxLocation.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textBoxLocation.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.textBoxLocation.Location = new System.Drawing.Point(4, 4);
            this.textBoxLocation.Margin = new System.Windows.Forms.Padding(0);
            this.textBoxLocation.Name = "textBoxLocation";
            this.textBoxLocation.ReadOnly = true;
            this.textBoxLocation.Size = new System.Drawing.Size(340, 22);
            this.textBoxLocation.TabIndex = 0;
            this.textBoxLocation.TabStop = false;
            // 
            // panel9
            // 
            this.panel9.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(120)))), ((int)(((byte)(212)))));
            this.panel9.Controls.Add(this.panel10);
            this.panel9.Location = new System.Drawing.Point(48, 400);
            this.panel9.Margin = new System.Windows.Forms.Padding(0);
            this.panel9.Name = "panel9";
            this.panel9.Padding = new System.Windows.Forms.Padding(1);
            this.panel9.Size = new System.Drawing.Size(410, 128);
            this.panel9.TabIndex = 39;
            // 
            // panel10
            // 
            this.panel10.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(243)))), ((int)(((byte)(243)))));
            this.panel10.Controls.Add(this.textBoxBody);
            this.panel10.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel10.Location = new System.Drawing.Point(1, 1);
            this.panel10.Margin = new System.Windows.Forms.Padding(0);
            this.panel10.Name = "panel10";
            this.panel10.Padding = new System.Windows.Forms.Padding(4);
            this.panel10.Size = new System.Drawing.Size(408, 126);
            this.panel10.TabIndex = 8;
            // 
            // textBoxBody
            // 
            this.textBoxBody.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(243)))), ((int)(((byte)(243)))));
            this.textBoxBody.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBoxBody.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textBoxBody.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.textBoxBody.Location = new System.Drawing.Point(4, 4);
            this.textBoxBody.Margin = new System.Windows.Forms.Padding(0);
            this.textBoxBody.Multiline = true;
            this.textBoxBody.Name = "textBoxBody";
            this.textBoxBody.ReadOnly = true;
            this.textBoxBody.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textBoxBody.Size = new System.Drawing.Size(400, 118);
            this.textBoxBody.TabIndex = 0;
            this.textBoxBody.TabStop = false;
            // 
            // panel14
            // 
            this.panel14.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(120)))), ((int)(((byte)(212)))));
            this.panel14.Controls.Add(this.panel13);
            this.panel14.Location = new System.Drawing.Point(158, 304);
            this.panel14.Margin = new System.Windows.Forms.Padding(0);
            this.panel14.Name = "panel14";
            this.panel14.Padding = new System.Windows.Forms.Padding(1);
            this.panel14.Size = new System.Drawing.Size(300, 32);
            this.panel14.TabIndex = 40;
            // 
            // panel13
            // 
            this.panel13.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(243)))), ((int)(((byte)(243)))));
            this.panel13.Controls.Add(this.textBoxStart);
            this.panel13.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel13.Location = new System.Drawing.Point(1, 1);
            this.panel13.Margin = new System.Windows.Forms.Padding(0);
            this.panel13.Name = "panel13";
            this.panel13.Padding = new System.Windows.Forms.Padding(4);
            this.panel13.Size = new System.Drawing.Size(298, 30);
            this.panel13.TabIndex = 8;
            // 
            // textBoxStart
            // 
            this.textBoxStart.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(243)))), ((int)(((byte)(243)))));
            this.textBoxStart.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBoxStart.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textBoxStart.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.textBoxStart.Location = new System.Drawing.Point(4, 4);
            this.textBoxStart.Margin = new System.Windows.Forms.Padding(0);
            this.textBoxStart.Name = "textBoxStart";
            this.textBoxStart.ReadOnly = true;
            this.textBoxStart.Size = new System.Drawing.Size(290, 22);
            this.textBoxStart.TabIndex = 0;
            this.textBoxStart.TabStop = false;
            // 
            // panel16
            // 
            this.panel16.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(120)))), ((int)(((byte)(212)))));
            this.panel16.Controls.Add(this.panel15);
            this.panel16.Location = new System.Drawing.Point(158, 352);
            this.panel16.Margin = new System.Windows.Forms.Padding(0);
            this.panel16.Name = "panel16";
            this.panel16.Padding = new System.Windows.Forms.Padding(1);
            this.panel16.Size = new System.Drawing.Size(300, 32);
            this.panel16.TabIndex = 41;
            // 
            // panel15
            // 
            this.panel15.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(243)))), ((int)(((byte)(243)))));
            this.panel15.Controls.Add(this.textBoxEnd);
            this.panel15.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel15.Location = new System.Drawing.Point(1, 1);
            this.panel15.Margin = new System.Windows.Forms.Padding(0);
            this.panel15.Name = "panel15";
            this.panel15.Padding = new System.Windows.Forms.Padding(4);
            this.panel15.Size = new System.Drawing.Size(298, 30);
            this.panel15.TabIndex = 8;
            // 
            // textBoxEnd
            // 
            this.textBoxEnd.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(243)))), ((int)(((byte)(243)))));
            this.textBoxEnd.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBoxEnd.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textBoxEnd.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.textBoxEnd.Location = new System.Drawing.Point(4, 4);
            this.textBoxEnd.Margin = new System.Windows.Forms.Padding(0);
            this.textBoxEnd.Name = "textBoxEnd";
            this.textBoxEnd.ReadOnly = true;
            this.textBoxEnd.Size = new System.Drawing.Size(290, 22);
            this.textBoxEnd.TabIndex = 0;
            this.textBoxEnd.TabStop = false;
            // 
            // panel17
            // 
            this.panel17.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(120)))), ((int)(((byte)(212)))));
            this.panel17.Controls.Add(this.panel2);
            this.panel17.Location = new System.Drawing.Point(108, 208);
            this.panel17.Margin = new System.Windows.Forms.Padding(0);
            this.panel17.Name = "panel17";
            this.panel17.Padding = new System.Windows.Forms.Padding(1);
            this.panel17.Size = new System.Drawing.Size(350, 32);
            this.panel17.TabIndex = 35;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(243)))), ((int)(((byte)(243)))));
            this.panel2.Controls.Add(this.textBoxSubject);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(1, 1);
            this.panel2.Margin = new System.Windows.Forms.Padding(0);
            this.panel2.Name = "panel2";
            this.panel2.Padding = new System.Windows.Forms.Padding(4);
            this.panel2.Size = new System.Drawing.Size(348, 30);
            this.panel2.TabIndex = 8;
            // 
            // textBoxSubject
            // 
            this.textBoxSubject.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(243)))), ((int)(((byte)(243)))));
            this.textBoxSubject.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBoxSubject.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textBoxSubject.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.textBoxSubject.Location = new System.Drawing.Point(4, 4);
            this.textBoxSubject.Margin = new System.Windows.Forms.Padding(0);
            this.textBoxSubject.Name = "textBoxSubject";
            this.textBoxSubject.ReadOnly = true;
            this.textBoxSubject.Size = new System.Drawing.Size(340, 22);
            this.textBoxSubject.TabIndex = 0;
            this.textBoxSubject.TabStop = false;
            // 
            // label12
            // 
            this.label12.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(243)))), ((int)(((byte)(243)))));
            this.label12.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label12.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold);
            this.label12.Location = new System.Drawing.Point(48, 0);
            this.label12.Margin = new System.Windows.Forms.Padding(0);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(410, 32);
            this.label12.TabIndex = 34;
            this.label12.Text = "Календари";
            this.label12.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // buttonSynchronize
            // 
            this.buttonSynchronize.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(120)))), ((int)(((byte)(212)))));
            this.buttonSynchronize.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonSynchronize.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.buttonSynchronize.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(243)))), ((int)(((byte)(243)))));
            this.buttonSynchronize.Location = new System.Drawing.Point(48, 544);
            this.buttonSynchronize.Margin = new System.Windows.Forms.Padding(0);
            this.buttonSynchronize.Name = "buttonSynchronize";
            this.buttonSynchronize.Size = new System.Drawing.Size(410, 32);
            this.buttonSynchronize.TabIndex = 33;
            this.buttonSynchronize.Text = "Синхронизировать";
            this.buttonSynchronize.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.buttonSynchronize.Click += new System.EventHandler(this.buttonSynchronize_Click);
            this.buttonSynchronize.MouseDown += new System.Windows.Forms.MouseEventHandler(this.buttonSynchronize_MouseDown);
            this.buttonSynchronize.MouseEnter += new System.EventHandler(this.buttonSynchronize_MouseEnter);
            this.buttonSynchronize.MouseLeave += new System.EventHandler(this.buttonSynchronize_MouseLeave);
            this.buttonSynchronize.MouseUp += new System.Windows.Forms.MouseEventHandler(this.buttonSynchronize_MouseUp);
            // 
            // authorization
            // 
            this.authorization.Controls.Add(this.textBoxBorderURL);
            this.authorization.Controls.Add(this.label2);
            this.authorization.Controls.Add(this.buttonFurther);
            this.authorization.Controls.Add(this.textBoxBorderAccount);
            this.authorization.Controls.Add(this.label3);
            this.authorization.Location = new System.Drawing.Point(96, 192);
            this.authorization.Margin = new System.Windows.Forms.Padding(0);
            this.authorization.Name = "authorization";
            this.authorization.Size = new System.Drawing.Size(410, 224);
            this.authorization.TabIndex = 6;
            // 
            // textBoxBorderURL
            // 
            this.textBoxBorderURL.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(120)))), ((int)(((byte)(212)))));
            this.textBoxBorderURL.Controls.Add(this.panel4);
            this.textBoxBorderURL.Location = new System.Drawing.Point(0, 144);
            this.textBoxBorderURL.Margin = new System.Windows.Forms.Padding(0);
            this.textBoxBorderURL.Name = "textBoxBorderURL";
            this.textBoxBorderURL.Padding = new System.Windows.Forms.Padding(1);
            this.textBoxBorderURL.Size = new System.Drawing.Size(410, 32);
            this.textBoxBorderURL.TabIndex = 13;
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(243)))), ((int)(((byte)(243)))));
            this.panel4.Controls.Add(this.textBoxURL);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel4.Location = new System.Drawing.Point(1, 1);
            this.panel4.Margin = new System.Windows.Forms.Padding(0);
            this.panel4.Name = "panel4";
            this.panel4.Padding = new System.Windows.Forms.Padding(4);
            this.panel4.Size = new System.Drawing.Size(408, 30);
            this.panel4.TabIndex = 8;
            // 
            // textBoxURL
            // 
            this.textBoxURL.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(243)))), ((int)(((byte)(243)))));
            this.textBoxURL.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBoxURL.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textBoxURL.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.textBoxURL.ForeColor = System.Drawing.Color.Gray;
            this.textBoxURL.Location = new System.Drawing.Point(4, 4);
            this.textBoxURL.Margin = new System.Windows.Forms.Padding(0);
            this.textBoxURL.Name = "textBoxURL";
            this.textBoxURL.Size = new System.Drawing.Size(400, 22);
            this.textBoxURL.TabIndex = 0;
            this.textBoxURL.TabStop = false;
            this.textBoxURL.Text = "URL-адрес сервера";
            this.textBoxURL.Enter += new System.EventHandler(this.textBoxURL_Enter);
            this.textBoxURL.KeyDown += new System.Windows.Forms.KeyEventHandler(this.textBoxURL_KeyDown);
            this.textBoxURL.Leave += new System.EventHandler(this.textBoxURL_Leave);
            // 
            // label2
            // 
            this.label2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(243)))), ((int)(((byte)(243)))));
            this.label2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.Location = new System.Drawing.Point(0, 32);
            this.label2.Margin = new System.Windows.Forms.Padding(0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(410, 48);
            this.label2.TabIndex = 14;
            this.label2.Text = "Для просмотра календарей и синхронизации событий Outlook введите учётную запись и" +
    " URL-адрес сервера";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // buttonFurther
            // 
            this.buttonFurther.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(120)))), ((int)(((byte)(212)))));
            this.buttonFurther.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonFurther.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buttonFurther.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(243)))), ((int)(((byte)(243)))));
            this.buttonFurther.Location = new System.Drawing.Point(0, 192);
            this.buttonFurther.Margin = new System.Windows.Forms.Padding(0);
            this.buttonFurther.Name = "buttonFurther";
            this.buttonFurther.Size = new System.Drawing.Size(410, 32);
            this.buttonFurther.TabIndex = 11;
            this.buttonFurther.Text = "Далее";
            this.buttonFurther.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.buttonFurther.Click += new System.EventHandler(this.buttonFurther_Click);
            this.buttonFurther.MouseDown += new System.Windows.Forms.MouseEventHandler(this.buttonFurther_MouseDown);
            this.buttonFurther.MouseEnter += new System.EventHandler(this.buttonFurther_MouseEnter);
            this.buttonFurther.MouseLeave += new System.EventHandler(this.buttonFurther_MouseLeave);
            this.buttonFurther.MouseUp += new System.Windows.Forms.MouseEventHandler(this.buttonFurther_MouseUp);
            // 
            // textBoxBorderAccount
            // 
            this.textBoxBorderAccount.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(120)))), ((int)(((byte)(212)))));
            this.textBoxBorderAccount.Controls.Add(this.panel6);
            this.textBoxBorderAccount.Location = new System.Drawing.Point(0, 96);
            this.textBoxBorderAccount.Margin = new System.Windows.Forms.Padding(0);
            this.textBoxBorderAccount.Name = "textBoxBorderAccount";
            this.textBoxBorderAccount.Padding = new System.Windows.Forms.Padding(1);
            this.textBoxBorderAccount.Size = new System.Drawing.Size(410, 32);
            this.textBoxBorderAccount.TabIndex = 10;
            // 
            // panel6
            // 
            this.panel6.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(243)))), ((int)(((byte)(243)))));
            this.panel6.Controls.Add(this.textBoxAccount);
            this.panel6.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel6.Location = new System.Drawing.Point(1, 1);
            this.panel6.Margin = new System.Windows.Forms.Padding(0);
            this.panel6.Name = "panel6";
            this.panel6.Padding = new System.Windows.Forms.Padding(4);
            this.panel6.Size = new System.Drawing.Size(408, 30);
            this.panel6.TabIndex = 8;
            // 
            // textBoxAccount
            // 
            this.textBoxAccount.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(243)))), ((int)(((byte)(243)))));
            this.textBoxAccount.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBoxAccount.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textBoxAccount.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.textBoxAccount.ForeColor = System.Drawing.Color.Gray;
            this.textBoxAccount.Location = new System.Drawing.Point(4, 4);
            this.textBoxAccount.Margin = new System.Windows.Forms.Padding(0);
            this.textBoxAccount.Name = "textBoxAccount";
            this.textBoxAccount.Size = new System.Drawing.Size(400, 22);
            this.textBoxAccount.TabIndex = 0;
            this.textBoxAccount.TabStop = false;
            this.textBoxAccount.Text = "Учётная запись";
            this.textBoxAccount.Enter += new System.EventHandler(this.textBoxAccount_Enter);
            this.textBoxAccount.KeyDown += new System.Windows.Forms.KeyEventHandler(this.textBoxAccount_KeyDown);
            this.textBoxAccount.Leave += new System.EventHandler(this.textBoxAccount_Leave);
            // 
            // label3
            // 
            this.label3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(243)))), ((int)(((byte)(243)))));
            this.label3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label3.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label3.Location = new System.Drawing.Point(0, 0);
            this.label3.Margin = new System.Windows.Forms.Padding(0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(410, 32);
            this.label3.TabIndex = 12;
            this.label3.Text = "Авторизация";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(243)))), ((int)(((byte)(243)))));
            this.label1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(32, 0);
            this.label1.Margin = new System.Windows.Forms.Padding(0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(224, 32);
            this.label1.TabIndex = 1;
            this.label1.Text = "Синхронизатор календарей Outlook";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // buttonMinimize
            // 
            this.buttonMinimize.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonMinimize.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(243)))), ((int)(((byte)(243)))));
            this.buttonMinimize.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonMinimize.Font = new System.Drawing.Font("Segoe UI Light", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buttonMinimize.Image = global::OutlookCalendarSynchronizer.Properties.Resources.minus_small;
            this.buttonMinimize.Location = new System.Drawing.Point(538, 0);
            this.buttonMinimize.Margin = new System.Windows.Forms.Padding(0);
            this.buttonMinimize.Name = "buttonMinimize";
            this.buttonMinimize.Size = new System.Drawing.Size(32, 32);
            this.buttonMinimize.TabIndex = 2;
            this.buttonMinimize.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.buttonMinimize.Click += new System.EventHandler(this.buttonMinimize_Click);
            this.buttonMinimize.MouseDown += new System.Windows.Forms.MouseEventHandler(this.buttonMinimize_MouseDown);
            this.buttonMinimize.MouseEnter += new System.EventHandler(this.buttonMinimize_MouseEnter);
            this.buttonMinimize.MouseLeave += new System.EventHandler(this.buttonMinimize_MouseLeave);
            this.buttonMinimize.MouseUp += new System.Windows.Forms.MouseEventHandler(this.buttonMinimize_MouseUp);
            // 
            // buttonClose
            // 
            this.buttonClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonClose.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(243)))), ((int)(((byte)(243)))));
            this.buttonClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonClose.Font = new System.Drawing.Font("Segoe UI Light", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buttonClose.Image = global::OutlookCalendarSynchronizer.Properties.Resources.cross_small;
            this.buttonClose.Location = new System.Drawing.Point(570, 0);
            this.buttonClose.Margin = new System.Windows.Forms.Padding(0);
            this.buttonClose.Name = "buttonClose";
            this.buttonClose.Size = new System.Drawing.Size(32, 32);
            this.buttonClose.TabIndex = 3;
            this.buttonClose.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.buttonClose.Click += new System.EventHandler(this.buttonClose_Click);
            this.buttonClose.MouseDown += new System.Windows.Forms.MouseEventHandler(this.buttonClose_MouseDown);
            this.buttonClose.MouseEnter += new System.EventHandler(this.buttonClose_MouseEnter);
            this.buttonClose.MouseLeave += new System.EventHandler(this.buttonClose_MouseLeave);
            this.buttonClose.MouseUp += new System.Windows.Forms.MouseEventHandler(this.buttonClose_MouseUp);
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(243)))), ((int)(((byte)(243)))));
            this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.pictureBox1.Image = global::OutlookCalendarSynchronizer.Properties.Resources.icons8_календарь_outlook_16;
            this.pictureBox1.Location = new System.Drawing.Point(0, 0);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(32, 32);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pictureBox1.TabIndex = 4;
            this.pictureBox1.TabStop = false;
            // 
            // notifyIconOCS
            // 
            this.notifyIconOCS.ContextMenuStrip = this.contextMenuOCS;
            this.notifyIconOCS.Icon = ((System.Drawing.Icon)(resources.GetObject("notifyIconOCS.Icon")));
            this.notifyIconOCS.Text = "Синхронизатор календарей Outlook";
            this.notifyIconOCS.Visible = true;
            this.notifyIconOCS.MouseClick += new System.Windows.Forms.MouseEventHandler(this.notifyIconOCS_MouseClick);
            // 
            // contextMenuOCS
            // 
            this.contextMenuOCS.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.синхронизаторКалендарейOutlookToolStripMenuItem,
            this.выходToolStripMenuItem});
            this.contextMenuOCS.Name = "contextMenuOCS";
            this.contextMenuOCS.Size = new System.Drawing.Size(284, 48);
            // 
            // синхронизаторКалендарейOutlookToolStripMenuItem
            // 
            this.синхронизаторКалендарейOutlookToolStripMenuItem.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.синхронизаторКалендарейOutlookToolStripMenuItem.Name = "синхронизаторКалендарейOutlookToolStripMenuItem";
            this.синхронизаторКалендарейOutlookToolStripMenuItem.Size = new System.Drawing.Size(283, 22);
            this.синхронизаторКалендарейOutlookToolStripMenuItem.Text = "Синхронизатор календарей Outlook";
            this.синхронизаторКалендарейOutlookToolStripMenuItem.Click += new System.EventHandler(this.синхронизаторКалендарейOutlookToolStripMenuItem_Click);
            // 
            // выходToolStripMenuItem
            // 
            this.выходToolStripMenuItem.Name = "выходToolStripMenuItem";
            this.выходToolStripMenuItem.Size = new System.Drawing.Size(283, 22);
            this.выходToolStripMenuItem.Text = "Выход";
            this.выходToolStripMenuItem.Click += new System.EventHandler(this.выходToolStripMenuItem_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(243)))), ((int)(((byte)(243)))));
            this.ClientSize = new System.Drawing.Size(602, 672);
            this.Controls.Add(this.buttonMinimize);
            this.Controls.Add(this.buttonClose);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.pictureBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Синхронизатор календарей Outlook";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.MainForm_MouseDown);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.MainForm_MouseMove);
            this.MouseUp += new System.Windows.Forms.MouseEventHandler(this.MainForm_MouseUp);
            this.panel1.ResumeLayout(false);
            this.synchronization.ResumeLayout(false);
            this.panel11.ResumeLayout(false);
            this.panel12.ResumeLayout(false);
            this.panel8.ResumeLayout(false);
            this.panel7.ResumeLayout(false);
            this.panel7.PerformLayout();
            this.panel9.ResumeLayout(false);
            this.panel10.ResumeLayout(false);
            this.panel10.PerformLayout();
            this.panel14.ResumeLayout(false);
            this.panel13.ResumeLayout(false);
            this.panel13.PerformLayout();
            this.panel16.ResumeLayout(false);
            this.panel15.ResumeLayout(false);
            this.panel15.PerformLayout();
            this.panel17.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.authorization.ResumeLayout(false);
            this.textBoxBorderURL.ResumeLayout(false);
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.textBoxBorderAccount.ResumeLayout(false);
            this.panel6.ResumeLayout(false);
            this.panel6.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.contextMenuOCS.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label buttonMinimize;
        private System.Windows.Forms.Label buttonClose;
        private System.Windows.Forms.Panel authorization;
        private System.Windows.Forms.Panel textBoxBorderURL;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.TextBox textBoxURL;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label buttonFurther;
        private System.Windows.Forms.Panel textBoxBorderAccount;
        private System.Windows.Forms.Panel panel6;
        private System.Windows.Forms.TextBox textBoxAccount;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Panel synchronization;
        private System.Windows.Forms.Label buttonEventRight;
        private System.Windows.Forms.Label buttonCalendarLeft;
        private System.Windows.Forms.Label buttonCalendarRight;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Panel panel11;
        private System.Windows.Forms.Panel panel12;
        private System.Windows.Forms.Label labelCalendar;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label buttonEventLeft;
        private System.Windows.Forms.Panel panel8;
        private System.Windows.Forms.Panel panel7;
        private System.Windows.Forms.TextBox textBoxLocation;
        private System.Windows.Forms.Panel panel9;
        private System.Windows.Forms.Panel panel10;
        private System.Windows.Forms.TextBox textBoxBody;
        private System.Windows.Forms.Panel panel14;
        private System.Windows.Forms.Panel panel13;
        private System.Windows.Forms.TextBox textBoxStart;
        private System.Windows.Forms.Panel panel16;
        private System.Windows.Forms.Panel panel15;
        private System.Windows.Forms.TextBox textBoxEnd;
        private System.Windows.Forms.Panel panel17;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.TextBox textBoxSubject;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label buttonSynchronize;
        private System.Windows.Forms.NotifyIcon notifyIconOCS;
        private System.Windows.Forms.ContextMenuStrip contextMenuOCS;
        private System.Windows.Forms.ToolStripMenuItem синхронизаторКалендарейOutlookToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem выходToolStripMenuItem;
    }
}

