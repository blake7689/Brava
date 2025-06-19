using Brava.Interfaces;
using Brava.Models;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BravaTests.Mocks
{
    public class FAQRepositoryMocks
    {
        public static Mock<IFAQItemRepository> GetFAQItemRepository()
        {
            var faqItems = new List<FAQItem>
            {
                new FAQItem {
                    FAQItemId = 1,
                    Question = "Where do you ship?",
                    Answer = "We ship worldwide!",
                    FAQCategory = new FAQCategory { FAQCategoryId = 1, Category = "Shipping" }
                },
                new FAQItem
                {
                    FAQItemId = 2,
                    Question = "How long does shipping take?",
                    Answer = "3-7 business days depending on your location.",
                    FAQCategory = new FAQCategory { FAQCategoryId = 1, Category = "Shipping" }
                },
                new FAQItem
                {
                    FAQItemId = 3,
                    Question = "Can I return my order?",
                    Answer = "Yes, within 30 days of receipt.",
                    FAQCategory = new FAQCategory { FAQCategoryId = 2, Category = "Returns & Refunds" }
                },
                new FAQItem
                {
                    FAQItemId = 4,
                    Question = "How are refunds processed?",
                    Answer = "Refunds are credited back to your original payment method.",
                    FAQCategory = new FAQCategory { FAQCategoryId = 2, Category = "Returns & Refunds" }
                }
            };

            var mockFAQItemRepository = new Mock<IFAQItemRepository>();
            mockFAQItemRepository.Setup(repo => repo.AllFAQItems).Returns(faqItems);
            return mockFAQItemRepository;
        }

        public static Mock<IFAQCategoryRepository> GetFAQCategoryRepository()
        {
            var faqCategories = new List<FAQCategory>
            {
                new FAQCategory { FAQCategoryId = 1, Category = "Shipping" },
                new FAQCategory { FAQCategoryId = 2, Category = "Returns & Refunds" }
            };

            var mockFAQCategoryRepository = new Mock<IFAQCategoryRepository>();
            mockFAQCategoryRepository.Setup(repo => repo.AllFAQCategories).Returns(faqCategories);
            return mockFAQCategoryRepository;
        }

        public static Mock<IFAQCategoryRepository> GetEmptyFAQCategoryRepository()
        {
            var mockFAQCategoryRepository = new Mock<IFAQCategoryRepository>();
            mockFAQCategoryRepository.Setup(r => r.AllFAQCategories).Returns(new List<FAQCategory>());
            return mockFAQCategoryRepository;
        }

        public static Mock<IFAQCategoryRepository> GetNullFAQCategoryRepository()
        {
            var mockFAQCategoryRepository = new Mock<IFAQCategoryRepository>();
            mockFAQCategoryRepository.Setup(r => r.AllFAQCategories).Returns((List<FAQCategory>)null);
            return mockFAQCategoryRepository;
        }

        public static Mock<IFAQCategoryRepository> GetExceptionFAQCategoryRepository()
        {
            var mockFAQCategoryRepository = new Mock<IFAQCategoryRepository>();
            mockFAQCategoryRepository.Setup(r => r.AllFAQCategories).Throws(new Exception("DB error"));
            return mockFAQCategoryRepository;
        }

        public static Mock<IFAQCategoryRepository> GetLargeFAQCategoryRepository()
        {
            var largeCategoryList = new List<FAQCategory>();
            for (int i = 1; i <= 1000; i++)
            {
                largeCategoryList.Add(new FAQCategory
                {
                    FAQCategoryId = i,
                    Category = $"Category {i}"
                });
            }

            var mockFAQCategoryRepository = new Mock<IFAQCategoryRepository>();
            mockFAQCategoryRepository.Setup(r => r.AllFAQCategories).Returns(largeCategoryList);
            return mockFAQCategoryRepository;
        }

        public static Mock<IFAQCategoryRepository> GetSpecialCharFAQCategoryRepository()
        {
            var specialCategories = new List<FAQCategory>
            {
                new FAQCategory { FAQCategoryId = 1, Category = "Café & Thé" },
                new FAQCategory { FAQCategoryId = 2, Category = "Überraschung!" },
                new FAQCategory { FAQCategoryId = 3, Category = "中文类别" },
                new FAQCategory { FAQCategoryId = 4, Category = "Категория" },
                new FAQCategory { FAQCategoryId = 5, Category = "Espaço & Ciência" },
                new FAQCategory { FAQCategoryId = 6, Category = "Emoji 😀🚀" }
            };

            var mockFAQCategoryRepository = new Mock<IFAQCategoryRepository>();
            mockFAQCategoryRepository.Setup(r => r.AllFAQCategories).Returns(specialCategories);
            return mockFAQCategoryRepository;
        }
    }
}
