
using Dapper;
using DemoApi.Context;
using DemoApi.Models.Domain.Pages;
using DemoApi.Models.Dtos.PermissonUserDto;
using System.Data;

namespace DemoApi.Services.AuthService
{
    public class PermissonUserService: IPermissonUserService
    {
        private readonly DapperConnection _dapperConnection;
        public PermissonUserService(DapperConnection dapperConnection)
        {
            _dapperConnection = dapperConnection;
        }
        public async Task<List<PermissonUserDto>> GetPermissonUser(int id)
        {
            var procedureName = "sp_getUserPageRole";
            try
            {
                using (var connection = _dapperConnection.GetConnection())
                {
                    await connection.OpenAsync();

                    var res = await connection.QueryAsync<PermissonUserDto>(procedureName,
                        new
                        {
                            p_ID = id
                        },
                    commandType: CommandType.StoredProcedure);
                    return res.ToList();
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Error: {ex.Message}",ex);
            }
        }
    }
}
