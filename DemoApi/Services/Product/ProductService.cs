using Dapper;
using DemoApi.Context;
using DemoApi.Models.Dtos.ProductDtos;
using System.Data;

namespace DemoApi.Services.Product
{
    public class ProductService: IProductService
    {
        private readonly DapperConnection _dapperConnection;
        public ProductService(DapperConnection dapperConnection)
        {
            _dapperConnection = dapperConnection;
        }

        public async Task<bool> AddProductAsync(ProductDtos productDtos,int createdById)
        {
            using (var connection = _dapperConnection.GetConnection())
            {
                await connection.OpenAsync();
                var procedureName = "sp_product_insert";
                try
                {
                    var addProductParameters = new DynamicParameters(new
                    {
                        p_productName = productDtos.ProductName,
                        p_description = productDtos.Description,
                        p_price = productDtos.Price,
                        p_stockQuantity = productDtos.StockQuantity,
                        p_category = productDtos.Category,
                        p_supplier = productDtos.Supplier,
                        p_createdBy = createdById,
                    });

                    await connection.ExecuteAsync(
                        procedureName,
                        addProductParameters,
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

        public async Task<ProductDtos> DeleteProductAsync(int id,ProductDtos productDtos,int deletedById)
        {
            var procedureName = "sp_product_delete";
            var parameters = new DynamicParameters();
            parameters.Add("p_ID",id);
            parameters.Add("p_DeletedBy",deletedById);

            try
            {
                using (var connection = _dapperConnection.GetConnection())
                {
                    await connection.OpenAsync();

                    var result = await connection.QueryFirstOrDefaultAsync<ProductDtos>(
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

        public async Task<List<ProductDtos>> GetAllProductAsync()
        {
            var procedureName = "sp_product_selectAll";
            try
            {
                using (var connection = _dapperConnection.GetConnection())
                {
                    await connection.OpenAsync();
                    var res = (await connection.QueryAsync<ProductDtos>(
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

        public async Task<ProductDtos> GetProductByIdAsync(int id)
        {
            var procedureName = "sp_product_selectByID";
            var parameters = new DynamicParameters();
            parameters.Add("p_ID",id,DbType.Int32,ParameterDirection.Input);
            try
            {
                using (var connection = _dapperConnection.GetConnection())
                {
                    await connection.OpenAsync();
                    var res = await connection.QueryFirstOrDefaultAsync<ProductDtos>(procedureName,parameters,commandType: CommandType.StoredProcedure);
                    return res;
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Error: {ex.Message}",ex);
            }
        }

        public async Task<bool> UpdateProductAsync(int id,ProductDtos productDtos,int updatedById)
        {
            using (var connection = _dapperConnection.GetConnection())
            {
                await connection.OpenAsync();
                var procedureName = "sp_product_update";
                try
                {
                    var addProductParameters = new DynamicParameters(new
                    {
                        p_id = id,
                        p_productName = productDtos.ProductName,
                        p_description = productDtos.Description,
                        p_price = productDtos.Price,
                        p_stockQuantity = productDtos.StockQuantity,
                        p_category = productDtos.Category,
                        p_supplier = productDtos.Supplier,
                        p_updatedBy = updatedById,
                    });

                    await connection.ExecuteAsync(
                        procedureName,
                        addProductParameters,
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
