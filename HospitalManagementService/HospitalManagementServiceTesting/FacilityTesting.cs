using HospitalManagementService.Models;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

  namespace HospitalManagementServiceTesting
{
    [TestFixture]
    public class FacilityTesting
    {
        private int hospitalId;
        [Test]
        public void Patients_WithSame_HospitalIds_MustBeEqual()
        {
            var hospital1 = new Facility(1, "Room", "7 Hills");
            var hospital2 = new Facility(1, "Room", "7 Hills");

            hospital1.Id = 101;
            hospital2.Id = 102;

            var result = hospital1.Equals(hospital2);
            Assert.That(result, Is.False);
        }
        [Test]
        public void Name_WillNotEmpty()
        {
            var Patient = new Facility(1, "Bed", "7Hills");
            Assert.That(Patient, Is.Not.Null);
        }
        [TestCase(2, "Bed", "")]
        [TestCase(3, "", null)]
        [TestCase(4, "", "7Hills")]
        [TestCase(5, null, "7Hills")]
        [TestCase(6, "", "")]
        public void Throw_ArgumentException_For_Invalid_Input(int id, string facilityName, string facilityDescription)
        {
            Assert.Throws<ArgumentException>(() => new Facility(hospitalId, facilityName, facilityDescription));
        }
    }
}