namespace Brava.Models
{
    public class FAQCategory
    {
        public string Name { get; set; }
        public List<FAQItem> FAQs { get; set; } = new List<FAQItem>();
    }
}
