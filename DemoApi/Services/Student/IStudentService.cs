using DemoApi.Models.Domain.Student;
using DemoApi.Models.Dtos.StudentDtos;

namespace DemoApi.Services.Student
{
    public interface IStudentService
    {
        public Task<List<Students>> GetAllStudentsAsync();
        public Task<Students> GetStudentByIdAsync(int id);
        public Task<Students> AddStudentAsync(StudentDto studentDto);
        public Task UpdateStudentAsync(int id,StudentDto studentDto);
        public Task DeleteStudentAsync(int id);
    }
}
