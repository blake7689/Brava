using AngleSharp.Html.Parser;
using Microsoft.AspNetCore.Mvc.Testing;
using System.Net;

namespace BravaTests.Integration
{
    public class TermsIndexPageTests : IClassFixture<WebApplicationFactory<Program>>
    {
        private readonly WebApplicationFactory<Program> _factory;

        public TermsIndexPageTests(WebApplicationFactory<Program> factory)
        {
            _factory = factory;
        }

        [Fact]
        public async Task Terms_Index_Renders_Expected_Sections_And_Content()
        {
            // Arrange
            var client = _factory.CreateClient();

            // Act
            var response = await client.GetAsync("/Terms");
            var html = await response.Content.ReadAsStringAsync();

            // Assert
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);

            var parser = new HtmlParser();
            var document = parser.ParseDocument(html);

            // Main header
            var header = document.QuerySelector("h1.text-center, h1, .terms-header");
            Assert.NotNull(header);
            Assert.Contains("Terms", header.TextContent, System.StringComparison.OrdinalIgnoreCase);

            // Section headers (should be at least 7-8 for each section)
            var sectionHeaders = document.QuerySelectorAll("h4");
            Assert.True(sectionHeaders.Length >= 7);

            // Contact email
            Assert.Contains("support@brava.com", html);
        }

        [Fact]
        public async Task Terms_Index_Contains_Expected_Static_Text()
        {
            var client = _factory.CreateClient();
            var response = await client.GetAsync("/Terms");
            var html = await response.Content.ReadAsStringAsync();

            Assert.Contains("Terms of Service", html);
            Assert.Contains("Overview", html);
            Assert.Contains("Online Store Terms", html);
            Assert.Contains("General Conditions", html);
            Assert.Contains("Accuracy, Completeness and Timeliness of Information", html);
            Assert.Contains("Modifications to the Service and Prices", html);
            Assert.Contains("Products or Services", html);
            Assert.Contains("Changes to Terms of Service", html);
        }
    }
}
