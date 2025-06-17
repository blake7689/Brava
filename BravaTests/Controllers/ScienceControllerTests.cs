using Brava.Controllers;
using Brava.ViewModels;
using BravaTests.Mocks;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BravaTests.Controllers
{
    public class ScienceControllerTests
    {
        [Fact]
        public void Index_ReturnsViewData()
        {
            //arrange
            var infoService = RepositoryMocks.GetInfoService();
            var scienceController = new ScienceController(infoService);
            var expectedContent = infoService.GetScience();

            //act
            var result = scienceController.Index();

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
