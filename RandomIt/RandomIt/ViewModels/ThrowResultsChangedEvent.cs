using System;
using System.Collections.Generic;
using System.Text;

namespace RandomIt.ViewModels
{
    internal delegate void ThrowResultsChangedEventHandler(object sender, ThrowResultsChangedEventArgs e);

    internal class ThrowResultsChangedEventArgs : EventArgs
    {
        public IEnumerable<int> ThrowResults { get; private set; }

        public ThrowResultsChangedEventArgs(IEnumerable<int> throwResults)
        {
            ThrowResults = throwResults;
        }
    }
}
