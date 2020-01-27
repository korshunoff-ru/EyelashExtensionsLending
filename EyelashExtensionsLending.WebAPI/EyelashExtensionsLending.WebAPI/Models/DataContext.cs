using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace EyelashExtensionsLending.WebAPI.Models
{
    public class EELendingDataContext : DbContext
    {
        public DbSet<Service> Services { get; set; }
        
        public DbSet<Order> Orders { get; set; }

        public DbSet<Client> Clients { get; set; }

        public DbSet<OrderTime> OrdersTime { get; set; }

        public DbSet<OrderService> OrderServices { get; set; }

        public EELendingDataContext(DbContextOptions<EELendingDataContext> options) : base(options) { }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {

            if (!optionsBuilder.IsConfigured)
            {
                //optionsBuilder.UseSqlServer(@"Server=MAHESHIG;Database=Login;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<OrderService>().HasKey(x =>  new { x.ServiceId, x.OrderId });
            modelBuilder.Entity<OrderTime>().HasKey(x =>  new { x.OrderId, x.Date });
        }

    }


}
