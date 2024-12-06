using DemoApi.Models.Domain.Pages;
using DemoApi.Models.Dtos.PageDtos;

namespace DemoApi.Services.Page
{
    public interface IPageService
    {
        public Task<List<Pages>> GetAllPagesAsync();
        public Task<Pages> GetPageByIdAsync(int id);
        public Task<Pages> AddPageAsync(PageDtos pageDtos);
        public Task<Pages> UpdatePageAsync(int id,PageDtos pageDtos);
        public Task<Pages> DeletePageAsync(int id, PageDtos pageDtos);
    }
}
