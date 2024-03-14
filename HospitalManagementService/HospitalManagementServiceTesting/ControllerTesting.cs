using HospitalManagementService;
using Microsoft.AspNetCore.Mvc.Testing;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Text;

namespace HospitalManagementServiceTesting
{
    [TestFixture]
    public class ControllerTesting
    {
        HttpClient SUT;
        WebApplicationFactory<Startup> server;

        [OneTimeSetUp]
        public void Init()
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
        public void Return_The_List_Of_TreatmentDetails()
        {
            //Act
            var response = SUT.GetAsync("api/Facility").Result;

            //Assert
            Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);
        }

        [Test]
        public void Return_Ok_While_Calling_By_Id()
        {
            //Act
            int id = 1;
            var response = SUT.GetAsync("api/Facility/" + id).Result;

            //Assert
            Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);
        }
    }
}
