using Microsoft.VisualStudio.TestTools.UnitTesting;
using ChildDevelopment.Models;
using System.Collections.Generic;
using System;

namespace ChildDevelopment.Tests
{
  [TestClass]
  public class PatronTest : IDisposable
  {

    public void Dispose()
    {
      Patron.ClearAll();
      Child.ClearAll();
    }

    public PatronTest()
    {
      DBConfiguration.ConnectionString = "server=localhost;user id=root;password=root;port=8889;database=child_development_test;";
    }

    [TestMethod]
    public void PatronConstructor_CreatesInstanceOfPatron_Patron()
    {
      Patron newPatron = new Patron("Gulzat", "123", 0);
      Assert.AreEqual(typeof(Patron), newPatron.GetType());
    }

    [TestMethod]
    public void GetName_ReturnsName_String()
    {
      //Arrange
      string Name = "Gulzat";
      Patron newPatron = new Patron(Name, "123", 0);

      //Act
      string result = newPatron.GetName();

      //Assert
      Assert.AreEqual(Name, result);
    }

    [TestMethod]
    public void GetPassword_ReturnsPassword_String()
    {
      //Arrange
      string Password = "123";
      Patron newPatron = new Patron("Gulzat", Password, 0);

      //Act
      string result = newPatron.GetPassword();

      //Assert
      Assert.AreEqual(Password, result);
    }

        [TestMethod]
    public void GetChildId_ReturnsChildId_Int()
    {
      //Arrange
      int ChildId = 1;
      Patron newPatron = new Patron("Gulzat", "123", ChildId);

      //Act
      int result = newPatron.GetChildId();

      //Assert
      Assert.AreEqual(ChildId, result);
    }


    [TestMethod]
    public void GetAll_ReturnsEmptyList_PatronList()
    {
      //Arrange
      List<Patron> newList = new List<Patron> { };

      //Act
      List<Patron> result = Patron.GetAll();

      //Assert
      CollectionAssert.AreEqual(newList, result);
    }


    [TestMethod]
    public void GetAll_ReturnsPatrons_PatronList()
    {
      //Arrange
      string namen01 = "Gulzat";
      string namen02 = "Kaveh";
      Patron newPatron1 = new Patron(namen01, "123", 1);
      newPatron1.Save();
      Patron newPatron2 = new Patron(namen02, "123", 2);
      newPatron2.Save();
      List<Patron> newList = new List<Patron> { newPatron1, newPatron2 };

      //Act
      List<Patron> result = Patron.GetAll();

      //Assert
      CollectionAssert.AreEqual(newList, result);
    }


    [TestMethod]
    public void FindByName_ReturnsCorrectPatronFromDatabase_Patron()
    {
      //Arrange
      Patron testPatron = new Patron("Gulzat", "123", 1);
      testPatron.Save();

      //Act
      Patron foundPatron = Patron.FindByName("Gulzat", "123");

      //Assert
      Assert.AreEqual(testPatron, foundPatron);
    }

    [TestMethod]
    public void Equals_ReturnsTrueIfNamesAreTheSame_Bool()
    {
      // Arrange, Act
      Patron firstPatron = new Patron("Gulzat", "123", 1);
      Patron secondPatron = new Patron("Gulzat", "123", 1);

      // Assert
      Assert.AreEqual(firstPatron, secondPatron);
    }

    [TestMethod]
    public void Save_SavesToDatabase_PatronList()
    {
      //Arrange
      Patron testPatron = new Patron("Gulzat", "123", 1);

      //Act
      testPatron.Save();
      List<Patron> result = Patron.GetAll();
      List<Patron> testList = new List<Patron>{testPatron};

      //Assert
      CollectionAssert.AreEqual(testList, result);
    }

    // [TestMethod]
    // public void Edit_UpdatesPatronInDatabase_String()
    // {
    //   //Arrange
    //   Patron testPatron = new Patron("Gulzat", "123", 1);
    //   testPatron.Save();
    //   string newName = "Mow the lawn";
    //   string newPassword = "123";

    //   //Act
    //   testPatron.Edit(newName, newPassword);
    //   string result = testPatron.GetName();

    //   //Assert
    //   Assert.AreEqual(newName, result);
    // }
  }
}