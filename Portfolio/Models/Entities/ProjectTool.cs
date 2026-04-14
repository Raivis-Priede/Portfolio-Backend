namespace Portfolio.Models.Entities
{
    public class ProjectTool
    {
        public Guid ProjectId { get; set; }
        public Project Project { get; set; } = null!;

        public Guid ToolId { get; set; }
        public Tool Tool { get; set; } = null!;
    }
}