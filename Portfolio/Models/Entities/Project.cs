namespace Portfolio.Models.Entities
{
    public class Project
    {
        public Guid id { get; set; }

        public string Title { get; set; } = null!;
        public string SubTitle { get; set; } = null!;
        public string Description { get; set; } = null!;
        public string FullDescription { get; set; } = null!;

        public string? ImageUrl { get; set; }
        public string? GifUrl { get; set; }

        public int TimeSpentHours { get; set; }
        public string Progress { get; set; } = null!;

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        public ICollection<Screenshot> Screenshots { get; set; } = new List<Screenshot>();
        public ICollection<ProjectSkills> ProjectSkills { get; set; } = new List<ProjectSkills>();
        public ICollection<ProjectTool> ProjectTools { get; set; } = new List<ProjectTool>();
    }
}
