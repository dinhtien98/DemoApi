using Dapper;
using DemoApi.Context;
using DemoApi.Models.Domain.Pages;
using DemoApi.Models.Domain.Users;
using DemoApi.Models.Dtos.PageDtos;
using DemoApi.Models.Dtos.UserDtos;
using Newtonsoft.Json;
using System.Data;

namespace DemoApi.Services.Page
{
    public class PageService: IPageService
    {
        private readonly DapperConnection _dapperConnection;
        public PageService(DapperConnection dapperConnection)
        {
            _dapperConnection = dapperConnection;
        }
        public async Task<bool> AddPageAsync(PageDtos pageDtos,int createdById)
        {
            using (var connection = _dapperConnection.GetConnection())
            {
                await connection.OpenAsync();
                var procedureName = "sp_auth_page_insert";
                try
                {
                    string actionCodeJson = JsonConvert.SerializeObject(pageDtos.ActionCode);
                    var addUserParameters = new DynamicParameters(new
                    {
                        p_Code = pageDtos.Code,
                        p_Name = pageDtos.Name,
                        p_ParentCode = pageDtos.ParentCode,
                        p_Level = pageDtos.Level,
                        p_Url = pageDtos.Url,
                        p_Hidden = pageDtos.Hidden,
                        p_Icon = pageDtos.Icon,
                        p_Sort = pageDtos.Sort,
                        p_CreatedBy = createdById,
                        p_ActionCode = actionCodeJson,
                    });

                    await connection.ExecuteAsync(
                        procedureName,
                        addUserParameters,
                        commandType: CommandType.StoredProcedure
                    );

                    return true;
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Failed to execute AddPage stored procedure: {ex.Message}");
                    return false;
                }
            }
        }

        public async Task<Pages> DeletePageAsync(int id,PageDtos pageDtos,int deletedById)
        {
            var procedureName = "sp_auth_page_delete";
            var parameters = new DynamicParameters();
            parameters.Add("p_ID",id);
            parameters.Add("p_DeletedBy",deletedById);

            try
            {
                using (var connection = _dapperConnection.GetConnection())
                {
                    await connection.OpenAsync();

                    var result = await connection.QueryFirstOrDefaultAsync<Pages>(
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

        public async Task<List<GetPageDtos>> GetAllPagesAsync()
        {
            var procedureName = "sp_auth_page_selectAll";
            
            try
            {
                using (var connection = _dapperConnection.GetConnection())
                {
                    await connection.OpenAsync();
                    var pages = (await connection.QueryAsync<GetPageDtos>(
                       procedureName,
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

        public async Task<Pages> GetPageByIdAsync(int id)
        {
            var procedureName = "sp_auth_page_selectByID";
            var parameters = new DynamicParameters();
            parameters.Add("p_ID",id,DbType.Int32,ParameterDirection.Input);
            try
            {
                using (var connection = _dapperConnection.GetConnection())
                {
                    await connection.OpenAsync();
                    var page = await connection.QueryFirstOrDefaultAsync<Pages>(procedureName,parameters,commandType: CommandType.StoredProcedure);
                    return page;
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Error: {ex.Message}",ex);
            }
        }

        public async Task<bool> UpdatePageAsync(int id,PageDtos pageDtos,int updatedById)
        {

            using (var connection = _dapperConnection.GetConnection())
            {
                await connection.OpenAsync();
                var procedureName = "sp_auth_page_update";
                try
                {
                    string actionCodeJson = JsonConvert.SerializeObject(pageDtos.ActionCode);
                    var addUserParameters = new DynamicParameters(new
                    {
                        p_id = id,
                        p_Code = pageDtos.Code,
                        p_Name = pageDtos.Name,
                        p_ParentCode = pageDtos.ParentCode,
                        p_Level = pageDtos.Level,
                        p_Url = pageDtos.Url,
                        p_Hidden = pageDtos.Hidden,
                        p_Icon = pageDtos.Icon,
                        p_Sort = pageDtos.Sort,
                        p_UPDATEDBY = updatedById,
                        p_ActionCode = actionCodeJson,
                    });

                    await connection.ExecuteAsync(
                        procedureName,
                        addUserParameters,
                        commandType: CommandType.StoredProcedure
                    );

                    return true;
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Failed to execute AddPage stored procedure: {ex.Message}");
                    return false;
                }
            }
        }
    }
}
