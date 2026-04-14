using Portfolio.Models.DTOs;
using Portfolio.Models.Entities;

namespace Portfolio.Services
{
    public interface ISkillService
    {
        Task<List<SkillDto>> GetAllSkillsAsync();
        Task<SkillDto> AddSkillAsync(SkillDto skill); 
        Task<bool> DeleteSkillAsync(Guid id);
    }
}
