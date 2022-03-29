using System;
using System.Collections.Generic;
using System.Text;
using RandomIt.Models;

namespace RandomIt.ViewModels
{
    internal class CoinFlipViewModel : ThrowableViewModel
    {
        public CoinFlipViewModel() : base(new CoinFlipModel())
        { }
    }
}
