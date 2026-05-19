namespace nз3.Models;

public class Course
{
    public int Id { get; set; }
    public string Title { get; set; } = "";
    public string Description { get; set; } = "";
    public int MaxStudents { get; set; }
    public List<ChildCourse> ChildCourses { get; set; } = new();
}