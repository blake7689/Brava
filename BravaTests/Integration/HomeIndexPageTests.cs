using AngleSharp.Html.Parser;
using Microsoft.AspNetCore.Mvc.Testing;
using System.Net;
using System.Threading.Tasks;
using Xunit;

namespace BravaTests.Integration
{
    public class HomeIndexPageTests : IClassFixture<WebApplicationFactory<Program>>
    {
        private readonly WebApplicationFactory<Program> _factory;

        public HomeIndexPageTests(WebApplicationFactory<Program> factory)
        {
            _factory = factory;
        }

        [Fact]
        public async Task Home_Index_Renders_Expected_Elements()
        {
            // Arrange
            var client = _factory.CreateClient();

            // Act
            var response = await client.GetAsync("/");
            var html = await response.Content.ReadAsStringAsync();

            // Assert
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);

            var parser = new HtmlParser();
            var document = parser.ParseDocument(html);

            // Check for a main banner/header
            var banner = document.QuerySelector(".video-banner, .overlay, shop-now-button-banner");
            Assert.NotNull(banner);

            // Check for at least one gummie card 
            var gummieCard = document.QuerySelector(".gummie-card, .gummie, .gummie-list");
            Assert.NotNull(gummieCard);

            // Check for FAQ or benefits section if present
            var faqSection = document.QuerySelector(".faq-section, #faq, .faq");
            Assert.NotNull(faqSection);

            // Check for ViewData content 
            Assert.Contains("Brava", html); 
        }

        [Fact]
        public async Task Home_Index_Contains_Expected_ViewData_Content()
        {
            var client = _factory.CreateClient();
            var response = await client.GetAsync("/");
            var html = await response.Content.ReadAsStringAsync();

            Assert.Contains("Welcome to Brava", html);
            Assert.Contains("Creatine Gummies", html);
            Assert.Contains("Meet the best creatine supplement", html);
        }
    }
}
