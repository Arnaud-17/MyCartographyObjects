using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyCartographyObjects
{
    interface IIsPointClose
    {
        bool IsPointClose(Coordonnees c2,double presision);
    }
}
