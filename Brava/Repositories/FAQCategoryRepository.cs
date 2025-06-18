using Brava.DbContext;
using Brava.Interfaces;
using Brava.Models;
using Microsoft.EntityFrameworkCore;

namespace Brava.Repositories
{
    public class FAQCategoryRepository : IFAQCategoryRepository
    {
        public readonly BravaDbContext _bravaDbContext;

        public FAQCategoryRepository(BravaDbContext bravaDbContext)
        {
            _bravaDbContext = bravaDbContext;
        }

        public IEnumerable<FAQCategory> AllFAQCategories => _bravaDbContext.FAQCategories.Include(c => c.FAQItems).OrderBy(c => c.Category);
    }
}