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
    public class TermsControllerTests
    {
        [Fact]
        public void Index_ReturnsViewData()
        {
            //arrange
            var infoService = RepositoryMocks.GetInfoService();
            var mockLogger = new Mock<ILogger<TermsController>>();
            var termsController = new TermsController(infoService, mockLogger.Object);
            var expectedContent = infoService.GetTerms();

            //act
            var result = termsController.Index();

            // Assert
            var viewResult = Assert.IsType<ViewResult>(result);

            foreach (var kvp in expectedContent)
            {
                Assert.True(viewResult.ViewData.ContainsKey(kvp.Key));
                Assert.Equal(kvp.Value, viewResult.ViewData[kvp.Key]);
            }
        }
    }
}
