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
    class WorkerLogicTest
    {
        private IUnitOfWork UnitOFWork;
        private WorkerLogic TWorkerLogic;

        [SetUp]
        public void SetUp()
        {
            UnitOFWork = new MockUnitOfWork();
            TWorkerLogic = new WorkerLogic(UnitOFWork);
        }
        [Test]
        public void GetAllTest()
        {
            UnitOFWork.Worker.Add(new Worker() { Names = "Багряний Андрій Іванович", DateOfBirth = "22.06.1987", Email = "email@.com" });
            List<MWorker> currentData = TWorkerLogic.GetAll();
            Assert.AreEqual(1, currentData.Count);
            Assert.AreEqual("Багряний Андрій Іванович", currentData[0].Names);
            Assert.AreEqual("22.06.1987", currentData[0].DateOfBirth);
        }
        [Test]
        public void GetByIdTest()
        {
            UnitOFWork.Worker.Add(new Worker() { Id = 8, Names = "Кулаков Вадим Романович", DateOfBirth = "16.09.1989", Email = "email@.com" });
            UnitOFWork.Worker.Add(new Worker() { Id = 5, Names = "Багряний Андрій Іванович", DateOfBirth = "22.06.1987", Email = "email@.com" });
            MWorker currentData = TWorkerLogic.GetById(5);
            Assert.AreEqual(5, currentData.Id);
            Assert.AreEqual("Багряний Андрій Іванович", currentData.Names);
            Assert.AreEqual("22.06.1987", currentData.DateOfBirth);
        }
        [Test]
        public void DeleteByIdTest()
        {
            UnitOFWork.Worker.Add(new Worker() { Id = 8, Names = "Кулаков Вадим Романович", DateOfBirth = "16.09.1989", Email = "email@.com" });
            UnitOFWork.Worker.Add(new Worker()
            {
                Id = 5,
                Names = "Багряний Андрій Іванович",
                DateOfBirth = "22.06.1987",
                Email = "email@.com",
                Resumes = new List<Resume>() { new Resume() { DateOfBirth = "22.06.1987", JobTitle = "Програміст", OfferedSalary = 300, Experience = 4 } }
            });
            TWorkerLogic.DeleteById(5);
            Assert.AreEqual(1, UnitOFWork.Worker.GetData().Count);
            Assert.AreEqual("Кулаков Вадим Романович", UnitOFWork.Worker.GetData()[0].Names);
            Assert.AreEqual(8, UnitOFWork.Worker.GetData()[0].Id);
        }
        [Test]
        public void ChangeTest()
        {
            UnitOFWork.Worker.Add(new Worker() { Id = 8, Names = "Кулаков Вадим Романович", DateOfBirth = "16.09.1989", Email = "email@.com" });
            UnitOFWork.Worker.Add(new Worker() { Id = 5, Names = "Багряний Андрій Іванович", DateOfBirth = "22.06.1987", Email = "email@.com" });
            TWorkerLogic.Change(new MWorker() { Id = 8, Names = "Купр Олег Степанович", DateOfBirth = "06.01.2000", Email = "email@.com" });
            Assert.AreEqual("Купр Олег Степанович", UnitOFWork.Worker.GetData()[0].Names);
            Assert.AreEqual("06.01.2000", UnitOFWork.Worker.GetData()[0].DateOfBirth);
        }
        [Test]
        public void CreateResumeTest()
        {
            UnitOFWork.Worker.Add(new Worker() { Id = 8, Names = "Кулаков Вадим Романович", DateOfBirth = "16.09.1989", Email = "email@.com", Resumes = new List<Resume>() });
            UnitOFWork.Worker.Add(new Worker() { Id = 5, Names = "Багряний Андрій Іванович", DateOfBirth = "22.06.1987", Email = "email@.com", Resumes = new List<Resume>() });
            TWorkerLogic.CreateResume(5, new MResume() { JobTitle = "Програміст", OfferedSalary = 300, Experience = 4 });
            Assert.AreEqual(1, UnitOFWork.Resume.GetData().Count);
            Assert.AreEqual("Програміст", UnitOFWork.Resume.GetData()[0].JobTitle);
            Assert.AreEqual(300, UnitOFWork.Resume.GetData()[0].OfferedSalary);
            Assert.AreEqual(5, UnitOFWork.Resume.GetData()[0].WorkerId);
        }
        [Test]
        public void CreateTest()
        {
            TWorkerLogic.Create(new MWorker() { Id = 5, Names = "Багряний Андрій Іванович", DateOfBirth = "22.06.1987", Email = "email@.com" });
            Assert.AreEqual(1, UnitOFWork.Worker.GetData().Count);
            Assert.AreEqual("Багряний Андрій Іванович", UnitOFWork.Worker.GetData()[0].Names);
            Assert.AreEqual("22.06.1987", UnitOFWork.Worker.GetData()[0].DateOfBirth);
        }
    }
}
