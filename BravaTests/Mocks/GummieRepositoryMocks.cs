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
    public class GummieRepositoryMocks
    {
        public static Mock<IGummieRepository> GetGummieRepository()
        {
            var gummies = new List<Gummie>
            {
                new Gummie {
                    GummieID = 1,
                    Name= "Strawberry",
                    Price=19.99M,
                    Description="Strawberry Flavoured Creatine Gummies",
                    Size="1,25g",
                    ImagePath="images/300x300noBG.png",
                    AllergyInformation="~Allergy Info~"
                }
            };

            var mockGummieRepository = new Mock<IGummieRepository>();
            mockGummieRepository.Setup(repo => repo.AllGummies).Returns(gummies);
            return mockGummieRepository;
        }

        public static Mock<IGummieRepository> GetErrorGummieRepository()
        {
            var mockGummieRepository = new Mock<IGummieRepository>();
            mockGummieRepository.Setup(r => r.AllGummies).Throws(new Exception("DB error"));
            return mockGummieRepository;
        }
    }
}
