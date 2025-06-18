using Brava.Models;

namespace Brava.Interfaces
{
    public interface IFAQCategoryRepository
    {
        IEnumerable<FAQCategory> AllFAQCategories { get; }
    }
}
