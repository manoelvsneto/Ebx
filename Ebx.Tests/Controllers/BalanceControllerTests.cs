using Ebx.Service;
using Ebx.WebApi.Controllers;
using Moq;
using NUnit.Framework;
using System;

namespace Ebx.Tests.Controllers
{
    [TestFixture]
    public class BalanceControllerTests
    {
        private MockRepository mockRepository;

        private Mock<IAccountService> mockAccountService;

        [SetUp]
        public void SetUp()
        {
            this.mockRepository = new MockRepository(MockBehavior.Strict);

            this.mockAccountService = this.mockRepository.Create<IAccountService>();
        }

        private BalanceController CreateBalanceController()
        {
            return new BalanceController(
                this.mockAccountService.Object);
        }

        [Test]
        public void GetBalance_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var balanceController = this.CreateBalanceController();
            string account_id = null;

            // Act
            var result = balanceController.GetBalance(
                account_id);

            // Assert
            Assert.Fail();
            this.mockRepository.VerifyAll();
        }
    }
}
