using Ebx.Data;
using Ebx.Models;
using Ebx.Repository;
using Moq;
using NUnit.Framework;
using System;

namespace Ebx.Tests
{
    [TestFixture]
    public class AccountRepositoryTests
    {
        private MockRepository mockRepository;

        private Mock<AppDbContext> mockAppDbContext;

        [SetUp]
        public void SetUp()
        {
            this.mockRepository = new MockRepository(MockBehavior.Strict);

            this.mockAppDbContext = this.mockRepository.Create<AppDbContext>();
        }

        private AccountRepository CreateAccountRepository()
        {
            return new AccountRepository(
                this.mockAppDbContext.Object);
        }

        [Test]
        public void GetAll_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var accountRepository = this.CreateAccountRepository();

            // Act
            _ = accountRepository.GetAll();

            // Assert
            Assert.Fail();
            this.mockRepository.VerifyAll();
        }

        [Test]
        public void GetById_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var accountRepository = this.CreateAccountRepository();
            string id = null;

            // Act
            _ = accountRepository.GetById(
                id);

            // Assert
            Assert.Fail();
            this.mockRepository.VerifyAll();
        }

        [Test]
        public void GetList_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var accountRepository = this.CreateAccountRepository();

            // Act
            _ = accountRepository.GetList();

            // Assert
            Assert.Fail();
            this.mockRepository.VerifyAll();
        }

        [Test]
        public void Add_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var accountRepository = this.CreateAccountRepository();
            Account ac = null;

            // Act
            accountRepository.Add(
                ac);

            // Assert
            Assert.Fail();
            this.mockRepository.VerifyAll();
        }

        [Test]
        public void Update_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var accountRepository = this.CreateAccountRepository();
            Account ac = null;

            // Act
            accountRepository.Update(
                ac);

            // Assert
            Assert.Fail();
            this.mockRepository.VerifyAll();
        }

        [Test]
        public void Delete_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var accountRepository = this.CreateAccountRepository();
            Account ac = null;

            // Act
            accountRepository.Delete(
                ac);

            // Assert
            Assert.Fail();
            this.mockRepository.VerifyAll();
        }

        [Test]
        public void DeleteAll_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var accountRepository = this.CreateAccountRepository();

            // Act
            accountRepository.DeleteAll();

            // Assert
            Assert.Fail();
            this.mockRepository.VerifyAll();
        }
    }
}
