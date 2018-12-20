using Microsoft.VisualStudio.TestTools.UnitTesting;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using ChildDevelopment.Controllers;
using ChildDevelopment.Models;
using System;

namespace ChildDevelopment.Tests
{
    [TestClass]
    public class ChildrenControllerTest
    {
        [TestMethod]
        public void Index_ReturnsCorrectActionType_ViewResult()
        {
            //Arrange
            ChildrenController controller = new ChildrenController();

            //Act
            IActionResult view = controller.Index();

            //Assert
            Assert.IsInstanceOfType(view, typeof(ViewResult));
        }

        [TestMethod]
        public void New_ReturnsCorrectActionType_ViewResult()
        {
            //Arrange
            ChildrenController controller = new ChildrenController();

            //Act
            IActionResult view = controller.New();

            //Assert
            Assert.IsInstanceOfType(view, typeof(ViewResult));
        }
    }
}
