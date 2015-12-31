using System;
using System.Web.Mvc;
using DripScript.Controllers;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DripScript.Tests
{
    [TestClass]
    public class DripScriptAPIControllerTests
    {
        [TestMethod]
        public void DripScriptAPIControllerEnsureICanCallGetAction()
        {
            // Arrange
            DripScriptAPIController my_controller = new DripScriptAPIController();
            string expected_output = "Hello World!";

            // Act
            string actual_output = my_controller.Get();

            // Assert
            Assert.AreEqual(expected_output, actual_output);
        }
    }
}
