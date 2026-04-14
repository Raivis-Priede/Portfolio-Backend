using Portfolio.Models.DTOs;
using Portfolio.Models.Entities;

namespace Portfolio.Services
{
    public class ToolService : IToolService
    {
        public Task<ToolDto> AddToolAsync(ToolDto tool)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteToolAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        Task<List<ToolDto>> IToolService.GetAllToolsAsync()
        {
            throw new NotImplementedException();
        }
    }
}
