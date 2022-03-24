using System;
using System.Collections.Generic;
using System.Text;

namespace RandomIt.Models
{
    internal class ListElement
    {
        public string Name { get; private set; }

        public ListElement(string name)
        {
            Name = name;
        }

        public override string ToString()
        {
            return Name;
        }
    }
}
