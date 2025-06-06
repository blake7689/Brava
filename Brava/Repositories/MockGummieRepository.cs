using Brava.Interfaces;
using Brava.Models;

namespace Brava.Repositories
{
    public class MockGummieRepository : IGummieRepository
    {
        public IEnumerable<Gummie> AllGummies =>
            new List<Gummie>
            {
                new Gummie {
                    GummieID = 1,
                    Name= "Strawberry",
                    Price=19.99M,
                    Description="Strawberry Flavoured Creatine Gummies",
                    Size="1,25g",
                    ImagePath="images/product1.jpg",
                    AllergyInformation="~Allergy Info~"},

                new Gummie {
                    GummieID = 2,
                    Name= "Strawberry",
                    Price=19.99M,
                    Description="Strawberry Flavoured Creatine Gummies",
                    Size="1,25g",
                    ImagePath="images/product1.jpg",
                    AllergyInformation="~Allergy Info~"}
            };
    }
}
