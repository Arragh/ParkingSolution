using System;

namespace ParkingBL.Model
{
    public class Car
    {
        public int Id { get; private set; }
        public string Brand { get; set; }
        public string Model { get; set; }
        public string Number { get; set; }

        // Сюда сохраняем ID клиента через переопределённый метод GetHashCode
        public int ClientId { get; set; }
    }
}
