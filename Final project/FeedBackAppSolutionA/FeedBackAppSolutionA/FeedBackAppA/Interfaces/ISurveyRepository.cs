using FeedBackAppA.Models;

namespace FeedBackAppA.Interfaces
{
    public interface ISurveyRepository
    {
        object Survey { get; }
        IEnumerable<Survey> GetAll();

        Survey GetById(int id);
        void Add(Survey survey);
       
    }
}
