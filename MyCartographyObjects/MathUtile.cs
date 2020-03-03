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
            double a,b,d;

            //Console.WriteLine("Lat = " + Latitude + " long = " + Longitude + " c.lat = " + c.Latitude + " c.long = " + c.Longitude);
            //Console.WriteLine("precision = " + precision);
            if(Longitude == c.Longitude)
            {
                //Console.WriteLine("long == c2.long");
                d = Math.Abs(Latitude - c.Latitude) ;
                if (d < precision)
                    return true;
                else
                    return false;
            }
            else
            {
                if(Latitude == c.Latitude)
                {
                    //Console.WriteLine("lat == c2.lat");
                    d = Math.Abs(Longitude - c.Longitude);
                    if (d < precision)
                        return true;
                    else
                        return false;
                }
                else
                {
                    //Console.WriteLine("pythagore");
                    if(Longitude > c.Longitude)
                    {
                        a = Math.Abs(Longitude) - Math.Abs(c.Longitude);
                    }
                    else
                    {
                         a = Math.Abs(c.Longitude) - Math.Abs(Longitude);
                    }

                    if(Latitude > c.Latitude)
                    {
                         b = Math.Abs(Latitude) - Math.Abs(c.Latitude);
                    }
                    else
                    {
                         b = Math.Abs(c.Latitude) - Math.Abs(Latitude);
                    }

                    //Console.WriteLine("a = " + a + " b = " + b);
                    d = Math.Sqrt(Math.Pow(a, 2) + Math.Pow(b, 2));
                    //Console.WriteLine("d = " + d);

                    if (d <= precision)
                        return true;
                    else
                        return false;
                }
            }
        }
       public static bool DistanceLignePoint(Coordonnees c1, Coordonnees c2, Coordonnees c, double precision)
        {
            double a, x, y, b;
            double d = precision;
            bool ret_val = false;

            Coordonnees tmp;

            if (c2.Latitude < c1.Latitude || c2.Longitude < c1.Longitude)
            {
                //Console.WriteLine("J'echange Collection[i] et Collection[i+1]");
                tmp = c1;
                c1 = c2;
                c2 = tmp;
            }

            //Console.WriteLine("c1.lat = " + c1.Latitude + " c1.long = " + c1.Longitude + " c2.lat = " + c2.Latitude + " c2.long = " + c2.Longitude);
            //Console.WriteLine("c.lat = " + c.Latitude + " c.long = " + c.Longitude + " precision = " + precision);
            if (c1.Latitude == c2.Latitude) //Les 2 coordonnees ont la même longitude
            {
                //Console.WriteLine("c1.lat == c2.lat");
                if (c.Longitude < c1.Longitude)
                {
                    //Console.WriteLine("c.long < c1.long");
                    ret_val = Pythagore(c1.Latitude, c1.Longitude, c, precision);

                    return ret_val;
                }
                else
                {
                    if (c.Longitude > c2.Longitude)
                    {
                        //Console.WriteLine("c.long > c2.long");
                        ret_val = Pythagore(c2.Latitude, c2.Longitude, c, precision);

                        return ret_val;
                    }
                    else
                    {
                        //Console.WriteLine("c2 est entre la ligne"); --> car la pente est égale a null
                        d = Math.Abs(c1.Latitude - c.Latitude);

                        if (d <= precision)
                            return true;
                        else
                            return false;
                    }
                }
            }
            else
            {
                if (c1.Longitude == c2.Longitude) //Les 2 coordonnees ont la même latitude
                {
                    //Console.WriteLine("c1.long == c2.long");
                    if (c.Latitude < c1.Latitude)
                    {
                        //Console.WriteLine("c.lat < c1.lat");
                        ret_val = Pythagore(c1.Latitude, c1.Longitude, c, precision);
                        return ret_val;
                    }
                    else
                    {
                        if (c.Latitude > c2.Latitude)
                        {
                            //Console.WriteLine("c.lat > c2.lat");
                            ret_val = Pythagore(c2.Latitude, c2.Longitude, c, precision);
                            return ret_val;
                        }
                        else
                        {
                            //Console.WriteLine("c est entre la ligne"); --> car la pente est égale a null
                            d = Math.Abs(c1.Longitude - c.Longitude);
                            if (d <= precision)
                                return true;
                            else
                                return false;
                        }
                    }
                }
                else //Les 2 points n'ont pas la même longitude ou latitude
                {
                    if(c.Latitude < c1.Latitude || c.Longitude < c1.Longitude)
                    {
                        //Console.WriteLine("le point est < que les coordonnees");
                        ret_val = Pythagore(c1.Latitude, c1.Longitude, c, precision);
                        return ret_val;
                    }
                    else
                    {
                        if(c.Latitude > c2.Latitude || c.Latitude > c.Longitude)
                        {
                            //Console.WriteLine("le point est > que les coordonnees");
                            ret_val = Pythagore(c2.Latitude, c2.Longitude, c, precision);
                            return ret_val;
                        }
                        else
                        {
                            //Console.WriteLine("le point est entre les 2 coordonnees");
                            a = (c2.Longitude - c1.Longitude) / (c2.Latitude - c1.Latitude);
                            y = c1.Longitude;
                            x = c1.Latitude;
                            b = -(a * x) + y;
                            //Console.WriteLine("a = " + a + " b = " + b + " x =  " + x + " y = " + y);

                            b = -b;
                            a = -a;
                            
                            //Console.WriteLine("a = " + a + " x0 = " + c.Latitude + " b = 1" + " y0 = " + c.Longitude + " c = " + b);
                            d = Math.Abs((a * c.Latitude + 1 * c.Longitude + b) / Math.Sqrt(Math.Pow(a, 2) + Math.Pow(1, 2)));

                            //Console.WriteLine("d = " + d);

                            if (d <= precision)
                                return true;
                            else
                                return false;
                        }
                    }
                }
            }
        }

        public static double Longueur(Coordonnees[] collection)
        {
            double distance;
            double longueur=0;
            int i;
            byte NbrPoint = 0;
            Coordonnees c1, c2;

            foreach (Coordonnees c in collection)
            {
                NbrPoint++;
            }

            for (i = 1; i < NbrPoint; i++)
            {
                c1 = collection[i];
                c2 = collection[i - 1];

                distance = Math.Sqrt(Math.Pow((c2.Latitude - c1.Latitude), 2) + Math.Pow((c2.Longitude - c1.Longitude), 2));
                longueur += distance;
            }
            return longueur;
        }
    }
}

