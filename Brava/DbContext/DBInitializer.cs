using System.IO.Pipelines;
using Brava.Models;
using Microsoft.EntityFrameworkCore;

namespace Brava.DbContext
{
    public class DBInitializer
    {
        public static void Seed(IApplicationBuilder applicationBuilder)
        {
            BravaDbContext context = applicationBuilder.ApplicationServices.CreateScope().ServiceProvider.GetRequiredService<BravaDbContext>();

            if (!context.Gummies.Any())
            {
                context.AddRange
                (
                    new Gummie
                    {
                        //GummieID = 1,
                        Name = "Strawberry",
                        Price = 19.99M,
                        Description = "Strawberry Flavoured Creatine Gummies",
                        Size = "1,25g",
                        ImagePath = "images/300x300noBG.png",
                        AllergyInformation = "~Allergy Info~"
                    }
                );
            }

            context.SaveChanges();
            context.Dispose();
            context = applicationBuilder.ApplicationServices.CreateScope().ServiceProvider.GetRequiredService<BravaDbContext>();

            if (!context.Batches.Any())
            {
                context.AddRange
                (
                    new Batch
                    {
                        //BatchID = 1,
                        BatchNumber = "1234A",
                        ManufacturedDate = DateTime.Today.AddDays(-27),
                        ManufacturedLocation = "Atlanta, Ga",
                        CreatineContent = "1.25g Per Serving"
                    },

                    new Batch
                    {
                        //BatchID = 2,
                        BatchNumber = "1234B",
                        ManufacturedDate = DateTime.Today.AddDays(-35),
                        ManufacturedLocation = "Atlanta, Ga",
                        CreatineContent = "1.25g Per Serving"
                    },

                    new Batch
                    {
                        //BatchID = 3,
                        BatchNumber = "1234C",
                        ManufacturedDate = DateTime.Today.AddDays(-30),
                        ManufacturedLocation = "Atlanta, Ga",
                        CreatineContent = "1.25g Per Serving"
                    },

                    new Batch
                    {
                        //BatchID = 4,
                        BatchNumber = "1234D",
                        ManufacturedDate = DateTime.Today.AddDays(-10),
                        ManufacturedLocation = "Atlanta, Ga",
                        CreatineContent = "1.25g Per Serving"
                    }
                );
            }

            context.SaveChanges();
            context.Dispose();
            context = applicationBuilder.ApplicationServices.CreateScope().ServiceProvider.GetRequiredService<BravaDbContext>();

            if (!context.FAQCategories.Any())
            {
                context.FAQCategories.AddRange(FAQCategories.Select(c => c.Value));   
            }

            if (!context.FAQItems.Any())
            {
                context.FAQItems.AddRange
                (
                    new FAQItem
                    {
                        Question = "Where do you ship?",
                        Answer = "We ship worldwide!",
                        FAQCategory = FAQCategories["Shipping"]
                    },
                    new FAQItem
                    {
                        Question = "How long does shipping take?",
                        Answer = "3-7 business days depending on your location.",
                        FAQCategory = FAQCategories["Shipping"]
                    },
                    new FAQItem
                    {
                        Question = "Can I return my order?",
                        Answer = "Yes, within 30 days of receipt.",
                        FAQCategory = FAQCategories["Returns & Refunds"]
                    },
                    new FAQItem
                    {
                        Question = "How are refunds processed?",
                        Answer = "Refunds are credited back to your original payment method.",
                        FAQCategory = FAQCategories["Returns & Refunds"]
                    }
                );
            }

            context.SaveChanges();
        }

        private static Dictionary<string, FAQCategory>? faqCategories;

        public static Dictionary<string, FAQCategory> FAQCategories
        {
            get
            {
                if (faqCategories == null)
                {
                    var genresList = new FAQCategory[]
                    {
                        new FAQCategory { Category = "Shipping" },
                        new FAQCategory { Category = "Returns & Refunds" }
                    };

                    faqCategories = new Dictionary<string, FAQCategory>();

                    foreach (FAQCategory genre in genresList)
                    {
                        FAQCategories.Add(genre.Category, genre);
                    }
                }

                return faqCategories;
            }
        }
    }
}
