namespace CinemaSystemWF
{
    partial class TemplateForm
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
            this.ExitBtn = new System.Windows.Forms.Button();
            this.TopTitle = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.TopTitle.SuspendLayout();
            this.SuspendLayout();
            // 
            // ExitBtn
            // 
            this.ExitBtn.BackgroundImage = global::CinemaSystemWF.Properties.Resources.close;
            this.ExitBtn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.ExitBtn.Dock = System.Windows.Forms.DockStyle.Right;
            this.ExitBtn.FlatAppearance.BorderSize = 0;
            this.ExitBtn.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.ExitBtn.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.ExitBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ExitBtn.Location = new System.Drawing.Point(760, 0);
            this.ExitBtn.Margin = new System.Windows.Forms.Padding(0);
            this.ExitBtn.Name = "ExitBtn";
            this.ExitBtn.Size = new System.Drawing.Size(40, 30);
            this.ExitBtn.TabIndex = 0;
            this.ExitBtn.UseVisualStyleBackColor = true;
            this.ExitBtn.Click += new System.EventHandler(this.ExitBtn_Click);
            // 
            // TopTitle
            // 
            this.TopTitle.Controls.Add(this.label1);
            this.TopTitle.Controls.Add(this.ExitBtn);
            this.TopTitle.Dock = System.Windows.Forms.DockStyle.Top;
            this.TopTitle.Location = new System.Drawing.Point(0, 0);
            this.TopTitle.Name = "TopTitle";
            this.TopTitle.Size = new System.Drawing.Size(800, 30);
            this.TopTitle.TabIndex = 3;
            this.TopTitle.MouseDown += new System.Windows.Forms.MouseEventHandler(this.TopTitle_MouseDown);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label1.Location = new System.Drawing.Point(3, 3);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(118, 21);
            this.label1.TabIndex = 1;
            this.label1.Text = "Cinema System";
            this.label1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.TopTitle_MouseDown);
            // 
            // TemplateForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.TopTitle);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "TemplateForm";
            this.Text = "Template";
            this.TopTitle.ResumeLayout(false);
            this.TopTitle.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private Button ExitBtn;
        private Panel TopTitle;
        private Label label1;
    }
}