using ParkingBL.Model;
using System.Data.Entity;
using System.Linq;
using System.Windows.Forms;
using System;
using System.Collections.Generic;

namespace ParkingUI
{
    public partial class AddCar : Form
    {
        ParkingContext db;
        public Car Car { get; set; }

        public AddCar()
        {
            InitializeComponent();
            db = new ParkingContext();
            db.Clients.Load();

            comboBoxClient.DataSource = db.Clients.Local.ToBindingList();
            comboBoxClient.ValueMember = "id";
            comboBoxClient.DisplayMember = "FirstName";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Car = new Car()
            {
                Brand = textBoxBrand.Text,
                Model = textBoxModel.Text,
                Number = textBoxNumber.Text,
                ClientId = comboBoxClient.SelectedValue.GetHashCode()
            };
        }
    }
}
