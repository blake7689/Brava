using Brava.Models;

namespace Brava.Interfaces
{
    public interface IBatchRepository
    {
        IEnumerable<Batch> AllBatches { get; }
        Batch? GetBatchById(int BatchID);
        Batch? GetBatchByBatchNumber(string batchNumber);
    }
}