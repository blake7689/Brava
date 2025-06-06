using Brava.Models;

namespace Brava.Interfaces
{
    public interface IGummieRepository
    {
        IEnumerable<Gummie> AllGummies { get; }
    }
}
