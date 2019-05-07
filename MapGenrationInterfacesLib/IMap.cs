using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MapGenrationInterfacesLib
{
    public interface IMap
    {
        ITitle Get(int x, int y);
        void Set(int x, int y, ITitle title);
    }
}
