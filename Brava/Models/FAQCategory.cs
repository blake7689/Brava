namespace Brava.Models
{
    public class FAQCategory
    {
        public int FAQCategoryId { get; set; }
        public string Category { get; set; } = string.Empty;
        public List<FAQItem> FAQItems { get; set; } = new();
    }
}