namespace Brava.Interfaces
{
    public interface IInfoRepository
    {
        Dictionary<string, string> GetHomeContent();
        Dictionary<string, string> GetScienceContent();
        Dictionary<string, string> GetOurStoryContent();
        Dictionary<string, string> GetFAQContent();
        Dictionary<string, string> GetPrivacyContent();
        Dictionary<string, string> GetTermsContent();
    }
}
