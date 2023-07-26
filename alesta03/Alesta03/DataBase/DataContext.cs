using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;

namespace Alesta03.DataBase
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {

        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseNpgsql("Server=localhost;Database=alesta3;port=5432;Username=postgres;Password=admin;");
        }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
           
        }
    }
}
