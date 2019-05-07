using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IslandMapGenerationLib.Common
{
    public class IslandTitle
    {
        public double Value { get; private set; }

        public IslandTitle(double value)
        {
            Value = value;
        }
    }
}
