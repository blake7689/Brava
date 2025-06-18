using Brava.Models;

namespace Brava.Interfaces
{
    public interface IFAQItemRepository
    {
        IEnumerable<FAQItem> AllFAQItems { get; }
    }
}
