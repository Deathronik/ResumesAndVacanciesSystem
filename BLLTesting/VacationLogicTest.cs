using System.Collections.Generic;
using BLLTesting.Mocks;
using NUnit.Framework;
using BLL.Logics;
using BLL.Entities;
using DAL.Models;
using DAL;

namespace BLLTesting
{
    [TestFixture]
    class VacationLogicTest
    {
        private IUnitOfWork UnitOFWork;
        private VacationLogic TVacationLogic;

        [SetUp]
        public void SetUp()
        {
            UnitOFWork = new MockUnitOfWork();
            TVacationLogic = new VacationLogic(UnitOFWork);
        }
        [Test]
        public void GetAllTest()
        {
            UnitOFWork.Hirer.Add(new Hirer() { Id = 8, Names = "Багряний Андрій Іванович", CompanyName = "Фора", Email = "email@.com" });
            UnitOFWork.Vacation.Add(new Vacation() { JobTitle = "Програміст", Salary = 300, CityName = "Київ", HirerId = 8, Id = 4 });
            List<MVacation> currentData = TVacationLogic.GetAll();
            Assert.AreEqual(1, currentData.Count);
            Assert.AreEqual("Програміст", currentData[0].JobTitle);
            Assert.AreEqual(300, currentData[0].Salary);
        }
        [Test]
        public void GetByIdTest()
        {
            UnitOFWork.Hirer.Add(new Hirer() { Id = 8, Names = "Багряний Андрій Іванович", CompanyName = "Фора", Email = "email@.com" });
            UnitOFWork.Vacation.Add(new Vacation() { JobTitle = "Програміст", Salary = 300, CityName = "Київ", HirerId = 8 , Id = 4 });
            UnitOFWork.Vacation.Add(new Vacation() { JobTitle = "Касир", Salary = 500, CityName = "Київ", HirerId = 8, Id = 2 });
            MVacation currentData = TVacationLogic.GetById(2);
            Assert.AreEqual(2, currentData.Id);
            Assert.AreEqual("Касир", currentData.JobTitle);
            Assert.AreEqual(500, currentData.Salary);
        }
        [Test]
        public void DeleteByIdTest()
        {
            UnitOFWork.Hirer.Add(new Hirer() { Id = 8, Names = "Багряний Андрій Іванович", CompanyName = "Фора", Email = "email@.com" });
            UnitOFWork.Vacation.Add(new Vacation() { JobTitle = "Програміст", Salary = 300, CityName = "Київ", HirerId = 8, Id = 4 });
            UnitOFWork.Vacation.Add(new Vacation() { JobTitle = "Касир", Salary = 500, CityName = "Київ", HirerId = 8, Id = 2 });
            TVacationLogic.DeleteById(2);
            Assert.AreEqual(1, UnitOFWork.Vacation.GetData().Count);
            Assert.AreEqual("Програміст", UnitOFWork.Vacation.GetData()[0].JobTitle);
            Assert.AreEqual(4, UnitOFWork.Vacation.GetData()[0].Id);
        }
        [Test]
        public void ChangeTest()
        {
            UnitOFWork.Hirer.Add(new Hirer() { Id = 8, Names = "Багряний Андрій Іванович", CompanyName = "Фора", Email = "email@.com" });
            UnitOFWork.Vacation.Add(new Vacation() { JobTitle = "Програміст", Salary = 300, CityName = "Київ", HirerId = 8, Id = 4 });
            UnitOFWork.Vacation.Add(new Vacation() { JobTitle = "Касир", Salary = 500, CityName = "Київ", HirerId = 8, Id = 2 });
            TVacationLogic.Change(new MVacation() { JobTitle = "Сторож", Salary = 400, CityName = "Київ", HirerId = 8, Id = 4 });
            Assert.AreEqual("Сторож", UnitOFWork.Vacation.GetData()[0].JobTitle);
            Assert.AreEqual(400, UnitOFWork.Vacation.GetData()[0].Salary);
        }
        [Test]
        public void OfferVacationTest()
        {
            UnitOFWork.Worker.Add(new Worker() { Id = 7, Names = "Кулаков Вадим Романович", DateOfBirth = "16.09.1989", Email = "email@.com" });
            UnitOFWork.Hirer.Add(new Hirer() { Id = 8, Names = "Багряний Андрій Іванович", CompanyName = "Фора", Email = "email@.com" });
            UnitOFWork.Vacation.Add(new Vacation() { JobTitle = "Програміст", Salary = 300, CityName = "Київ", HirerId = 8, Id = 4, WorkerId = new List<int>() });
            TVacationLogic.OfferVacation(4, 7);
            Assert.AreEqual(1, UnitOFWork.Vacation.GetData()[0].WorkerId.Count);
            Assert.AreEqual(7, UnitOFWork.Vacation.GetData()[0].WorkerId[0]);
        }
        [Test]
        public void GetHirerVacationsTest()
        {
            UnitOFWork.Hirer.Add(new Hirer() { Id = 8, Names = "Багряний Андрій Іванович", CompanyName = "Фора", Email = "email@.com" });
            UnitOFWork.Vacation.Add(new Vacation() { JobTitle = "Програміст", Salary = 300, CityName = "Київ", HirerId = 8, Id = 4 });
            UnitOFWork.Vacation.Add(new Vacation() { JobTitle = "Касир", Salary = 500, CityName = "Київ", HirerId = 8, Id = 2 });
            UnitOFWork.Hirer.Add(new Hirer() { Id = 7, Names = "Кулаков Вадим Романович", CompanyName = "Ашан", Email = "email@.com" });
            UnitOFWork.Vacation.Add(new Vacation() { JobTitle = "Сторож", Salary = 400, CityName = "Київ", HirerId = 7, Id = 5 });
            List<MVacation> currentData = TVacationLogic.GetHirerVacations(8);
            Assert.AreEqual(2, currentData.Count);
            Assert.AreEqual("Програміст", currentData[0].JobTitle);
            Assert.AreEqual("Касир", currentData[1].JobTitle);
        }
        [Test]
        public void GetOferedVacationsTest()
        {
            UnitOFWork.Hirer.Add(new Hirer() { Id = 8, Names = "Багряний Андрій Іванович", CompanyName = "Фора", Email = "email@.com" });
            UnitOFWork.Vacation.Add(new Vacation() { JobTitle = "Програміст", Salary = 300, CityName = "Київ", HirerId = 8, Id = 4, WorkerId = new List<int>() { 6 } });
            UnitOFWork.Vacation.Add(new Vacation() { JobTitle = "Касир", Salary = 500, CityName = "Київ", HirerId = 8, Id = 2, WorkerId = new List<int>() { 7 } });
            UnitOFWork.Hirer.Add(new Hirer() { Id = 7, Names = "Кулаков Вадим Романович", CompanyName = "Ашан", Email = "email@.com" });
            UnitOFWork.Vacation.Add(new Vacation() { JobTitle = "Сторож", Salary = 400, CityName = "Київ", HirerId = 7, Id = 5, WorkerId = new List<int>() { 6 } });
            UnitOFWork.Worker.Add(new Worker() { Id = 6, Names = "Попов Андрій Григорович", DateOfBirth = "11.06.1977", Email = "email@.com" });
            List<MVacation> currentData = TVacationLogic.GetOferedVacations(6);
            Assert.AreEqual(2, currentData.Count);
            Assert.AreEqual("Програміст", currentData[0].JobTitle);
            Assert.AreEqual("Сторож", currentData[1].JobTitle);
        }
        [Test]
        public void GetFilteredDataTest1()
        {
            UnitOFWork.Vacation.Add(new Vacation() { JobTitle = "Програміст", Salary = 300, CityName = "Київ", Experience = 2, IsHigherEducation = true });
            UnitOFWork.Vacation.Add(new Vacation() { JobTitle = "Касир", Salary = 500, CityName = "Київ", Experience = 0, IsHigherEducation = true });
            UnitOFWork.Vacation.Add(new Vacation() { JobTitle = "Сторож", Salary = 400, CityName = "Київ", Experience = 1, IsHigherEducation = false });
            List<MVacation> currentData = TVacationLogic.GetFilteredData("none", 400, 0, false);
            Assert.AreEqual(2, currentData.Count);
            Assert.AreEqual("Касир", currentData[0].JobTitle);
            Assert.AreEqual("Сторож", currentData[1].JobTitle);
        }
        [Test]
        public void GetFilteredDataTest2()
        {
            UnitOFWork.Vacation.Add(new Vacation() { JobTitle = "Програміст", Salary = 300, CityName = "Київ", Experience = 2, IsHigherEducation = true });
            UnitOFWork.Vacation.Add(new Vacation() { JobTitle = "Касир", Salary = 500, CityName = "Київ", Experience = 0, IsHigherEducation = true });
            UnitOFWork.Vacation.Add(new Vacation() { JobTitle = "Сторож", Salary = 400, CityName = "Київ", Experience = 1, IsHigherEducation = false });
            List<MVacation> currentData = TVacationLogic.GetFilteredData("Сторож", 0, 1, true);
            Assert.AreEqual(1, currentData.Count);
            Assert.AreEqual("Сторож", currentData[0].JobTitle);
        }
    }
}
