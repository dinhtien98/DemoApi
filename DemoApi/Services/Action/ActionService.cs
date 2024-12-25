using Dapper;
using DemoApi.Context;
using DemoApi.Models.Domain.Action;
using DemoApi.Models.Domain.Role;
using DemoApi.Models.Dtos.ActionDtos;
using DemoApi.Models.Dtos.RoleDtos;
using Newtonsoft.Json;
using System.Data;

namespace DemoApi.Services.Action
{
    public class ActionService : IActionService
    {
        private readonly DapperConnection _dapperConnection;
        public ActionService(DapperConnection dapperConnection)
        {
            _dapperConnection = dapperConnection;
        }

        public async Task<Actions> AddActionAsync(ActionDtos actionDtos,int createdById)
        {
            var procedureName = "sp_auth_action_insert";
            var parameters = new DynamicParameters(new
            {
                p_ActionCode = actionDtos.ActionCode,
                p_Name = actionDtos.Name,
                p_CreatedBy = createdById,
            });

            try
            {
                using (var connection = _dapperConnection.GetConnection())
                {
                    await connection.OpenAsync();

                    var result = await connection.QueryFirstOrDefaultAsync<Actions>(
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

        public async Task<Actions> DeleteActionAsync(int id,ActionDtos actionDtos,int deletedById)
        {
            var procedureName = "sp_auth_action_delete";
            var parameters = new DynamicParameters();
            parameters.Add("p_ID",id);
            parameters.Add("p_DeletedBy",deletedById);

            try
            {
                using (var connection = _dapperConnection.GetConnection())
                {
                    await connection.OpenAsync();

                    var result = await connection.QueryFirstOrDefaultAsync<Actions>(
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

        public async Task<Actions> GetActionByIdAsync(int id)
        {
            var procedureName = "sp_auth_action_selectByID";
            var parameters = new DynamicParameters();
            parameters.Add("p_ID",id,DbType.Int32,ParameterDirection.Input);
            try
            {
                using (var connection = _dapperConnection.GetConnection())
                {
                    await connection.OpenAsync();
                    var res = await connection.QueryFirstOrDefaultAsync<Actions>(procedureName,parameters,commandType: CommandType.StoredProcedure);
                    return res;
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Error: {ex.Message}",ex);
            }
        }

        public async Task<List<Actions>> GetAllActionsAsync()
        {
            var procedureName = "sp_auth_action_selectAll";
            try
            {
                using (var connection = _dapperConnection.GetConnection())
                {
                    await connection.OpenAsync();
                    var res = await connection.QueryAsync<Actions>(procedureName);
                    return res.ToList();
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Error: {ex.Message}",ex);
            }
        }

        public async Task<Actions> UpdateActionAsync(int id,ActionDtos actionDtos,int updatedById)
        {
            var procedureName = "sp_auth_action_update";
            var parameters = new DynamicParameters(new
            {
                p_ID = id,
                p_ActionCode = actionDtos.ActionCode,
                p_Name = actionDtos.Name,
                p_UpdatedBy = updatedById,
            });

            try
            {
                using (var connection = _dapperConnection.GetConnection())
                {
                    await connection.OpenAsync();

                    var result = await connection.QueryFirstOrDefaultAsync<Actions>(
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
