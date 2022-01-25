//using Microsoft.EntityFrameworkCore;
//using System.Diagnostics.CodeAnalysis;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;
//using Microsoft.Extensions.Configuration;

//namespace example1
//{
//    public class CarContext : DbContext
//    {
//        public CarContext(DbContextOptions<CarContext> options)
//            : base(options)
//        {
//        }

//        public DbSet<CarContext> Cars { get; set; } = null!;

//        //  public DbSet<Car> Cars { get; set; } = null!;
//        //public DbSet<User> Users { get; set; } = null!;

//    }


//    /*public class CarContext : DbContext
//    {
//        protected readonly IConfiguration Configuration;
//        public void CarContext
//        {

//        }
//        //public CarContext(DbContextOptions<CarContext> options)
//    //: base(options)
//    //    { }

//        public DbSet<CarContext> Cars { get; set; } = null!;
//        protected override void OnConfiguring(DbContextOptionsBuilder options)
//        {
//            //options.UseSqlServer(Configuration.GetConnectionString("UserDBEntities"));
//            options.UseSqlServer("Data Source = localhost; Database = RentCarDB; integrated security = True;");

//        }
//        protected override void OnModelCreating(ModelBuilder modelBuilder)
//        {
//            modelBuilder.Entity<Car>().ToTable("Car");
//            modelBuilder.Entity<User>().ToTable("User");
//        }
//        public DbSet<Car> Car { get; set; }
//        public DbSet<User> User { get; set; }
//    }*/
//}
///*
// * In ASP.NET Core, services such as the DB context must be registered 
// * with the dependency injection (DI) container. 
// * The container provides the service to controllers.  To do this go to --> Program.cs
// */