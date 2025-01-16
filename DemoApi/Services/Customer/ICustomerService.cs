using DemoApi.Models.Dtos.CustomerDtos;

namespace DemoApi.Services.Customer
{
    public interface ICustomerService
    {
        public Task<List<CustomerDtos>> GetAllCustomerAsync();
        public Task<CustomerDtos> GetCustomerByIdAsync(int id);
        public Task<bool> AddCustomerAsync(CustomerDtos customerDtos,int createdById);
        public Task<bool> UpdateCustomerAsync(int id,CustomerDtos customerDtos,int updatedById);
        public Task<CustomerDtos> DeleteCustomerAsync(int id,CustomerDtos customerDtos,int deletedById);
    }
}
