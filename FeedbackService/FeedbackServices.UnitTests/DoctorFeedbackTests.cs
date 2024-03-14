using FeedbackService;
using FeedbackService.Controllers;
using FeedbackService.Model;
using FeedbackService.Model.DTO;
using FeedbackService.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Testing;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Text;

namespace FeedbackServices.UnitTests
{
    [TestFixture]
    public class DoctorFeedbackTests
    {
        HttpClient SUT;
        WebApplicationFactory<Startup> server;
        [OneTimeSetUp]
        public void SetUp()
        {
            server = new WebApplicationFactory<Startup>();
            SUT = server.CreateClient();
        }
        [OneTimeTearDown]
        public void Clean()
        {
            SUT.Dispose();
        }

        [Test]
        public void GetDoctorTest()
        {
            //Act
            var response = SUT.GetAsync("api/DoctorFeedback").Result;

            //Assert
            Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);
        }
        [Test]
        public void Return_Ok_While_Calling_By_Id()
        {
            //Act
            int id = 1;
            var response = SUT.GetAsync("api/DoctorFeedback/" + id).Result;

            //Assert
            Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);
        }
    }
}
