using Dapper;
using DemoApi.Context;
using System.Data;
using DemoApi.Models.Dtos.StudentDtos;
using DemoApi.Models.Domain.Student;

namespace DemoApi.Services.Student
{
    public class StudentService: IStudentService
    {
        private readonly DapperConnection _dapperConnection;

        public StudentService(DapperConnection dapperConnection)
        {
            _dapperConnection = dapperConnection;
        }
        public async Task<Students> AddStudentAsync(StudentDto studentDto)
        {
            var query = @"
            INSERT INTO student (Name, Age, Email, Address) 
            VALUES (@Name, @Age, @Email, @Address);
            SELECT LAST_INSERT_ID();";
            var parameters = new DynamicParameters();
            parameters.Add("Name",studentDto.FullName,DbType.String);
            parameters.Add("Age",studentDto.Age,DbType.Int64);
            parameters.Add("Email",studentDto.Email,DbType.String);
            parameters.Add("Address",studentDto.Address,DbType.String);

            try
            {
                using (var connection = _dapperConnection.GetConnection())
                {
                    await connection.OpenAsync();
                    var id = await connection.QuerySingleAsync<int>(query,parameters);
                    var addStudent = new Students
                    {
                        Id = id,
                        FullName = studentDto.FullName,
                        Age = studentDto.Age,
                        Email = studentDto.Email,
                        Address = studentDto.Address,
                    };
                    return addStudent;
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Error: {ex.Message}",ex);
            }
        }

        public async Task DeleteStudentAsync(int id)
        {
            var query = "DELETE FROM Student WHERE Id=@id";
            try
            {
                using (var connection = _dapperConnection.GetConnection())
                {
                    await connection.ExecuteAsync(query,new
                    {
                        id
                    });
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Error: {ex.Message}",ex);
            }
        }

        public async Task<List<Students>> GetAllStudentsAsync()
        {
            var query = "SELECT * FROM Student";

            try
            {
                using (var connection = _dapperConnection.GetConnection())
                {
                    await connection.OpenAsync();
                    var students = await connection.QueryAsync<Students>(query);
                    return students.ToList();
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Error: {ex.Message}",ex);
            }
        }


        public async Task<Students> GetStudentByIdAsync(int id)
        {
            var query = "SELECT * FROM Student WHERE Id = @Id";

            try
            {
                using (var connection = _dapperConnection.GetConnection())
                {
                    await connection.OpenAsync();
                    var student = await connection.QuerySingleOrDefaultAsync<Students>(query,new
                    {
                        Id = id
                    });
                    return student;
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Error occurred while fetching student with ID {id}: {ex.Message}",ex);
            }
        }


        public async Task UpdateStudentAsync(int id,StudentDto studentDto)
        {
            var query = @"
            UPDATE student SET Name = @Name, Age=@Age,Email=@Email,Address=@Address WHERE Id=@id;";
            var parameters = new DynamicParameters();
            parameters.Add("Id",id,DbType.Int32);
            parameters.Add("Name",studentDto.FullName,DbType.String);
            parameters.Add("Age",studentDto.Age,DbType.Int64);
            parameters.Add("Email",studentDto.Email,DbType.String);
            parameters.Add("Address",studentDto.Address,DbType.String);

            try
            {
                using (var connection = _dapperConnection.GetConnection())
                {
                    await connection.ExecuteAsync(query,parameters);
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Error: {ex.Message}",ex);
            }
        }
    }
}
