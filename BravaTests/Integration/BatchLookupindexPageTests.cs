using AngleSharp.Html.Parser;
using Microsoft.AspNetCore.Mvc.Testing;
using System.Net;
using System.Threading.Tasks;
using Xunit;

namespace BravaTests.Integration
{
    public class BatchLookupIndexPageTests : IClassFixture<WebApplicationFactory<Program>>
    {
        private readonly WebApplicationFactory<Program> _factory;

        public BatchLookupIndexPageTests(WebApplicationFactory<Program> factory)
        {
            _factory = factory;
        }

        [Fact]
        public async Task BatchLookup_Index_Renders_Expected_Elements()
        {
            // Arrange
            var client = _factory.CreateClient();

            // Act
            var response = await client.GetAsync("/BatchLookup");
            var html = await response.Content.ReadAsStringAsync();

            // Assert
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);

            var parser = new HtmlParser();
            var document = parser.ParseDocument(html);

            // Check for main section and header
            var section = document.QuerySelector("section.test-results");
            Assert.NotNull(section);

            var header = document.QuerySelector("section.test-results h1");
            Assert.NotNull(header);
            Assert.Contains("Batch Lookup", header.TextContent);

            // Check for batch form
            var form = document.QuerySelector("form#batchForm");
            Assert.NotNull(form);

            var input = document.QuerySelector("input#batchInput[name='batchNumber']");
            Assert.NotNull(input);

            var button = document.QuerySelector("form#batchForm button[type='submit']");
            Assert.NotNull(button);
            Assert.Contains("Search", button.TextContent);

            // Check for error div
            var errorDiv = document.QuerySelector("#batchError");
            Assert.NotNull(errorDiv);

            // Check for batch modal partial (by id)
            var batchModal = document.QuerySelector("#batchModal");
            Assert.NotNull(batchModal);
        }

        [Fact]
        public async Task BatchLookup_Index_Contains_Expected_Static_Text()
        {
            var client = _factory.CreateClient();
            var response = await client.GetAsync("/BatchLookup");
            var html = await response.Content.ReadAsStringAsync();

            Assert.Contains("Batch Lookup", html);
            Assert.Contains("Enter your batch number", html);
            Assert.Contains("Search", html);
        }
    }
}