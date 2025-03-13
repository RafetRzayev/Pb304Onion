using Academy.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Academy.Infrastructure.EfCore;

public class AppDbContext : DbContext
{
    public DbSet<Student> Students { get; set; }
    public DbSet<Group> Groups { get; set; }
    public DbSet<Teacher> Teachers { get; set; }
    public DbSet<TeacherGroup> TeacherGroups { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer("Server=.\\SqlExpress;Database=Pb304OnionDb;Trusted_Connection=True;TrustServerCertificate=true");
    }
}
