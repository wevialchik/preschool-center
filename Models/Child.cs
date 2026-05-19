namespace nз3.Models;

public class Child
{
    public int Id { get; set; }
    public string FullName { get; set; } = "";
    public DateTime BirthDate { get; set; }
    public string InsuranceNumber { get; set; } = "";
    public List<ChildCourse> ChildCourses { get; set; } = new();
}