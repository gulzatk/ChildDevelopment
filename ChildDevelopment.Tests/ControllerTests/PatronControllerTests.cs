using Microsoft.VisualStudio.TestTools.UnitTesting;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using ChildDevelopment.Controllers;
using ChildDevelopment.Models;
using System;

namespace ChildDevelopment.Tests
{
    [TestClass]
    public class PatronControllerTest
    {
        [TestMethod]
        public void Login_ReturnsCorrectActionType_ViewResult()
        {
            //Arrange
            PatronController controller = new PatronController();

            //Act
            IActionResult view = controller.Login("name", "123");

            //Assert
            Assert.IsInstanceOfType(view, typeof(ViewResult));
        }

        [TestMethod]
        public void Exist_ReturnsCorrectActionType_ViewResult()
        {
            //Arrange
            PatronController controller = new PatronController();

            //Act
            IActionResult view = controller.Exist();

            //Assert
            Assert.IsInstanceOfType(view, typeof(ViewResult));
        }

        [TestMethod]
        public void Account_ReturnsCorrectActionType_ViewResult()
        {
            //Arrange
            PatronController controller = new PatronController();

            //Act
            IActionResult view = controller.Account();

            //Assert
            Assert.IsInstanceOfType(view, typeof(ViewResult));
        }
    }
}