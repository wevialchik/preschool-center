using Microsoft.EntityFrameworkCore;
using nз3.Data;
using nз3.Models;

namespace nз3.Services;

public class DataService : IDataService
{
    private readonly SchoolContext _context;

    public DataService(SchoolContext context)
    {
        _context = context;
    }

    public async Task<List<Child>> GetAllChildrenAsync()
    {
        return await _context.Children.ToListAsync();
    }

    public async Task<List<Course>> GetAllCoursesAsync()
    {
        return await _context.Courses.ToListAsync();
    }

    public async Task EnrollChildToCourseAsync(int childId, int courseId)
    {
        var existing = await _context.ChildCourses
            .FirstOrDefaultAsync(cc => cc.ChildId == childId && cc.CourseId == courseId);

        if (existing == null)
        {
            var enrollment = new ChildCourse
            {
                ChildId = childId,
                CourseId = courseId,
                EnrollmentDate = DateTime.Now
            };
            _context.ChildCourses.Add(enrollment);
            await _context.SaveChangesAsync();
        }
    }
}