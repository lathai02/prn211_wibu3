namespace CinemaSystemWF
{
    partial class CheckTicket
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            label4 = new Label();
            CheckBtn = new Button();
            label3 = new Label();
            TextBoxOTP = new TextBox();
            TextBoxEmail = new TextBox();
            label2 = new Label();
            backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            groupBox1 = new GroupBox();
            DGLogs = new DataGridView();
            Time = new DataGridViewTextBoxColumn();
            Email = new DataGridViewTextBoxColumn();
            Status = new DataGridViewTextBoxColumn();
            btnHome = new Button();
            groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)DGLogs).BeginInit();
            SuspendLayout();
            // 
            // label4
            // 
            label4.Font = new Font("Segoe UI", 20.25F, FontStyle.Regular, GraphicsUnit.Point);
            label4.Location = new Point(12, 71);
            label4.Name = "label4";
            label4.Size = new Size(376, 42);
            label4.TabIndex = 8;
            label4.Text = "Check Ticket";
            label4.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // CheckBtn
            // 
            CheckBtn.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            CheckBtn.Location = new Point(130, 208);
            CheckBtn.Name = "CheckBtn";
            CheckBtn.Size = new Size(140, 40);
            CheckBtn.TabIndex = 13;
            CheckBtn.Text = "Check";
            CheckBtn.UseVisualStyleBackColor = true;
            CheckBtn.Click += CheckBtn_Click;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(12, 169);
            label3.Name = "label3";
            label3.Size = new Size(28, 15);
            label3.TabIndex = 12;
            label3.Text = "OTP";
            // 
            // TextBoxOTP
            // 
            TextBoxOTP.Location = new Point(75, 166);
            TextBoxOTP.Name = "TextBoxOTP";
            TextBoxOTP.Size = new Size(313, 23);
            TextBoxOTP.TabIndex = 11;
            // 
            // TextBoxEmail
            // 
            TextBoxEmail.Location = new Point(75, 137);
            TextBoxEmail.Name = "TextBoxEmail";
            TextBoxEmail.Size = new Size(313, 23);
            TextBoxEmail.TabIndex = 10;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(12, 140);
            label2.Name = "label2";
            label2.Size = new Size(36, 15);
            label2.TabIndex = 9;
            label2.Text = "Email";
            // 
            // groupBox1
            // 
            groupBox1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            groupBox1.Controls.Add(DGLogs);
            groupBox1.Location = new Point(394, 36);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(394, 402);
            groupBox1.TabIndex = 14;
            groupBox1.TabStop = false;
            groupBox1.Text = "Logs";
            // 
            // DGLogs
            // 
            DGLogs.AllowUserToAddRows = false;
            DGLogs.AllowUserToDeleteRows = false;
            DGLogs.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            DGLogs.Columns.AddRange(new DataGridViewColumn[] { Time, Email, Status });
            DGLogs.Dock = DockStyle.Fill;
            DGLogs.Location = new Point(3, 19);
            DGLogs.Name = "DGLogs";
            DGLogs.ReadOnly = true;
            DGLogs.RowTemplate.Height = 25;
            DGLogs.Size = new Size(388, 380);
            DGLogs.TabIndex = 0;
            // 
            // Time
            // 
            Time.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            Time.HeaderText = "Time";
            Time.Name = "Time";
            Time.ReadOnly = true;
            Time.Width = 58;
            // 
            // Email
            // 
            Email.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            Email.HeaderText = "Email";
            Email.Name = "Email";
            Email.ReadOnly = true;
            // 
            // Status
            // 
            Status.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            Status.HeaderText = "Status";
            Status.Name = "Status";
            Status.ReadOnly = true;
            Status.Width = 64;
            // 
            // btnHome
            // 
            btnHome.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            btnHome.Location = new Point(12, 410);
            btnHome.Name = "btnHome";
            btnHome.Size = new Size(91, 25);
            btnHome.TabIndex = 15;
            btnHome.Text = "Back to home";
            btnHome.UseVisualStyleBackColor = true;
            btnHome.Click += btnHome_Click;
            // 
            // CheckTicket
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(btnHome);
            Controls.Add(groupBox1);
            Controls.Add(label4);
            Controls.Add(CheckBtn);
            Controls.Add(label3);
            Controls.Add(TextBoxOTP);
            Controls.Add(TextBoxEmail);
            Controls.Add(label2);
            Name = "CheckTicket";
            Text = "CheckTicket";
            Controls.SetChildIndex(label2, 0);
            Controls.SetChildIndex(TextBoxEmail, 0);
            Controls.SetChildIndex(TextBoxOTP, 0);
            Controls.SetChildIndex(label3, 0);
            Controls.SetChildIndex(CheckBtn, 0);
            Controls.SetChildIndex(label4, 0);
            Controls.SetChildIndex(groupBox1, 0);
            Controls.SetChildIndex(btnHome, 0);
            groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)DGLogs).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label4;
        private Button CheckBtn;
        private Label label3;
        private TextBox TextBoxOTP;
        private TextBox TextBoxEmail;
        private Label label2;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private GroupBox groupBox1;
        private DataGridView DGLogs;
        private DataGridViewTextBoxColumn Time;
        private DataGridViewTextBoxColumn Email;
        private DataGridViewTextBoxColumn Status;
        private Button btnHome;
    }
}