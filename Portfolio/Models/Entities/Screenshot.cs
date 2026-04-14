namespace Portfolio.Models.Entities
{
    public class Screenshot
    {
        public Guid id { get; set; }
        public string imageUrl { get; set; } = null!;
        public Guid ProjectId { get; set; }
        public Project Project { get; set; } = null!;
    }
}