using Lap2.Models;
using Microsoft.EntityFrameworkCore;

namespace Lap2
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Address> Addresses { get; set; }
        public DbSet<Client> Clients { get; set; }
        public DbSet<NhanVien> NhanViens { get; set; }
        public DbSet<ThanNhan> ThanNhans { get; set; }

        public DbSet<Person> People { get; set; }
        public DbSet<Company> Companies { get; set; }
        public DbSet<PersonCompany> PersonCompanies { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Client>()
                .HasOne(c => c.Address)
                .WithMany(a => a.Clients)
                .HasForeignKey(c => c.Address_ID);

            modelBuilder.Entity<NhanVien>()
              .HasMany(nv => nv.ThanNhans)
              .WithOne(tn => tn.NhanVien)
              .HasForeignKey(tn => tn.MA_NVIEN);

            modelBuilder.Entity<ThanNhan>()
                .HasKey(tn => new { tn.MA_NVIEN, tn.TENTN });

            base.OnModelCreating(modelBuilder);
        }
    }
}
