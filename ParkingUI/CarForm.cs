using System;
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
            // Загружем данные из базы db.Cars
            db.Cars.Load();
            // Задаем названия колонок в dataGridView1
            dataGridView1.DataSource = db.Cars.Local.ToBindingList();
            dataGridView1.Columns[0].HeaderText = "Идентификатор";
            dataGridView1.Columns[1].HeaderText = "Марка";
            dataGridView1.Columns[2].HeaderText = "Модель";
            dataGridView1.Columns[3].HeaderText = "Госномер";
            dataGridView1.Columns[4].HeaderText = "ID клиента";
            // Запрет на редактирование поля textBoxClient
            textBoxClient.ReadOnly = true;
        }

        // Кнопка добавить
        private void buttonAdd_Click(object sender, EventArgs e)
        {
            // Создаем экземпляр класса формы добавления машины и открываем его
            AddCar form = new AddCar();
            if (form.ShowDialog() == DialogResult.OK)
            {
                // Получаем данные новой машины с формы добавления и сохраняем её в базе
                db.Cars.Add(form.Car);
                db.SaveChanges();
            }
        }

        // Кнопка выход
        private void buttonExit_Click(object sender, EventArgs e)
        {
            Close();
        }

        // Кнопка удалить
        private void buttonDelete_Click(object sender, EventArgs e)
        {
            // Выбираем в поле dataGridView1 то, что хотим удалить и сохраняем Id в отдельную переменную
            int id = (int)dataGridView1.SelectedRows[0].Cells[0].Value;
            // По этой переменной находим в базе нужную нам машину
            Car car = db.Cars.Find(id);
            // Проверяем на null, и если такая машина существует - удаляем её
            if (car != null)
            {
                db.Cars.Remove(car);
                db.SaveChanges();
            }
        }

        // Кнопка изменить
        private void buttonEdit_Click(object sender, EventArgs e)
        {
            // Выбираем в поле dataGridView1 то, что хотим изменить и сохраняем Id в отдельную переменную
            int id = (int)dataGridView1.SelectedRows[0].Cells[0].Value;
            // По этой переменной находим в базе нужную нам машину
            Car car = db.Cars.Find(id);
            // Проверяем на null, и если такая машина существует - открываем окно редактирования
            if (car != null)
            {
                // Передавая в конструктор экземпляр класса car, мы открываем форму редактирования
                AddCar form = new AddCar(car);
                if (form.ShowDialog() == DialogResult.OK)
                {
                    // Присваиваем свойствам новые значения из формы и сохраняем
                    car.Brand = form.Car.Brand;
                    car.Model = form.Car.Model;
                    car.Number = form.Car.Number;
                    car.ClientId = form.Car.ClientId;
                    db.SaveChanges();
                }
            }
        }

        // Выводим информацию о владельце машины в поле textBoxClient
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            // Запоминаем ID клиента из столбца с индексом 4
            int clientId = Convert.ToInt32(dataGridView1.CurrentRow.Cells[4].Value);
            // Ищем такого клиента в базе
            Client client = db.Clients.Find(clientId);
            // Создаем переменную для записи в неё информации о клиенте
            string clientName = "";
            // Если клиент существует, то сохраняем в переменную его полные ФИО
            if (client != null)
            {
                clientName = client.FirstName + " " + client.SecondName + " " + client.LastName;
            }
            // Если клиента не существует, то сообщаем об этом в той же переменной
            else
            {
                clientName = "Клиент не найден в базе";
            }
            // Выводим значение переменной в textBoxClient
            textBoxClient.Text = clientName;
        }
    }
}
