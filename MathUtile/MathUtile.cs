using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MathUtile
{
   public class MathUtile
    {
        public bool Pythagore(double Longitude1, double Latitude1, double Longitude2, double Latitude2, double precision)
        {
            double a = Longitude1 - Longitude2;
            double b = Latitude1 - Latitude2;

            if (Math.Pow(a, 2) + Math.Pow(b, 2) > Math.Pow(precision, 2))
                return true;
            else
                return false;
        }
    }
}
