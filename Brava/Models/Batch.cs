using System.ComponentModel.DataAnnotations;

namespace Brava.Models
{
    public class Batch
    {
        public int BatchID { get; set; }
        [Required]
        [RegularExpression(@"^(?i)[a-z0-9]+$", ErrorMessage = "Only alphanumeric characters (a-z, 0-9) are allowed.")]
        public required string BatchNumber { get; set; }
        public DateTime ManufacturedDate { get; set; }
        public string? ManufacturedLocation { get; set; }
        public string? CreatineContent { get; set; }
    }
}
