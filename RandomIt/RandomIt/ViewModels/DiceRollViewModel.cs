using RandomIt.Models;

namespace RandomIt.ViewModels
{
    internal class DiceRollViewModel : ThrowableViewModel
    {
        public DiceRollViewModel() : base(new DiceRollModel())
        { }
    }
}
