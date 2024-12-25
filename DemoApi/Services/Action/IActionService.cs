using DemoApi.Models.Domain.Action;
using DemoApi.Models.Dtos.ActionDtos;

namespace DemoApi.Services.Action
{
    public interface IActionService
    {
        public Task<List<Actions>> GetAllActionsAsync();
        public Task<Actions> GetActionByIdAsync(int id);
        public Task<Actions> AddActionAsync(ActionDtos actionDtos,int createdById);
        public Task<Actions> UpdateActionAsync(int id,ActionDtos actionDtos,int updatedById);
        public Task<Actions> DeleteActionAsync(int id,ActionDtos actionDtos,int deletedById);
    }
}
