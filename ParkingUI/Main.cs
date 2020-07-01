using System;
using System.Windows.Forms;

namespace ParkingUI
{
    public partial class Main : Form
    {
        public Main()
        {
            InitializeComponent();
        }

        private void buttonBrowseClients_Click(object sender, EventArgs e)
        {
            ClientForm form = new ClientForm();
            form.Show();
        }

        private void buttonBrowseCars_Click(object sender, EventArgs e)
        {
            CarForm form = new CarForm();
            form.Show();
        }

        private void buttonExit_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
