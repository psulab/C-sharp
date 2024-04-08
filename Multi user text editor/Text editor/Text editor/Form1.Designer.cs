namespace Text_editor
{
    partial class EditorText
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(EditorText));
            this.button_close = new System.Windows.Forms.Button();
            this.button_minimize = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.panel_footer = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panelError = new System.Windows.Forms.Panel();
            this.panel5 = new System.Windows.Forms.Panel();
            this.labelAdvice = new System.Windows.Forms.Label();
            this.labelError = new System.Windows.Forms.Label();
            this.labelDisconnected = new System.Windows.Forms.Label();
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel4 = new System.Windows.Forms.Panel();
            this.timer_logo = new System.Windows.Forms.Timer(this.components);
            this.timer_button = new System.Windows.Forms.Timer(this.components);
            this.timer_text_editor = new System.Windows.Forms.Timer(this.components);
            this.timer_form = new System.Windows.Forms.Timer(this.components);
            this.timer_error = new System.Windows.Forms.Timer(this.components);
            this.dragControl1 = new Text_editor.DragControl();
            this.panel_footer.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panelError.SuspendLayout();
            this.panel5.SuspendLayout();
            this.SuspendLayout();
            // 
            // button_close
            // 
            this.button_close.FlatAppearance.BorderSize = 0;
            this.button_close.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(159)))), ((int)(((byte)(141)))));
            this.button_close.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button_close.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(82)))), ((int)(((byte)(36)))), ((int)(((byte)(82)))));
            this.button_close.Image = ((System.Drawing.Image)(resources.GetObject("button_close.Image")));
            this.button_close.Location = new System.Drawing.Point(756, 42);
            this.button_close.Name = "button_close";
            this.button_close.Size = new System.Drawing.Size(32, 32);
            this.button_close.TabIndex = 1;
            this.button_close.UseVisualStyleBackColor = true;
            this.button_close.Visible = false;
            this.button_close.Click += new System.EventHandler(this.button_close_Click);
            // 
            // button_minimize
            // 
            this.button_minimize.FlatAppearance.BorderSize = 0;
            this.button_minimize.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(42)))), ((int)(((byte)(64)))));
            this.button_minimize.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button_minimize.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(82)))), ((int)(((byte)(36)))), ((int)(((byte)(82)))));
            this.button_minimize.Image = ((System.Drawing.Image)(resources.GetObject("button_minimize.Image")));
            this.button_minimize.Location = new System.Drawing.Point(718, 42);
            this.button_minimize.Name = "button_minimize";
            this.button_minimize.Size = new System.Drawing.Size(32, 32);
            this.button_minimize.TabIndex = 2;
            this.button_minimize.UseVisualStyleBackColor = true;
            this.button_minimize.Visible = false;
            this.button_minimize.Click += new System.EventHandler(this.button_minimize_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label1.Font = new System.Drawing.Font("Comfortaa", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(242)))), ((int)(((byte)(242)))));
            this.label1.Image = ((System.Drawing.Image)(resources.GetObject("label1.Image")));
            this.label1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.label1.Location = new System.Drawing.Point(42, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(81, 30);
            this.label1.TabIndex = 2;
            this.label1.Text = "     Text";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.label1.Visible = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label2.Font = new System.Drawing.Font("Comfortaa", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(242)))), ((int)(((byte)(242)))));
            this.label2.Image = ((System.Drawing.Image)(resources.GetObject("label2.Image")));
            this.label2.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.label2.Location = new System.Drawing.Point(42, 40);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(104, 30);
            this.label2.TabIndex = 2;
            this.label2.Text = "Editor     ";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.label2.Visible = false;
            // 
            // panel_footer
            // 
            this.panel_footer.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(120)))), ((int)(((byte)(109)))));
            this.panel_footer.Controls.Add(this.panel2);
            this.panel_footer.Controls.Add(this.panel1);
            this.panel_footer.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel_footer.Location = new System.Drawing.Point(0, 599);
            this.panel_footer.Margin = new System.Windows.Forms.Padding(0);
            this.panel_footer.Name = "panel_footer";
            this.panel_footer.Size = new System.Drawing.Size(800, 1);
            this.panel_footer.TabIndex = 3;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(35)))), ((int)(((byte)(53)))));
            this.panel2.Controls.Add(this.panelError);
            this.panel2.Controls.Add(this.richTextBox1);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 1);
            this.panel2.Name = "panel2";
            this.panel2.Padding = new System.Windows.Forms.Padding(10);
            this.panel2.Size = new System.Drawing.Size(800, 0);
            this.panel2.TabIndex = 7;
            // 
            // panelError
            // 
            this.panelError.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(42)))), ((int)(((byte)(64)))));
            this.panelError.Controls.Add(this.labelError);
            this.panelError.Controls.Add(this.labelDisconnected);
            this.panelError.Controls.Add(this.panel5);
            this.panelError.Location = new System.Drawing.Point(440, 518);
            this.panelError.Name = "panelError";
            this.panelError.Size = new System.Drawing.Size(350, 90);
            this.panelError.TabIndex = 7;
            // 
            // panel5
            // 
            this.panel5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(120)))), ((int)(((byte)(109)))));
            this.panel5.Controls.Add(this.labelAdvice);
            this.panel5.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel5.Location = new System.Drawing.Point(0, 65);
            this.panel5.Margin = new System.Windows.Forms.Padding(0);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(350, 25);
            this.panel5.TabIndex = 0;
            // 
            // labelAdvice
            // 
            this.labelAdvice.BackColor = System.Drawing.Color.Transparent;
            this.labelAdvice.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.labelAdvice.Font = new System.Drawing.Font("Comfortaa", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelAdvice.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(242)))), ((int)(((byte)(242)))));
            this.labelAdvice.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.labelAdvice.Location = new System.Drawing.Point(37, -3);
            this.labelAdvice.Margin = new System.Windows.Forms.Padding(0);
            this.labelAdvice.Name = "labelAdvice";
            this.labelAdvice.Size = new System.Drawing.Size(276, 24);
            this.labelAdvice.TabIndex = 2;
            this.labelAdvice.Text = "please close and restart the client";
            this.labelAdvice.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // labelError
            // 
            this.labelError.BackColor = System.Drawing.Color.Transparent;
            this.labelError.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.labelError.Font = new System.Drawing.Font("Comfortaa", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelError.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(242)))), ((int)(((byte)(242)))));
            this.labelError.Image = ((System.Drawing.Image)(resources.GetObject("labelError.Image")));
            this.labelError.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.labelError.Location = new System.Drawing.Point(61, 12);
            this.labelError.Margin = new System.Windows.Forms.Padding(0);
            this.labelError.Name = "labelError";
            this.labelError.Size = new System.Drawing.Size(228, 40);
            this.labelError.TabIndex = 2;
            this.labelError.Text = "Server not found";
            this.labelError.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.labelError.Visible = false;
            // 
            // labelDisconnected
            // 
            this.labelDisconnected.BackColor = System.Drawing.Color.Transparent;
            this.labelDisconnected.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.labelDisconnected.Font = new System.Drawing.Font("Comfortaa", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelDisconnected.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(242)))), ((int)(((byte)(242)))));
            this.labelDisconnected.Image = ((System.Drawing.Image)(resources.GetObject("labelDisconnected.Image")));
            this.labelDisconnected.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.labelDisconnected.Location = new System.Drawing.Point(44, 12);
            this.labelDisconnected.Margin = new System.Windows.Forms.Padding(0);
            this.labelDisconnected.Name = "labelDisconnected";
            this.labelDisconnected.Size = new System.Drawing.Size(262, 40);
            this.labelDisconnected.TabIndex = 2;
            this.labelDisconnected.Text = "Server disconnected";
            this.labelDisconnected.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.labelDisconnected.Visible = false;
            // 
            // richTextBox1
            // 
            this.richTextBox1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(35)))), ((int)(((byte)(53)))));
            this.richTextBox1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.richTextBox1.BulletIndent = 3;
            this.richTextBox1.DetectUrls = false;
            this.richTextBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.richTextBox1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(242)))), ((int)(((byte)(242)))));
            this.richTextBox1.Location = new System.Drawing.Point(10, 10);
            this.richTextBox1.Margin = new System.Windows.Forms.Padding(0);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.ShortcutsEnabled = false;
            this.richTextBox1.Size = new System.Drawing.Size(780, 0);
            this.richTextBox1.TabIndex = 6;
            this.richTextBox1.Text = "";
            this.richTextBox1.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.richTextBox1_KeyPress);
            // 
            // panel1
            // 
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(800, 1);
            this.panel1.TabIndex = 5;
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.panel4.Location = new System.Drawing.Point(83, 69);
            this.panel4.Margin = new System.Windows.Forms.Padding(0);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(100, 12);
            this.panel4.TabIndex = 0;
            this.panel4.Visible = false;
            // 
            // timer_logo
            // 
            this.timer_logo.Interval = 10;
            this.timer_logo.Tick += new System.EventHandler(this.timer_logo_Tick);
            // 
            // timer_button
            // 
            this.timer_button.Interval = 10;
            this.timer_button.Tick += new System.EventHandler(this.timer_button_Tick);
            // 
            // timer_text_editor
            // 
            this.timer_text_editor.Interval = 10;
            this.timer_text_editor.Tick += new System.EventHandler(this.timer_text_editor_Tick);
            // 
            // timer_form
            // 
            this.timer_form.Interval = 10;
            this.timer_form.Tick += new System.EventHandler(this.timer_form_Tick);
            // 
            // timer_error
            // 
            this.timer_error.Interval = 10;
            this.timer_error.Tick += new System.EventHandler(this.timer_error_Tick);
            // 
            // dragControl1
            // 
            this.dragControl1.SelectControl = this;
            // 
            // EditorText
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(42)))), ((int)(((byte)(64)))));
            this.ClientSize = new System.Drawing.Size(800, 600);
            this.Controls.Add(this.panel_footer);
            this.Controls.Add(this.panel4);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button_minimize);
            this.Controls.Add(this.button_close);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximumSize = new System.Drawing.Size(800, 600);
            this.MinimumSize = new System.Drawing.Size(800, 0);
            this.Name = "EditorText";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Text editor";
            this.Load += new System.EventHandler(this.Text_editor_Load);
            this.panel_footer.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panelError.ResumeLayout(false);
            this.panel5.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button button_close;
        private System.Windows.Forms.Button button_minimize;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel panel_footer;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Timer timer_logo;
        private System.Windows.Forms.Timer timer_button;
        private System.Windows.Forms.Timer timer_text_editor;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Timer timer_form;
        private System.Windows.Forms.RichTextBox richTextBox1;
        private System.Windows.Forms.Panel panel2;
        private DragControl dragControl1;
        private System.Windows.Forms.Panel panelError;
        private System.Windows.Forms.Label labelError;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.Label labelAdvice;
        private System.Windows.Forms.Timer timer_error;
        private System.Windows.Forms.Label labelDisconnected;
    }
}

