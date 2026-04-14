using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Portfolio.Models.DTOs;
using Portfolio.Services;

namespace Portfolio.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ToolsController(IToolService service) : ControllerBase
    {
        //get all tools
        [HttpGet]
        public async Task<ActionResult<List<ToolDto>>> GetTools() 
            => Ok(await service.GetAllToolsAsync());

        //post new tools
        [Authorize(Roles = "Admin")]
        [HttpPost]
        public async Task<ActionResult<ToolDto>> AddTool(ToolDto tool)
        {
            var result = await service.AddToolAsync(tool);
            return CreatedAtAction(nameof(GetTools), new { id = result.Id }, result);
        }
        //delete tool

        [Authorize(Roles = "Admin")]
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteTool(Guid id)
        {
            var success = await service.DeleteToolAsync(id);
            if (!success) return NotFound();
            return NoContent();
        }
    }
}
