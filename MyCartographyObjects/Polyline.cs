using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace MyCartographyObjects
{
    public class Polyline : CartoObj, IIsPointClose
    {
        #region VARIABLES MEMBRES
        private Coordonnees[] _collection;
        private int _epaisseur;
        private Color _couleur;
        #endregion

        #region PROPRIETES
        public Coordonnees[] Collection
        {
            set { _collection = value; }
            get { return _collection; }
        }
        public Color Couleur
        {
            set { _couleur = value; }
            get { return _couleur; }
        }
        public int Epaisseur
        {
            set { _epaisseur = value; }
            get { return _epaisseur; }
        }
        #endregion

        #region CONSTRUCTEUR
        public Polyline()
        {
            this.Collection = null;
            this.Couleur = Colors.White;
            this.Epaisseur = 0;
        }

        public Polyline(Coordonnees[] newCoordonees,Color newCouleur, int newEpaisseur) : base()
        {
            this.Collection = newCoordonees;
            this.Couleur = newCouleur;
            this.Epaisseur = newEpaisseur;
        }
        #endregion

        #region Draw
        public override string ToString()
        {
            return string.Format(base.ToString() + " > Couleur : " + Couleur + " / Epaisseur : " + Epaisseur);
        }

        public override void Draw()
        {
            Console.WriteLine(this.ToString());
            Console.WriteLine("\nCollection Polyline :");

            if (Collection != null)
            {
                foreach (Coordonnees c in Collection)
                {
                    Console.WriteLine(c);
                }
            }
            else
                Console.WriteLine("NULL");
        }

        public bool IsPointClose(Coordonnees c2, double precision)
        {
            int i=0;
            double m,x,y,p;
            double d = precision;
            bool ret_val = true;

            Coordonnees coord1 = Collection[i];
            Coordonnees coord2 = Collection[i + 1];
            Coordonnees tmp;

            if(coord2.Latitude < coord1.Latitude || coord2.Longitude < coord1.Longitude)
            {
                //Console.WriteLine("J'echange Collection[i] et Collection[i+1]");
                tmp = coord1;
                coord1 = coord2;
                coord2 = tmp;
            }

            //Console.WriteLine("coord1.lat = " + coord1.Latitude + " coord1.long = " + coord1.Longitude + " coord2.lat = " + coord2.Latitude + " coord2.long = " + coord2.Longitude);
            //Console.WriteLine("c2.lat = " + c2.Latitude + " c2.long = " + c2.Longitude + " precision = " + precision);
            if(coord1.Latitude == coord2.Latitude)
            {
                //Console.WriteLine("coord1.lat == coord2.lat");
                if (c2.Longitude < coord1.Longitude)
                {
                    //Console.WriteLine("c2.lat < coord1.lat");
                    ret_val = MathUtile.Pythagore(coord1.Latitude, coord1.Longitude, c2, precision);
                }
                else
                {
                    if(c2.Longitude > coord2.Longitude)
                    {
                        //Console.WriteLine("c2.lat > coord2.lat");
                        ret_val = MathUtile.Pythagore(coord2.Latitude, coord2.Longitude, c2, precision);
                    }
                    else
                    {
                        //Console.WriteLine("c2 est entre la ligne");
                        d = Math.Abs(coord1.Latitude - c2.Latitude);
                    }
                }
            }
            else
            {
                if(coord1.Longitude == coord2.Longitude)
                {
                    //Console.WriteLine("coord1.long == coord2.long");
                    if (c2.Latitude < coord1.Latitude)
                    {
                        //Console.WriteLine("c2 < coord1.long");
                        ret_val = MathUtile.Pythagore(coord1.Latitude, coord1.Longitude, c2, precision);
                    }
                    else
                    {
                        if (c2.Latitude > coord2.Latitude)
                        {
                            //Console.WriteLine("c2 > coord2.long");
                            ret_val = MathUtile.Pythagore(coord2.Latitude, coord2.Longitude, c2, precision);
                        }
                        else
                        {
                            //Console.WriteLine("c2 est entre la ligne");
                            d = Math.Abs(coord1.Longitude - c2.Longitude);
                        }
                    }
                }
                else
                {
                    m = (coord2.Longitude - coord1.Longitude) / (coord2.Latitude - coord1.Latitude);
                    y = coord1.Longitude;
                    x = coord1.Latitude;
                    p = -m * x + y;

                    //Console.WriteLine("y = " + y + " m = " + m + " x = " + x + " p = " + p);

                    d = Math.Abs(-m * c2.Latitude + 1 * c2.Longitude - p) / Math.Sqrt(Math.Pow(m, 2) + Math.Pow(p, 2));

                    //Console.WriteLine("d = " + d);
                }
            }

            //Console.WriteLine(ret_val + " " + d);
            if (ret_val == true && d <= precision)
                return true;
            else
                return false;
        }
        #endregion
    }
}
