using Dapper;
using DemoApi.Context;
using DemoApi.Models.Domain.Student;
using DemoApi.Models.Domain.Users;
using DemoApi.Models.Dtos.StudentDtos;
using DemoApi.Models.Dtos.UserDtos;
using System.Data;
using BCrypt.Net;
using Newtonsoft.Json;
using Org.BouncyCastle.Asn1.Ocsp;

namespace DemoApi.Services.User
{
    public class UserService: IUserService
    {
        private readonly DapperConnection _dapperConnection;

        public UserService(DapperConnection dapperConnection)
        {
            _dapperConnection = dapperConnection;
        }
        public async Task<bool> AddUserAsync(UserDto userDto)
        {
            var addUserProcedure = "AddUser";

            using (var connection = _dapperConnection.GetConnection())
            {
                await connection.OpenAsync();

                try
                {
                    var plainPassword = userDto.Password;
                    var hashedPassword = BCrypt.Net.BCrypt.HashPassword(plainPassword);

                    var addUserParameters = new DynamicParameters(new
                    {
                        p_UserName = userDto.UserName,
                        p_PassWord = hashedPassword,
                        p_FullName = userDto.FullName,
                        p_Email = userDto.Email,
                        p_FirstLogin = userDto.FirstLogin,
                        p_InDate = userDto.InDate,
                        p_OutDate = userDto.OutDate,
                        p_Avatar = userDto.Avatar,
                        p_CreatedBy = userDto.CreatedBy,
                        p_RoleCode = userDto.RoleCode,
                    });

                    await connection.ExecuteAsync(
                        addUserProcedure,
                        addUserParameters,
                        commandType: CommandType.StoredProcedure
                    );

                    return true;
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Failed to execute AddUser stored procedure: {ex.Message}");
                    return false;
                }
            }
        }


        public async Task<Users?> DeleteUserAsync(int id,UserDto userDto)
        {
            var procedureName = "DeleteUser";
            var parameters = new DynamicParameters();
            parameters.Add("p_ID",id);
            parameters.Add("p_DeletedBy",userDto.DeletedBy);

            try
            {
                using (var connection = _dapperConnection.GetConnection())
                {
                    await connection.OpenAsync();

                    var result = await connection.QueryFirstOrDefaultAsync<Users>(
                        procedureName,
                        parameters,
                        commandType: CommandType.StoredProcedure
                    );

                    return result;
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Error occurred while adding user: {ex.Message}",ex);
            }
        }

        public async Task<List<Users>> GetAllUserAsync()
        {
            var procedureName = "GetAllUsers";
            try
            {
                using (var connection = _dapperConnection.GetConnection())
                {
                    await connection.OpenAsync();
                    var user = await connection.QueryAsync<Users>(procedureName);
                    return user.ToList();
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Error: {ex.Message}",ex);
            }
        }

        public async Task<Users> GetUserByIdAsync(int id)
        {
            var procedureName = "GetUserById";
            var parameters = new DynamicParameters();
            parameters.Add("p_ID",id,DbType.Int32,ParameterDirection.Input);
            try
            {
                using (var connection = _dapperConnection.GetConnection())
                {
                    await connection.OpenAsync();
                    var user = await connection.QueryFirstOrDefaultAsync<Users>(procedureName,parameters,commandType: CommandType.StoredProcedure);
                    return user;
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Error: {ex.Message}",ex);
            }
        }

        public async Task<Users?> UpdateUserAsync(int id,UserDto userDto)
        {
            var procedureName = "UpdateUser";
            var parameters = new DynamicParameters();
            parameters.Add("p_ID",id);
            parameters.Add("p_UserName",userDto.UserName);
            parameters.Add("p_PassWord",userDto.Password);
            parameters.Add("p_FullName",userDto.FullName);
            parameters.Add("p_Email",userDto.Email);
            parameters.Add("p_FirstLogin",userDto.FirstLogin);
            parameters.Add("p_InDate",userDto.InDate);
            parameters.Add("p_OutDate",userDto.OutDate);
            parameters.Add("p_Avatar",userDto.Avatar);
            parameters.Add("p_CreatedBy",userDto.CreatedBy);
            parameters.Add("p_FailCount",userDto.FailCount);
            parameters.Add("p_IsLocked",userDto.IsLocked);
            parameters.Add("p_UpdatedBy",userDto.UpdatedBy);

            try
            {
                using (var connection = _dapperConnection.GetConnection())
                {
                    await connection.OpenAsync();

                    var result = await connection.QueryFirstOrDefaultAsync<Users>(
                        procedureName,
                        parameters,
                        commandType: CommandType.StoredProcedure
                    );

                    return result;
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Error occurred while adding user: {ex.Message}",ex);
            }
        }
    }
}
