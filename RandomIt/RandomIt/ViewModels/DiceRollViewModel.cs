using System;
using System.Collections.Generic;
using System.Text;
using RandomIt.Models;

namespace RandomIt.ViewModels
{
    internal class DiceRollViewModel : ThrowableViewModel
    {
        public DiceRollViewModel() : base(new DiceRollModel())
        { }
    }
}
