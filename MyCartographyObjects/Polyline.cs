using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace MyCartographyObjects
{
    public class Polyline : CartoObj, IIsPointClose, IPointy, IComparable<Polyline>, IEquatable<Polyline>
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

        #region CODE
        public override string ToString()
        {
            return string.Format(base.ToString() + " > Couleur : " + Couleur + " / Epaisseur : " + Epaisseur);
        }

        public override void Draw()
        {
            Console.WriteLine(this.ToString());
            Console.WriteLine("-----Collection Polyline-----");

            if (Collection != null)
            {
                foreach (Coordonnees c in Collection)
                {
                    Console.WriteLine("     " +  c);
                }
            }
            else
                Console.WriteLine("NULL");
        }

        public bool IsPointClose(Coordonnees c2, double precision)
        {
            int i = 1;
            bool ret_val;
            bool PointClose = false;

            //foreach (Coordonnees c in Collection)
            for(i=1; i <this.GetNumberOfPoint();i++)
            {
                Coordonnees coord1 = Collection[i];
                Coordonnees coord2 = Collection[i-1];

                ret_val = MathUtile.PointLineDistance(coord1, coord2,c2, precision);

                if (ret_val == true)
                    PointClose = true;
            }
            //Console.WriteLine(" PointClose = " + PointClose);
            return PointClose;
        }

        public byte GetNumberOfPoint()
        {
            byte NbrPoint = 0;

            foreach (Coordonnees c in this.Collection)
            {
                NbrPoint++;
            }
            return NbrPoint;
        }
        public double PolylineBoundingBox()
        {
            int i;
            byte k = GetNumberOfPoint();
            double Longueur, Largeur;
            double LatMax = 0, LongMax = 0, LatMin = 0, LongMin = 0;
            Coordonnees c;

            for (i = 1; i < k; i++)
            {
                c = Collection[i];

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
            Longueur = LatMin - LatMax;
            Largeur = LongMin - LongMax;

            return Longueur * Largeur;
        }
        public int CompareTo(Polyline other)
        {
            double d1 = MathUtile.Longueur(this.Collection);
            double d2 = MathUtile.Longueur(other.Collection);
            return d1.CompareTo(d2);
        }
        public bool Equals(Polyline other)
        {
            if (other == null) return false;
            return (MathUtile.Longueur(this.Collection).Equals(MathUtile.Longueur(other.Collection)));
        }
        #endregion
    }
}
