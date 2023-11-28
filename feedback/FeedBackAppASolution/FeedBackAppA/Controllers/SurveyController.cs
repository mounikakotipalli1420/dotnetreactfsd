using FeedBackAppA.Interfaces;
using FeedBackAppA.Models;
using FeedBackAppA.Repositories;
using FeedBackAppA.Services;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Text.Json;

namespace FeedBackAppA.Controllers
{
    [EnableCors("reactApp")]
    [Route("api/[controller]")]
    [ApiController]
    public class SurveyController : ControllerBase
    {
        private readonly ISurveyService _surveyService;
        private readonly ILogger<SurveyController> _logger;

        // private readonly ISurveyRepository _surveyRepository;

        //  private readonly EmailSender _emailSender;

        public SurveyController(ISurveyService surveyService, ILogger<SurveyController> logger)
        {
            _surveyService = surveyService;
            _logger = logger;
            /*_surveyRepository = surveyRepository;
            _emailSender = emailSender;*/


        }

        [HttpGet("{id}")]
        public IActionResult GetSurvey(int id)
        {
            var survey = _surveyService.GetSurveyById(id);
            if (survey == null)
                return NotFound();

            /*string jsonString = JsonSerializer.Serialize(survey);

            _emailSender.SendEmail("gandimary8@gmail.com", "FeedBackApp", jsonString);*/

            return Ok(survey);
        }

        [HttpPost]
        public IActionResult CreateSurvey([FromBody] Survey survey)
        {
            _surveyService.CreateSurvey(survey);
            return CreatedAtAction(nameof(GetSurvey), new { id = survey.Id }, survey);
        }


        /*[HttpGet("{surveyId}")]
        public IActionResult GetSurveyById(int surveyId)
        {
            var survey = _surveyRepository.GetById(surveyId);


            *//*Survey
            .Include(s => s.Questions)
            .ThenInclude(q => q.Answers)
            .FirstOrDefault(s => s.SurveyId == surveyId);//

            if (survey == null)
            {
                return NotFound($"Survey with ID {surveyId} not found.");
            }

            string jsonString = JsonSerializer.Serialize(survey);

            _emailSender.SendEmail("gandimary8@gmail.com", "FeedBackApp", jsonString);



            return Ok(survey);
        }*/
        [HttpGet]
        public IActionResult GetAllSurveys()
        {
            var surveys = _surveyService.GetAllSurveys();
            return Ok(surveys);
        }
        [HttpGet("{id}/report")]
        public IActionResult GetSurveyReport(int id)
        {
            var survey = _surveyService.GetSurveyById(id);

            if (survey == null)
            {
                return NotFound("Survey not found");
            }

            var report = new SurveyReport(survey); // Pass the survey object to the constructor

            return Ok(report);
        }
    }
}