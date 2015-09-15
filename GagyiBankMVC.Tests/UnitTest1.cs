using GagyiBankMVC.Controllers;
using GagyiBankMVC.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Web.Mvc;

namespace GagyiBankMVC.Tests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void FooActionReturnsAboutView()
        {
            var homeController = new HomeController();
            var result = homeController.Foo() as ViewResult;
            Assert.AreEqual("About", result.ViewName);
        }
        [TestMethod]
        public void ContactFormSaysThanks()
        {
            var homeController = new HomeController();
            var result = homeController.Contact("I love your bank.") as ViewResult;
            Assert.IsNotNull(result.ViewBag.TheMessage);
        }

        [TestMethod]
        public void BalanceIsCorrectAfterDeposit()
        {
            var fakeDb = new FakeApplicationDbContext();
            fakeDb.CheckingAccounts = new FakeDbSet<CheckingAccount>();

            var checkingAccount = new CheckingAccount { Id = 1, AccountNumber = "0001234TEST", Balance = 0 };
            fakeDb.CheckingAccounts.Add(checkingAccount);
            fakeDb.Transactions = new FakeDbSet<TransactionModel>();
            var transactionController = new TransactionController(fakeDb);

            transactionController.Deposit(new TransactionModel { CheckingAccountId = 1, Amount = 25 });
            
            Assert.AreEqual(25, checkingAccount.Balance);
        }
    }
}
