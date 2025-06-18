using Brava.Controllers;
using BravaTests.Mocks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Moq;

namespace BravaTests.Controllers
{
    public class ScienceControllerTests
    {
        [Fact]
        public void Index_ReturnsViewData()
        {
            // Arrange
            var infoService = RepositoryMocks.GetInfoService();
            var mockLogger = new Mock<ILogger<ScienceController>>();
            var scienceController = new ScienceController(infoService, mockLogger.Object);
            var expectedContent = infoService.GetScience();

            // Act
            var result = scienceController.Index();

            // Assert
            var viewResult = Assert.IsType<ViewResult>(result);
            foreach (var kvp in expectedContent)
            {
                Assert.True(viewResult.ViewData.ContainsKey(kvp.Key));
                Assert.Equal(kvp.Value, viewResult.ViewData[kvp.Key]);
            }
        }

        [Fact]
        public void Index_ReturnsView_WhenNoException()
        {
            // Arrange
            var infoService = RepositoryMocks.GetInfoService();
            var mockLogger = new Mock<ILogger<ScienceController>>();
            var scienceController = new ScienceController(infoService, mockLogger.Object);

            // Act
            var result = scienceController.Index();

            // Assert
            var viewResult = Assert.IsType<ViewResult>(result);
            Assert.Null(viewResult.ViewName); // Default view
        }

        [Fact]
        public void Index_ReturnsErrorView_OnException()
        {
            // Arrange
            var infoService = RepositoryMocks.GetErrorInfoService();
            var loggerMock = new Mock<ILogger<ScienceController>>();
            var controller = new ScienceController(infoService, loggerMock.Object);

            // Act
            var result = controller.Index();

            // Assert
            var viewResult = Assert.IsType<ViewResult>(result);
            Assert.Equal("Error", viewResult.ViewName);
        }

        [Fact]
        public void Index_LogsError_OnException()
        {
            // Arrange
            var infoService = RepositoryMocks.GetErrorInfoService();
            var loggerMock = new Mock<ILogger<ScienceController>>();
            var controller = new ScienceController(infoService, loggerMock.Object);

            // Act
            controller.Index();

            // Assert
            loggerMock.Verify(
                l => l.Log(
                    LogLevel.Error,
                    It.IsAny<EventId>(),
                    It.Is<It.IsAnyType>((v, t) => v.ToString().Contains("Error retrieving science content")),
                    It.IsAny<Exception>(),
                    It.IsAny<Func<It.IsAnyType, Exception, string>>()
                ),
                Times.Once
            );
        }
    }
}