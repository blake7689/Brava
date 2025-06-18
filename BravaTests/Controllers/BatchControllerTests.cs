using Brava.Controllers.Api;
using Brava.Models;
using BravaTests.Mocks;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Microsoft.Extensions.Logging;

namespace BravaTests.Controllers
{
    public class BatchControllerTests
    {
        [Fact]
        public void GetBatchJson_ReturnsBadRequest_WhenBatchNumberIsNullOrEmpty()
        {
            var mockBatchRepository = RepositoryMocks.GetBatchRepository();
            var mockLogger = new Mock<ILogger<BatchController>>();
            var batchController = new BatchController(mockBatchRepository.Object, mockLogger.Object);

            string? nullBatchNumber = null;
            var result1 = batchController.GetBatchJson(nullBatchNumber);
            var result2 = batchController.GetBatchJson("");
            var result3 = batchController.GetBatchJson("   ");

            Assert.IsType<BadRequestObjectResult>(result1);
            Assert.IsType<BadRequestObjectResult>(result2);
            Assert.IsType<BadRequestObjectResult>(result3);
        }

        [Fact]
        public void GetBatchJson_ReturnsNotFound_WhenBatchDoesNotExist()
        {
            var mockBatchRepository = RepositoryMocks.GetBatchRepository();
            var mockLogger = new Mock<ILogger<BatchController>>();
            var batchController = new BatchController(mockBatchRepository.Object, mockLogger.Object);

            var result = batchController.GetBatchJson("NONEXISTENT");

            var notFound = Assert.IsType<NotFoundObjectResult>(result);
            Assert.NotNull(notFound.Value);
            Assert.Contains("Batch not found", notFound.Value!.ToString());
        }

        [Fact]
        public void GetBatchJson_ReturnsJsonResult_WhenBatchExists()
        {
            var mockBatchRepository = RepositoryMocks.GetBatchRepository();
            var mockLogger = new Mock<ILogger<BatchController>>();
            var batchController = new BatchController(mockBatchRepository.Object, mockLogger.Object);

            var result = batchController.GetBatchJson("1234A");

            var jsonResult = Assert.IsType<JsonResult>(result);
            var batch = Assert.IsType<Batch>(jsonResult.Value);
            Assert.Equal("1234A", batch.BatchNumber);
        }

        [Fact]
        public void GetBatchJson_IsCaseInsensitive_ForBatchNumber()
        {
            var mockBatchRepository = RepositoryMocks.GetBatchRepository();
            var mockLogger = new Mock<ILogger<BatchController>>();
            var batchController = new BatchController(mockBatchRepository.Object, mockLogger.Object);

            var result = batchController.GetBatchJson("1234a");

            var jsonResult = Assert.IsType<JsonResult>(result);
            var batch = Assert.IsType<Batch>(jsonResult.Value);
            Assert.Equal("1234A", batch.BatchNumber);
        }

        [Fact]
        public void GetBatchJson_ReturnsCorrectBatch_ForDifferentBatchNumbers()
        {
            var mockBatchRepository = RepositoryMocks.GetBatchRepository();
            var mockLogger = new Mock<ILogger<BatchController>>();
            var batchController = new BatchController(mockBatchRepository.Object, mockLogger.Object);

            var result = batchController.GetBatchJson("1234B");

            var jsonResult = Assert.IsType<JsonResult>(result);
            var batch = Assert.IsType<Batch>(jsonResult.Value);
            Assert.Equal("1234B", batch.BatchNumber);
        }
    }
}