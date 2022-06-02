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
    class HirerLogicTest
    {
        private IUnitOfWork UnitOFWork;
        private HirerLogic THirerLogic;

        [SetUp]
        public void SetUp()
        {
            UnitOFWork = new MockUnitOfWork();
            THirerLogic = new HirerLogic(UnitOFWork);
        }
        [Test]
        public void GetAllTest()
        {
            UnitOFWork.Hirer.Add(new Hirer() { Names = "Багряний Андрій Іванович", CompanyName = "Фора", Email = "email@.com" });
            List<MHirer> currentData = THirerLogic.GetAll();
            Assert.AreEqual(1, currentData.Count);
            Assert.AreEqual("Багряний Андрій Іванович", currentData[0].Names);
            Assert.AreEqual("Фора", currentData[0].CompanyName);
        }
        [Test]
        public void GetByIdTest()
        {
            UnitOFWork.Hirer.Add(new Hirer() { Id = 8, Names = "Кулаков Вадим Романович", CompanyName = "Фора", Email = "email@.com" });
            UnitOFWork.Hirer.Add(new Hirer() { Id = 5, Names = "Багряний Андрій Іванович", CompanyName = "Ашан", Email = "email@.com" });
            MHirer currentData = THirerLogic.GetById(5);
            Assert.AreEqual(5, currentData.Id);
            Assert.AreEqual("Багряний Андрій Іванович", currentData.Names);
            Assert.AreEqual("Ашан", currentData.CompanyName);
        }
        [Test]
        public void DeleteByIdTest()
        {
            UnitOFWork.Hirer.Add(new Hirer() { Id = 8, Names = "Кулаков Вадим Романович", CompanyName = "Ашан", Email = "email@.com" });
            UnitOFWork.Hirer.Add(new Hirer()
            {
                Id = 5,
                Names = "Багряний Андрій Іванович",
                CompanyName = "Фора",
                Email = "email@.com",
                Vacations = new List<Vacation>() { new Vacation() { JobTitle = "Програміст", Salary = 300, CityName = "Київ" } }
            });
            THirerLogic.DeleteById(5);
            Assert.AreEqual(1, UnitOFWork.Hirer.GetData().Count);
            Assert.AreEqual("Кулаков Вадим Романович", UnitOFWork.Hirer.GetData()[0].Names);
            Assert.AreEqual(8, UnitOFWork.Hirer.GetData()[0].Id);
        }
        [Test]
        public void ChangeTest()
        {
            UnitOFWork.Hirer.Add(new Hirer() { Id = 8, Names = "Кулаков Вадим Романович", CompanyName = "Ашан", Email = "email@.com" });
            UnitOFWork.Hirer.Add(new Hirer() { Id = 5, Names = "Багряний Андрій Іванович", CompanyName = "Фора", Email = "email@.com" });
            THirerLogic.Change(new MHirer() { Id = 8, Names = "Купр Олег Степанович", CompanyName = "АТБ", Email = "email@.com" });
            Assert.AreEqual("Купр Олег Степанович", UnitOFWork.Hirer.GetData()[0].Names);
            Assert.AreEqual("АТБ", UnitOFWork.Hirer.GetData()[0].CompanyName);
        }
        [Test]
        public void CreateVacationTest()
        {
            UnitOFWork.Hirer.Add(new Hirer() { Id = 8, Names = "Багряний Андрій Іванович", CompanyName = "Фора", Email = "email@.com" });
            UnitOFWork.Hirer.Add(new Hirer() { Id = 5, Names = "Кулаков Вадим Романович", CompanyName = "Ашан", Email = "email@.com" });
            THirerLogic.CreateVacation(5, new MVacation() { JobTitle = "Програміст", Salary = 300, CityName = "Київ" });
            Assert.AreEqual(1, UnitOFWork.Vacation.GetData().Count);
            Assert.AreEqual("Програміст", UnitOFWork.Vacation.GetData()[0].JobTitle);
            Assert.AreEqual(300, UnitOFWork.Vacation.GetData()[0].Salary);
            Assert.AreEqual(5, UnitOFWork.Vacation.GetData()[0].HirerId);
        }
        [Test]
        public void CreateTest()
        {
            THirerLogic.Create(new MHirer() { Id = 5, Names = "Багряний Андрій Іванович", CompanyName = "Фора", Email = "email@.com" });
            Assert.AreEqual(1, UnitOFWork.Hirer.GetData().Count);
            Assert.AreEqual("Багряний Андрій Іванович", UnitOFWork.Hirer.GetData()[0].Names);
            Assert.AreEqual("Фора", UnitOFWork.Hirer.GetData()[0].CompanyName);
        }
    }
}
