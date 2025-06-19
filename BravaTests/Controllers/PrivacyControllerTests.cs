using Brava.Controllers;
using BravaTests.Mocks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Moq;

namespace BravaTests.Controllers
{
    public class PrivacyControllerTests
    {
        [Fact]
        public void Index_ReturnsViewData()
        {
            // Arrange
            var infoService = InfoServiceMocks.GetInfoService();
            var mockLogger = new Mock<ILogger<PrivacyController>>();
            var privacyController = new PrivacyController(infoService, mockLogger.Object);
            var expectedContent = infoService.GetPrivacy();

            // Act
            var result = privacyController.Index();

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
            var infoService = InfoServiceMocks.GetInfoService();
            var mockLogger = new Mock<ILogger<PrivacyController>>();
            var privacyController = new PrivacyController(infoService, mockLogger.Object);

            // Act
            var result = privacyController.Index();

            // Assert
            var viewResult = Assert.IsType<ViewResult>(result);
            Assert.Null(viewResult.ViewName); // Should return default view
        }

        [Fact]
        public void Index_ReturnsErrorView_OnException()
        {
            // Arrange
            var infoService = InfoServiceMocks.GetErrorInfoService();
            var loggerMock = new Mock<ILogger<PrivacyController>>();
            var privacyController = new PrivacyController(infoService, loggerMock.Object);

            // Act
            var result = privacyController.Index();

            // Assert
            var viewResult = Assert.IsType<ViewResult>(result);
            Assert.Equal("Error", viewResult.ViewName);
        }

        [Fact]
        public void Index_LogsError_OnException()
        {
            // Arrange
            var infoService = InfoServiceMocks.GetErrorInfoService();
            var loggerMock = new Mock<ILogger<PrivacyController>>();
            var privacyController = new PrivacyController(infoService, loggerMock.Object);

            // Act
            privacyController.Index();

            // Assert
            loggerMock.Verify(
                l => l.Log(
                    LogLevel.Error,
                    It.IsAny<EventId>(),
                    It.Is<It.IsAnyType>((v, t) => v.ToString().Contains("Error retrieving privacy content")),
                    It.IsAny<Exception>(),
                    It.IsAny<Func<It.IsAnyType, Exception, string>>()
                ),
                Times.Once
            );
        }
    }
}