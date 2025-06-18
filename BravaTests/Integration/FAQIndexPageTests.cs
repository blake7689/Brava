using AngleSharp.Html.Parser;
using Microsoft.AspNetCore.Mvc.Testing;
using System.Net;

namespace BravaTests.Integration
{
    public class FAQIndexPageTests : IClassFixture<WebApplicationFactory<Program>>
    {
        private readonly WebApplicationFactory<Program> _factory;

        public FAQIndexPageTests(WebApplicationFactory<Program> factory)
        {
            _factory = factory;
        }

        [Fact]
        public async Task FAQ_Index_Renders_Expected_Elements()
        {
            // Arrange
            var client = _factory.CreateClient();

            // Act
            var response = await client.GetAsync("/FAQ");
            var html = await response.Content.ReadAsStringAsync();

            // Assert
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);

            var parser = new HtmlParser();
            var document = parser.ParseDocument(html);

            // Search bar
            var searchBar = document.QuerySelector("input#faqSearch.faq-search-bar");
            Assert.NotNull(searchBar);
            Assert.Equal("Search FAQs...", searchBar.GetAttribute("placeholder"));

            // Category list
            var categoryList = document.QuerySelector("#categoryList");
            Assert.NotNull(categoryList);

            // At least one category link
            var categoryLinks = document.QuerySelectorAll("#categoryList a.list-group-item");
            Assert.NotEmpty(categoryLinks);

            // At least one FAQ category section
            var faqCategories = document.QuerySelectorAll(".faq-category");
            Assert.NotEmpty(faqCategories);

            // At least one accordion item (FAQ)
            var faqItems = document.QuerySelectorAll(".accordion-item.faq-item");
            Assert.NotEmpty(faqItems);
        }

        [Fact]
        public async Task FAQ_Index_Contains_Expected_Static_Text()
        {
            var client = _factory.CreateClient();
            var response = await client.GetAsync("/FAQ");
            var html = await response.Content.ReadAsStringAsync();

            Assert.Contains("Search FAQs", html);
            Assert.Contains("FAQ", html, System.StringComparison.OrdinalIgnoreCase);
        }
    }
}