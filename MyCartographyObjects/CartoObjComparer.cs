using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyCartographyObjects
{
    public class CartoObjComparer : IComparer<CartoObj>
    {
        public int Compare(CartoObj x, CartoObj y)
        {
            return x.NbrPointCarto().CompareTo(y.NbrPointCarto());
        }
    }
}
