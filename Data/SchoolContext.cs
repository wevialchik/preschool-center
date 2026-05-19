using Microsoft.EntityFrameworkCore;
using nз3.Models;

namespace nз3.Data;

public class SchoolContext : DbContext
{
    public SchoolContext(DbContextOptions<SchoolContext> options) : base(options) { }

    public DbSet<Child> Children => Set<Child>();
    public DbSet<Course> Courses => Set<Course>();
    public DbSet<ChildCourse> ChildCourses => Set<ChildCourse>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(SchoolContext).Assembly);
    }
}