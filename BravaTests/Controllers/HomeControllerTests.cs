using Brava.Controllers;
using Brava.Services;
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
    public class HomeControllerTests
    {
        [Fact]
        public void Index_ReturnsGummie()
        {
            //arrange
            var mockGummieRepository = RepositoryMocks.GetGummieRepository();
            var infoService = RepositoryMocks.GetInfoService();
            var homeController = new HomeController(mockGummieRepository.Object, infoService);

            //act
            var result = homeController.Index();

            //assert
            var viewResult = Assert.IsType<ViewResult>(result);
            var homeViewModel = Assert.IsAssignableFrom<HomeViewModel>(viewResult.ViewData.Model);
            Assert.Single(homeViewModel.Gummies);
        }

        [Fact]
        public void Index_ReturnsViewData()
        {
            //arrange
            var mockGummieRepository = RepositoryMocks.GetGummieRepository();
            var infoService = RepositoryMocks.GetInfoService();
            var homeController = new HomeController(mockGummieRepository.Object, infoService);
            var expectedContent = infoService.GetHome();

            //act
            var result = homeController.Index();

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
