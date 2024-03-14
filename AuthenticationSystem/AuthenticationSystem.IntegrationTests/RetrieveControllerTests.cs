using Microsoft.AspNetCore.Mvc.Testing;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Text;

namespace AuthenticationSystem.IntegrationTests
{
    [TestFixture]
    public class RetrieveControllerTests
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
            var response = SUT.GetAsync("api/Retrieve/GetDoctors").Result;

            //Assert
            Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);

        }
        [Test]
        public void GetPatientTest()
        {
            //Act
            var response = SUT.GetAsync("api/Retrieve/GetPatients").Result;

            //Assert
            Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);

        }
        [Test]
        public void GetHospitalTest()
        {
            //Act
            var response = SUT.GetAsync("api/Retrieve/GetHospitals").Result;

            //Assert
            Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);

        }


    }
}
