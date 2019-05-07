using IslandMapGenerationLib.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IslandMapGenerationLib.Interfaces
{
    public interface IIslandMapGenerator
    {
        IslandMap Generate(int width, int height);
    }
}
