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
            using (var connection = _dapperConnection.GetConnection())
            {
                await connection.OpenAsync();

                using (var transaction = connection.BeginTransaction())
                {
                    try
                    {
                        // Stored procedure user
                        var procedureName1 = "AddUser";
                        var plainPassword = userDto.Password;
                        var hashedPassword = BCrypt.Net.BCrypt.HashPassword(plainPassword);
                        var parameters1 = new DynamicParameters();
                        parameters1.Add("p_UserName",userDto.UserName);
                        parameters1.Add("p_PassWord",hashedPassword);
                        parameters1.Add("p_FullName",userDto.FullName);
                        parameters1.Add("p_Email",userDto.Email);
                        parameters1.Add("p_FirstLogin",userDto.FirstLogin);
                        parameters1.Add("p_InDate",userDto.InDate);
                        parameters1.Add("p_OutDate",userDto.OutDate);
                        parameters1.Add("p_Avatar",userDto.Avatar);
                        parameters1.Add("p_CreatedBy",userDto.CreatedBy);
                        var roleCodesJson = JsonConvert.SerializeObject(userDto.ListRoleCode);
                        parameters1.Add("p_RoleCode",roleCodesJson,dbType: DbType.String,direction: ParameterDirection.Input);

                        var userId = await connection.QuerySingleAsync<int>(
                            procedureName1,
                            parameters1,
                            transaction,
                            commandType: CommandType.StoredProcedure
                        );

                        // Stored procedure user_role
                        var procedureName2 = "AddUserRole";

                        foreach (var roleCode in userDto.ListRoleCode)
                        {
                            var parameters2 = new DynamicParameters();
                            parameters2.Add("p_UserId",userId);
                            parameters2.Add("p_RoleCode",roleCode);  
                            parameters2.Add("p_CreatedBy",userDto.CreatedBy);

                            await connection.ExecuteAsync(
                                procedureName2,
                                parameters2,
                                transaction,
                                commandType: CommandType.StoredProcedure
                            );
                        }

                        
                        transaction.Commit();
                        return true;
                    }
                    catch (Exception ex)
                    {
                        transaction.Rollback();
                        Console.WriteLine($"Transaction failed: {ex.Message}");
                        return false;
                    }
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
