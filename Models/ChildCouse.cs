namespace nз3.Models;

public class ChildCourse
{
    public int ChildId { get; set; }
    public Child Child { get; set; } = null!;
    public int CourseId { get; set; }
    public Course Course { get; set; } = null!;
    public DateTime EnrollmentDate { get; set; } = DateTime.Now;
}