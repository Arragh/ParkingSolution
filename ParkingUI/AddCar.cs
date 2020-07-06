using ParkingBL.Model;
using System;
using System.Data.Entity;
using System.Linq;
using System.Windows.Forms;

namespace ParkingUI
{
    public partial class AddCar : Form
    {
        ParkingContext db;
        public Car Car { get; set; }

        // Конструктор для добавления новой машины в БД
        public AddCar()
        {
            InitializeComponent();
            db = new ParkingContext();

            // Загружаем клиентскую базу для привязки машины к определенному клиенту
            db.Clients.Load();
            // Подгружаем список клиентов в comboBox
            comboBoxClient.DataSource = db.Clients.Local.ToBindingList();
            // в БД машин будет записан ID владельца
            comboBoxClient.ValueMember = "id";
            // В combobox будут отображаться имена клиентов
            comboBoxClient.DisplayMember = "FirstName";
        }

        // Конструктор для редактирования машины
        public AddCar(Car car) : this()
        {
            // передает в поля textBox данные переданной в конструктор машины
            textBoxBrand.Text = car.Brand;
            textBoxModel.Text = car.Model;
            textBoxNumber.Text = car.Number;
            // по ID владельца находит его в базе клиентов и выводит его полное имя в comboBox
            comboBoxClient.SelectedItem = db.Clients.Single(c => c.Id == car.ClientId);
        }

        // кнопка ОК
        private void button1_Click(object sender, EventArgs e)
        {
            Car = new Car()
            {
                Brand = textBoxBrand.Text,
                Model = textBoxModel.Text,
                Number = textBoxNumber.Text,
                // Переопределение метода GetHashCode в классе Client возвращает ID клиента
                // и записывает его в поле ClientId класса Car
                ClientId = comboBoxClient.SelectedValue.GetHashCode()
            };
        }

        // Кнопка отмены
        private void button2_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
