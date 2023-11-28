using FeedBackAppA.Contexts;
using FeedBackAppA.Interfaces;
using FeedBackAppA.Models;
using Microsoft.EntityFrameworkCore;

namespace FeedBackAppA.Repositories
{
    public class SurveyRepository : ISurveyRepository
    {
        private readonly FeedBackContext _dbContext;

        object ISurveyRepository.Survey => throw new NotImplementedException();

        public SurveyRepository(FeedBackContext dbContext)
        {
            _dbContext = dbContext;
        }
        public IEnumerable<Survey> GetAll()
        {
            return _dbContext.Surveys.ToList();
        }


        public Survey GetById(int id)
        {
            return _dbContext.Surveys.Include(s => s.Questions).ThenInclude(q => q.Answers).FirstOrDefault(s => s.Id == id);
        }

        public void Add(Survey survey)
        {
            _dbContext.Surveys.Add(survey);
            _dbContext.SaveChanges();
        }
        public List<SurveyReport> GetSurveyReports(int surveyId)
        {
            var survey = _dbContext.Surveys
                .Where(s => s.Id == surveyId)
                .Include(s => s.Questions) // Include questions if needed
                .FirstOrDefault();

            if (survey == null)
            {
                // Handle survey not found
                return new List<SurveyReport>();
            }

            var reports = new List<SurveyReport>
            {
                new SurveyReport(survey)
            };

            return reports;
        }


    }
}