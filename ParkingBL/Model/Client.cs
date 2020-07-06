namespace ParkingBL.Model
{
    public class Client
    {
        public int Id { get; private set; }
        public string FirstName { get; set; }
        public string SecondName { get; set; }
        public string LastName { get; set; }

        // Переопределяем метод GetHashCode, чтобы возвращал ID экземпляра класса
        public override int GetHashCode()
        {
            return Id;
        }
    }
}
