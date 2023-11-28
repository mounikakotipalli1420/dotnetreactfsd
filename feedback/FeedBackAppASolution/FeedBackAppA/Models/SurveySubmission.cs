using FeedBackAppA.Migrations;

namespace FeedBackAppA.Models
{
    public class SurveySubmission
    {
        public int SurveySubmissionId { get; set; }
        public string Username { get; set; }

        //  public User User { get; set; }
        public int SurveyId { get; set; }
        public Survey Survey { get; set; }
        public ICollection<QuestionResponse> QuestionResponses { get; set; }

        // ... existing properties ...

        // Add a method to convert SurveySubmission to SurveyReport
        public SurveyReport ToSurveyReport()
        {
            if (Survey == null)
            {
                // Handle the case where Survey is null
                // You can throw an exception or handle it based on your requirements
                throw new InvalidOperationException("Survey cannot be null");
            }

            return new SurveyReport(Survey)
            {
                RespondentCount = QuestionResponses?.Count ?? 0,
                // Set other properties as needed
            };
        }
    }
}