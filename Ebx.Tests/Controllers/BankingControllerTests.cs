using Ebx.Service;
using Ebx.WebApi.Controllers;
using Moq;
using NUnit.Framework;
using System;
using static Ebx.Models.Event;

namespace Ebx.Tests.Controllers
{
    [TestFixture]
    public class BankingControllerTests
    {
        private MockRepository mockRepository;

        private Mock<IAccountService> mockAccountService;

        [SetUp]
        public void SetUp()
        {
            this.mockRepository = new MockRepository(MockBehavior.Strict);

            this.mockAccountService = this.mockRepository.Create<IAccountService>();
        }

        private BankingController CreateBankingController()
        {
            return new BankingController(
                this.mockAccountService.Object);
        }

        [Test]
        public void Post_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var bankingController = this.CreateBankingController();
            Request request = null;

            // Act
            var result = bankingController.Post(
                request);

            // Assert
            Assert.Fail();
            this.mockRepository.VerifyAll();
        }
    }
}
