using FeedBackAppA.Models;
using Microsoft.EntityFrameworkCore;

namespace FeedBackAppA.Contexts
{
    public class FeedBackContext : DbContext
    {
        public FeedBackContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Survey> Surveys { get; set; }
        public DbSet<Question> Questions { get; set; }
        public DbSet<Answer> Answers { get; set; }
        public DbSet<SurveySubmission> SurveySubmissions { get; set; }
        public DbSet<QuestionResponse> QuestionResponses { get; set; }
        public DbSet<SurveyReport> SurveyReports { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<SurveySubmission>()
     .HasOne(ss => ss.User)
     .WithMany(u => u.SurveySubmissions)
     .HasForeignKey(ss => ss.Username);
            // Other configurations...
            modelBuilder.Entity<SurveyReport>().HasNoKey();
            // Add more configurations as needed
        }
    }
}