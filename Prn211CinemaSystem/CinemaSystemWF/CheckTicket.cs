using CinemeSystemWF;
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
    public partial class CheckTicket : TemplateForm
    {
        private int showID;

        public CheckTicket(int showId)
        {
            this.showID = showId;
            InitializeComponent();
        }

        private async void CheckBtn_Click(object sender, EventArgs e)
        {
            var email = TextBoxEmail.Text.Trim();
            var otp = TextBoxOTP.Text.Trim();

            if (email.Length == 0 || otp.Length == 0)
            {
                MessageBox.Show("Please fill all fields");
                return;
            }

            var response = await ShowRequest.Instance.CheckTicket(Program.Token, showID, email, otp).ConfigureAwait(false);

            if (response.Success)
            {
                MessageBox.Show("Ticket is valid");
            }
            else
            {
                MessageBox.Show(response.Message);
            }

            this.Invoke(() =>
            {
                DGLogs.Rows.Add(DateTime.Now, email, response.Success);
            });
        }

        private void btnHome_Click(object sender, EventArgs e)
        {
            this.Close();


        }
    }
}
