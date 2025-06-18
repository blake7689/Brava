namespace Brava.Models
{
    public class Gummie
    {
        public int GummieID { get; set; }
        public string Name { get; set; } = string.Empty;
        public string? Size { get; set; }
        public string? Description { get; set; }
        public string? AllergyInformation { get; set; }
        public decimal Price { get; set; }
        public string? ImagePath { get; set; }
    }
}