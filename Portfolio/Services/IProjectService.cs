using Portfolio.Models.DTOs;
using Portfolio.Models.Entities;

namespace Portfolio.Services
{
    public interface IProjectService
    {
        Task<List<ProjectDto>> GetAllProjectsAsync();
        Task<ProjectDto?> GetProjectByIdAsync(Guid id);
        Task<ProjectDto> AddProjectAsync(CreateProjectDto project);
        Task<bool> UpdateProjectAsync(Guid id, UpdateProjectDto project);
        Task<bool> DeleteProjectAsync(Guid id);
    }
}
