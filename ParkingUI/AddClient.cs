using ParkingBL.Model;
using System;
using System.Windows.Forms;

namespace ParkingUI
{
    public partial class AddClient : Form
    {
        public Client Client { get; set; }

        // Конструктор для добавления нового клиента в базу
        public AddClient()
        {
            InitializeComponent();
        }

        // Конструктор для редактирования имеющегося в базе клиента
        public AddClient(Client client) : this()
        {
            // Передаем в поля textBox данные клиента client, переданного в конструктор
            textBoxFirstName.Text = client.FirstName;
            textBoxSecondName.Text = client.SecondName;
            textBoxLastName.Text = client.LastName;
        }

        private void AddClient_Load(object sender, EventArgs e)
        {
        }

        // Кнопка ОК
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

        // Кнопка отмены
        private void button2_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
