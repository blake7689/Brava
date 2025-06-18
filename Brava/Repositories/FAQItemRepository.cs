using Brava.DbContext;
using Brava.Interfaces;
using Brava.Models;
using Microsoft.EntityFrameworkCore;

namespace Brava.Repositories
{
    public class FAQItemRepository : IFAQItemRepository
    {
        private readonly BravaDbContext _bravaDbContext;

        public FAQItemRepository(BravaDbContext bravaDbContext)
        {
            _bravaDbContext = bravaDbContext;
        }

        public IEnumerable<FAQItem> AllFAQItems
        {
            get
            {
                return _bravaDbContext.FAQItems.Include(f => f.FAQCategory);
            }
        }
    }
}
