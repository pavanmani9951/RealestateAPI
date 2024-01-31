using Microsoft.EntityFrameworkCore;
using RealEstateAPI.Models;

namespace RealEstateAPI.Data
{
    public class ApiDbContext:DbContext
    {
        public DbSet<Category> Categories { get; set; }

        //.net7 connection string to the dbcontext class
        //refer contactapi in github for different connection string
        // we will connect the connection string in appsettings.json alsoo
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=(localdb)\MSSQLLocalDB;Database=RealestateDb");
        }
    }
}
