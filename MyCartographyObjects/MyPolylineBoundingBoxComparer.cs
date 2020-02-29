using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyCartographyObjects
{
    public class MyPolylineBoundingBoxComparer : Polyline, IComparable<Polyline>
    {
        public MyPolylineBoundingBoxComparer() : base() { }

        public new int CompareTo(Polyline other)
        {
            int NbrPoint = GetNumberOfPoint();
            int NbrPointOther = other.GetNumberOfPoint();
            double d1 = MathUtile.PolylineBoundingBox(Collection, NbrPoint);
            double d2 = MathUtile.PolylineBoundingBox(other.Collection, NbrPointOther);
            return d1.CompareTo(d2);
        }
    }
}
