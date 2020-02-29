using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyCartographyObjects
{
    public class MathUtile
    {
        public static bool Pythagore(double Latitude, double Longitude, Coordonnees c, double precision)
        {
            bool ret_val = true;
            double d = precision;

            //Console.WriteLine("Lat = " + Latitude + " long = " + Longitude + " c2.lat = " + c2.Latitude + " c2.long = " + c2.Longitude);
            //Console.WriteLine("precision = " + precision);
            if(Longitude == c.Longitude)
            {
                //Console.WriteLine("long == c2.long");
                d = Math.Abs(Latitude - c.Latitude) ;
            }
            else
            {
                if(Latitude == c.Latitude)
                {
                    //Console.WriteLine("lat == c2.lat");
                    d = Math.Abs(Longitude - c.Longitude);
                }
                else
                {
                    //Console.WriteLine("pythagore");
                    double a = Longitude - c.Longitude;
                    double b = Latitude - c.Latitude;

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
        public static bool PointLineDistance(Coordonnees c1, Coordonnees c2, Coordonnees c, double precision)
        {
            double m, x, y, p;
            double d = precision;
            bool ret_val = true;

            Coordonnees tmp;

            if (c2.Latitude < c1.Latitude || c2.Longitude < c1.Longitude)
            {
                //Console.WriteLine("J'echange Collection[i] et Collection[i+1]");
                tmp = c1;
                c1 = c2;
                c2 = tmp;
            }

            //Console.WriteLine("coord1.lat = " + coord1.Latitude + " coord1.long = " + coord1.Longitude + " coord2.lat = " + coord2.Latitude + " coord2.long = " + coord2.Longitude);
            //Console.WriteLine("c2.lat = " + c2.Latitude + " c2.long = " + c2.Longitude + " precision = " + precision);
            if (c1.Latitude == c2.Latitude)
            {
                //Console.WriteLine("coord1.lat == coord2.lat");
                if (c.Longitude < c1.Longitude)
                {
                    //Console.WriteLine("c2.lat < coord1.lat");
                    ret_val = Pythagore(c1.Latitude, c1.Longitude, c, precision);
                }
                else
                {
                    if (c.Longitude > c2.Longitude)
                    {
                        //Console.WriteLine("c2.lat > coord2.lat");
                        ret_val = Pythagore(c2.Latitude, c2.Longitude, c, precision);
                    }
                    else
                    {
                        //Console.WriteLine("c2 est entre la ligne");
                        d = Math.Abs(c1.Latitude - c.Latitude);
                    }
                }
            }
            else
            {
                if (c1.Longitude == c2.Longitude)
                {
                    //Console.WriteLine("coord1.long == coord2.long");
                    if (c.Latitude < c1.Latitude)
                    {
                        //Console.WriteLine("c2 < coord1.long");
                        ret_val = Pythagore(c1.Latitude, c1.Longitude, c, precision);
                    }
                    else
                    {
                        if (c.Latitude > c2.Latitude)
                        {
                            //Console.WriteLine("c2 > coord2.long");
                            ret_val = Pythagore(c2.Latitude, c2.Longitude, c, precision);
                        }
                        else
                        {
                            //Console.WriteLine("c2 est entre la ligne");
                            d = Math.Abs(c1.Longitude - c.Longitude);
                        }
                    }
                }
                else
                {
                    m = (c2.Longitude - c1.Longitude) / (c2.Latitude - c1.Latitude);
                    y = c1.Longitude;
                    x = c1.Latitude;
                    p = -m * x + y;

                    //Console.WriteLine("y = " + y + " m = " + m + " x = " + x + " p = " + p);

                    d = Math.Abs(-m * c.Latitude + 1 * c.Longitude - p) / Math.Sqrt(Math.Pow(m, 2) + Math.Pow(p, 2));

                    //Console.WriteLine("d = " + d);
                }
            }

            //Console.WriteLine(ret_val + " " + d);
            if (ret_val == true && d <= precision)
                return true;
            else
                return false;
        }

        public static double Longueur(Coordonnees[] collection,int nbrPoint)
        {
            double distance;
            double longueur=0; 
            Coordonnees c1,c2;
            int i;

            for (i = 1; i < nbrPoint;i++)
            {
                c1 = collection[i];
                c2 = collection[i - 1];

                distance = Math.Sqrt(Math.Pow((c2.Latitude - c1.Latitude), 2) + Math.Pow((c2.Longitude - c1.Longitude), 2));
                longueur += distance;
            }
            return longueur;
        }
        public static double PolylineBoundingBox(Coordonnees[] collection, int nbrPoint)
        {
            int i;
            double LatMax = 0, LongMax = 0, LatMin = 0, LongMin = 0;
            Coordonnees c;

            for(i=1;i< nbrPoint; i++)
            {
                c = collection[i];

                if (c.Latitude < LatMin)
                {
                    LatMin = c.Latitude;
                }
                else
                {
                    if (c.Latitude > LatMax)
                    {
                        LatMax = c.Latitude;
                    }
                }

                if (c.Longitude < LongMin)
                {
                    LongMin = c.Longitude;
                }
                else
                {
                    if (c.Longitude > LongMax)
                    {
                        LongMax = c.Longitude;
                    }
                }
            }

            Console.WriteLine("latMax = " + LatMax + " longmax = " + LongMax + " latmin = " + LatMin + " longmin = " + LongMin);
            return 0;
        }
    }
}
