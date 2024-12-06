using Dapper;
using DemoApi.Context;
using DemoApi.Models.Domain.Pages;
using DemoApi.Models.Domain.Users;
using DemoApi.Models.Dtos.PageDtos;
using DemoApi.Models.Dtos.UserDtos;
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
        public async Task<Pages> AddPageAsync(PageDtos pageDtos)
        {
            var procedureName = "AddPage";
            var parameters = new DynamicParameters();
            parameters.Add("p_Code",pageDtos.Code);
            parameters.Add("p_Name",pageDtos.Name);
            parameters.Add("p_ParentCode",pageDtos.ParentCode);
            parameters.Add("p_Level",pageDtos.Level);
            parameters.Add("p_Url",pageDtos.Url);
            parameters.Add("p_Hidden",pageDtos.Hidden);
            parameters.Add("p_Icon",pageDtos.Icon);
            parameters.Add("p_Sort",pageDtos.Sort);
            parameters.Add("p_CreatedBy",pageDtos.CreatedBy);

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
                throw new Exception($"Error occurred while adding page: {ex.Message}",ex);
            }
        }

        public async Task<Pages> DeletePageAsync(int id,PageDtos pageDtos)
        {
            var procedureName = "DeletePage";
            var parameters = new DynamicParameters();
            parameters.Add("p_ID",id);
            parameters.Add("p_DeletedBy",pageDtos.DeletedBy);

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

        public async Task<List<Pages>> GetAllPagesAsync()
        {
            var procedureName = "GetAllPages";
            try
            {
                using (var connection = _dapperConnection.GetConnection())
                {
                    await connection.OpenAsync();
                    var page = await connection.QueryAsync<Pages>(procedureName);
                    return page.ToList();
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Error: {ex.Message}",ex);
            }
        }

        public async Task<Pages> GetPageByIdAsync(int id)
        {
            var procedureName = "GetPage";
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

        public async Task<Pages> UpdatePageAsync(int id,PageDtos pageDtos)
        {
            var procedureName = "UpdatePage";
            var parameters = new DynamicParameters();
            parameters.Add("p_ID",id);
            parameters.Add("p_Code",pageDtos.Code);
            parameters.Add("p_Name",pageDtos.Name);
            parameters.Add("p_ParentCode",pageDtos.ParentCode);
            parameters.Add("p_Level",pageDtos.Level);
            parameters.Add("p_Url",pageDtos.Url);
            parameters.Add("p_Hidden",pageDtos.Hidden);
            parameters.Add("p_Icon",pageDtos.Icon);
            parameters.Add("p_Sort",pageDtos.Sort);
            parameters.Add("p_UpdatedBy",pageDtos.UpdatedBy);

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
                throw new Exception($"Error occurred while adding page: {ex.Message}",ex);
            }
        }
    }
}
