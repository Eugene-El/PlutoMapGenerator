using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MapGenrationInterfacesLib
{
    public interface IMapGenerator
    {
        IMap Generate(int width, int height);
    }
}
