using FeedBackAppA.Models;
using FeedBackAppA.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Reflection.Emit;

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

    }
}