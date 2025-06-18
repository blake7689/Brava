using AngleSharp.Html.Parser;
using Microsoft.AspNetCore.Mvc.Testing;
using System.Net;
using System.Threading.Tasks;
using Xunit;

namespace BravaTests.Integration
{
    public class ScienceIndexPageTests : IClassFixture<WebApplicationFactory<Program>>
    {
        private readonly WebApplicationFactory<Program> _factory;

        public ScienceIndexPageTests(WebApplicationFactory<Program> factory)
        {
            _factory = factory;
        }

        [Fact]
        public async Task Science_Index_Renders_Expected_Sections_And_Content()
        {
            // Arrange
            var client = _factory.CreateClient();

            // Act
            var response = await client.GetAsync("/Science");
            var html = await response.Content.ReadAsStringAsync();

            // Assert
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);

            var parser = new HtmlParser();
            var document = parser.ParseDocument(html);

            // Hero section
            var heroHeader = document.QuerySelector(".science-hero h1");
            Assert.NotNull(heroHeader);
            Assert.False(string.IsNullOrWhiteSpace(heroHeader.TextContent));

            var heroContent = document.QuerySelector(".science-hero p.lead");
            Assert.NotNull(heroContent);
            Assert.False(string.IsNullOrWhiteSpace(heroContent.TextContent));

            // Section 1
            var section1Header = document.QuerySelector(".science-content h2");
            Assert.NotNull(section1Header);

            // Section 2
            var section2Header = document.QuerySelectorAll(".science-content h2");
            Assert.True(section2Header.Length >= 2);

            // Call to action
            var ctaHeader = document.QuerySelector(".call-to-action h3");
            Assert.NotNull(ctaHeader);
            Assert.False(string.IsNullOrWhiteSpace(ctaHeader.TextContent));

            var ctaButton = document.QuerySelector(".call-to-action a.btn");
            Assert.NotNull(ctaButton);
            Assert.Contains("Shop", ctaButton.TextContent);
        }

        [Fact]
        public async Task Science_Index_Contains_Expected_ViewData_Content()
        {
            var client = _factory.CreateClient();
            var response = await client.GetAsync("/Science");
            var html = await response.Content.ReadAsStringAsync();

            // Example: Check for key ViewData content (adjust as needed)
            Assert.Contains("The Science Behind Brava", html);
            Assert.Contains("Optimal Hydration Formula", html);
            Assert.Contains("Clean, Natural Ingredients", html);
            Assert.Contains("Backed by Research", html);
            Assert.Contains("Ready to experience hydration science", html);
        }
    }
}
