using Microsoft.EntityFrameworkCore;
using Microsoft.VisualBasic;

namespace Lap
{
    public class infomationDbContext : DbContext
    {
        public infomationDbContext(DbContextOptions<infomationDbContext> options) : base(options) { }

        public DbSet<Information> Infomations { get; set; }

        public DbSet<Department> Departments { get; set; }
        public DbSet<Employee> Employees { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Department>()
                .HasMany(d => d.Employees)
                .WithOne(e => e.Department)
                .HasForeignKey(e => e.DepartmentId);

            base.OnModelCreating(modelBuilder);
        }
    }
}
