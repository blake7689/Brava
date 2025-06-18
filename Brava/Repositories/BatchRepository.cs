using Brava.DbContext;
using Brava.Interfaces;
using Brava.Models;

namespace Brava.Repositories
{
    public class BatchRepository : IBatchRepository
    {
        private readonly BravaDbContext _bravaDbContext;

        public BatchRepository(BravaDbContext bravaDbContext)
        {
            _bravaDbContext = bravaDbContext;
        }

        public IEnumerable<Batch> AllBatches
        {
            get
            {
                return _bravaDbContext.Batches;
            }
        }

        public Batch? GetBatchById(int batchId)
        {
            return _bravaDbContext.Batches.FirstOrDefault(c => c.BatchID.Equals(batchId));
        }

        public Batch? GetBatchByBatchNumber(string batchNumber)
        {
            return _bravaDbContext.Batches.FirstOrDefault(c => c.BatchNumber.ToLower() == batchNumber.ToLower());
        }
    }
}