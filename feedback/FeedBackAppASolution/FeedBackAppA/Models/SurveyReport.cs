namespace FeedBackAppA.Models
{
    public class SurveyReport
    {
        public int SurveyId { get; set; }
        public string SurveyTitle { get; set; }
        public int RespondentCount { get; set; }
        // Add other properties as needed

        // Constructor to initialize from a Survey object
        public SurveyReport(Survey survey)
        {
            SurveyId = survey.Id;
            SurveyTitle = survey.Title ?? ""; // Set the title based on your logic
            //RespondentCount = survey.ResponseCount;
            // Set other properties as needed
        }
    }
}