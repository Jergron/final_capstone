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
        public void DSUserEnsureUserHasUserId()
        {
            // Arrange
            DSUser a_user = new DSUser();
            int expected = 13452;

            // Act
            a_user.UserId = 13452;
            int actual = a_user.UserId;

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void DSUserEnsureUserHasFirstName()
        {
            // Arrange
            DSUser a_user = new DSUser();
            string expected = "Jeremy";

            // Act
            a_user.FirstName = "Jeremy";
            string actual = a_user.FirstName;

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void DSUserEnsureUserHasLastName()
        {
            // Arrange
            DSUser a_user = new DSUser();
            string expected = "Grondahl";

            // Act
            a_user.LastName = "Grondahl";
            string actual = a_user.LastName;

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void DSUserEnsureUserHasDescription()
        {
            // Arrange
            DSUser a_user = new DSUser();
            string expected = "I am a software developer";

            // Act
            a_user.Description = "I am a software developer";
            string actual = a_user.Description;

            // Assert
            Assert.AreEqual(expected, actual);
        }

    }
}
