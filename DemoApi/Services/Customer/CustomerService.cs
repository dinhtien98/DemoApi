using Dapper;
using DemoApi.Context;
using DemoApi.Models.Dtos.CustomerDtos;
using DemoApi.Models.Dtos.ProductDtos;
using System.Data;

namespace DemoApi.Services.Customer
{
    public class CustomerService: ICustomerService
    {
        private readonly DapperConnection _dapperConnection;
        public CustomerService(DapperConnection dapperConnection)
        {
            _dapperConnection = dapperConnection;
        }

        public async Task<bool> AddCustomerAsync(CustomerDtos customerDtos,int createdById)
        {
            using (var connection = _dapperConnection.GetConnection())
            {
                await connection.OpenAsync();
                var procedureName = "sp_customer_insert";
                try
                {
                    var parameters = new DynamicParameters(new
                    {
                        p_userName = customerDtos.UserName,
                        p_password = customerDtos.Password,
                        p_fullName = customerDtos.FullName,
                        p_email = customerDtos.Email,
                        p_avatar = customerDtos.Avatar,
                        p_firstLogin = customerDtos.FirstLogin,
                        p_inDate = customerDtos.InDate,
                        p_outDate = customerDtos.OutDate,
                        p_failCount = customerDtos.FailCount,
                        p_isLocked = customerDtos.IsLocked,
                        p_total = customerDtos.Total,
                        p_level = customerDtos.Level,
                        p_discount = customerDtos.Discount,
                        p_createdBy = createdById,
                    });

                    await connection.ExecuteAsync(
                        procedureName,
                        parameters,
                        commandType: CommandType.StoredProcedure
                    );

                    return true;
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Failed to execute AddProduct stored procedure: {ex.Message}");
                    return false;
                }
            }
        }

        public async Task<CustomerDtos> DeleteCustomerAsync(int id,CustomerDtos customerDtos,int deletedById)
        {
            var procedureName = "sp_customer_delete";
            var parameters = new DynamicParameters();
            parameters.Add("p_ID",id);
            parameters.Add("p_DeletedBy",deletedById);

            try
            {
                using (var connection = _dapperConnection.GetConnection())
                {
                    await connection.OpenAsync();

                    var result = await connection.QueryFirstOrDefaultAsync<CustomerDtos>(
                        procedureName,
                        parameters,
                        commandType: CommandType.StoredProcedure
                    );

                    return result;
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Error: {ex.Message}",ex);
            }
        }

        public async Task<List<CustomerDtos>> GetAllCustomerAsync()
        {
            var procedureName = "sp_customer_selectAll";
            try
            {
                using (var connection = _dapperConnection.GetConnection())
                {
                    await connection.OpenAsync();
                    var res = (await connection.QueryAsync<CustomerDtos>(
                      procedureName,
                      commandType: CommandType.StoredProcedure
                   )).ToList();

                    return res;
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Error: {ex.Message}",ex);
            }
        }

        public async Task<CustomerDtos> GetCustomerByIdAsync(int id)
        {
            var procedureName = "sp_customer_selectByID";
            var parameters = new DynamicParameters();
            parameters.Add("p_ID",id,DbType.Int32,ParameterDirection.Input);
            try
            {
                using (var connection = _dapperConnection.GetConnection())
                {
                    await connection.OpenAsync();
                    var res = await connection.QueryFirstOrDefaultAsync<CustomerDtos>(procedureName,parameters,commandType: CommandType.StoredProcedure);
                    return res;
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Error: {ex.Message}",ex);
            }
        }

        public async Task<bool> UpdateCustomerAsync(int id,CustomerDtos customerDtos,int updatedById)
        {
            using (var connection = _dapperConnection.GetConnection())
            {
                await connection.OpenAsync();
                var procedureName = "sp_customer_update";
                try
                {
                    var parameters = new DynamicParameters(new
                    {
                        p_password = customerDtos.Password,
                        p_fullName = customerDtos.FullName,
                        p_email = customerDtos.Email,
                        p_avatar = customerDtos.Avatar,
                        p_firstLogin = customerDtos.FirstLogin,
                        p_inDate = customerDtos.InDate,
                        p_outDate = customerDtos.OutDate,
                        p_failCount = customerDtos.FailCount,
                        p_isLocked = customerDtos.IsLocked,
                        p_total = customerDtos.Total,
                        p_level = customerDtos.Level,
                        p_discount = customerDtos.Discount,
                        p_updatedBy = updatedById,
                    });

                    await connection.ExecuteAsync(
                        procedureName,
                        parameters,
                        commandType: CommandType.StoredProcedure
                    );

                    return true;
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Failed to execute AddProduct stored procedure: {ex.Message}");
                    return false;
                }
            }
        }
    }
}
