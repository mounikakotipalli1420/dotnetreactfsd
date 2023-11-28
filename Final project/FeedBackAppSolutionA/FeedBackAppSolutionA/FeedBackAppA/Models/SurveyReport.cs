using System.ComponentModel.DataAnnotations.Schema;

namespace FeedBackAppA.Models
{
    public class SurveyReport
    {
        
        public int SurveyId { get; set; }
        public string SurveyTitle { get; set; }
        public int RespondentCount { get; set; }
        public string Username { get; set; }

        // Parameterless constructor
        public SurveyReport()
        {
        }

        // Constructor to initialize from a Survey object
        public SurveyReport(Survey survey)
        {
            if (survey != null && survey.SurveySubmissions != null && survey.SurveySubmissions.Any())
            {
                SurveyId = survey.Id;
                SurveyTitle = survey.Title ?? "";
                RespondentCount = survey.SurveySubmissions.Count;

                // Assuming there is at least one SurveySubmission
                Username = survey.SurveySubmissions.First().Username;
            }
        }
    }
}