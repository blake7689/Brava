using Brava.DbContext;
using Brava.Interfaces;
using Brava.Models;

namespace Brava.Repositories
{
    public class GummieRepository : IGummieRepository
    {
        private readonly BravaDbContext _bravaDbContext;

        public GummieRepository(BravaDbContext bravaDbContext)
        {
            _bravaDbContext = bravaDbContext;
        }

        public IEnumerable<Gummie> AllGummies
        {
            get
            {
                return _bravaDbContext.Gummies;
            }
        }
    }
}
