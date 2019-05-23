using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IslandMapGenerationLib.Common.Extensions
{
    public static class RandomExtension
    {
        public static bool NextBool(this Random random)
        {
            return random.Next() % 2 == 0;
        }
    }
}
