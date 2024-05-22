using Microsoft.EntityFrameworkCore;
using System;
using Lap3.Models;

namespace Lap3.Models
{

    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<Student> Students { get; set; }

public DbSet<Lap3.Models.ProductViewModel> ProductViewModel { get; set; } = default!;

    }
}