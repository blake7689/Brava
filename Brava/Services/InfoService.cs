using Brava.Interfaces;

namespace Brava.Services
{
    public class InfoService
    {
        private readonly IInfoRepository _repository;

        public InfoService(IInfoRepository repository)
        {
            _repository = repository;
        }

        public Dictionary<string, string> GetHome() => _repository.GetHomeContent();
        public Dictionary<string, string> GetScience() => _repository.GetScienceContent();
        public Dictionary<string, string> GetOurStory() => _repository.GetOurStoryContent();
    }
}
