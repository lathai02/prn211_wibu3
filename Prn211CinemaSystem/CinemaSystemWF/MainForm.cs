using CinemeSystemWF.Requests;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CinemaSystemWF
{
    public partial class MainForm : TemplateForm
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private async void MainForm_Load(object sender, EventArgs e)
        {
            var response = await ShowRequest.Instance.GetShows(TimeSpan.FromHours(1)).ConfigureAwait(false);


            this.Invoke(() =>
            {
                if (response.Success)
                {
                    foreach (var show in response.Shows)
                    {
                        DGShows.Rows.Add(show.ID, show.Film, show.Start, show.End, show.TicketPrice, show.Room, "Check");
                    }
                }
            });
        }

        private void DGShows_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.ColumnIndex == 6)
                {
                    int showID = (int)DGShows.Rows[e.RowIndex].Cells[0].Value;
                    this.Hide();
                    var form = new CheckTicket(showID);
                    form.FormClosing += (_, _) => this.Show();
                    form.ShowDialog();
                }
            }
            catch { }
        }

        private void DGShows_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
