using Moq;
using SSC.Eshop.Business.DTOs;
using SSC.Eshop.Business.Services.UserService;
using SSC.EShop.Core.Entities;
using SSC.EShop.Core.Interfaces;
using System.Linq.Expressions;
using NUnit.Framework.Legacy;

namespace SSC.EShop.Tests
{
    public class UserServiceTests
    {
        private Mock<IUserRepository> _userRepositoryMock;
        private Mock<IUnitOfWork> _unitOfWorkMock;
        private Mock<IAppLogger<UserService>> _loggerMock;

        private UserService _userService;

        [SetUp]
        public void Setup()
        {
            _userRepositoryMock = new Mock<IUserRepository>();
            _unitOfWorkMock = new Mock<IUnitOfWork>();
            _loggerMock = new Mock<IAppLogger<UserService>>();

            _userService = new UserService(
                _userRepositoryMock.Object,
                _loggerMock.Object,
                _unitOfWorkMock.Object
            );
        }

        [Test]
        public async Task RegisterAsync_ShouldReturnTrue_WhenUserIsNew()
        {
            // Arrange (Підготовка)
            var dto = new CreateUserDto { Login = "new_user", FirstName = "Test", Password = "123" };

            _userRepositoryMock
                .Setup(repo => repo.GetByConditionAsync(It.IsAny<Expression<Func<User, bool>>>()))
                .ReturnsAsync(new List<User>());

            // Act (Дія)
            var result = await _userService.RegisterAsync(dto);

            // Assert (Перевірка)
            Assert.That(result, Is.True);

            
            _userRepositoryMock.Verify(repo => repo.InsertAsync(It.IsAny<User>()), Times.Once);
            _unitOfWorkMock.Verify(uow => uow.SaveChangesAsync(), Times.Once);
        }
    }
}
