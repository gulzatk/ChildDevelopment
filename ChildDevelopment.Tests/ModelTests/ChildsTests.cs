using Microsoft.VisualStudio.TestTools.UnitTesting;
using ChildDevelopment.Models;
using System.Collections.Generic;
using System;

namespace ChildDevelopment.Tests
{

[TestClass]
  public class ChildTest : IDisposable
  {

    public void Dispose()
    {
      Child.ClearAll();
      Patron.ClearAll();
    }

    public ChildTest()
    {
      DBConfiguration.ConnectionString = "server=localhost;user id=root;password=root;port=8889;database=child_development_tests;";
    }

    [TestMethod]
    public void ChildConstructor_CreatesInstanceOfChild_Child()
    {
      Child newChild = new Child("Nancy", false, 8, 20, default(DateTime), false);
      Assert.AreEqual(typeof(Child), newChild.GetType());
    }

    [TestMethod]
    public void GetName_ReturnsName_String()
    {
      //Arrange
      string Name = "Nancy";
      Child newChild = new Child(Name, false, 8, 20, default(DateTime), false);

      //Act
      string result = newChild.GetName();

      //Assert
      Assert.AreEqual(Name, result);
    }

    [TestMethod]
    public void GetGender_ReturnsGender_Boolean()
    {
      //Arrange
      bool gender = false;
      Child newChild = new Child("Nancy", gender, 8, 20, default(DateTime), false);

      //Act
      bool result = newChild.GetGender();

      //Assert
      Assert.AreEqual(gender, result);
    }

    [TestMethod]
    public void GetWeight_ReturnsWeight_Int()
    {
      //Arrange
      int Weight = 8;
      Child newChild = new Child("Nancy", false, Weight, 20, default(DateTime), false);

      //Act
      int result = newChild.GetWeight();

      //Assert
      Assert.AreEqual(Weight, result);
    }

    [TestMethod]
    public void GetHeight_ReturnsHeight_Int()
    {
      //Arrange
      int Height = 20;
      Child newChild = new Child("Nancy", false, 8, Height, default(DateTime), false);

      //Act
      int result = newChild.GetHeight();

      //Assert
      Assert.AreEqual(Height, result);
    }

    [TestMethod]
    public void GetBirthdate_ReturnsBirthdate_DateTime()
    {
      //Arrange
      DateTime Birthdate = default(DateTime);
      Child newChild = new Child("Nancy", false, 8, 20, Birthdate, false);

      //Act
      DateTime result = newChild.GetBirthdate();

      //Assert
      Assert.AreEqual(Birthdate, result);
    }

    [TestMethod]
    public void GetBreastfeeding_ReturnsBreastfeeding_Boolean()
    {
      //Arrange
      bool Breastfeeding = false;
      Child newChild = new Child("Nancy", false, 8, 20, default(DateTime), Breastfeeding);

      //Act
      bool result = newChild.GetBreastfeeding();

      //Assert
      Assert.AreEqual(Breastfeeding, result);
    }

    [TestMethod]
    public void GetId_ReturnsId_Int()
    {
      //Arrange
      int Id = 7;
      Child newChild = new Child("Nancy", false, 8, 20, default(DateTime), false, Id);

      //Act
      int result = newChild.GetId();

      //Assert
      Assert.AreEqual(Id, result);
    }


    [TestMethod]
    public void GetAll_ReturnsEmptyList_ChildList()
    {
      //Arrange
      List<Child> newList = new List<Child> { };

      //Act
      List<Child> result = Child.GetAll();

      //Assert
      CollectionAssert.AreEqual(newList, result);
    }

    [TestMethod]
    public void GetAll_ReturnsChildren_ChildList()
    {
      //Arrange
      string name01 = "Nancy";
      string name02 = "Jackson";
      Child newChild1 = new Child(name01, false, 8, 20, default(DateTime), false);
      newChild1.Save();
      Child newChild2 = new Child(name02, false, 8, 20, default(DateTime), false);
      newChild2.Save();
      List<Child> newList = new List<Child> { newChild1, newChild2 };

      //Act
      List<Child> result = Child.GetAll();

      //Assert
      CollectionAssert.AreEqual(newList, result);
    }

    [TestMethod]
    public void Find_ReturnsCorrectChildFromDatabase_Child()
    {
      //Arrange
      Child testChild = new Child("nancy", false, 8, 20, default(DateTime), false);
      testChild.Save();

      //Act
      Child foundChild = Child.Find(testChild.GetId());

      //Assert
      Assert.AreEqual(testChild, foundChild);
    }

    [TestMethod]
    public void Equals_ReturnsTrueIfNamesAreTheSame_Child()
    {
      // Arrange, Act
      Child firstChild = new Child("nancy", false, 8, 20, default(DateTime), false);
      Child secondChild = new Child("nancy", false, 8, 20, default(DateTime), false);

      // Assert
      Assert.AreEqual(firstChild, secondChild);
    }

    [TestMethod]
    public void Save_SavesToDatabase_ChildList()
    {
      //Arrange
      Child newChild = new Child("Nancy", false, 8, 20, default(DateTime), false, 7);

      //Act
      newChild.Save();
      List<Child> result = Child.GetAll();
      List<Child> testList = new List<Child>{newChild};

      //Assert
      CollectionAssert.AreEqual(testList, result);
    }

    [TestMethod]
    public void Save_AssignsIdToObject_Id()
    {
      //Arrange
      Child testChild = new Child("nancy", false, 8, 20, default(DateTime), false);

      //Act
      testChild.Save();
      Child savedChild = Child.GetAll()[0];

      int result = savedChild.GetId();
      int testId = testChild.GetId();

      //Assert
      Assert.AreEqual(testId, result);
    }

    [TestMethod]
    public void AddChildEvents_AddsChildEventsToChild_ChildEventsList()
    {
      //Arrange
      Child testChild = new Child("nancy", false, 8, 20, default(DateTime), false);
      testChild.Save();
      int testDateTime = 50;


      //Act
      testChild.AddChildEvents(2, testDateTime);
      testChild.AddChildEvents(4, testDateTime);


      List<int> result = testChild.GetEvents();
      List<int> testList = new List<int>{2, 4};

      //Assert
      CollectionAssert.AreEqual(testList, result);
    }

        [TestMethod]
    public void GetEvents_GetsEventsFromChildEvents_ChildEventsList()
    {
      //Arrange
      Child testChild = new Child("nancy", false, 8, 20, default(DateTime), false);
      testChild.Save();
      int testDateTime = 50;


      //Act
      testChild.AddChildEvents(2, testDateTime);
      testChild.AddChildEvents(4, testDateTime);
      List<int> result = testChild.GetEvents();
      List<int> testList = new List<int>{2, 4};

      //Assert
      CollectionAssert.AreEqual(testList, result);
    }

    // [TestMethod]
    // public void GetDates_ReturnsChildsDates_List()
    // {
    //   //Arrange



    //   //Act



    //   //Assert

    // }

    // [TestMethod]
    // public void Edit_UpdatesChildInDatabase_String()
    // {
    //   //Arrange
    //   Child testChild = new Child("Nancy", false, 8, 20, default(DateTime), false);
    //   testChild.Save();
    //   string secondName = "Rover";

    //   //Act
    //   testChild.Edit(secondName, false, 8, 20, default(DateTime), false);
    //   string result = Child.Find(testChild.GetId()).GetName();

    //   //Assert
    //   Assert.AreEqual(secondName, result);
    // }
  }
}
