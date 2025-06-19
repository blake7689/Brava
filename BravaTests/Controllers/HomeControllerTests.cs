using Brava.Controllers;
using Brava.ViewModels;
using BravaTests.Mocks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Moq;

namespace BravaTests.Controllers
{
    public class HomeControllerTests
    {
        [Fact]
        public void Index_ReturnsView_WithHomeViewModel_AndViewData()
        {
            // Arrange
            var infoService = InfoServiceMocks.GetInfoService();
            var loggerMock = new Mock<ILogger<HomeController>>();
            var mockGummieRepository = GummieRepositoryMocks.GetGummieRepository();
            var homeController = new HomeController(mockGummieRepository.Object, infoService, loggerMock.Object);

            // Act
            var result = homeController.Index();

            // Assert
            var viewResult = Assert.IsType<ViewResult>(result);
            var model = Assert.IsType<HomeViewModel>(viewResult.Model);
            Assert.NotNull(model.Gummies);
            Assert.Equal(mockGummieRepository.Object.AllGummies.Count(), model.Gummies.Count());

            // Check ViewData contains all keys from infoService.GetHome()
            var expectedContent = infoService.GetHome();
            foreach (var kvp in expectedContent)
            {
                Assert.True(viewResult.ViewData.ContainsKey(kvp.Key));
                Assert.Equal(kvp.Value, viewResult.ViewData[kvp.Key]);
            }
        }

        [Fact]
        public void Index_ReturnsErrorView_OnException_GummieRepository()
        {
            // Arrange
            var infoService = InfoServiceMocks.GetInfoService();
            var loggerMock = new Mock<ILogger<HomeController>>();
            var mockGummieRepository = GummieRepositoryMocks.GetErrorGummieRepository();
            var homeController = new HomeController(mockGummieRepository.Object, infoService, loggerMock.Object);

            // Act
            var result = homeController.Index();

            // Assert
            var viewResult = Assert.IsType<ViewResult>(result);
            Assert.Equal("Error", viewResult.ViewName);
        }

        [Fact]
        public void Index_ReturnsErrorView_OnException_InfoService()
        {
            // Arrange
            var infoService = InfoServiceMocks.GetErrorInfoService();
            var loggerMock = new Mock<ILogger<HomeController>>();
            var mockGummieRepository = GummieRepositoryMocks.GetGummieRepository();
            var controller = new HomeController(mockGummieRepository.Object, infoService, loggerMock.Object);

            // Act
            var result = controller.Index();

            // Assert
            var viewResult = Assert.IsType<ViewResult>(result);
            Assert.Equal("Error", viewResult.ViewName);
        }

        [Fact]
        public void Index_LogsError_OnException_InfoService()
        {
            // Arrange
            var infoService = InfoServiceMocks.GetErrorInfoService();
            var loggerMock = new Mock<ILogger<HomeController>>();
            var mockGummieRepository = GummieRepositoryMocks.GetGummieRepository();
            var controller = new HomeController(mockGummieRepository.Object, infoService, loggerMock.Object);

            // Act
            controller.Index();

            // Assert
            loggerMock.Verify(
                l => l.Log(
                    LogLevel.Error,
                    It.IsAny<EventId>(),
                    It.Is<It.IsAnyType>((v, t) => v.ToString().Contains("An error occurred while loading the home page.")),
                    It.IsAny<Exception>(),
                    It.IsAny<Func<It.IsAnyType, Exception, string>>()
                ),
                Times.Once
            );
        }
    }
}