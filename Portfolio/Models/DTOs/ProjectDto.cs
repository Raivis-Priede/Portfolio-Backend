namespace Portfolio.Models.DTOs
{
    public class ProjectDto
    {
        public Guid Id { get; set; }
        public string Title { get; set; } = null!;
        public string SubTitle { get; set; } = null!;
        public string Description { get; set; } = null!;
        public string FullDescription { get; set; } = null!;

        public string? ImageUrl { get; set; }
        public string? GifUrl { get; set; }

        public int TimeSpentHours { get; set; }
        public string Progress { get; set; } = null!;


        public List<string> Screenshots { get; set; } = new List<string>();
        public List<string> Skills { get; set; } = new List<string>();
        public List<string> Tools { get; set; } = new List<string>();

    }
}
