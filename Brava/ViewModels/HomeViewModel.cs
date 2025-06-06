using Brava.Models;

namespace Brava.ViewModels
{
    public class HomeViewModel
    {
        public IEnumerable<Gummie> Gummies { get; }

        public HomeViewModel(IEnumerable<Gummie> gummies)
        {
            Gummies = gummies;
        }
    }
}
