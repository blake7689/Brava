using Brava.Interfaces;
using Brava.Models;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BravaTests.Mocks
{
    public class BatchRepositoryMocks
    {
        public static Mock<IBatchRepository> GetBatchRepository(int id = 1, string batchNumber = "1234A")
        {
            var batches = new List<Batch>
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

            var mockBatchRepository = new Mock<IBatchRepository>();
            mockBatchRepository.Setup(repo => repo.AllBatches).Returns(batches);
            mockBatchRepository.Setup(repo => repo.GetBatchById(id)).Returns(batches.FirstOrDefault(c => c.BatchID == id));
            mockBatchRepository.Setup(repo => repo.GetBatchByBatchNumber(It.IsAny<string>())).Returns((string bn) => batches.FirstOrDefault(c => c.BatchNumber.Equals(bn, StringComparison.CurrentCultureIgnoreCase)));
            return mockBatchRepository;
        }
    }
}
