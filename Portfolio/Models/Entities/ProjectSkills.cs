namespace Portfolio.Models.Entities
{
    public class ProjectSkills
    {
        public Guid ProjectId { get; set; }
        public Project Project { get; set; } = null!;

        public Guid SkillId { get; set; }
        public Skill Skill { get; set; } = null!;
    }
}