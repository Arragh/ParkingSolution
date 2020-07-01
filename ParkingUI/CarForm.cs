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

        private void buttonDelete_Click(object sender, System.EventArgs e)
        {
            int id = (int)dataGridView1.SelectedRows[0].Cells[0].Value;
            Car car = db.Cars.Find(id);
            if (car != null)
            {
                db.Cars.Remove(car);
                db.SaveChanges();
            }
        }

        private void buttonEdit_Click(object sender, System.EventArgs e)
        {
            int id = (int)dataGridView1.SelectedRows[0].Cells[0].Value;
            Car car = db.Cars.Find(id);
            if (car != null)
            {
                AddCar form = new AddCar(car);
                if (form.ShowDialog() == DialogResult.OK)
                {
                    car.Brand = form.Car.Brand;
                    car.Model = form.Car.Model;
                    car.Number = form.Car.Number;
                    car.ClientId = form.Car.ClientId;
                    db.SaveChanges();
                }
            }
        }
    }
}
