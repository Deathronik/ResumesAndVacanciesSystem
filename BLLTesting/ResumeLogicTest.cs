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
    class ResumeLogicTest
    {
        private IUnitOfWork UnitOFWork;
        private ResumeLogic TResumeLogic;

        [SetUp]
        public void SetUp()
        {
            UnitOFWork = new MockUnitOfWork();
            TResumeLogic = new ResumeLogic(UnitOFWork);
        }
        [Test]
        public void GetAllTest()
        {
            UnitOFWork.Worker.Add(new Worker() { Id = 8, Names = "Багряний Андрій Іванович", DateOfBirth = "22.06.1987", Email = "email@.com" });
            UnitOFWork.Resume.Add(new Resume() { JobTitle = "Програміст", OfferedSalary = 300, WorkerId = 8, Id = 4 });
            List<MResume> currentData = TResumeLogic.GetAll();
            Assert.AreEqual(1, currentData.Count);
            Assert.AreEqual("Програміст", currentData[0].JobTitle);
            Assert.AreEqual(300, currentData[0].OfferedSalary);
        }
        [Test]
        public void GetByIdTest()
        {
            UnitOFWork.Worker.Add(new Worker() { Id = 8, Names = "Багряний Андрій Іванович", DateOfBirth = "22.06.1987", Email = "email@.com" });
            UnitOFWork.Resume.Add(new Resume() { JobTitle = "Програміст", OfferedSalary = 300, WorkerId = 8, Id = 4 });
            UnitOFWork.Resume.Add(new Resume() { JobTitle = "Касир", OfferedSalary = 500, WorkerId = 8, Id = 2 });
            MResume currentData = TResumeLogic.GetById(2);
            Assert.AreEqual(2, currentData.Id);
            Assert.AreEqual("Касир", currentData.JobTitle);
            Assert.AreEqual(500, currentData.OfferedSalary);
        }
        [Test]
        public void DeleteByIdTest()
        {
            UnitOFWork.Worker.Add(new Worker() { Id = 8, Names = "Багряний Андрій Іванович", DateOfBirth = "22.06.1987", Email = "email@.com" });
            UnitOFWork.Resume.Add(new Resume() { JobTitle = "Програміст", OfferedSalary = 300, WorkerId = 8, Id = 4 });
            UnitOFWork.Resume.Add(new Resume() { JobTitle = "Касир", OfferedSalary = 500, WorkerId = 8, Id = 2 });
            TResumeLogic.DeleteById(2);
            Assert.AreEqual(1, UnitOFWork.Resume.GetData().Count);
            Assert.AreEqual("Програміст", UnitOFWork.Resume.GetData()[0].JobTitle);
            Assert.AreEqual(4, UnitOFWork.Resume.GetData()[0].Id);
        }
        [Test]
        public void ChangeTest()
        {
            UnitOFWork.Worker.Add(new Worker() { Id = 8, Names = "Багряний Андрій Іванович", DateOfBirth = "22.06.1987", Email = "email@.com" });
            UnitOFWork.Resume.Add(new Resume() { JobTitle = "Програміст", OfferedSalary = 300, WorkerId = 8, Id = 4 });
            UnitOFWork.Resume.Add(new Resume() { JobTitle = "Касир", OfferedSalary = 500, WorkerId = 8, Id = 2 });
            TResumeLogic.Change(new MResume() { JobTitle = "Сторож", OfferedSalary = 400, WorkerId = 8, Id = 4 });
            Assert.AreEqual("Сторож", UnitOFWork.Resume.GetData()[0].JobTitle);
            Assert.AreEqual(400, UnitOFWork.Resume.GetData()[0].OfferedSalary);
        }
        [Test]
        public void OfferResumeTest()
        {
            UnitOFWork.Hirer.Add(new Hirer() { Id = 7, Names = "Кулаков Вадим Романович", CompanyName = "Ашан", Email = "email@.com" });
            UnitOFWork.Worker.Add(new Worker() { Id = 8, Names = "Багряний Андрій Іванович", DateOfBirth = "22.06.1987", Email = "email@.com" });
            UnitOFWork.Resume.Add(new Resume() { JobTitle = "Програміст", OfferedSalary = 300, WorkerId = 8, Id = 4, HirerId = new List<int>() });
            TResumeLogic.OfferResume(4, 7);
            Assert.AreEqual(1, UnitOFWork.Resume.GetData()[0].HirerId.Count);
            Assert.AreEqual(7, UnitOFWork.Resume.GetData()[0].HirerId[0]);
        }
        [Test]
        public void GetOferedResumesTest()
        {
            UnitOFWork.Worker.Add(new Worker() { Id = 8, Names = "Багряний Андрій Іванович", DateOfBirth = "22.06.1987", Email = "email@.com" });
            UnitOFWork.Resume.Add(new Resume() { JobTitle = "Програміст", OfferedSalary = 300, WorkerId = 8, Id = 4, HirerId = new List<int>() { 3 } });
            UnitOFWork.Resume.Add(new Resume() { JobTitle = "Касир", OfferedSalary = 500, WorkerId = 8, Id = 2, HirerId = new List<int>() });
            UnitOFWork.Worker.Add(new Worker() { Id = 7, Names = "Кулаков Вадим Романович", DateOfBirth = "16.09.1989", Email = "email@.com" });
            UnitOFWork.Resume.Add(new Resume() { JobTitle = "Сторож", OfferedSalary = 400, WorkerId = 7, Id = 5, HirerId = new List<int>() { 3 } });
            UnitOFWork.Hirer.Add(new Hirer() { Id = 3, Names = "Попов Андрій Григорович", CompanyName = "Ашан", Email = "email@.com" });
            List<MResume> currentData = TResumeLogic.GetOferedResumes(3);
            Assert.AreEqual(2, currentData.Count);
            Assert.AreEqual("Програміст", currentData[0].JobTitle);
            Assert.AreEqual("Сторож", currentData[1].JobTitle);
        }
        [Test]
        public void GetWorkerResumesTest()
        {
            UnitOFWork.Worker.Add(new Worker() { Id = 8, Names = "Багряний Андрій Іванович", DateOfBirth = "22.06.1987", Email = "email@.com" });
            UnitOFWork.Resume.Add(new Resume() { JobTitle = "Програміст", OfferedSalary = 300, WorkerId = 8, Id = 4 });
            UnitOFWork.Resume.Add(new Resume() { JobTitle = "Касир", OfferedSalary = 500, WorkerId = 8, Id = 2 });
            UnitOFWork.Worker.Add(new Worker() { Id = 7, Names = "Кулаков Вадим Романович", DateOfBirth = "16.09.1989", Email = "email@.com" });
            UnitOFWork.Resume.Add(new Resume() { JobTitle = "Сторож", OfferedSalary = 400, WorkerId = 7, Id = 5 });
            List<MResume> currentData = TResumeLogic.GetWorkerResumes(8);
            Assert.AreEqual(2, currentData.Count);
            Assert.AreEqual("Програміст", currentData[0].JobTitle);
            Assert.AreEqual("Касир", currentData[1].JobTitle);
        }
        [Test]
        public void GetFilteredResumeTest1()
        {
            UnitOFWork.Resume.Add(new Resume() { JobTitle = "Програміст", OfferedSalary = 300, Experience = 2, IsHigherEducation = true });
            UnitOFWork.Resume.Add(new Resume() { JobTitle = "Касир", OfferedSalary = 500, Experience = 0, IsHigherEducation = true });
            UnitOFWork.Resume.Add(new Resume() { JobTitle = "Сторож", OfferedSalary = 400, Experience = 1, IsHigherEducation = false });
            List<MResume> currentData = TResumeLogic.GetFilteredResume("none", 400, 0, true);
            Assert.AreEqual(1, currentData.Count);
            Assert.AreEqual("Касир", currentData[0].JobTitle);
        }
        [Test]
        public void GetFilteredResumeTest2()
        {
            UnitOFWork.Resume.Add(new Resume() { JobTitle = "Програміст", OfferedSalary = 300, Experience = 2, IsHigherEducation = true });
            UnitOFWork.Resume.Add(new Resume() { JobTitle = "Касир", OfferedSalary = 500, Experience = 0, IsHigherEducation = true });
            UnitOFWork.Resume.Add(new Resume() { JobTitle = "Сторож", OfferedSalary = 400, Experience = 1, IsHigherEducation = false });
            List<MResume> currentData = TResumeLogic.GetFilteredResume("Сторож", 0, 1, false);
            Assert.AreEqual(1, currentData.Count);
            Assert.AreEqual("Сторож", currentData[0].JobTitle);
        }
    }
}
