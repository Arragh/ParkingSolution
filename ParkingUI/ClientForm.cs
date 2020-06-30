using ParkingBL.Model;
using System;
using System.Data.Entity;
using System.Windows.Forms;

namespace ParkingUI
{
    public partial class ClientForm : Form
    {
        ParkingContext db;
        public ClientForm()
        {
            InitializeComponent();
            db = new ParkingContext();
            db.Clients.Load();
            dataGridView1.DataSource = db.Clients.Local.ToBindingList();
        }

        private void ClientForm_Load(object sender, EventArgs e)
        {

        }

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            AddClient form = new AddClient();
            if (form.ShowDialog() == DialogResult.OK)
            {
                db.Clients.Add(form.Client);
                db.SaveChanges();
            }
        }

        private void buttonEdit_Click(object sender, EventArgs e)
        {
            int id = (int)dataGridView1.SelectedRows[0].Cells[0].Value;
            Client client = db.Clients.Find(id);
            if (client != null)
            {
                AddClient form = new AddClient(client);
                if (form.ShowDialog() == DialogResult.OK)
                {
                    client.FirstName = form.Client.FirstName;
                    client.SecondName = form.Client.SecondName;
                    client.LastName = form.Client.LastName;
                    db.SaveChanges();
                    dataGridView1.Update();
                }
            }
        }

        private void buttonDelete_Click(object sender, EventArgs e)
        {
            int id = (int)dataGridView1.SelectedRows[0].Cells[0].Value;
            Client client = db.Clients.Find(id);
            if (client != null)
            {
                db.Clients.Remove(client);
                db.SaveChanges();
            }
        }

        private void buttonClose_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
