using Brava.Interfaces;
using Brava.Models;

namespace Brava.Repositories
{
    public class MockBatchRepository : IBatchRepository
    {
        public IEnumerable<Batch> AllBatches =>
            new List<Batch>
            {
                new Batch {
                    BatchID = 1,
                    BatchNumber = "1234A",
                    ManufacturedDate = DateTime.Today.AddDays(-27),
                    ManufacturedLocation = "Atlanta, Ga",
                    CreatineContent = "1.25g Per Serving"
                },

                new Batch {
                    BatchID = 2,
                    BatchNumber= "1234B",
                    ManufacturedDate = DateTime.Today.AddDays(-35),
                    ManufacturedLocation = "Atlanta, Ga",
                    CreatineContent = "1.25g Per Serving"
                },

                new Batch {
                    BatchID = 3,
                    BatchNumber= "1234C",
                    ManufacturedDate = DateTime.Today.AddDays(-30),
                    ManufacturedLocation = "Atlanta, Ga",
                    CreatineContent = "1.25g Per Serving"
                },

                new Batch {
                    BatchID = 4,
                    BatchNumber= "1234D",
                    ManufacturedDate = DateTime.Today.AddDays(-10),
                    ManufacturedLocation = "Atlanta, Ga",
                    CreatineContent = "1.25g Per Serving"
                }
            };

        public Batch? GetBatchById(int batchID) => 
            AllBatches.FirstOrDefault(c => c.BatchID == batchID);

        public Batch? GetBatchByBatchNumber(string batchNumber) => 
            AllBatches.FirstOrDefault(c => c.BatchNumber.Equals(batchNumber, StringComparison.CurrentCultureIgnoreCase));
    }
}