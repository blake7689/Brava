using AngleSharp.Html.Parser;
using Microsoft.AspNetCore.Mvc.Testing;
using System.Net;

namespace BravaTests.Integration
{
    public class OurStoryIndexPageTests : IClassFixture<WebApplicationFactory<Program>>
    {
        private readonly WebApplicationFactory<Program> _factory;

        public OurStoryIndexPageTests(WebApplicationFactory<Program> factory)
        {
            _factory = factory;
        }

        [Fact]
        public async Task OurStory_Index_Renders_Expected_Sections_And_Content()
        {
            // Arrange
            var client = _factory.CreateClient();

            // Act
            var response = await client.GetAsync("/OurStory");
            var html = await response.Content.ReadAsStringAsync();

            // Assert
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);

            var parser = new HtmlParser();
            var document = parser.ParseDocument(html);

            // Check for a timeline or journey section
            var timeline = document.QuerySelector(".timeline, .our-journey, .ourstory-timeline");
            Assert.NotNull(timeline);

            // Check for founders or team section
            var founders = document.QuerySelector(".meet-founders");
            Assert.NotNull(founders);

            // Check for values or mission section
            var values = document.QuerySelector(".brand-values");
            Assert.NotNull(values);

            // Brand name should appear somewhere
            Assert.Contains("Brava", html);
        }

        [Fact]
        public async Task OurStory_Index_Contains_Expected_ViewData_Content()
        {
            var client = _factory.CreateClient();
            var response = await client.GetAsync("/OurStory");
            var html = await response.Content.ReadAsStringAsync();

            // Check for key content
            Assert.Contains("Meet the Founders", html);
            Assert.Contains("Our Journey", html);
            Assert.Contains("What Drives Us", html);
            Assert.Contains("Uncompromising Quality", html);
            Assert.Contains("Science-Backed Formulas", html);
            Assert.Contains("Commitment to Sustainability", html);
        }
    }
}
