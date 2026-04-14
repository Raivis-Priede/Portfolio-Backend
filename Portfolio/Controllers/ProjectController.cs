using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Portfolio.Models.DTOs;
using Portfolio.Models.Entities;
using Portfolio.Services;

namespace Portfolio.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProjectController(IProjectService service) : ControllerBase
    {
        //get all projects
        [HttpGet]
        public async Task<ActionResult<List<ProjectDto>>> GetProjects()
            => Ok(await service.GetAllProjectsAsync());


        //get project by id for search for example
        [HttpGet("{id:guid}")]
        public async Task<ActionResult<ProjectDto>> GetProjectById(Guid id)
        {
            var result = await service.GetProjectByIdAsync(id);
            if (result is null) return NotFound();
            return Ok(result);
        }

        [Authorize(Roles = "Admin")]
        [HttpPost]
        public async Task<ActionResult<CreateProjectDto>> AddProject(CreateProjectDto project)
        {
            var result = await service.AddProjectAsync(project);
            return CreatedAtAction(nameof(GetProjectById), new { id = result.Id }, result);
        }

        //put (update) a project (admin)

        [Authorize(Roles = "Admin")]
        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateProject(Guid id, UpdateProjectDto project)
        {
            var success = await service.UpdateProjectAsync(id, project);
            if (!success) return NotFound();
            return NoContent();
        }
        //delete a project (admin)

        [Authorize(Roles = "Admin")]
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteProject(Guid id)
        {
            var success = await service.DeleteProjectAsync(id);
            if (!success) return NotFound();
            return NoContent();
        }
    }
}
