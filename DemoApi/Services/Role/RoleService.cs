using Dapper;
using DemoApi.Context;
using DemoApi.Models.Domain.Pages;
using DemoApi.Models.Domain.Role;
using DemoApi.Models.Dtos.PageDtos;
using DemoApi.Models.Dtos.RoleDtos;
using System.Data;

namespace DemoApi.Services.Role
{
    public class RoleService: IRoleService
    {
        private readonly DapperConnection _dapperConnection;
        public RoleService(DapperConnection dapperConnection)
        {
            _dapperConnection = dapperConnection;
        }

        public async Task<Roles> AddRoleAsync(RoleDtos roleDtos)
        {
            var procedureName = "AddRole";
            var parameters = new DynamicParameters();
            parameters.Add("p_Code",roleDtos.Code);
            parameters.Add("p_Name",roleDtos.Name);
            parameters.Add("p_CreatedBy",roleDtos.CreatedBy);

            try
            {
                using (var connection = _dapperConnection.GetConnection())
                {
                    await connection.OpenAsync();

                    var result = await connection.QueryFirstOrDefaultAsync<Roles>(
                        procedureName,
                        parameters,
                        commandType: CommandType.StoredProcedure
                    );

                    return result;
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Error occurred while adding page: {ex.Message}",ex);
            }
        }

        public async Task<Roles> DeleteRoleAsync(int id,RoleDtos roleDtos)
        {
            var procedureName = "DeleteRole";
            var parameters = new DynamicParameters();
            parameters.Add("p_ID",id);
            parameters.Add("p_DeletedBy",roleDtos.DeletedBy);

            try
            {
                using (var connection = _dapperConnection.GetConnection())
                {
                    await connection.OpenAsync();

                    var result = await connection.QueryFirstOrDefaultAsync<Roles>(
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

        public async Task<List<Roles>> GetAllRolesAsync()
        {
            var procedureName = "GetAllRoles";
            try
            {
                using (var connection = _dapperConnection.GetConnection())
                {
                    await connection.OpenAsync();
                    var role = await connection.QueryAsync<Roles>(procedureName);
                    return role.ToList();
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Error: {ex.Message}",ex);
            }
        }

        public async Task<Roles> GetRoleByIdAsync(int id)
        {
            var procedureName = "GetRole";
            var parameters = new DynamicParameters();
            parameters.Add("p_ID",id,DbType.Int32,ParameterDirection.Input);
            try
            {
                using (var connection = _dapperConnection.GetConnection())
                {
                    await connection.OpenAsync();
                    var role = await connection.QueryFirstOrDefaultAsync<Roles>(procedureName,parameters,commandType: CommandType.StoredProcedure);
                    return role;
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Error: {ex.Message}",ex);
            }
        }

        public async Task<Roles> UpdateRoleAsync(int id,RoleDtos roleDtos)
        {
            var procedureName = "UpdateRole";
            var parameters = new DynamicParameters();
            parameters.Add("p_ID",id);
            parameters.Add("p_Code",roleDtos.Code);
            parameters.Add("p_Name",roleDtos.Name);
            parameters.Add("p_UpdatedBy",roleDtos.UpdatedBy);

            try
            {
                using (var connection = _dapperConnection.GetConnection())
                {
                    await connection.OpenAsync();

                    var result = await connection.QueryFirstOrDefaultAsync<Roles>(
                        procedureName,
                        parameters,
                        commandType: CommandType.StoredProcedure
                    );

                    return result;
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Error occurred while adding page: {ex.Message}",ex);
            }
        }
    }
}
