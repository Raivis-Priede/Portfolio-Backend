using Microsoft.EntityFrameworkCore;
using Portfolio.Models.Entities;

namespace Portfolio.Data
{
    public class AppDpContext(DbContextOptions<AppDpContext> options) : DbContext(options)
    {
        public DbSet<Project> Projects => Set<Project>();
        public DbSet<Skill> Skills => Set<Skill>();
        public DbSet<Tool> Tools => Set<Tool>();
        public DbSet<ProjectSkills> ProjectSkills => Set<ProjectSkills>();
        public DbSet<ProjectTool> ProjectTools => Set<ProjectTool>();
        public DbSet<User> Users {  get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // project - skills many to many relationship configuration

            modelBuilder.Entity<ProjectSkills>().HasKey(ps => new {ps.ProjectId, ps.SkillId });

            modelBuilder.Entity<ProjectSkills>().HasOne(ps => ps.Project).WithMany(p => p.ProjectSkills).HasForeignKey(ps => ps.ProjectId);

            modelBuilder.Entity<ProjectSkills>().HasOne(ps => ps.Skill).WithMany().HasForeignKey(ps => ps.SkillId);

            //project - tool many to many relationship configuration

            modelBuilder.Entity<ProjectTool>().HasKey(pt => new { pt.ProjectId, pt.ToolId });

            modelBuilder.Entity<ProjectTool>().HasOne(pt => pt.Project).WithMany(p => p.ProjectTools).HasForeignKey(pt => pt.ProjectId);

            modelBuilder.Entity<ProjectTool>().HasOne(pt => pt.Tool).WithMany().HasForeignKey(pt => pt.ToolId);
        }

    }
}
