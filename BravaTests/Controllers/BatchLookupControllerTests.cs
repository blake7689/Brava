using Brava.Controllers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Moq;

namespace BravaTests.Controllers
{
    public class BatchLookupControllerTests
    {
        [Fact]
        public void Index_ReturnsView()
        {
            // Arrange
            var mockLogger = new Mock<ILogger<BatchLookupController>>();
            var batchLookupController = new BatchLookupController(mockLogger.Object);

            // Act
            var result = batchLookupController.Index();

            // Assert
            Assert.IsType<ViewResult>(result);
        }

        [Fact]
        public void Index_ReturnsErrorView_OnException()
        {
            // Arrange
            var mockLogger = new Mock<ILogger<BatchLookupController>>();
            var batchLookupControllerMock = new Mock<BatchLookupController>(mockLogger.Object) { CallBase = true };
            batchLookupControllerMock.Setup(c => c.View()).Throws(new Exception("View error"));

            // Act
            var result = batchLookupControllerMock.Object.Index();

            // Assert
            var viewResult = Assert.IsType<ViewResult>(result);
            Assert.Equal("Error", viewResult.ViewName);
        }

        [Fact]
        public void Index_LogsError_OnException()
        {
            // Arrange
            var loggerMock = new Mock<ILogger<BatchLookupController>>();
            var batchLookupControllerMock = new Mock<BatchLookupController>(loggerMock.Object) { CallBase = true };
            batchLookupControllerMock.Setup(c => c.View()).Throws(new Exception("View error"));

            // Act
            batchLookupControllerMock.Object.Index();

            // Assert
            loggerMock.Verify(
                l => l.Log(
                    LogLevel.Error,
                    It.IsAny<EventId>(),
                    It.Is<It.IsAnyType>((v, t) => v.ToString().Contains("Error in BatchLookupController.Index")),
                    It.IsAny<Exception>(),
                    It.IsAny<Func<It.IsAnyType, Exception, string>>()
                ),
                Times.Once
            );
        }
    }
}
