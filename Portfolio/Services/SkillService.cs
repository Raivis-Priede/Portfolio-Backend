using Portfolio.Models.DTOs;

namespace Portfolio.Services
{
    public class SkillService : ISkillService
    {
        public Task<SkillDto> AddSkillAsync(SkillDto skill)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteSkillAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        Task<List<SkillDto>> ISkillService.GetAllSkillsAsync()
        {
            throw new NotImplementedException();
        }
    }
}
