using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using example1;
//using DAL.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace Entities
{
    public class CarContext : DbContext
    {

        public CarContext():base()
        {
        }

        public CarContext(DbContextOptions<CarContext> options)
            : base(options)
        {
        }


        public DbSet<User> Users { get; set; }
        public DbSet<Car> Cars { get; set; }
        protected readonly IConfiguration Configuration;
        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            //options.UseSqlServer(Configuration.GetConnectionString("UserDBEntities"));
            options.UseSqlServer("Data Source = localhost; Database = RentCarDB; integrated security = True;");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().ToTable("User");
            modelBuilder.Entity<Car>().ToTable("Car");
            //  modelBuilder.Entity<APIAuthority>().ToTable("APIAuthority");
        }
        //public DbSet<User> User { get; set; }
        //public DbSet<Car> Cars { get; set; }
        // public DbSet<APIAuthority> APIAuthority { get; set; }
    }
}
