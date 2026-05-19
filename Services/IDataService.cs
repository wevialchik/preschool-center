using nз3.Models;

namespace nз3.Services;

public interface IDataService
{
    Task<List<Child>> GetAllChildrenAsync();
    Task<List<Course>> GetAllCoursesAsync();
    Task EnrollChildToCourseAsync(int childId, int courseId);
}