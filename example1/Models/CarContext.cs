using Microsoft.EntityFrameworkCore;
using System.Diagnostics.CodeAnalysis;

namespace example1.Models
{
    public class CarContext : DbContext
    {
        public CarContext(DbContextOptions<CarContext> options)
            : base(options)
        {
        }

        public DbSet<CarContext> Cars { get; set; } = null!;
    }
}
/*
 * In ASP.NET Core, services such as the DB context must be registered 
 * with the dependency injection (DI) container. 
 * The container provides the service to controllers.  To do this go to --> Program.cs
 */