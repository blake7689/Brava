using Brava.Interfaces;

namespace Brava.Repositories
{
    public class StaticInfoRepository : IInfoRepository
    {
        public Dictionary<string, string> GetHomeContent()
        {
            Dictionary<string, string> homeDictionary = new Dictionary<string, string>();
            homeDictionary.Add("bannerHeader", "Welcome to Brava");
            homeDictionary.Add("bannerContent", "Creatine Gummies. Backed by science. Built for performance.");
            homeDictionary.Add("faqTitle", "Meet the best creatine supplement on the GD planet");
            homeDictionary.Add("faqQuestion1", "What is Brava Nutrients and how does it work?");
            homeDictionary.Add("faqAnswer1", "Brava Nutrients is a gummie for dummies. One second you're weak and frail, the next you're an absolutely ripped meat hulk.");
            homeDictionary.Add("faqQuestion2", "How do I use Brava Nutrients?");
            homeDictionary.Add("faqAnswer2", "Just pop a gummie and then you're shredded, it's that easy!.");
            homeDictionary.Add("faqQuestion3", "Can I OD on Brava Nutrients?");
            homeDictionary.Add("faqAnswer3", "It's too late, you're fucked.");
            homeDictionary.Add("faqQuestion4", "Is Dylan Clark actually gay?");
            homeDictionary.Add("faqAnswer4", "Yes, he is in fact gay af");
            homeDictionary.Add("faqQuestion5", "Should I take the whole bag at once?");
            homeDictionary.Add("faqAnswer5", "You will be remembered..for being dumb af. No don't take the whole bag at once you fucking sped.");
            homeDictionary.Add("benefitsTitle", "Key Benefits");
            homeDictionary.Add("benefitsTitle1", "Fight Oxidative Stress");
            homeDictionary.Add("benefitsContent1", "Support your cells at the source. Hydrogen targets free radicals to help reduce oxidative stress and protect cellular health.");
            homeDictionary.Add("benefitsTitle2", "Enhance Energy + Recovery");
            homeDictionary.Add("benefitsContent2", "Boost your cellular function to fuel your cells, fight fatigue, and recover faster—so you can feel your best every day.");
            homeDictionary.Add("benefitsTitle3", "Support Gut Health");
            homeDictionary.Add("benefitsContent3", "Give your gut the support it deserves by promoting a healthy microbiome—key to better digestion and overall health.");
            homeDictionary.Add("benefitsTitle4", "Boost Cognitive Function");
            homeDictionary.Add("benefitsContent4", "Combat brain fog and sharpen mental clarity with hydrogen’s ability to cross the blood-brain barrier—helping you stay focused and energized.");
            homeDictionary.Add("testimonialContent1", "\"Brava's creatine gummies have transformed my workouts!\"");
            homeDictionary.Add("testimonialAuthor1", "- Alex A.");
            homeDictionary.Add("testimonialContent2", "\"I feel stronger and more energized during lifts.\"");
            homeDictionary.Add("testimonialAuthor2", "- Alex B.");
            homeDictionary.Add("testimonialContent3", "\"These are the best-tasting supplements I've tried!\"");
            homeDictionary.Add("testimonialAuthor3", "- Alex C.");
            homeDictionary.Add("testimonialContent4", "\"Noticeable results within weeks. Highly recommend!\"");
            homeDictionary.Add("testimonialAuthor4", "- Alex D.");

            return homeDictionary;
        }
        public Dictionary<string, string> GetScienceContent()
        {
            Dictionary<string, string> scienceDictionary = new Dictionary<string, string>();
            scienceDictionary.Add("bodyHeader", "Back by Science");
            scienceDictionary.Add("bodyContent", "Creatine is one of the most studied supplements for performance and recovery.");

            return scienceDictionary;
        }
        public Dictionary<string, string> GetOurStoryContent()
        {
            Dictionary<string, string> aboutDictionary = new Dictionary<string, string>();
            aboutDictionary.Add("bodyHeader", "Our Story");
            aboutDictionary.Add("bodyContent", "Born from the need for clean, easy-to-consume performance supplements...");

            return aboutDictionary;
        }
    }
}
