using Brava.Controllers;
using Brava.Controllers.Api;
using BravaTests.Mocks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BravaTests.Controllers
{
    public class BatchLookupControllerTests
    {
        [Fact]
        public void Index_ReturnsViewData()
        {
            //arrange
            var mockLogger = new Mock<ILogger<BatchLookupController>>();
            var batchLookupControler = new BatchLookupController(mockLogger.Object);

            //act
            var result = batchLookupControler.Index();

            //Assert
            Assert.IsType<ViewResult>(result);
        }
    }
}
