using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using nз3.Models;

namespace nз3.Data.Configurations;

public class ChildCourseConfiguration : IEntityTypeConfiguration<ChildCourse>
{
    public void Configure(EntityTypeBuilder<ChildCourse> builder)
    {
        builder.ToTable("ChildCourses");
        builder.HasKey(cc => new { cc.ChildId, cc.CourseId });
        builder.Property(cc => cc.EnrollmentDate).HasDefaultValueSql("datetime('now')");
    }
}