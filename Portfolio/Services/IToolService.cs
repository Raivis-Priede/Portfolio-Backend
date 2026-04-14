using Portfolio.Models.DTOs;
using Portfolio.Models.Entities;

namespace Portfolio.Services
{
    public interface IToolService
    {
        Task<List<ToolDto>> GetAllToolsAsync();
        Task<ToolDto> AddToolAsync(ToolDto tool);
        Task<bool> DeleteToolAsync(Guid id);
    }
}
