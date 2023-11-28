using FeedBackAppA.Contexts;
using FeedBackAppA.Models;
using Microsoft.AspNetCore.Mvc;

namespace FeedBackAppA.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SurveySubmissionController : ControllerBase
    {


        private readonly FeedBackContext _context;

        public SurveySubmissionController(FeedBackContext context)
        {
            _context = context;
        }

        [HttpPost]
        public IActionResult SubmitSurvey([FromBody] SurveySubmission submission)
        {


            _context.SurveySubmissions.Add(submission);
            _context.SaveChanges();
            return Ok(submission);
        }
    }
}