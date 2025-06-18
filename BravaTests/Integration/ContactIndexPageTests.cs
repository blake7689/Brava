using AngleSharp.Html.Parser;
using Microsoft.AspNetCore.Mvc.Testing;
using System.Net;

namespace BravaTests.Integration
{
    public class ContactIndexPageTests : IClassFixture<WebApplicationFactory<Program>>
    {
        private readonly WebApplicationFactory<Program> _factory;

        public ContactIndexPageTests(WebApplicationFactory<Program> factory)
        {
            _factory = factory;
        }

        [Fact]
        public async Task Contact_Index_Renders_Expected_Form_And_Elements()
        {
            // Arrange
            var client = _factory.CreateClient();

            // Act
            var response = await client.GetAsync("/Contact");
            var html = await response.Content.ReadAsStringAsync();

            // Assert
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);

            var parser = new HtmlParser();
            var document = parser.ParseDocument(html);

            // Check for main header
            var header = document.QuerySelector("h2.text-center");
            Assert.NotNull(header);
            Assert.Contains("Contact Us", header.TextContent);

            // Check for form
            var form = document.QuerySelector("form");
            Assert.NotNull(form);

            // Check for Name input
            var nameInput = document.QuerySelector("input[name='Name']");
            Assert.NotNull(nameInput);

            // Check for Email input
            var emailInput = document.QuerySelector("input[name='Email']");
            Assert.NotNull(emailInput);
            Assert.Equal("email", emailInput.GetAttribute("type"));

            // Check for Message textarea
            var messageTextarea = document.QuerySelector("textarea[name='Message']");
            Assert.NotNull(messageTextarea);

            // Check for submit button
            var submitButton = document.QuerySelector("button[type='submit']");
            Assert.NotNull(submitButton);
            Assert.Contains("Send Message", submitButton.TextContent);
        }

        [Fact]
        public async Task Contact_Index_Contains_Expected_Static_Text()
        {
            var client = _factory.CreateClient();
            var response = await client.GetAsync("/Contact");
            var html = await response.Content.ReadAsStringAsync();

            Assert.Contains("Contact Us", html);
            Assert.Contains("Your full name", html);
            Assert.Contains("yourname@example.com", html);
            Assert.Contains("Write your message here", html);
            Assert.Contains("Send Message", html);
        }
    }
}