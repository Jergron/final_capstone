using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using DripScript.Models;

namespace DripScript.Tests.Models
{
    [TestClass]
    public class DSUserTests
    {
        [TestMethod]
        public void DSUserEnsureICanCreateInstance()
        {
            DSUser a_user = new DSUser();
            Assert.IsNotNull(a_user);
        }

        [TestMethod]
        public void DSUserEnsureHasAllThings()
        {
            // Arrange
            DSUser a_user = new DSUser();
            a_user.UserId = 13452;
            a_user.FirstName = "Jeremy";
            a_user.LastName = "Grondahl";
            a_user.Description = "I am a software developer";


            // Assert
            Assert.AreEqual(13452, a_user.UserId);
            Assert.AreEqual("Jeremy", a_user.FirstName);
            Assert.AreEqual("Grondahl", a_user.LastName);
            Assert.AreEqual("I am a software developer", a_user.Description);
        }
    }
}
