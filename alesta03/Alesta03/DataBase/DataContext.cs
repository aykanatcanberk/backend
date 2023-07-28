using Alesta03.Services.PostServices;
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
            optionsBuilder.UseNpgsql("Server=localhost;Database=backend;port=5432;Username=postgres;Password=admin;");
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Post> Posts { get; set; }
        public DbSet<Company> Companies { get; set; }
        public DbSet<Advert>Adverts { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
           
        }
    }
}
