using Microsoft.AspNetCore.Mvc.Testing;
using NUnit;
using NUnit.Framework;
using PatientRecordsService;
using PatientRecordsService.DTO;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Net.Http.Formatting;
using System.Text;

namespace PatientRecordServiceTests
{
    public class PatientTreatmentControllerShould
    {
        private HttpClient SUT;
        WebApplicationFactory<Startup> server;

        [SetUp]
        public void Init()
        {
            server = new WebApplicationFactory<Startup>();
            SUT = server.CreateClient();
        }
        [Test]
        public void Return_The_List_Of_TreatmentDetails()
        {
            //Act
            var response = SUT.GetAsync("api/PatientTreatment/GetTreatmentList").Result;

            //Assert
            Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);

        }

        [Test]
        public void Return_Ok_While_Calling_By_Id()
        {
            //Act
            int id = 1;
            var response = SUT.GetAsync("api/PatientTreatment/" + id).Result;

            //Assert
            Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);
        }

        [Test]
        public void Should_Add_TreatmentDetails()
        {

            var obj = new PatientTreatmentDetailsDTO()
            {
                AppointmentId = 1,
                PatientId = 1,
                Observations = "Headache",
                Treatment = "Migrane Treatment",
                Recommendations = "Avoid working with laptops",
                Prescriptions = "Paracetamol"
            };

            var result = SUT.PostAsync("api/PatientTreatment/AddTreatmentDetails", obj, new JsonMediaTypeFormatter()).Result;
            Assert.AreEqual(HttpStatusCode.OK, result.StatusCode);
        }
        [Test]
        public void Return_Ok_After_Updating_TreatmentDetails()
        {
            var obj = new PatientTreatmentDetailsDTO()
            {
                AppointmentId = 1,
                PatientId = 1,
                Observations = "Headache",
                Treatment = "Migrane Treatment",
                Recommendations = "Avoid working with laptops",
                Prescriptions = "Paracetamol"
            };
            var result = SUT.PutAsync("api/PatientTreatment/UpdateTreatmentDetails", obj, new JsonMediaTypeFormatter()).Result;
            Assert.AreEqual(HttpStatusCode.OK, result.StatusCode);
        }

        [TearDown]
        public void Clean()
        {
            SUT.Dispose();
            server.Dispose();
        }
    }
}
