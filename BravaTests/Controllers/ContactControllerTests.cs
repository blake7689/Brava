using Brava.Controllers;
using Brava.Interfaces;
using Brava.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Moq;

namespace BravaTests.Controllers
{
    public class ContactControllerTests
    {
        [Fact]
        public void Index_Get_ReturnsView()
        {
            // Arrange
            var loggerMock = new Mock<ILogger<ContactController>>();
            var emailServiceMock = new Mock<IEmailService>();
            var controller = new ContactController(loggerMock.Object, emailServiceMock.Object);

            // Act
            var result = controller.Index();

            // Assert
            Assert.IsType<ViewResult>(result);
        }

        [Fact]
        public void Index_Get_ReturnsErrorView_OnException()
        {
            // Arrange
            var loggerMock = new Mock<ILogger<ContactController>>();
            var emailServiceMock = new Mock<IEmailService>();
            var controllerMock = new Mock<ContactController>(loggerMock.Object, emailServiceMock.Object) { CallBase = true };
            controllerMock.Setup(c => c.View()).Throws(new Exception("View error"));

            // Act
            var result = controllerMock.Object.Index();

            // Assert
            var viewResult = Assert.IsType<ViewResult>(result);
            Assert.Equal("Error", viewResult.ViewName);
        }

        [Fact]
        public void Index_Post_ReturnsViewWithSuccessMessage_WhenModelIsValid_AndEmailSent()
        {
            var loggerMock = new Mock<ILogger<ContactController>>();
            var emailServiceMock = new Mock<IEmailService>();
            var controller = new ContactController(loggerMock.Object, emailServiceMock.Object);

            var model = new ContactFormModel
            {
                Name = "Test User",
                Email = "test@example.com",
                Message = "Hello!"
            };

            var result = controller.Index(model);

            var viewResult = Assert.IsType<ViewResult>(result);
            Assert.Equal("Your message has been sent!", viewResult.ViewData["Message"]);
            emailServiceMock.Verify(e => e.Send(
                "bravanutrients@gmail.com",
                "Brava Contact Form Submission",
                It.Is<string>(body => body.Contains("Test User") && body.Contains("Hello!"))
            ), Times.Once);
        }

        [Fact]
        public void Index_Post_ReturnsViewWithModelErrors_WhenModelIsInvalid()
        {
            var loggerMock = new Mock<ILogger<ContactController>>();
            var emailServiceMock = new Mock<IEmailService>();
            var controller = new ContactController(loggerMock.Object, emailServiceMock.Object);
            controller.ModelState.AddModelError("Email", "Email is required");

            var model = new ContactFormModel
            {
                Name = "Test User",
                Email = "",
                Message = "Hello!"
            };

            var result = controller.Index(model);

            var viewResult = Assert.IsType<ViewResult>(result);
            Assert.False(viewResult.ViewData.ModelState.IsValid);
            Assert.Equal(model, viewResult.Model);
        }

        [Fact]
        public void Index_Post_ReturnsErrorView_OnException()
        {
            var loggerMock = new Mock<ILogger<ContactController>>();
            var emailServiceMock = new Mock<IEmailService>();
            var controllerMock = new Mock<ContactController>(loggerMock.Object, emailServiceMock.Object) { CallBase = true };
            var model = new ContactFormModel
            {
                Name = "Test User",
                Email = "test@example.com",
                Message = "Hello!"
            };

            controllerMock.Setup(c => c.View(model)).Throws(new Exception("View error"));

            var result = controllerMock.Object.Index(model);

            var viewResult = Assert.IsType<ViewResult>(result);
            Assert.True(viewResult.ViewName == "Error" || viewResult.ViewName == null);
        }
    }
}
