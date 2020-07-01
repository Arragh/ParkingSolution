using System.Data.Entity;
using System.Windows.Forms;
using ParkingBL.Model;

namespace ParkingUI
{
    public partial class CarForm : Form
    {
        ParkingContext db;
        public CarForm()
        {
            InitializeComponent();
            db = new ParkingContext();
            db.Cars.Load();
            dataGridView1.DataSource = db.Cars.Local.ToBindingList();
        }

        private void buttonAdd_Click(object sender, System.EventArgs e)
        {
            AddCar form = new AddCar();
            if (form.ShowDialog() == DialogResult.OK)
            {
                db.Cars.Add(form.Car);
                db.SaveChanges();
            }
        }

        private void buttonExit_Click(object sender, System.EventArgs e)
        {
            Close();
        }
    }
}
