using Microsoft.EntityFrameworkCore;
using Portfolio.Data;
using Portfolio.Models.DTOs;
using Portfolio.Models.Entities;

namespace Portfolio.Services
{
    public class ProjectService(AppDpContext context) : IProjectService
    {
        public async Task<ProjectDto> AddProjectAsync(CreateProjectDto project)
        {
            var newProject = new Project
            {
                Title = project.Title,
                SubTitle = project.SubTitle,
                Description = project.Description,
                FullDescription = project.FullDescription,
                ImageUrl = project.ImageUrl,
                GifUrl = project.GifUrl,
                Progress = project.Progress,
                TimeSpentHours = project.TimeSpentHours
            };

            context.Projects.Add(newProject);
            await context.SaveChangesAsync();

            return new ProjectDto
            {
                Id = newProject.id,
                Title = newProject.Title,
                SubTitle = newProject.SubTitle,
                Description = newProject.Description,
                FullDescription = newProject.FullDescription,
                ImageUrl = newProject.ImageUrl,
                GifUrl = newProject.GifUrl,
                Progress = newProject.Progress,
                TimeSpentHours = newProject.TimeSpentHours,
                Screenshots = new List<string>(),
                Skills = new List<string>(),
                Tools = new List<string>()
            };
        }

        public async Task<bool> DeleteProjectAsync(Guid id)
        {
            var projectToDelete = await context.Projects.FindAsync(id);
            if (projectToDelete == null) return false;

            context.Projects.Remove(projectToDelete);
            await context.SaveChangesAsync();

            return true;
        }

        public async Task<ProjectDto?> GetProjectByIdAsync(Guid id)
        {
            var result = await context.Projects
                .Where(p => p.id == id)
                .Select(p => new ProjectDto
                {
                    Title = p.Title,
                    SubTitle = p.SubTitle,
                    Description = p.Description,
                    FullDescription = p.FullDescription,
                    ImageUrl = p.ImageUrl,
                    GifUrl = p.GifUrl,
                    Progress = p.Progress,
                    TimeSpentHours = p.TimeSpentHours,
                    Screenshots = p.Screenshots.Select(s => s.imageUrl).ToList(),
                    Skills = p.ProjectSkills.Select(ps => ps.Skill.Name).ToList(),
                    Tools = p.ProjectTools.Select(pt => pt.Tool.Name).ToList()
                })
                .FirstOrDefaultAsync();
            return result;
        }

        public async Task<bool> UpdateProjectAsync(Guid id, UpdateProjectDto project)
        {
            var existingProject = await context.Projects.FindAsync(id);
            if(existingProject == null) return false;
            existingProject.Title = project.Title;
            existingProject.SubTitle = project.SubTitle;
            existingProject.Description = project.Description;
            existingProject.FullDescription = project.FullDescription;
            existingProject.ImageUrl = project.ImageUrl;
            existingProject.GifUrl = project.GifUrl;
            existingProject.Progress = project.Progress;
            existingProject.TimeSpentHours = project.TimeSpentHours;

            await context.SaveChangesAsync();
            return true;
        }

        async Task<List<ProjectDto>> IProjectService.GetAllProjectsAsync()
            => await context.Projects
                .Select(p => new ProjectDto
                {
                    Title = p.Title,
                    SubTitle = p.SubTitle,
                    Description = p.Description,
                    FullDescription = p.FullDescription,
                    ImageUrl = p.ImageUrl,
                    GifUrl = p.GifUrl,
                    Progress = p.Progress,
                    TimeSpentHours = p.TimeSpentHours,
                    Screenshots = p.Screenshots.Select(s => s.imageUrl).ToList(),
                    Skills = p.ProjectSkills.Select(ps => ps.Skill.Name).ToList(),
                    Tools = p.ProjectTools.Select(pt => pt.Tool.Name).ToList()
                })
                .ToListAsync();
    }
}
