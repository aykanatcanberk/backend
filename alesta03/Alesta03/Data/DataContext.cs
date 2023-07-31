
global using Microsoft.EntityFrameworkCore;

namespace Alesta03.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options): base(options)
        {
            AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);
            AppContext.SetSwitch("Npgsql.DisableDateTimeInfinityConversions", true);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseNpgsql("Host=localhost;Port=5432;Database=vizyonergenc03;Username=postgres;Password=354354;");

        }

        public DbSet<Approval>  Approvals { get; set; }
        public DbSet<BackEdu> BackEdus { get; set; }
        public DbSet<BackWork> BackWorks { get; set; }
        public DbSet<Company> Companies { get; set; }
        public DbSet<EduStatus> EduStatuses { get; set; }
        public DbSet<ExpReview> ExpReviews { get; set; }
        public DbSet<Person> People { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<WorkStatus> WorkStatuses { get; set; }
        public DbSet<Post> Posts { get; set; }
        public DbSet<Advert> Adverts { get; set; }
        public DbSet<AdvertApproval> AdvertApprovals { get; set; }
    }
}
