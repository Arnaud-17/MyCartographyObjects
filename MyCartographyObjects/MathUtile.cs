using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyCartographyObjects
{
    public class MathUtile
    {
        public static bool Pythagore(double Latitude, double Longitude, Coordonnees c2, double precision)
        {
            bool ret_val = true;
            double d = precision;

            //Console.WriteLine("Lat = " + Latitude + " long = " + Longitude + " c2.lat = " + c2.Latitude + " c2.long = " + c2.Longitude);
            //Console.WriteLine("precision = " + precision);
            if(Longitude == c2.Longitude)
            {
                //Console.WriteLine("long == c2.long");
                d = Math.Abs(Latitude - c2.Latitude) ;
            }
            else
            {
                if(Latitude == c2.Latitude)
                {
                    //Console.WriteLine("lat == c2.lat");
                    d = Math.Abs(Longitude - c2.Longitude);
                }
                else
                {
                    //Console.WriteLine("pythagore");
                    double a = Longitude - c2.Longitude;
                    double b = Latitude - c2.Latitude;

                    if (Math.Pow(a, 2) + Math.Pow(b, 2) > Math.Pow(precision, 2))
                        ret_val = true;
                    else
                        ret_val = false;
                }
            }

            //Console.WriteLine("ret_val pytha = " + ret_val + " d = " + d);
            if (ret_val == true && d <= precision)
                return true;
            else
                return false;
        }
    }
}
