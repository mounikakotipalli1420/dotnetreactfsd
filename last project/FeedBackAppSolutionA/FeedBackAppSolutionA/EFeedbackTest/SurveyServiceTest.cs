using Microsoft.EntityFrameworkCore;

using NUnit.Framework;
using FeedBackAppA.Contexts;
using FeedBackAppA.Interfaces;
using FeedBackAppA.Models;
using FeedBackAppA.Repositories;
using FeedBackAppA.Services;
using System.Collections.Generic;

namespace FeedBackAppTest
{
    public class SurveyServiceTest
    {
        private ISurveyRepository surveyRepository;

        [SetUp]
        public void Setup()
        {
            var dbOptions = new DbContextOptionsBuilder<FeedBackContext>()
                                .UseInMemoryDatabase("dbTestSurvey")
                                .Options;
            FeedBackContext context = new FeedBackContext(dbOptions);
            surveyRepository = new SurveyRepository(context);
        }

        [Test]
        public void CreateSurvey_ValidSurvey_AddedToRepository()
        {
            // Arrange
            var surveyService = new SurveyService(surveyRepository);

            var sampleSurvey = new Survey
            {
                Title = "Customer Satisfaction Survey",
                Questions = new List<Question>
                {
                    new Question
                    {
                        Text = "How satisfied are you with our product?",
                        
                        Answers = new List<Answer>
                        {
                            new Answer { Text = "Very Satisfied" },
                            new Answer { Text = "Satisfied" },
                            new Answer { Text = "Neutral" },
                            new Answer { Text = "Dissatisfied" },
                            new Answer { Text = "Very Dissatisfied" }
                        }
                    },
                    new Question
                    {
                        Text = "What features do you like the most?",
                        
                        Answers = new List<Answer>
                        {
                            new Answer { Text = "User Interface" },
                            new Answer { Text = "Performance" },
                            new Answer { Text = "Functionality" },
                            new Answer { Text = "Other" }
                        }
                    },
                    new Question
                    {
                        Text = "Any additional comments?",
                        
                    }
                }
            };

            // Act
            surveyService.CreateSurvey(sampleSurvey);

            // Assert
            var retrievedSurvey = surveyService.GetSurveyById(sampleSurvey.Id);
            Assert.IsNotNull(retrievedSurvey);
            Assert.AreEqual(sampleSurvey.Id, retrievedSurvey.Id);
        }

        // Add other test cases as needed
    }
}
