using ParkingBL.Model;
using System;
using System.Windows.Forms;

namespace ParkingUI
{
    public partial class AddClient : Form
    {
        public Client Client { get; set; }

        public AddClient()
        {
            InitializeComponent();
        }
        public AddClient(Client client) : this()
        {
            textBoxFirstName.Text = client.FirstName;
            textBoxSecondName.Text = client.SecondName;
            textBoxLastName.Text = client.LastName;
        }

        private void AddClient_Load(object sender, EventArgs e)
        {

        }

        private void buttonOK_Click(object sender, EventArgs e)
        {
            Client = new Client()
            {
                FirstName = textBoxFirstName.Text,
                SecondName = textBoxSecondName.Text,
                LastName = textBoxLastName.Text
            };
            Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
