
using Dapper;
using DemoApi.Context;
using DemoApi.Models.Domain.Pages;
using DemoApi.Models.Dtos.PageDtos;
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
        public async Task<List<GetPageDtos>> GetPermissonUser(int id)
        {
            var procedureName = "sp_auth_page_get_permisson_user";

            try
            {
                var parameters = new DynamicParameters();
                parameters.Add("p_ID",id);
                using (var connection = _dapperConnection.GetConnection())
                {
                    await connection.OpenAsync();
                    var pages = (await connection.QueryAsync<GetPageDtos>(
                       procedureName,
                       parameters,
                       commandType: CommandType.StoredProcedure
                    )).ToList();

                    return pages;
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Error: {ex.Message}",ex);
            }
        }

    }
}
