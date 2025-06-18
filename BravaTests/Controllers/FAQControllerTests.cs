using Brava.Controllers;
using Brava.Models;
using BravaTests.Mocks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Moq;

namespace BravaTests.Controllers
{
    public class FAQControllerTests
    {
        [Fact]
        public void Index_ReturnsCategories_WhenGivenCategories()
        {
            //arrange
            var mockFAQCategoryRepository = RepositoryMocks.GetFAQCategoryRepository();
            var loggerMock = new Mock<ILogger<FAQController>>();
            var expectedCategories = mockFAQCategoryRepository.Object.AllFAQCategories.ToList();
            var faqController = new FAQController(mockFAQCategoryRepository.Object, loggerMock.Object);

            //act
            var result = faqController.Index();

            //assert
            var viewResult = Assert.IsType<ViewResult>(result);
            var model = Assert.IsAssignableFrom<List<FAQCategory>>(viewResult.Model);
            Assert.NotNull(model);
            Assert.Equal(expectedCategories.Count, model.Count);

            for (int i = 0; i < expectedCategories.Count; i++)
            {
                Assert.Equal(expectedCategories[i].FAQCategoryId, model[i].FAQCategoryId);
                Assert.Equal(expectedCategories[i].Category, model[i].Category);
            }
        }

        [Fact]
        public void Index_ReturnsEmptyList_WhenNoCategoriesExist()
        {
            // Arrange
            var mockFAQCategoryRepository = RepositoryMocks.GetEmptyFAQCategoryRepository();
            var loggerMock = new Mock<ILogger<FAQController>>();
            var faqController = new FAQController(mockFAQCategoryRepository.Object, loggerMock.Object);

            // Act
            var result = faqController.Index();

            // Assert
            var viewResult = Assert.IsType<ViewResult>(result);
            var model = Assert.IsAssignableFrom<List<FAQCategory>>(viewResult.Model);
            Assert.Empty(model);
        }

        [Fact]
        public void Index_ReturnsEmptyList_WhenRepositoryReturnsNull()
        {
            // Arrange
            var mockFAQCategoryRepository = RepositoryMocks.GetNullFAQCategoryRepository();
            var loggerMock = new Mock<ILogger<FAQController>>();
            var faqController = new FAQController(mockFAQCategoryRepository.Object, loggerMock.Object);

            // Act
            var result = faqController.Index();

            // Assert
            var viewResult = Assert.IsType<ViewResult>(result);
            var model = Assert.IsAssignableFrom<List<FAQCategory>>(viewResult.Model);
            Assert.Empty(model);
        }

        [Fact]
        public void Index_ReturnsErrorView_WhenRepositoryThrows()
        {
            // Arrange 
            var mockFAQCategoryRepository = RepositoryMocks.GetExceptionFAQCategoryRepository();
            var loggerMock = new Mock<ILogger<FAQController>>();
            var faqController = new FAQController(mockFAQCategoryRepository.Object, loggerMock.Object);

            // Act
            var result = faqController.Index();

            // Assert
            var viewResult = Assert.IsType<ViewResult>(result);
            Assert.Equal("Error", viewResult.ViewName);
        }

        [Fact]
        public void Index_SetsFaqHeaderInViewData()
        {
            // Arrange
            var mockFAQCategoryRepository = RepositoryMocks.GetFAQCategoryRepository();
            var loggerMock = new Mock<ILogger<FAQController>>();
            var faqController = new FAQController(mockFAQCategoryRepository.Object, loggerMock.Object);

            // Act
            var result = faqController.Index();

            // Assert
            var viewResult = Assert.IsType<ViewResult>(result);
            Assert.Equal("Frequently Asked Questions", viewResult.ViewData["faqHeader"]);
        }

        [Fact]
        public void Index_ReturnsAllCategories_WithLargeDataset()
        {
            // Arrange
            var mockFAQCategoryRepository = RepositoryMocks.GetLargeFAQCategoryRepository();
            var loggerMock = new Mock<ILogger<FAQController>>();
            var expectedCategories = mockFAQCategoryRepository.Object.AllFAQCategories.ToList();
            var faqController = new FAQController(mockFAQCategoryRepository.Object, loggerMock.Object);

            // Act
            var result = faqController.Index();

            // Assert
            var viewResult = Assert.IsType<ViewResult>(result);
            var model = Assert.IsAssignableFrom<List<FAQCategory>>(viewResult.Model);
            Assert.Equal(1000, model.Count);
            for (int i = 0; i < 1000; i++)
            {
                Assert.Equal(expectedCategories[i].FAQCategoryId, model[i].FAQCategoryId);
                Assert.Equal(expectedCategories[i].Category, model[i].Category);
            }
        }

        [Fact]
        public void Index_ReturnsCategories_WithSpecialCharacters()
        {
            // Arrange
            var mockFAQCategoryRepository = RepositoryMocks.GetLargeFAQCategoryRepository();
            var loggerMock = new Mock<ILogger<FAQController>>();
            var expectedCategories = mockFAQCategoryRepository.Object.AllFAQCategories.ToList();
            var faqController = new FAQController(mockFAQCategoryRepository.Object, loggerMock.Object);

            // Act
            var result = faqController.Index();

            // Assert
            var viewResult = Assert.IsType<ViewResult>(result);
            var model = Assert.IsAssignableFrom<List<FAQCategory>>(viewResult.Model);
            Assert.Equal(expectedCategories.Count, model.Count);
            for (int i = 0; i < expectedCategories.Count; i++)
            {
                Assert.Equal(expectedCategories[i].FAQCategoryId, model[i].FAQCategoryId);
                Assert.Equal(expectedCategories[i].Category, model[i].Category);
            }
        }
    }
}