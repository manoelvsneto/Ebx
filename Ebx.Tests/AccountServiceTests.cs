using Ebx.Models;
using Ebx.Repository;
using Ebx.Service;
using Moq;
using NUnit.Framework;
using System;

namespace Ebx.Tests
{
    [TestFixture]
    public class AccountServiceTests
    {
        private MockRepository? mockRepository;

        private Mock<IAccountRepository> mockAccountRepository;

        [SetUp]
        public void SetUp()
        {
            this.mockRepository = new MockRepository(MockBehavior.Strict);

            this.mockAccountRepository = this.mockRepository.Create<IAccountRepository>();
        }

        private AccountService CreateService()
        {
            return new AccountService(
                this.mockAccountRepository.Object);
        }

        [Test]
        public void GetBalance_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var service = this.CreateService();
            string accountId = null;

            // Act
            var result = service.GetBalance(
                accountId);

            // Assert
            Assert.Fail();
            mockRepository.VerifyAll();
        }

        [Test]
        public void Deposit_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var service = this.CreateService();

            // Act
            service.Deposit(
                "2",1);

            // Assert
            Assert.Fail();
            this.mockRepository.VerifyAll();
        }

        [Test]
        public void Withdraw_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var service = this.CreateService();

            // Act
            service.Withdraw(
                "2",1);

            // Assert
            Assert.Fail();
            this.mockRepository.VerifyAll();
        }

        [Test]
        public void Transfer_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var service = this.CreateService();
            string originAccountId = null;
            string destinationAccountId = null;
            int amount = 0;

            // Act
            service.Transfer(
                originAccountId,
                destinationAccountId,
                amount);

            // Assert
            Assert.Fail();
            this.mockRepository.VerifyAll();
        }
    }
}
