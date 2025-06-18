using AngleSharp.Html.Parser;
using Microsoft.AspNetCore.Mvc.Testing;
using System.Net;

namespace BravaTests.Integration
{
    public class LayoutRenderingTests : IClassFixture<WebApplicationFactory<Program>>
    {
        private readonly WebApplicationFactory<Program> _factory;

        public LayoutRenderingTests(WebApplicationFactory<Program> factory)
        {
            _factory = factory;
        }

        [Theory]
        [InlineData("/")]
        [InlineData("/Science")]
        [InlineData("/OurStory")]
        [InlineData("/FAQ")]
        [InlineData("/Contact")]
        public async Task Layout_Renders_Navbar_And_Footer_On_AllPages(string url)
        {
            var client = _factory.CreateClient();

            var response = await client.GetAsync(url);
            var html = await response.Content.ReadAsStringAsync();

            Assert.Equal(HttpStatusCode.OK, response.StatusCode);

            var parser = new HtmlParser();
            var document = parser.ParseDocument(html);

            var nav = document.QuerySelector("header .navbar-container");
            Assert.NotNull(nav);

            var logo = document.QuerySelector("header .logo img");
            Assert.NotNull(logo);

            var footer = document.QuerySelector("footer.site-footer");
            Assert.NotNull(footer);

            if (!url.ToLower().Contains("batchlookup"))
            {
                var batchForm = document.QuerySelector("form#batchForm");
                Assert.NotNull(batchForm);
            }
        }

        [Fact]
        public async Task Layout_Includes_Bootstrap_And_SiteCss()
        {
            var client = _factory.CreateClient();
            var response = await client.GetAsync("/");
            var html = await response.Content.ReadAsStringAsync();

            var parser = new HtmlParser();
            var document = parser.ParseDocument(html);

            var bootstrap = document.QuerySelector("link[href*='bootstrap']");
            Assert.NotNull(bootstrap);

            var siteCss = document.QuerySelector("link[href*='/css/site.css']");
            Assert.NotNull(siteCss);
        }
    }
}