namespace CinemaSystemWF
{
    partial class MainForm
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
            DGShows = new DataGridView();
            ID = new DataGridViewTextBoxColumn();
            Film = new DataGridViewTextBoxColumn();
            Start = new DataGridViewTextBoxColumn();
            End = new DataGridViewTextBoxColumn();
            TicketPrice = new DataGridViewTextBoxColumn();
            Room = new DataGridViewTextBoxColumn();
            CheckTicket = new DataGridViewButtonColumn();
            panel1 = new Panel();
            ((System.ComponentModel.ISupportInitialize)DGShows).BeginInit();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // DGShows
            // 
            DGShows.AllowUserToAddRows = false;
            DGShows.AllowUserToDeleteRows = false;
            DGShows.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            DGShows.Columns.AddRange(new DataGridViewColumn[] { ID, Film, Start, End, TicketPrice, Room, CheckTicket });
            DGShows.Dock = DockStyle.Fill;
            DGShows.Location = new Point(0, 0);
            DGShows.Name = "DGShows";
            DGShows.ReadOnly = true;
            DGShows.RowTemplate.Height = 25;
            DGShows.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            DGShows.Size = new Size(776, 402);
            DGShows.TabIndex = 4;
            DGShows.CellClick += DGShows_CellClick;
            DGShows.CellContentClick += DGShows_CellContentClick;
            // 
            // ID
            // 
            ID.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            ID.HeaderText = "#";
            ID.Name = "ID";
            ID.ReadOnly = true;
            ID.Width = 39;
            // 
            // Film
            // 
            Film.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            Film.HeaderText = "Film";
            Film.Name = "Film";
            Film.ReadOnly = true;
            Film.Width = 55;
            // 
            // Start
            // 
            Start.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            Start.HeaderText = "Start";
            Start.Name = "Start";
            Start.ReadOnly = true;
            Start.Width = 56;
            // 
            // End
            // 
            End.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            End.HeaderText = "End";
            End.Name = "End";
            End.ReadOnly = true;
            End.Width = 52;
            // 
            // TicketPrice
            // 
            TicketPrice.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            TicketPrice.HeaderText = "TicketPrice";
            TicketPrice.Name = "TicketPrice";
            TicketPrice.ReadOnly = true;
            TicketPrice.Width = 89;
            // 
            // Room
            // 
            Room.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            Room.HeaderText = "Room";
            Room.Name = "Room";
            Room.ReadOnly = true;
            Room.Width = 64;
            // 
            // CheckTicket
            // 
            CheckTicket.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            CheckTicket.HeaderText = "CheckTicket";
            CheckTicket.Name = "CheckTicket";
            CheckTicket.ReadOnly = true;
            // 
            // panel1
            // 
            panel1.Controls.Add(DGShows);
            panel1.Location = new Point(12, 36);
            panel1.Name = "panel1";
            panel1.Size = new Size(776, 402);
            panel1.TabIndex = 5;
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(panel1);
            Name = "MainForm";
            Text = "MainForm";
            Load += MainForm_Load;
            Controls.SetChildIndex(panel1, 0);
            ((System.ComponentModel.ISupportInitialize)DGShows).EndInit();
            panel1.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private DataGridView DGShows;
        private DataGridViewTextBoxColumn ID;
        private DataGridViewTextBoxColumn Film;
        private DataGridViewTextBoxColumn Start;
        private DataGridViewTextBoxColumn End;
        private DataGridViewTextBoxColumn TicketPrice;
        private DataGridViewTextBoxColumn Room;
        private DataGridViewButtonColumn CheckTicket;
        private Panel panel1;
    }
}