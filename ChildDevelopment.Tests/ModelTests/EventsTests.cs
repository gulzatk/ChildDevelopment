// using Microsoft.VisualStudio.TestTools.UnitTesting;
// using ChildDevelopment.Models;
//  using System.Collections.Generic;
// using System;

// namespace ChildDevelopment.Tests
// {
//  [TestClass]
//   public class EventTest : IDisposable
//   {

//     public void Dispose()
//     {
//       Child.ClearAll();
//       Event.ClearAll();
//     }

//     public EventTest()
//     {
//       DBConfiguration.ConnectionString = "server=localhost;user id=root;password=root;port=8889;database=child_database_test;";
//     }

//     [TestMethod]
//     public void EventConstructor_CreatesInstanceOfEvent_Event()
//     {
//       Event newEvent = new Event("test");
//       Assert.AreEqual(typeof(Event), newEvent.GetType());
//     }

//     [TestMethod]
//     public void GetName_ReturnsName_String()
//     {
//       //Arrange
//       string Name = "Nancy";
//       Event newEvent = new Event(Name);

//       //Act
//       string result = newEvent.GetName();

//       //Assert
//       Assert.AreEqual(Name, result);
//     }
//   }
// }
