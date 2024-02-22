using Microsoft.EntityFrameworkCore;

namespace EFCodeFirstCRUD.Models
{
    public class CustomerDbContext : DbContext
    {

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=(localdb)\\ProjectModels;Initial Catalog=CustomerDB;Integrated Security=True;");
            base.OnConfiguring(optionsBuilder);
        }

        public  DbSet<Customer> Customers { get; set;}
    }
}
