using System.Data.Entity;

namespace ParkingBL.Model
{
    public class ParkingContext : DbContext
    {
        public ParkingContext() : base("ParkingConnection") { }
        public DbSet<Client> Clients { get; set; }
        public DbSet<Car> Cars { get; set; }
    }
}
