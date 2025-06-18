namespace Brava.Models
{
    public class FAQItem
    {
        public int FAQItemId { get; set; }
        public required string Question { get; set; }
        public required string Answer { get; set; }
        public int FAQCategoryId { get; set; }
        public FAQCategory FAQCategory { get; set; } = default!;
    }
}