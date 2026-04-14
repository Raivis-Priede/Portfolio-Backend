using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Portfolio.Models.DTOs;
using Portfolio.Services;

namespace Portfolio.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SkillsController(ISkillService service) : ControllerBase
    {
        //get all skills

        [HttpGet]
        public async Task<ActionResult<List<SkillDto>>> GetSkills()
            => Ok(await service.GetAllSkillsAsync());

        //post new skills
        [Authorize(Roles = "Admin")]
        [HttpPost]

        public async Task<ActionResult<SkillDto>> AddSkill(SkillDto skill)
        {
            var result = await service.AddSkillAsync(skill);
            return CreatedAtAction(nameof(GetSkills), new { id = result.Id }, result);
        }

        //delete skills
        [Authorize(Roles = "Admin")]
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteSkill(Guid id)
        {
            var success = await service.DeleteSkillAsync(id);
            if (!success) return NotFound();
            return NoContent();
        }

    }
}
