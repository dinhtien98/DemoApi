using Dapper;
using DemoApi.Context;
using DemoApi.Models.Domain.Pages;
using DemoApi.Models.Domain.Role;
using DemoApi.Models.Dtos.PageDtos;
using DemoApi.Models.Dtos.RoleDtos;
using Newtonsoft.Json;
using System.Data;
using System.Reflection.Emit;
using System.Xml.Linq;

namespace DemoApi.Services.Role
{
    public class RoleService: IRoleService
    {
        private readonly DapperConnection _dapperConnection;
        public RoleService(DapperConnection dapperConnection)
        {
            _dapperConnection = dapperConnection;
        }

        public async Task<Roles> AddRoleAsync(RoleDtos roleDtos,int createdById)
        {
            var procedureName = "sp_auth_role_insert";
            string pageCodeJson = JsonConvert.SerializeObject(roleDtos.PageCode);
            string actionCodeJson = JsonConvert.SerializeObject(roleDtos.ActionCode);
            var parameters = new DynamicParameters(new
            {
                p_Code = roleDtos.Code,
                p_Name = roleDtos.Name,
                p_CreatedBy = createdById,
                p_PageCode = pageCodeJson,
                p_ActionCode = actionCodeJson,
            });

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

        public async Task<Roles> DeleteRoleAsync(int id,RoleDtos roleDtos,int deletedById)
        {
            var procedureName = "sp_auth_role_delete";
            var parameters = new DynamicParameters();
            parameters.Add("p_ID",id);
            parameters.Add("p_DeletedBy",deletedById);

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

        public async Task<List<GetRoleDtos>> GetAllRolesAsync()
        {
            var procedureName = "sp_auth_role_selectAll";
            try
            {
                using (var connection = _dapperConnection.GetConnection())
                {
                    await connection.OpenAsync();
                    var roles = (await connection.QueryAsync<GetRoleDtos>(
                       procedureName,
                       commandType: CommandType.StoredProcedure
                    )).ToList();
                    return roles;
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Error: {ex.Message}",ex);
            }
        }

        public async Task<Roles> GetRoleByIdAsync(int id)
        {
            var procedureName = "sp_auth_role_selectByID";
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

        public async Task<Roles> UpdateRoleAsync(int id,RoleDtos roleDtos,int updatedById)
        {
            var procedureName = "sp_auth_role_update";
            string pageCodeJson = JsonConvert.SerializeObject(roleDtos.PageCode);
            string actionCodeJson = JsonConvert.SerializeObject(roleDtos.ActionCode);
            var parameters = new DynamicParameters(new
            {
                p_ID=id,
                p_Code = roleDtos.Code,
                p_Name = roleDtos.Name,
                p_UpdatedBy = updatedById,
                p_PageCode = pageCodeJson,
                p_ActionCode = actionCodeJson,
            });

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
