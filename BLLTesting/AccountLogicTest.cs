using BLLTesting.Mocks;
using NUnit.Framework;
using BLL.Logics;
using BLL.Entities;
using DAL.Models;
using DAL;

namespace BLLTesting
{
    [TestFixture]
    class AccountLogicTest
    {
        private IUnitOfWork UnitOFWork;
        private AccountLogic TAccountLogic;

        [SetUp]
        public void SetUp()
        {
            UnitOFWork = new MockUnitOfWork();
            TAccountLogic = new AccountLogic(UnitOFWork);
        }
        [Test]
        public void GetAccountTest1()
        {
            UnitOFWork.Worker.Add(new Worker() { Id = 8, Names = "Кулаков Вадим Романович", DateOfBirth = "16.09.1989", Email = "Kulakov@.com", Password = "198909" });
            UnitOFWork.Hirer.Add(new Hirer() { Id = 5, Names = "Багряний Андрій Іванович", CompanyName = "Ашан", Email = "Bagraniy@.com", Password = "165412" });
            Account currentData = TAccountLogic.GetAccount("Kulakov@.com", "198909");
            Assert.AreEqual("Кулаков Вадим Романович", currentData.Names);
            Assert.AreEqual(8, currentData.Id);
        }
        [Test]
        public void GetAccountTest2()
        {
            UnitOFWork.Worker.Add(new Worker() { Id = 8, Names = "Кулаков Вадим Романович", DateOfBirth = "16.09.1989", Email = "Kulakov@.com", Password = "198909" });
            UnitOFWork.Hirer.Add(new Hirer() { Id = 5, Names = "Багряний Андрій Іванович", CompanyName = "Ашан", Email = "Bagraniy@.com", Password = "165412" });
            Account currentData = TAccountLogic.GetAccount("Bagraniy@.com", "165412");
            Assert.AreEqual("Багряний Андрій Іванович", currentData.Names);
            Assert.AreEqual(5, currentData.Id);
        }
        [Test]
        public void GetAccountTest3()
        {
            UnitOFWork.Worker.Add(new Worker() { Id = 8, Names = "Кулаков Вадим Романович", DateOfBirth = "16.09.1989", Email = "Kulakov@.com", Password = "198909" });
            UnitOFWork.Hirer.Add(new Hirer() { Id = 5, Names = "Багряний Андрій Іванович", CompanyName = "Ашан", Email = "Bagraniy@.com", Password = "165412" });
            Account currentData = TAccountLogic.GetAccount("Ivanov@.com", "342154");
            Assert.IsNull(currentData);
        }
    }
}
