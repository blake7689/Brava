using Brava.Interfaces;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BravaTests.Mocks
{
    public class InfoRepositoryMocks
    {
        public static Mock<IInfoRepository> GetInfoRepository()
        {
            Dictionary<string, string> homeContext = StaticContentMocks.GetHomeContent();
            Dictionary<string, string> scienceContext = StaticContentMocks.GetScienceContent();
            Dictionary<string, string> ourStoryContext = StaticContentMocks.GetOurStoryContent();
            Dictionary<string, string> privacyContent = StaticContentMocks.GetPrivacyContent();
            Dictionary<string, string> termsContent = StaticContentMocks.GetTermsContent();

            var mockInfoRepository = new Mock<IInfoRepository>();
            mockInfoRepository.Setup(repo => repo.GetHomeContent()).Returns(homeContext);
            mockInfoRepository.Setup(repo => repo.GetScienceContent()).Returns(scienceContext);
            mockInfoRepository.Setup(repo => repo.GetOurStoryContent()).Returns(ourStoryContext);
            mockInfoRepository.Setup(repo => repo.GetPrivacyContent()).Returns(privacyContent);
            mockInfoRepository.Setup(repo => repo.GetTermsContent()).Returns(termsContent);

            return mockInfoRepository;
        }

        public static Mock<IInfoRepository> GetErrorInfoRepository()
        {
            Dictionary<string, string> homeContext = StaticContentMocks.GetHomeContent();
            Dictionary<string, string> scienceContext = StaticContentMocks.GetScienceContent();
            Dictionary<string, string> ourStoryContext = StaticContentMocks.GetOurStoryContent();
            Dictionary<string, string> privacyContent = StaticContentMocks.GetPrivacyContent();
            Dictionary<string, string> termsContent = StaticContentMocks.GetTermsContent();

            var mockInfoRepository = new Mock<IInfoRepository>();
            mockInfoRepository.Setup(repo => repo.GetHomeContent()).Throws(new Exception("Test exception"));
            mockInfoRepository.Setup(repo => repo.GetScienceContent()).Throws(new Exception("Test exception"));
            mockInfoRepository.Setup(repo => repo.GetOurStoryContent()).Throws(new Exception("Test exception"));
            mockInfoRepository.Setup(repo => repo.GetPrivacyContent()).Throws(new Exception("Test exception"));
            mockInfoRepository.Setup(repo => repo.GetTermsContent()).Throws(new Exception("Test exception"));

            return mockInfoRepository;
        }
    }
}
