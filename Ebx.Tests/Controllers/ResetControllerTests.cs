using Ebx.Service;
using Ebx.WebApi.Controllers;
using Moq;
using NUnit.Framework;

namespace Ebx.Tests.Controllers
{
    [TestFixture]
    public class ResetControllerTests
    {
        private MockRepository? mockRepository;

        private Mock<IAccountService>? mockAccountService;

        [SetUp]
        public void SetUp()
        {
            this.mockRepository = new MockRepository(MockBehavior.Strict);

            this.mockAccountService = this.mockRepository.Create<IAccountService>();
        }

        private ResetController CreateResetController()
        {
            return new ResetController(
                mockAccountService.Object);
        }

        [Test]
        public void ResetAll_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var resetController = this.CreateResetController();

            // Act
            _ = resetController.ResetAll();

            // Assert
            Assert.Fail();
            this.mockRepository.VerifyAll();
        }
    }
}
