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
            // Загружем данные из базы db.Clients
            db.Clients.Load();
            // Задаем названия колонок в dataGridView1
            dataGridView1.DataSource = db.Clients.Local.ToBindingList();
            dataGridView1.Columns[0].HeaderText = "Идентификатор";
            dataGridView1.Columns[1].HeaderText = "Фамилия";
            dataGridView1.Columns[2].HeaderText = "Имя";
            dataGridView1.Columns[3].HeaderText = "Отчество";
        }

        private void ClientForm_Load(object sender, EventArgs e)
        {
        }

        // Кнопка добавить
        private void buttonAdd_Click(object sender, EventArgs e)
        {
            // Создаем экземпляр класса формы добавления клиента и открываем его
            AddClient form = new AddClient();
            if (form.ShowDialog() == DialogResult.OK)
            {
                // Получаем данные нового клиента с формы добавления и сохраняем его в базе
                db.Clients.Add(form.Client);
                db.SaveChanges();
            }
        }

        // Кнопка изменить
        private void buttonEdit_Click(object sender, EventArgs e)
        {
            // Выбираем в поле dataGridView1 то, что хотим изменить и сохраняем Id в отдельную переменную
            int id = (int)dataGridView1.SelectedRows[0].Cells[0].Value;
            // По этой переменной находим в базе нужного нам клиента
            Client client = db.Clients.Find(id);
            // Проверяем на null, и если такой клиент существует - редактируем его
            if (client != null)
            {
                // Передавая в конструктор экземпляр класса client, мы открываем форму редактирования
                AddClient form = new AddClient(client);
                if (form.ShowDialog() == DialogResult.OK)
                {
                    // Присваиваем свойствам новые значения из формы и сохраняем
                    client.FirstName = form.Client.FirstName;
                    client.SecondName = form.Client.SecondName;
                    client.LastName = form.Client.LastName;
                    db.SaveChanges();
                    // По идее должен сразу обновить даные в dataGridView1, но почему-то не работает, надо разобраться
                    dataGridView1.Update();
                }
            }
        }

        // Кнопка удалить
        private void buttonDelete_Click(object sender, EventArgs e)
        {
            // Выбираем в поле dataGridView1 то, что хотим изменить и сохраняем Id в отдельную переменную
            int id = (int)dataGridView1.SelectedRows[0].Cells[0].Value;
            // По этой переменной находим в базе нужного нам клиента
            Client client = db.Clients.Find(id);
            // Проверяем на null, и если такой клиент существует - удаляем его
            if (client != null)
            {
                db.Clients.Remove(client);
                db.SaveChanges();
            }
        }

        // Кнопка закрыть
        private void buttonClose_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
