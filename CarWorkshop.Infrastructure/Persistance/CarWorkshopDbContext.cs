using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarWorkshop.Infrastructure.Persistance
{
    public class CarWorkshopDbContext : IdentityDbContext
    {
        public CarWorkshopDbContext(DbContextOptions<CarWorkshopDbContext> options):base(options)
        {

        }
        public DbSet<Domain.Entities.CarWorkshop> CarWorkshops { get; set; }
        /*protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=(localdb)\\MSSQLLocalDB;Database=CarWorkshopDb;Trusted_Connection=True;");
        }*/
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Domain.Entities.CarWorkshop>(m=>
            {
                m.OwnsOne(c => c.ContactDetails);
            });
        }
    }
}
