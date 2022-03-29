using System;
using System.Collections.Generic;
using System.Text;

namespace RandomIt.ViewModels
{
    public delegate void ThrowResultsChangedEventHandler(object sender, ThrowResultsChangedEventArgs e);

    public class ThrowResultsChangedEventArgs : EventArgs
    {
        public IEnumerable<int> ThrowResults { get; private set; }

        public ThrowResultsChangedEventArgs(IEnumerable<int> throwResults)
        {
            ThrowResults = throwResults;
        }
    }
}
