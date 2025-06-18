using AngleSharp.Html.Parser;
using Microsoft.AspNetCore.Mvc.Testing;
using System.Net;
using System.Threading.Tasks;
using Xunit;

namespace BravaTests.Integration
{
    public class PrivacyIndexPageTests : IClassFixture<WebApplicationFactory<Program>>
    {
        private readonly WebApplicationFactory<Program> _factory;

        public PrivacyIndexPageTests(WebApplicationFactory<Program> factory)
        {
            _factory = factory;
        }

        [Fact]
        public async Task Privacy_Index_Renders_Expected_Sections_And_Content()
        {
            // Arrange
            var client = _factory.CreateClient();

            // Act
            var response = await client.GetAsync("/Privacy");
            var html = await response.Content.ReadAsStringAsync();

            // Assert
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);

            var parser = new HtmlParser();
            var document = parser.ParseDocument(html);

            // Main header
            var header = document.QuerySelector("h1.text-center");
            Assert.NotNull(header);
            Assert.Contains("Privacy", header.TextContent, System.StringComparison.OrdinalIgnoreCase);

            // Section headers
            var sectionHeaders = document.QuerySelectorAll(".privacy-content h4");
            Assert.True(sectionHeaders.Length >= 8);

            // Contact email
            Assert.Contains("support@brava.com", html);
        }

        [Fact]
        public async Task Privacy_Index_Contains_Expected_Static_Text()
        {
            var client = _factory.CreateClient();
            var response = await client.GetAsync("/Privacy");
            var html = await response.Content.ReadAsStringAsync();

            Assert.Contains("Privacy Policy", html);
            Assert.Contains("Overview", html);
            Assert.Contains("Personal Information", html);
            Assert.Contains("How We Use Your Personal Information", html);
            Assert.Contains("Sharing Your Personal Information", html);
            Assert.Contains("Your Rights", html);
            Assert.Contains("Cookies", html);
            Assert.Contains("Data Retention", html);
            Assert.Contains("Changes to This Policy", html);
        }
    }
}