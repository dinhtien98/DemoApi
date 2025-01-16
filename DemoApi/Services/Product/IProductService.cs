using DemoApi.Models.Dtos.ProductDtos;

namespace DemoApi.Services.Product
{
    public interface IProductService
    {
        public Task<List<ProductDtos>> GetAllProductAsync();
        public Task<ProductDtos> GetProductByIdAsync(int id);
        public Task<bool> AddProductAsync(ProductDtos productDtos,int createdById);
        public Task<bool> UpdateProductAsync(int id,ProductDtos productDtos,int updatedById);
        public Task<ProductDtos> DeleteProductAsync(int id,ProductDtos productDtos,int deletedById);
    }
}
