using RandomIt.Models;

namespace RandomIt.ViewModels
{
    internal class CoinFlipViewModel : ThrowableViewModel
    {
        public CoinFlipViewModel() : base(new CoinFlipModel())
        { }
    }
}
