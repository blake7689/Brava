using Brava.Interfaces;
using Brava.Models;
using Brava.Repositories;
using Brava.Services;
using Moq;
using NuGet.Protocol.Core.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BravaTests.Mocks
{
    public class RepositoryMocks
    {
        public static Mock<IGummieRepository> GetGummieRepository()
        {
            var gummies = new List<Gummie>
            {
                new Gummie {
                    GummieID = 1,
                    Name= "Strawberry",
                    Price=19.99M,
                    Description="Strawberry Flavoured Creatine Gummies",
                    Size="1,25g",
                    ImagePath="images/300x300noBG.png",
                    AllergyInformation="~Allergy Info~"
                }
            };

            var mockGummieRepository = new Mock<IGummieRepository>();
            mockGummieRepository.Setup(repo => repo.AllGummies).Returns(gummies);
            return mockGummieRepository;
        }

        public static Mock<IBatchRepository> GetBatchRepository(int id = 1, string batchNumber = "1234A")
        {
            var batches = new List<Batch>
            {
                new Batch {
                    BatchID = 1,
                    BatchNumber = "1234A",
                    ManufacturedDate = DateTime.Today.AddDays(-27),
                    ManufacturedLocation = "Atlanta, Ga",
                    CreatineContent = "1.25g Per Serving"
                },

                new Batch {
                    BatchID = 2,
                    BatchNumber= "1234B",
                    ManufacturedDate = DateTime.Today.AddDays(-35),
                    ManufacturedLocation = "Atlanta, Ga",
                    CreatineContent = "1.25g Per Serving"
                },

                new Batch {
                    BatchID = 3,
                    BatchNumber= "1234C",
                    ManufacturedDate = DateTime.Today.AddDays(-30),
                    ManufacturedLocation = "Atlanta, Ga",
                    CreatineContent = "1.25g Per Serving"
                },

                new Batch {
                    BatchID = 4,
                    BatchNumber= "1234D",
                    ManufacturedDate = DateTime.Today.AddDays(-10),
                    ManufacturedLocation = "Atlanta, Ga",
                    CreatineContent = "1.25g Per Serving"
                }
            };

            var mockBatchRepository = new Mock<IBatchRepository>();
            mockBatchRepository.Setup(repo => repo.AllBatches).Returns(batches);
            mockBatchRepository.Setup(repo => repo.GetBatchById(id)).Returns(batches.FirstOrDefault(c => c.BatchID == id, null));
            mockBatchRepository.Setup(repo => repo.GetBatchByBatchNumber(batchNumber)).Returns(batches.FirstOrDefault(c => c.BatchNumber.Equals(batchNumber, StringComparison.CurrentCultureIgnoreCase), null));
            return mockBatchRepository;
        }

        public static InfoService GetInfoService()
        {
            var infoRepositoryMock = GetInfoRepository();
            var infoService = new InfoService(infoRepositoryMock.Object);

            return infoService;
        }

        private static Mock<IInfoRepository> GetInfoRepository()
        {
            Dictionary<string, string> homeContext = GetHomeContent();
            Dictionary<string, string> scienceContext = GetScienceContent();
            Dictionary<string, string> ourStoryContext = GetOurStoryContent();
            Dictionary<string, string> faqContent = GetFAQContent();
            Dictionary<string, string> privacyContent = GetPrivacyContent();
            Dictionary<string, string> termsContent = GetTermsContent();

            var mockInfoRepository = new Mock<IInfoRepository>();
            mockInfoRepository.Setup(repo => repo.GetHomeContent()).Returns(homeContext);
            mockInfoRepository.Setup(repo => repo.GetScienceContent()).Returns(homeContext);
            mockInfoRepository.Setup(repo => repo.GetOurStoryContent()).Returns(homeContext);
            mockInfoRepository.Setup(repo => repo.GetFAQContent()).Returns(homeContext);
            mockInfoRepository.Setup(repo => repo.GetPrivacyContent()).Returns(homeContext);
            mockInfoRepository.Setup(repo => repo.GetTermsContent()).Returns(homeContext);

            return mockInfoRepository;
        }

        
        private static Dictionary<string, string> GetHomeContent()
        {
            Dictionary<string, string> homeDictionary = new Dictionary<string, string>();
            homeDictionary.Add("bannerHeader", "Welcome to Brava");
            homeDictionary.Add("bannerContent", "Creatine Gummies. Backed by science. Built for performance.");
            homeDictionary.Add("faqTitle", "Meet the best creatine supplement on the GD planet");
            homeDictionary.Add("faqQuestion1", "What is Brava Nutrients and how does it work?");
            homeDictionary.Add("faqAnswer1", "Brava Nutrients is a gummie for dummies. One second you're weak and frail, the next you're an absolutely ripped meat machine.");
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

        private static Dictionary<string, string> GetScienceContent()
        {
            Dictionary<string, string> scienceDictionary = new Dictionary<string, string>();
            scienceDictionary.Add("heroHeader", "The Science Behind Brava");
            scienceDictionary.Add("heroContent", "At Brava, we’re committed to combining cutting-edge research with clean ingredients to deliver the best hydration experience possible.");
            scienceDictionary.Add("section1Header", "Optimal Hydration Formula");
            scienceDictionary.Add("section1Content1", "Our hydration formula is backed by scientific studies showing optimal electrolyte balance to maximize absorption and performance.");
            scienceDictionary.Add("section1Content2", "We focus on the right blend of sodium, potassium, and magnesium — the key minerals your body needs to stay hydrated during activity.");
            scienceDictionary.Add("section1Header2", "Clean, Natural Ingredients");
            scienceDictionary.Add("section2Content1", "We source only clean, natural ingredients — no artificial sweeteners, colors, or preservatives. Because what goes in matters just as much as how it works.");
            scienceDictionary.Add("section2Content2", "Our formulas are vegan, gluten-free, and non-GMO, crafted with your health in mind.");
            scienceDictionary.Add("section1Header3", "Backed by Research");
            scienceDictionary.Add("section3Content1", "We collaborate with top universities and hydration experts to continually improve our formulas and stay at the forefront of hydration science.");
            scienceDictionary.Add("section3Content2", "All our claims are based on published, peer-reviewed research to give you confidence in every sip.");
            scienceDictionary.Add("callToActionHeader", "Ready to experience hydration science at its best?");

            return scienceDictionary;
        }

        private static Dictionary<string, string> GetOurStoryContent()
        {
            Dictionary<string, string> aboutDictionary = new Dictionary<string, string>();
            aboutDictionary.Add("foundersHeader", "Meet the Founders");
            aboutDictionary.Add("founder1Name", "Jane Smith");
            aboutDictionary.Add("founder1Title", "Co-Founder & CEO");
            aboutDictionary.Add("founder1Content", "Passionate about hydration science and dedicated to delivering clean, effective products to consumers worldwide.");
            aboutDictionary.Add("founder2Name", "Michael Johnson");
            aboutDictionary.Add("founder2Title", "Co-Founder & Head of Innovation");
            aboutDictionary.Add("founder2Content", "Brings extensive scientific expertise and innovation to develop formulas that truly hydrate and refresh.");
            aboutDictionary.Add("founder3Name", "Emily Davis");
            aboutDictionary.Add("founder3Title", "Co-Founder & Marketing Director");
            aboutDictionary.Add("founder3Content", "Focuses on connecting the brand with customers through storytelling and impactful marketing strategies.");
            aboutDictionary.Add("timelineHeader", "Our Journey");
            aboutDictionary.Add("time1Header", "2018 - The Idea");
            aboutDictionary.Add("time1Content", "Inspired by the need for cleaner hydration options, Brava was born from a passion for science and health.");
            aboutDictionary.Add("time2Header", "2019 - First Product Launch");
            aboutDictionary.Add("time2Content", "We launched our first hydration formula, crafted with natural ingredients and backed by science.");
            aboutDictionary.Add("time3Header", "2021 - Growth & Innovation");
            aboutDictionary.Add("time3Content", "Expanded our product line and strengthened partnerships with top hydration scientists worldwide.");
            aboutDictionary.Add("time4Header", "2024 - Looking Ahead");
            aboutDictionary.Add("time4Content", "Continuing our mission to redefine hydration with innovative, clean, and effective products for everyone.");
            aboutDictionary.Add("valuesHeader", "What Drives Us");
            aboutDictionary.Add("values1Header", "Uncompromising Quality");
            aboutDictionary.Add("values1Content", "Every bottle is crafted with the highest standards and purest ingredients.");
            aboutDictionary.Add("values2Header", "Science-Backed Formulas");
            aboutDictionary.Add("values2Content", "We base every product on proven research to deliver real hydration benefits.");
            aboutDictionary.Add("values3Header", "Commitment to Sustainability");
            aboutDictionary.Add("values3Content", "Eco-friendly practices and packaging to protect the planet.");

            return aboutDictionary;
        }

        private static Dictionary<string, string> GetFAQContent()
        {
            //change when DB is implemented//
            Dictionary<string, string> faqDictionary = new Dictionary<string, string>();
            faqDictionary.Add("faqHeader", "Frequently Asked Questions");
            faqDictionary.Add("cat1Header", "Shipping");
            faqDictionary.Add("cat1Q1", "Where do you ship?");
            faqDictionary.Add("cat1A1", "We ship worldwide!");
            faqDictionary.Add("cat1Q2", "How long does shipping take?");
            faqDictionary.Add("cat1A2", "3-7 business days depending on your location.");
            faqDictionary.Add("cat2Header", "Returns & Refunds");
            faqDictionary.Add("cat2Q1", "Can I return my order?");
            faqDictionary.Add("cat2A1", "Yes, within 30 days of receipt.");
            faqDictionary.Add("cat2Q2", "How are refunds processed?");
            faqDictionary.Add("cat2A2", "Refunds are credited back to your original payment method.");

            return faqDictionary;
        }

        private static Dictionary<string, string> GetPrivacyContent()
        {
            Dictionary<string, string> privacyDictionary = new Dictionary<string, string>();
            privacyDictionary.Add("privacyHeader", "Privacy Policy");
            privacyDictionary.Add("headerContent", "Effective Date: January 1, 2025");
            privacyDictionary.Add("section1Header", "Overview");
            privacyDictionary.Add("section1Content", "This Privacy Policy describes how Brava (“we”, “us”, or “our”) collects, uses, and discloses your Personal Information when you visit or make a purchase from our website.");
            privacyDictionary.Add("section2Header", "Personal Information We Collect");
            privacyDictionary.Add("section2Content1", "When you visit our site, we automatically collect certain information about your device, including your web browser, IP address, time zone, and some cookies installed on your device.");
            privacyDictionary.Add("section2Content2", "Additionally, when you make a purchase, we collect order information such as your name, billing and shipping address, payment details, email address, and phone number.");
            privacyDictionary.Add("section3Header", "How We Use Your Personal Information");
            privacyDictionary.Add("section3Content", "We use this information to fulfill orders, communicate with you, screen for fraud, and improve our services. Marketing communications are only sent with your consent.");
            privacyDictionary.Add("section4Header", "Sharing Your Personal Information");
            privacyDictionary.Add("section4Content1", "We may share your Personal Information with service providers to help us deliver our services and fulfill contracts. For example, we use third-party logistics and payment processors.");
            privacyDictionary.Add("section4Content2", "We may also share information to comply with applicable laws and regulations or respond to lawful requests.");
            privacyDictionary.Add("section5Header", "Your Rights");
            privacyDictionary.Add("section5Content", "If you are a resident of certain jurisdictions (such as the EU or California), you have rights regarding access to, correction of, or deletion of your personal data.\r\nTo exercise these rights, please contact us using the information below.");
            privacyDictionary.Add("section6Header", "Cookies");
            privacyDictionary.Add("section6Content", "We use cookies to improve your experience, provide personalized content, and analyze traffic. You can manage cookies through your browser settings.");
            privacyDictionary.Add("section7Header", "Data Retention");
            privacyDictionary.Add("section7Content", "We retain your Personal Information for as long as necessary to fulfill the purposes outlined in this policy unless otherwise required by law.");
            privacyDictionary.Add("section8Header", "Changes to This Policy");
            privacyDictionary.Add("section8Content", "We may update this Privacy Policy occasionally to reflect operational, legal, or regulatory changes. Updates will be posted on this page with a new effective date.");
            privacyDictionary.Add("contactContent", "For more information or to contact us, email us at ");

            return privacyDictionary;
        }

        private static Dictionary<string, string> GetTermsContent()
        {
            Dictionary<string, string> termsDictionary = new Dictionary<string, string>();
            termsDictionary.Add("termsHeader", "Terms of Service");
            termsDictionary.Add("headerContent", "Effective Date: January 1, 2025");
            termsDictionary.Add("section1Header", "Overview");
            termsDictionary.Add("section1Content", "This website is operated by Brava. Throughout the site, the terms “we”, “us” and “our” refer to Brava. Brava offers this website,\r\nincluding all information, tools, and services available from this site to you, the user, conditioned upon your acceptance\r\nof all terms, conditions, policies, and notices stated here.");
            termsDictionary.Add("section2Header", "Online Store Terms");
            termsDictionary.Add("section2Content1", "By agreeing to these Terms of Service, you represent that you are at least the age of majority in your state or province of residence,\r\nor that you are the age of majority and you have given us your consent to allow any of your minor dependents to use this site.");
            termsDictionary.Add("section2Content2", "You may not use our products for any illegal or unauthorized purpose nor may you, in the use of the Service, violate any laws\r\nin your jurisdiction.");
            termsDictionary.Add("section3Header", "General Conditions");
            termsDictionary.Add("section3Content", "We reserve the right to refuse service to anyone for any reason at any time. You understand that your content (not including credit card information),\r\nmay be transferred unencrypted and involve transmissions over various networks.");
            termsDictionary.Add("section4Header", "Accuracy, Completeness and Timeliness of Information");
            termsDictionary.Add("section4Content", "We are not responsible if information made available on this site is not accurate, complete, or current. The material on this site is provided\r\nfor general information only and should not be relied upon or used as the sole basis for making decisions without consulting primary,\r\nmore accurate, more complete or more timely sources of information.");
            termsDictionary.Add("section5Header", "Modifications to the Service and Prices");
            termsDictionary.Add("section5Content", "Prices for our products are subject to change without notice. We reserve the right at any time to modify or discontinue the Service (or any part or content thereof)\r\nwithout notice at any time.");
            termsDictionary.Add("section6Header", "Products or Services");
            termsDictionary.Add("section6Content", "Certain products or services may be available exclusively online through the website. These products or services may have limited quantities\r\nand are subject to return or exchange only according to our Return Policy.");
            termsDictionary.Add("section7Header", "Changes to Terms of Service");
            termsDictionary.Add("section7Content", "You can review the most current version of the Terms of Service at any time at this page. We reserve the right, at our sole discretion,\r\nto update, change or replace any part of these Terms of Service by posting updates and changes to our website.");
            termsDictionary.Add("contactContent", "Questions about the Terms of Service should be sent to us at ");

            return termsDictionary;
        }
    }
}
